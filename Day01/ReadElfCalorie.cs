public class ReadElfCalorie
{
    elfList elfList;

    public ReadElfCalorie()
    {
        elfList = new elfList();
        this.getMaxElfCalorie();
        Console.WriteLine("PrintLinkedList");
        // elfList.PrintLinkedList();

        Console.WriteLine("Top Calories : " + elfList.getTopCalorie(1));
        Console.WriteLine("Top 3 Calories : " + elfList.getTopCalorie(3));
    }

    private void getMaxElfCalorie()
    {
        // Read each line of the file into a string array. Each element
        // of the array is one line of the file.
        string[] lines = System.IO.File.ReadAllLines("InputFile.txt");

        int countCalories = 0;
        for (int i = 0; i < lines.Length; i++)
        {
            string str = lines[i];

            if (str.Length > 1)
            {
                countCalories += int.Parse(str);
            }

            if (str.Length < 1 || i == lines.Length-1)
            {
                //Console.WriteLine(i + ":" + countCalories + "lines.Length:" + lines.Length);
                elfList.addItem(i, countCalories);
                countCalories = 0;
            }
        }
    }
}