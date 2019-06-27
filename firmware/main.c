#include <8052.h>

#define CMD_NRW         0x80
#define CMD_NDA         0x40
#define CMD_WEN         0x20
#define CMD_POA(val)    (((val) & 0x30) >> 4)
#define CMD_POD(val)    (((val) & 0x10) >> 4)
#define CMD_DAT(val)    ( (val) & 0x0F      )

typedef unsigned char byte;
typedef unsigned short word;

__bit busy = 0, avail = 0;

static byte recBuf = 0x00;
static byte dataBuf = 0x00;
static word readAddr = 0x0000, writeAddr = 0x0000;
static word eraseAddr = 0x0000;

void delay10ms();
void sendByte(byte data);
void sendString(char *s);

volatile __xdata __at (0x0000) byte eepRom[0x8000];

__sfr __at (0x8E) AUXR;
__sbit __at (0xE8) P40;
__sbit __at (0xE9) P41;

void main() {
    AUXR = 0x02; // Enable external ram

    SCON = 0x50;

    TMOD = 0x20;
    TH1 = TL1 = 0xFD;
    TR1 = 1;
    ES = 1;
    EA = 1;

    sendString("NSSTC-V1.1\r\n");

    while(1) {
        P1 = ~dataBuf;
        if (!avail) continue;

        if (recBuf & CMD_NRW) {
            // Write
            if (recBuf & CMD_NDA) {
                // Addr
                writeAddr &= ~(0x0F << (CMD_POA(recBuf) * 4));
                writeAddr |= (CMD_DAT(recBuf) << (CMD_POA(recBuf) * 4));
            } else {
                // Data
                if (recBuf & CMD_WEN) {
                    if (recBuf == 0xAA) {
                        // Disable SDP
                        P1 = 0xAA;
                        eepRom[0x5555] = 0xAA;
                        eepRom[0x2AAA] = 0x55;
                        eepRom[0x5555] = 0x80;
                        eepRom[0x5555] = 0xAA;
                        eepRom[0x2AAA] = 0x55;
                        eepRom[0x5555] = 0x20;
                        P1 = 0x55;
                    } else if (recBuf == 0xA5) {
                        // Enable SDP
                        P1 = 0x55;
                        eepRom[0x5555] = 0xAA;
                        eepRom[0x2AAA] = 0x55;
                        eepRom[0x5555] = 0xA0;
                        P1 = 0xAA;
                    } else if (recBuf == 0xB0) {
                        // Chip erase, 0x00
                        P1 = 0x00;
                        for (eraseAddr = 0x0000; eraseAddr < 0x8000; eraseAddr++) {
                            if ((eraseAddr % 0x40) == 0) {
                                delay10ms();
                                P40 = !P40;
                            }
                            eepRom[eraseAddr] = 0x00;
                        }
                        sendByte(0x0B);
                        P1 = 0xFF;
                    } else if (recBuf == 0xBF) {
                        // Chip erase, 0xFF
                        P1 = 0x00;
                        for (eraseAddr = 0x0000; eraseAddr < 0x8000; eraseAddr++) {
                            if ((eraseAddr % 0x40) == 0) {
                                delay10ms();
                                P40 = !P40;
                            }
                            eepRom[eraseAddr] = 0xFF;
                        }
                        sendByte(0xFB);
                        P1 = 0xFF;
                    } else {
                        // Write in
                        eepRom[writeAddr] = dataBuf;
                        sendByte(dataBuf); // Send to host to verify.
                        writeAddr += 1;
                        P40 = !P40;
                    }
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
                P41 = !P41;
            }
        }

        recBuf = 0x00;
        avail = 0;
    }
}

void delay10ms() {
	byte i, j;

	i = 18;
	j = 235;
	do
	{
		while (--j);
	} while (--i);
}

void __uart_interrupt() __interrupt 4 __using 1 {
    if (RI) {
        RI = 0;
        if (!avail) {
            recBuf = SBUF;
            avail = 1;
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
