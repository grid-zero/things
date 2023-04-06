#include <stdio.h>

void testfunction(int *x){
    printf("in function before manipulation: %i\n",*(x));
    *x+=10;
    printf("in function after manipulation: %i\n",*(x));
}

int main(void){
    int xtop = 3;
    printf("before function: %i\n",xtop);
    testfunction(&xtop);
    printf("after function: %i\n",xtop);

    
}

