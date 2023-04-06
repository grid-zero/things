#include <stdio.h>
#define MIN(a,b) ({ \
    int retval; \
    retval = (a<b) ? a : b;\
    retval;\
})
int main(void){
    int min = MIN(7,5);
    printf("%i",min);
}