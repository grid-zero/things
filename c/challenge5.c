#include <stdio.h>

int isOnes(int array[], int n){
    for(int i = 0; i < n; i++){
        if(array[i]!=1){
            return 0;
        }
    }
    return 1;
}

void setZero(int array[], int n){
    for(int i = 0; i < n; i++){
        array[i] = 0;
    }
}


int bitPatternSearch(unsigned int search, unsigned int pattern, unsigned int n){
    printf("size of u int: %i\n",sizeof(unsigned int));
    int bitcount = 16;
    int bits[bitcount];
    int patternbits[n];
    printf("search bits\n");
    for(int i = 0, check = 1; i < bitcount; i++){
        bits[15-i] = (search>>i) & check;
        
    }
    for(int i = 0; i < bitcount; i++){
        printf("%i", bits[i]);
    }

    printf("\n pattern bits \n");
    for(int i = 0, check = 1; i < n; i++){
        patternbits[n-i-1] = (pattern>>i) & check;
        
    }
    for(int i = 0, check = 1; i < n; i++){
        printf("%i",patternbits[i]);
    }

    int checker[n];
    for(int i = 0; i < bitcount-n; i++){
        for(int j = 0; j < n; j++){
            if(bits[i+j]==patternbits[j]){
                checker[j] = 1;
            }
        }
        if(isOnes(checker,n)==1){
            printf("\nfound at %i\n",i);
            return i;
        }
        setZero(checker,n);
    }

    return -1;
}

int main(void){
    bitPatternSearch(0xe1f4, 0x4, 3);
    return 0;
}