#include <stdio.h>
#include <stdlib.h>

struct node {
    int value;
    struct node *next;
};

struct node * loopList(struct node * origin,int index){
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

int returnIndex(struct node * origin, int index){
    struct node * current = origin;
    for(int i = 0; i < index; i++){
        if(current == NULL){
            return 0;
        }
        current= current->next;
    }
    return current->value;
}

struct node * returnIndexNode(struct node * origin, int index){
    struct node * current = origin;
    for(int i = 0; i < index; i++){
        if(current == NULL){
            return 0;
        }
        current= current->next;
    }
    return current;
}


void Append(struct node * origin,int val){
    struct node * end = loopList(origin,-1);
    
    end->next = (struct node *) malloc(sizeof(struct node));
    end->next->value = val;
    end->next->next = NULL;
}

void removeNode(struct node * origin, int index){
    
    if(index ==0){
        struct node * end = loopList(origin,0);
        
        struct node ** temp = &end;
        *end = *(end->next);
        free(temp);
    }else{
        struct node * end = loopList(origin,index-1);
        struct node **temp = &(end->next);
        end->next = end->next->next;
        free(temp);
        
        
    }
}

void swap(int* x, int* y)
{
    *(x) = *(x) + *(y);
    *(y) = *(x) - *(y);
    *(x) = *(x) - *(y);
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
void Sort(struct node * origin){
    int i,j,index = 0,length = findLength(origin);
    for(i = 0; i < length-1; i++){
        for(j = 0; j < length-i-1; j++){
            if(returnIndex(origin,j) > returnIndex(origin,j+1)){
                swap(&(returnIndexNode(origin,j)->value),&(returnIndexNode(origin,j+1)->value));
            }
        }
    }
}

void removeDuplicates (struct node* head){
    struct node * current = head;
    int index = 0;
    while(current->next!=NULL){
        if(current->value==current->next->value){
            removeNode(head,index+1);
            index--;
        }
        if(current->next!=NULL){
        current=current->next;
        }
        index++;
    }
}

int main(void){
    //adding initial values to linked list
    struct node * epic = NULL;
    epic = (struct node *) malloc(sizeof(struct node));
    epic->value = 2;
    epic->next = NULL;
    
    Append(epic,1);
    Append(epic,2);
    Append(epic,3);
    Append(epic,2);
    Append(epic,1);
    Append(epic,3);

    //original
    int length = findLength(epic);
    printf("original: ");
    for(int i = 0; i < length-1; i++){
        printf("%i->",returnIndex(epic,i));
    }
    printf("%i\n",returnIndex(epic,length-1));
    //remove duplicates
    Sort(epic);
    removeDuplicates(epic);
    length = findLength(epic);
    printf("duplicates removed: ");
    for(int i = 0; i < length-1; i++){
        printf("%i->",returnIndex(epic,i));
    }
    printf("%i\n",returnIndex(epic,length-1));
    return 0;
}