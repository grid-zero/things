# include <stdio.h>
/*
int CheckCacheList(int input, int primes[]) {
    for(int i = 0; i < sizeof(primes); i++){
        if (input == primes[i]){
            printf("is a primes");
            return 0;
        }

        if(input % primes[i] == 0){s
            printf("not a prime");
            return 0;
        }
        printf("i am a loop");
    }
}
*/
int absolute(){
    int input;
    printf("enter number to absolute: ");
    scanf("%i",&input);

    if(input< 0){
        input*=-1;
    }
    return input;
}

int evenodd(){
    int input;
    printf("enter number to even or odd: ");
    scanf("%i",&input);

    if (input%2 ==0){
        printf("input is even");
        return 0;
    }
    printf("input is odd");
}

int istype(){
    int input;
    printf("enter number to determine type: ");
    scanf("%i",&input);
    if(input == 0){
        printf("the number is zero\n");
        return 42;
    }
    if(input>0){
        printf("number is positive\n");
        return 90;
    }
    printf("numner is negativ\n");
}

int isleapYear(){
    int input;
    printf("enter year to determine type: ");
    scanf("%i",&input);

    if(input%400 ==0){
        printf("is a leap year");
        return 0;
    }
    if(input%100 ==0){
        printf("is not a leap year");
        return 0;
    } 
    if(input%4 ==0){
        printf("is a leap year");
        return 0;
    }
    printf("is not a leap year");
}

int calculator(){
    float val1, val2, result;
    char operator;
    printf("enter an equation using only 2 numbers and one opperator");
    scanf("%f %c %f", &val1, &operator, &val2);

    switch(operator){
        case '+':
            result = val1+val2;
            break;
        case '-':
            result = val1-val2;
            break;
        case '*':
            result = val1*val2;
            break;
        case '/':
            if(val2 ==0){
                printf("cannot divide by zero");
                return 0;
            }
            result = val1/val2;
    }
    printf("the result of %f %c %f is %f",val1,operator,val2, result);

}



int main(void){
    //istype();
    //isleapYear();
    //printf("\nthe number is: %i",absolute());
    //evenodd();
    calculator();
    printf("\nthis program will tell you if a number is a prime number or not\nenter input number: ");
    int input;

    scanf("%i", &input);
    printf("\nthe number you entered is: %i\n",input);

    //int primes[2] = {2,3};
    if(input == 1){
        printf("is a prime");
        return 0;
    }
    if(input ==2){
        printf("is a prime");
        return 0;
    }
    for(int i = 2; i< input; i++){
        if(input%i == 0){
            printf("input is not a prime");
            return 0;
        }
    }
    printf("is a prime");

    return 0;
}