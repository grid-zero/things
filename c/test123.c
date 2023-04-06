#include <stdio.h>
#include "linkedList.h"

int main(void){
    List * test = NULL;
    Add(&test,32);
    printf("%i",test->value);

}