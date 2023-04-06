#include <stdio.h>
#include <stdlib.h>

int FindStringLength(char input[], int arrayLength){  //1 2 3  0 0 0 0 0 0 0  ... \n
    int length;
    for(int i = 0; i < arrayLength; i++){
        if(input[i] == 0){
            length = i+1;
            break;
        }
    }
    return length;
}
//https://www.geeksforgeeks.org/c-program-for-bubble-sort/
//sort taken from here
void swap(char *xp, char *yp)
{
char temp = *xp;
*xp = *yp;
*yp = temp;
}

void bubbleSort(char arr[], int n)
{
int i, j;
for (i = 0; i < n-1; i++)
for (j = 0; j < n-i-1; j++)
if (arr[j] > arr[j+1])
swap(&arr[j], &arr[j+1]);
}

int CompareStrings(){
    char inputLong0[1024];
    char inputLong1[1024];

    printf("Input: ");
    scanf("%s", &inputLong0); 
    printf("Input: ");
    scanf("%s", &inputLong1);

    int input0Length = FindStringLength(inputLong0,1024);
    int input1Length = FindStringLength(inputLong1,1024);
    if(input0Length != input1Length){
        printf("Ouput: False");
        return 0;
    }

    bubbleSort(inputLong0,input0Length);
    bubbleSort(inputLong1,input0Length);

    for(int i = 0; i < input0Length; i++){
        if(inputLong0[i]!=inputLong1[i]){
            printf("Output: False");
            return 0;
        }
    }
    printf("Output: True");
}

int main(void){
    for(;;){
    CompareStrings();
    }   
}