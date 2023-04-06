#include <stdio.h>
#include <stdlib.h>



struct node {
    int value;
    struct node *next;
};

struct node * ReturnIndex(struct node * origin,int index){
    if(index<0){
        struct node * current = origin;
        while(current->next!=NULL){
            current = current->next;
        }
        return current;
    }
    else{
        struct node * current = origin;
        for(int i = 0; i < index ||current->next==NULL; i++){
            current = current->next;
        }
        return current;
    }
}
int findLength(struct node * origin){
    int length = 1;
    struct node * current = origin;
    while(current->next!=NULL){
        current = current->next;
        length++;
    }
    return length;
}
void Add(struct node ** list, int val){
    if(*list==NULL){
        *(list) = ((struct node *) malloc(sizeof(struct node)));
        (*(list))->value = val;
        (*(list))->next = NULL;
        //printf("%i",list->value);
    }else{
        struct node * end = ReturnIndex(*(list),-1);
        end->next = (struct node *) malloc(sizeof(struct node));
        end->next->value = val;
        end->next->next = NULL;
    }
}



void listPartition(struct node * list, int x){
    struct node * CurrentNode = list;
    int length = findLength(list);
    int data[length][2]; 
    int i = 0;
    while(CurrentNode!=NULL){
        if(CurrentNode->value<x){
            data[i][0] = CurrentNode->value;
            data[i][1] = -1;
        }else{
            data[i][0] = CurrentNode->value;
            data[i][1] = 1;
        }
        i++;
        CurrentNode = CurrentNode->next;
    }
    CurrentNode = list;
    
    for(int i = 0; i < length; i++){
        if(data[i][1] == -1){
            CurrentNode->value = data[i][0];
            CurrentNode = CurrentNode->next;
        }
    }
    for(int i = 0; i < length; i++){
        if(data[i][1] == 1){
            CurrentNode->value = data[i][0];
            CurrentNode = CurrentNode->next;
        }
    }
    
    CurrentNode = list;
    while(CurrentNode!=NULL){
        printf("%i",CurrentNode->value);
        CurrentNode = CurrentNode->next;
    }
    
}

int main(void){
    struct node * list = NULL;
    //add function just to test partition
    Add(&list,1);
    Add(&list,4);
    Add(&list,3);
    Add(&list,2);
    Add(&list,5);
    Add(&list,2);
    Add(&list,3);
    listPartition(list,3);
}