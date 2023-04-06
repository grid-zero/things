#include <stdio.h>
int main(void){
    printf("this program will tell you if a number is a prime number or not\n");
    int input;
    for(;;){
        printf("Input: ");
        scanf("%i", &input);

        if(input == 1){
            printf("Output: False\n");
            continue;
        }
        if(input == 2){
            printf("Output: True\n");
            continue;
        }
        for(int i = 2; i < input; i++){
            if(input % i == 0){
                printf("Output: False\n");
                goto END;
            }
        }
        
        printf("Output: True\n");
        END:
        printf("");//this line makes it not give compile warning
    }
    return 0;
}