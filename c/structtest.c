#include <stdio.h>
#include <stdlib.h>

#define MEMCPY(b, a, n) (*(struct foo { char x[n]; } *)(b) = \
                         *(struct foo *)(a))



typedef struct node {
    int value;
    struct node *next;    
}node_t;


node_t* loopList(node_t * origin,int index){
    if(index<0){
        node_t * current = origin;
        while(current->next!=NULL){
            current = current->next;
        }
        return current;
    }
    else{
        node_t * current = origin;
        for(int i = 0; i < index ||current->next==NULL; i++){
            current = current->next;
        }
        return current;
    }
}

int returnIndex(node_t * origin, int index){
    node_t * current = origin;
    for(int i = 0; i < index; i++){
        if(current == NULL){
            return 0;
        }
        current= current->next;
    }
    return current->value;
}

node_t * returnIndexNode(node_t * origin, int index){
    node_t * current = origin;
    for(int i = 0; i < index; i++){
        if(current == NULL){
            return 0;
        }
        current= current->next;
    }
    return current;
}

void printAll(node_t * origin){
    node_t * current = origin;
    while(current!=NULL){
        printf("%i\n",current->value);
        current = current->next;
    }
    
}

void Append(node_t * origin,int val){
    node_t * end = loopList(origin,-1);
    
    end->next = (node_t *) malloc(sizeof(node_t));
    end->next->value = val;
    end->next->next = NULL;
}

void Insert(node_t * origin, int val){
    node_t * oldorigin = (node_t*) malloc(sizeof(node_t));
    oldorigin->value = origin->value;
    oldorigin->next = origin->next;
    origin->next= oldorigin;
    origin-> value = val;
}

void removeNode(node_t * origin, int index){
    
    if(index ==0){
        node_t * end = loopList(origin,0);  
        node_t ** temp = &end;
        *end = *(end->next);
        free(temp);
    }else{
        node_t * end = loopList(origin,index-1);
        node_t *temp = end->next;
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


int findLength(node_t * origin){
    int length = 1;
    node_t * current = origin;
    while(current->next!=NULL){
        current = current->next;
        length++;
    }
    return length;
}
void Sort(node_t * origin){
    int i,j,index = 0,length = findLength(origin);
    for(i = 0; i < length-1; i++){
        for(j = 0; j < length-i-1; j++){
            if(returnIndex(origin,j) > returnIndex(origin,j+1)){
                swap(&(returnIndexNode(origin,j)->value),&(returnIndexNode(origin,j+1)->value));
            }
        }
    }
}

void removeDuplicates(node_t* head){
    node_t * current = head;
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

void insertAtIndex(node_t * origin, int val, int index){
    node_t * newNode = (node_t*) malloc(sizeof(node_t));
    newNode->value = val;
    node_t * location = loopList(origin,index-1);
    newNode->next = location->next;
    location->next = newNode;
}

void next(void){
    printf("call 2");
}
void first(void){
    printf("call one\n");
}



int main(void){
    
    node_t * epic = NULL;
    epic = (node_t *) malloc(sizeof(node_t));
    epic->value = 7;
    epic->next = NULL;
    
    Append(epic,1);
    Append(epic,2);
    Append(epic,3);
    Append(epic,4);
    Append(epic,5);
    Append(epic,6);
    
    int length = findLength(epic);
    for(int i = 0; i < length; i++){
        printf("%i",returnIndex(epic,i));
    }
    
    printf("epic-> next %i, value: %i\n",epic,epic->value);

    /*node_t * temp = (epic->next);
    epic->next = epic->next->next;
    free(temp);*/
    removeNode(epic,0);
    MEMCPY(a,b,c)
    
    printf("epic free next %i, value: %i\n",epic,epic->value);
    return 0;
}