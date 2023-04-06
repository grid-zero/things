

void DoMath()
{

    double[] splitinput = {3,3,3,3,3,3};
    double[] second = { 3.5, 3.1, 3.05,3.01,3.001,3.0001 };
    
    string[] splitinput2 = { };
    for (int i = 0; i< splitinput.Length; i++)
    {
        double a = second[i] - splitinput[1];
        Console.Write("b-a ={0}",a);
        a = Math.Pow(second[i],3);
        double b = Math.Pow(splitinput[i], 3);
        double c = a - b;
        double d = second[i] - splitinput[1];
        double e = c / d;


        Console.WriteLine("f thing = {0}",e);
    }
}

void Derivative()
{
    string input = Console.ReadLine();
    string[] splitinput = input.Split("x");

}
DoMath();