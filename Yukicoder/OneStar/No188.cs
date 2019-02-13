using System;

public class No188
{
    static int happyDayCount = 0;
    static int month = 1;

    public static void Main()
    {
        int day = 0;


        //string[] input = Console.ReadLine().Split(' ');
        while (month < 12)
        {
            day = DecideDay(month);
            CalculateHappyDay(day);
            month++;
        }
        Console.WriteLine(happyDayCount);
    }

    public static int DecideDay(int month)
    {
        int day = 0;

        switch (month)
        {
            case 1:
            case 3:
            case 5:
            case 7:
            case 8:
            case 10:
            case 12:
                day = 31;
                break;

            case 4:
            case 6:
            case 9:
            case 11:
                day = 30;
                break;

            case 2:
                day = 28;
                break;
        }
        return day;
    }
    public static void CalculateHappyDay(int day)
    {
        for (int i = 1; i <= day; i++)
        {
            int onesPlace = i % 10;
            int tensPlace = i / 10;
            if (month.Equals(onesPlace + tensPlace))
            {
                happyDayCount++;
            }
        }
    }
}
