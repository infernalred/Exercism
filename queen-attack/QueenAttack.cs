using System;

public class Queen
{
    
    public Queen(int row, int column)
    {
        Row = row;
        Column = column;
    }

    public int Row { get; }
    public int Column { get; }
}

public static class QueenAttack
{
    public static bool CanAttack(Queen white, Queen black) => (white.Column == black.Column || white.Row == black.Row) || Math.Abs(white.Column - black.Column) == Math.Abs(white.Row - black.Row);

    public static Queen Create(int row, int column)
    {
        int[,] array = new int[8,8];
        try
        {
            array[row, column] = 0;
        }
        catch (Exception)
        {
            throw new ArgumentOutOfRangeException();
        }

        return new Queen(row, column);
    }
}