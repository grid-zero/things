// Build a simple dictionary in C by completing this code
#include <stdio.h>
#include <stdbool.h>

struct entry {
    char word[15];
    char definition[50];
};

// Implement this function!
// Did you already complete this function in the previous lesson practice set?
bool equalStrings(const char s1[], const char s2[]) {
    bool areEqual = 1;
    int i = 0;
    while(s1[i]!='\0' || s2[i]!='\0'){
        if(s1[i]!=s2[i]){
            areEqual = 0;
            return areEqual;
        }
        i++;
        if((s1[i] == '\0' && s2[i]!='\0') || (s1[i] != '\0' && s2[i] == '\0')){
            areEqual = 0;
            return areEqual;
        }
    }       
    // Write code to check if strings, s1 and s2, are the same
    
    return areEqual;
}

// Implement this function!
// Note that the first argument is an array of struct entry
// This function should make use of equalStrings()
int lookup(const struct entry dictionary[], const char searchTerm[], const int entries) {
    for(int i = 0; i < entries; i++){
        if(equalStrings(searchTerm,dictionary[i].word) == 1){
            return i;
        }
    }
    int i = -1;
    
    // Write code so that this function returns the index of searchTerm if it is in the dictionary, if not, it should return -1
    // In terms of a search algorithm, it should be fine to just carry out a linear search
    
    return i;
}

// main() is complete
// study how an array of structures is initialized
// Perhaps you can add a few more entries to dictionary
int main() {
    const struct entry dictionary[100] = {
        { "abyss", "a bottomless pit" },
        { "acumen", "mentally sharp; keen" },
        { "addle", "to become confused" },
        { "affix", "to append; attach" },
        { "ajar", "partially opened" }
    };

    char word[15];
    int entries = 5;
    int entry;
    
    printf("Enter word: ");
    scanf("%14s", word);
    entry = lookup(dictionary, word, entries);
    
    if (entry != -1) {
        printf("%s\n", dictionary[entry].definition);
    } else {
        printf("Word not found!\n");
    }

    return 0;
}