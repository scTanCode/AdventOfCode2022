// See https://aka.ms/new-console-template for more information

public class Program
{
    static int getMarkerPosition(char[] arrStr, int numOfCharater)
    {
        char previous = default;
        int markerPosition = 0;
        Queue<char> charSet = new Queue<char>();
        Queue<char> charSet2 = new Queue<char>();

        for (int i = 0; i < arrStr.Length; i++)
        {

            if (arrStr[i] != previous)
            {
                if (!charSet.Contains(arrStr[i]))
                {
                    charSet.Enqueue(arrStr[i]);

                    if (charSet.Count() == numOfCharater)
                    {
                        /*
                        Console.WriteLine("character :");
                        foreach (char item in charSet)
                        {
                            Console.Write(item);
                        }
                        Console.WriteLine("Marker : " + (i + 1));
                        */
                        markerPosition = i + 1;
                        break;
                    }
                }
                else
                {
                    /*
                    foreach (char item in charSet)
                    {
                        Console.WriteLine("else character : " + item);
                    }
                    Console.WriteLine("Currr : " + arrStr[i]);
                    */
                    foreach (char item in charSet)
                    {
                        if (item == arrStr[i])
                        {
                            charSet2.Clear();
                        }
                        else if (item != arrStr[i])
                        {
                            charSet2.Enqueue(item);
                        }
                    }
                    charSet2.Enqueue(arrStr[i]);
                    charSet = new Queue<char>(charSet2);
                    charSet2.Clear();
                }
            }
        }
        return markerPosition;
    }

    static void Main(string[] args)
    {
        string[] inputStr = System.IO.File.ReadAllLines("InputFile.txt");

        //Console.WriteLine("inputStr : " + inputStr.Length);
        char[] arrStr = inputStr[0].ToArray<char>();
        Console.WriteLine("arrStr : " + arrStr.Length);
        Console.WriteLine("first start-of-packet marker (4 character) position: " + getMarkerPosition(arrStr, 4));

        Console.WriteLine("first start-of-packet marker (14 character) position:: " + getMarkerPosition(arrStr, 14));
    }


}