class Program
{
    // The name of this variable speaks by itself
    static string charset = "abcdefghijklmnopqrstuvwxyz";
    // This variable will store the password that will be found in the future
    static string password;
    // Is the length of the password that the program should start with.
    // IMPORTANT NOTE: If you enter 0, the program will start generating one character passwords...
    //...If you put 1, the program will start cracking 2 character passwords. And so on.
    static int length = 0;
    // The name of this variable speaks by itself
    static ulong numberOfAttempts = 0;

    static void Main()
    {
        Console.Write("Enter your password: ");
        string pass = Console.ReadLine();

        bf("", pass);

        Console.Write("Your password is: ");
        if (password == "")
            Console.WriteLine("Empty String");
        else
            Console.WriteLine(password);
        Console.WriteLine("Number of attempts: " + numberOfAttempts);
    }
    // This function counts how many times the last char of the variable "charset" appears in a string
    static int countLast(string s)
    {
        int result = 0;
        foreach (char c in s)
            if (c == charset[charset.Length - 1])
                result++;
        return result;
    }
    // Generate all possible combinations of a string based on a charset
    static void bf(string attempt, string pass)
    {
        // Console.WriteLine(attempt); -> uncomment this line if you want to see the combinations beeing generated
        if (attempt == pass)
        {
            password = attempt;
        }
        if (length < attempt.Length)
        {
            if (countLast(attempt) == attempt.Length)
                length = attempt.Length;
            return;
        }
        for (int i = 0; i <= charset.Length; i++)
        {
            if (i == charset.Length)
            {
                if (attempt == "")
                    i = 0;
                else
                    return;
            }
            numberOfAttempts++;
            bf(attempt + charset[i], pass);
            if (password == pass)
                return;
        }
    }
}
