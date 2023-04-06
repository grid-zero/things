#include <stdio.h>

int main(void){
    int test = 10;
    int *epic = &test;
    epic = &epic;
    printf("%d\n",test);
    printf("%d\n",&test);
    printf("%d\n",epic);
    printf("%d\n",(int)(*epic));
    printf("%d\n",&epic);

}