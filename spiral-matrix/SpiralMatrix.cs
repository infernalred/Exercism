using System;

public class SpiralMatrix
{
    public static int[,] GetMatrix(int size)
    {
        int[,] rezult = new int[size, size];
        int numMax = size * size;
        int startNum = 1;
        int minX = 0;
        int maxY = size - 1;
        int minY = 0;
        int maxX = size - 1;

        while (startNum <= numMax)
        {
            //go right
            for (int i = minY; i <= maxY; i++)
            {
                rezult[minX, i] = startNum;
                startNum++;
            }
            minX++;

            //go down
            for (int j = minX; j <= maxX; j++)
            {
                rezult[j, maxY] = startNum;
                startNum++;
            }
            maxY--;

            //go left
            if (minY <= maxY)
            {
                for (int k = maxY; k >= minY; k--)
                {
                    rezult[maxX, k] = startNum;
                    startNum++;
                }
                maxX--;
            }

            //go up
            if (minX <= maxX)
            {
                for (int l = maxX; l >= minX; l--)
                {
                    rezult[l, minY] = startNum;
                    startNum++;
                }
                minY++;
            }

        }

        return rezult;
    }
}
