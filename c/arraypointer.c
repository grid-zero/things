#include <stdio.h>


int arraySum(int array[], int n){
    int sum = 0;
    for(int i = 0; i < n; i++){
        sum+=array[i];
    }
    return sum;
}

int arraySumP(int *array, int n){
    int sum = 0;
    for(int i = 0; array+i != array+n; i++){
        sum+=*(array+i);
    }
    return sum;
}

int main(void){
    int array[] = {1,6,2,6,3,1,6,8};
    printf("1: %i\n",arraySum(array,sizeof(array)/sizeof(int)));
    printf("2: %i\n",arraySumP(array,sizeof(array)/sizeof(int)));
    return 0;
}