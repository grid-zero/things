import random




def game():
    print('This is a guessing game')
    guess = "not a number"
    number = random.randint(0, 10)
    # number = 15
    while(True):
        guess = Guess()
        if guess == number:
            print("you win")
            break
        if(guess> number):
            print("guess is too high")
        else:
            print("guess to low")
        print(f"big L cringer you are wrong")

def Guess():
    guess = "l boz  o"
    while (guess.isnumeric() == False):
        guess = input("guess a number between 0 and 10: ")
        if guess.isnumeric():
            guess = int(guess)
            return guess
            break
        else:
            print("not a number")

def kevin():
    #loops but multiplies by one not i
    for i in range(1, 5):
        print("*" * i)

    for i in reversed(range(1, 4)):
        print("*" * i)

    #donest work because ends imeaditly
    #for i in range(4, 1):
     #   print("*" * i)
def kevin2():
    num = int(input("Enter a positive or negative number: "))
    if num == 0:
        print("number is zero")
    elif(num<0):
        print("numer is negative")
    else:
        print("number is positive")
if __name__ == '__main__':
    kevin2()