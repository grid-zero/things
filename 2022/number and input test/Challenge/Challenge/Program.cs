using System;

public class PracticeChallenge
{
    // DO NOT CHANGE ANY METHOD NAMES
    // YOU MUST ONLY WRITE CODE WHERE YOU ARE INDICATED TO DO SO BY THE COMMENTS
    // USUALLY THIS MEANS YOU CAN ONLY WRITE CODE INSIDE THE METHOD DEFINITIONS
    // AVOID WRITING CODE WHICH HAS ANY OTHER EFFECT BEYOND THE REQUIREMENT FOR THE CHALLENGE QUESTION

    // REMEMBER: YOU HAVE A TIME LIMIT TO SUBMIT YOUR CODE FOR THIS CHALLENGE
    // YOU MUST COPY AND PASTE ALL OF YOUR INTO A GOOGLE DOC AND SUBMIT IT TO THE RELEVANT POST ON CLASSROOM
    // ALLOW EXTRA TIME TO DO THIS SO THAT YOUR SUBMISSION IS NOT LATE
    // IF GOOGLE CLASSROOM MARKS YOUR SUBMISSION AS LATE, THEN YOUYR SUBMISSION IS LATE

    // Challenge 1
    // Write a while loop that prints every third number from 0 to 36
    // So it should output: 0, 3, 6, 9, ... etc. ... 36
    public static void challenge1()
    {
        int i = 0;
        while (i < 13)
        {
            Console.WriteLine(i * 3);
            i++;
        }
    }

    // Challenge 2
    // Write a do while loop that prints every number from 0 to 100, except if it is odd
    // So it should output: 0, 2, 4, 6, 8, ... etc ... 100
    public static void challenge2()
    {
        int i = 0;
        do
        {
            Console.WriteLine(i * 2);
            i++;
        }
        while (i < 51);

    }

    // Challenge 3
    // Write a for loop that prints a right-angled triangle made of *'s
    // The triangle should have a base of 10 *'s
    /* So it should output:
		**********
		*********
		********
		*******
		******
		*****
		****
		***
		**
		*
	*/
    public static void challenge3()
    {
        int i = 10;
        while (i > 0)
        {
            Console.WriteLine(String.Concat(Enumerable.Repeat("*",i)));
            i--;
        }
    }

    // DO NOT EDIT THE MAIN METHOD
    // CODE FROM THE MAIN METHOD WILL NOT BE ASSESSED
    // THE CODE WRITTEN HERE IS PROVIDED FOR YOUR CONVENIENCE (SO YOU CAN TEST YOUR WORK)
    public static void Main()
    {
        Console.WriteLine("This is the output of your challenge 1:");
        challenge1();
        Console.WriteLine("");

        Console.WriteLine("This is the output of your challenge 2:");
        challenge2();
        Console.WriteLine("");

        Console.WriteLine("This is the output of your challenge 3:");
        challenge3();
        Console.WriteLine("");
        Console.WriteLine("\n Enter any key to quit");
        Console.ReadKey();
    }
}

