#include <8052.h>
#include <string.h>

typedef unsigned char byte;

__bit busy;

void sendByte(byte data);
void sendString(char *s);

volatile __xdata __at (0x0000) byte romBase[0x8000];

void main() {
    SCON = 0x50;

    TMOD = 0x20;
    TH1 = TL1 = 0xFD;
    TR1 = 1;
    ES = 1;
    EA = 1;

    sendString("NSSTC-V1.0\r\n");
    P1 = 0xFE;
    romBase[0] = 0x32;
    romBase[1] = 0x32;
    if (romBase[0] == 0x32 && romBase[1] == 0x32)
        P1 <<= 1;
    strcpy(romBase, "Hello Gensokyo!\r\n\0");
    P1 <<= 1;
    sendString(romBase);
    P1 <<= 1;
    while(1);
}

void __uart_interrupt() __interrupt 4 __using 1 {
    if (RI) {
        RI = 0;
        P1 = SBUF;
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

