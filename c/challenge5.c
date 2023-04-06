#include <stdio.h>

int isOnes(int array[], int n){
    for(int i = 0; i < n; i++){
            if(array[i] != 1){
                return 0;
            }
        }
    return 1;
}

void setZero(int array[], int n){
    for(int i = 0; i < n; i++){
        array[i] = 0;
    }
    printf("set zero %i\n",array[0]);
}


int bitPatternSearch(unsigned int search, unsigned int pattern, unsigned int n){
    printf("size of u int: %i\n",sizeof(unsigned int));
    int bitcount = 16;
    int bits[bitcount];
    int patternbits[n];
    printf("search bits\n");
    for(int i = 0, check = 1; i < bitcount; i++){
        bits[i] = (search>>i) & check;
        printf("%i,",bits[i]);
    }
    printf("\n pattern bits \n");
    for(int i = 0, check = 1; i < n; i++){
        patternbits[i] = (pattern>>i) & check;
        printf("%i,",patternbits[i]);
    }
    int checker[n];
    setZero(checker,n);
    for(int i = 15; i > 2; i--){
        for(int j = 0; j < n; j++){
            if(bits[i-j] == patternbits[2-j]){
                checker[j] = 1;
            }
        }
        printf("\n ehat \n");
        if (isOnes(checker,n) == 1){
            printf("location found at %i\n",i-2);
            return 16-i-1;
        }
        
    }

    return -1;
}

int main(void){
    bitPatternSearch(0xe1f4, 0x5, 3);
    return 0;
}