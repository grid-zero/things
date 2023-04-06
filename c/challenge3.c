#include <stdio.h>


void insertString(char text[], char str[], int position){
    int strlength = 0;
    for(int i = 0; str[i]!='\0';i++){
        strlength++;
    }
    int txtlength = 0;
    for(int i = 0; text[i]!='\0';i++){
        txtlength++;
    }
    txtlength++;
    printf("str len %i, txt len %i\n",strlength,txtlength);

    for(int i = txtlength-1-strlength; i > position; i--){
        text[i+strlength] = text[i];
    }
    
    for(int i = position+1,j = 0; j < strlength; i++,j++){
        text[i] = str[j];
    }
    text[txtlength-1]= '\0';
    
    
}

int main(void){

    char text[] = "Epic word24ufdsfiusfiueriufhehrfhefhehf8";
    char str[] = "notsuper";
    //this technically can work without voiding the end of the original string
    //by setting line 13 to txtlength+=strlength
    //however will overite exisiting memory
    //and for some reason does not throw an out of index error
    insertString(text,str, 4);
    printf("%s\n",text);

}