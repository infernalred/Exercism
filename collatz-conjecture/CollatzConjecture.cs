using System;

public static class CollatzConjecture
{
    public static int Steps(int number)
    {
        int i = 0;
        if (number == 1)
            return 0;
        try
        {
            
            if (number <= 0)
            {
                throw new ArgumentException();
            }
        }
        catch (Exception)
        {

            throw;
        }
        while (number != 1)
        {
            if (number % 2 == 0)
            {
                number /= 2;
                i++;
            }
            else
            {
                number = number * 3 + 1;
                i++;
            }
        }
        return i;
    }
}