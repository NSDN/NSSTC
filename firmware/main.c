#include <8052.h>

#define CMD_NRW         0x80
#define CMD_NDA         0x40
#define CMD_WEN         0x20
#define CMD_POA(val)    (((val) & 0x30) >> 4)
#define CMD_POD(val)    (((val) & 0x10) >> 4)
#define CMD_DAT(val)    ( (val)         >> 4)

typedef unsigned char byte;
typedef unsigned short word;

__bit busy = 0;

static byte recBuf = 0x00;
static byte dataBuf = 0x00;
static word readAddr = 0x0000, writeAddr = 0x0000;

void sendByte(byte data);
void sendString(char *s);

volatile __xdata __at (0x0000) byte eepRom[0x8000];

void main() {
    SCON = 0x50;

    TMOD = 0x20;
    TH1 = TL1 = 0xFD;
    TR1 = 1;
    ES = 1;
    EA = 1;

    sendString("NSSTC-V1.0\r\n");

    while(1);
}

void __uart_interrupt() __interrupt 4 __using 1 {
    if (RI) {
        RI = 0;
        recBuf = SBUF;

        if (recBuf & CMD_NRW) {
            // Write
            if (recBuf & CMD_NDA) {
                // Addr
                writeAddr &= ~(0x0F << (CMD_POA(recBuf) * 4));
                writeAddr |= (CMD_DAT(recBuf) << (CMD_POA(recBuf) * 4));
            } else {
                // Data
                if (recBuf & CMD_WEN) {
                    // Write in
                    eepRom[writeAddr] = dataBuf;
                    writeAddr += 1;
                } else {
                    // Write set
                    dataBuf &= ~(0x0F << (CMD_POD(recBuf) * 4));
                    dataBuf |= (CMD_DAT(recBuf) << (CMD_POD(recBuf) * 4));
                }
            }
        } else {
            // Read
            if (recBuf & CMD_NDA) {
                // Addr
                readAddr &= ~(0x0F << (CMD_POA(recBuf) * 4));
                readAddr |= (CMD_DAT(recBuf) << (CMD_POA(recBuf) * 4));
            } else {
                // Data
                sendByte(eepRom[readAddr]);
                readAddr += 1;
            }
        }
    }
    if (TI) {
        TI = 0;
        busy = 0;
    }
}

void sendByte(byte data) {
    while (busy);
    busy = 1;
    SBUF = data;
}

void sendString(char *s) {
    while (*s) {
        sendByte(*s++);
    }
}
