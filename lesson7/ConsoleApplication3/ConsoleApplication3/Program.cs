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
    // Write a method that changes the first element of array, a, to 0
    public static void challenge1(int[] a)
    {
        a[0] = 0;

    }

    // Challenge 2
    // Write a method that prints the first and last element of an array on the same line
    public static void challenge2(int[] a)
    {
        Console.Write(a[0]+" ");
        Console.Write(a[a.Length-1]);
    }

    // Challenge 3
    // Write a method that checks an array, a,  of characters for '*'
    // It should return true if it is present at least once, false otherwise
    public static bool challenge3(char[] a)
    {
        
        for(int i = 0; i<a.Length; i++)
        {
            if (a[i] == "*"){
                return true;
            }
            else
            {
                return false;
            }
        }

    }

    // Challenge 4
    // Write a method that adds the lowest number to the highest number for an array of integers, a
    // It should return this value
    public static int challenge4(int[] a)
    {
        int sum = a.Min;
        int sum1 = a.Max;
        int res = sum + sum1;
        return res;
        
    }

    // Challenge 5
    // Write a method that checks if a character array, a, contains only unique characters
    // It should return false if a duplicate is detected, true otherwise
    public static bool challenge5(char[] a)
    {
        return false;
    }

    // Challenge 6
    // Write a method that accepts a character array, a, then returns a new array of the elements in reverse order
    // You CAN NOT use the inbuilt Array.Reverse method in this challenge
    public static char[] challenge6(char[] a)
    {
        char[] reversed = { };
        return reversed;
    }

    // Challenge 7
    // Write a method that accepts two integer arrays, a and b, then checks if the have the same elements
    // The elements being checked does NOT have to be in the same order
    // If both contain the same elements in the sane quantity of each, then return true, otherwise, return false
    public static bool challenge7(char[] a, char[] b)
    {
        return false;
    }

    // DO NOT EDIT THE MAIN METHOD
    // CODE FROM THE MAIN METHOD WILL NOT BE ASSESSED
    // THE CODE WRITTEN HERE IS PROVIDED FOR YOUR CONVENIENCE (SO YOU CAN TEST YOUR WORK)
    public static void Main()
    {
        Console.WriteLine("This is the output of your challenge 1:");
        int[] testInt = { };
        char[] testChar = { };

        //challenge1(testInt);
        Console.WriteLine("");

        Console.WriteLine("This is the output of your challenge 2:");
        //challenge2();

        Console.WriteLine("This is the output of your challenge 3:");
        challenge3(testChar);
        Console.WriteLine("");

        Console.WriteLine("This is the output of your challenge 4:");
        challenge4(testInt);
        Console.WriteLine("");

        Console.WriteLine("This is the output of your challenge 5:");
        challenge5(testChar);
        Console.WriteLine("");

        Console.WriteLine("This is the output of your challenge 6:");
        challenge6(testChar);
        Console.WriteLine("");

        Console.WriteLine("This is the output of your challenge 7:");
        challenge7(testChar, testChar);
        Console.WriteLine("");
        Console.ReadKey();
    }
}