#include <stdio.h>

void cleanBuffer(){
    int n;
    while((n = getchar()) != EOF && n != '\n' );
}