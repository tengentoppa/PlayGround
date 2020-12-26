#include <stdio.h>
#include <stdlib.h>
#include <sys/ipc.h>
#include <sys/shm.h>
#include <unistd.h>
#include "clearBuffer.c"

#define SHM_KEY 123456
int shmid;
int *ptr;

int main () {
    int id;
    char themeSplit[] = "\033[33m";
    char themeMessage[] = "\033[1;32m";
    char themeEnd[] = "\033[0m";

    if ((shmid = shmget(SHM_KEY, 1024, IPC_CREAT)) < 0) {
        perror("shmget");
        exit(1);
    }

    if ((ptr = shmat(shmid, NULL, 0)) == (int *) -1) {
        perror("shmat");
        exit(1);
    }

    ptr[0] = 0;
    printf("%s[server] The value is %d%s\n", themeMessage, ptr[0], themeEnd);

    while(1) {
        int cmd;

        printf("%s----------------------------------%s\n", themeSplit, themeEnd);
        printf("1: Show the value\n");
        printf("2: Modify the value\n");
        printf("3: Exit\n");
        printf("Enter commands: ");
        scanf("%d", &cmd);

        if (cmd == 1)
            printf("%s[server] The value is %d%s\n", themeMessage, ptr[0], themeEnd);
        else if (cmd == 2) {
            printf("Input new value: ");
            scanf("%d", &ptr[0]);
            cleanBuffer();
        }
        else {
            cleanBuffer();
            break;      
        }       
    } 
}
