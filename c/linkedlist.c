#include <stdio.h>
#include <stdlib.h>

typedef struct list{
    int value;
    struct list * next;
}List;

List * ReturnIndex(List* list, int index){
    List * current;
    current = list;
    int count = 0;
    if (index<0){
        while(current->next!=NULL){
            current=current->next;
        }
        return current;
    }else{
        while(current->next!=NULL && index > count){
            current = current->next;
            count++;
        }
        return current;
    }
}
int ReturnValue(List* list, int index){
    List * now = ReturnIndex(list,index);
    return now->value;
}
int Length(List * list){
    int length = 1;
    List * now = list;
    while(now->next!=NULL){
        now = now->next;
        length++;
    }
    return length;
}
void Add(List ** list, int val){
    if(*list==NULL){
        *(list) = ((List*) malloc(sizeof(List)));
        (*(list))->value = val;
        (*(list))->next = NULL;
        //printf("%i",list->value);
    }else{
        List * end = ReturnIndex(*(list),-1);
        end->next = (List *) malloc(sizeof(List));
        end->next->value = val;
        end->next->next = NULL;
    }
}
void AddRange(List ** list, int* range, int length){
    for(int i = 0; i < length; i++){
        Add(list,range[i]);
    }
}
void RemoveIndex(List* list, int index){
    if(index ==0){
        List * end = ReturnIndex(list,0);
        List ** temp = &end;
        *end = *(end->next);
        free(temp);
    }else{
        List * end = ReturnIndex(list,index-1);
        List *temp = end->next;
        end->next = end->next->next;
        free(temp);        
    }
}
void Clear(List** list){
    int length = Length(*list);
    List *nodes[length];
    List * now = *list;
    int index = 0;
    while(now!=NULL){
        nodes[index] = now;
        index++;
        now=now->next;
    }
    for(int i = 0; i < length;i++){
        free(nodes[i]);
    }
    *list = NULL;
}
int Contains(List* list, int val){
    List * now = list;
    while(now->next!=NULL){
        if(now->value == val){
            return 1;
        }
        now=now->next;
    }
    return 0;
}
int IndexOf(List* list, int val){
    List * now = list;
    int index = 0;
    while(now->next!=NULL){
        if(now->value == val){
            return index;
        }
        now=now->next;
        index++;
    }
    return -1;
}
void Insert(List* list, int val, int index){
    if(index == 0){
        List* insertion = (List*) malloc(sizeof(List));
        insertion->value = list->value;
        insertion->next = list->next;
        list->value = val;
        list->next = insertion;
    }else{
        List* location = ReturnIndex(list,index-1);
        List* insertion = (List*) malloc(sizeof(List));
        insertion->next = location->next;
        insertion->value = val;
        location->next=insertion;
    }
}
void InsertRange(List* list, int index, int* range, int length){
    for(int i = 0; i < length; i++){
        Insert(list,range[i],index+i);
    }
}

void RemoveValue(List* list, int val){
    List* now = list;
    int count = 0;
    while(now->next!=NULL){
        if(now->value == val){
            RemoveIndex(list, count);
        }
        now = now->next;
        count++;
    }
}
void swap(int* x, int* y)
{
    *(x) = *(x) + *(y);
    *(y) = *(x) - *(y);
    *(x) = *(x) - *(y);
}
void Reverse(List* list){
    int length = Length(list);
    for(int i = 0; i < length/2; i++){
        swap(&(ReturnIndex(list,i)->value),&(ReturnIndex(list,(length)-i-1)->value));
    }
}

int main(void){
    int test[] = {34,65,23,87,345,87,324};
    List * newList = NULL;
    List ** ListPointer = & newList;
    AddRange(ListPointer,test,sizeof(test)/4);
    int length = Length(newList);
    List *nodes[length];
    List * now = newList;
    int index = 0;
    while(now!=NULL){
        nodes[index] = now;
        index++;
        now=now->next;
    }
    for(int i = 0; i < length; i++){
        printf("%i\n",nodes[i]->value);
    }
    for(int i = 0; i < length;i++){
        free(nodes[i]);
    }
    for(int i = 0; i < length; i++){
        printf("%i\n",ReturnValue(newList,i));
    }
}