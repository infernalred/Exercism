using System;
using System.Linq;

public enum Direction : byte
{
    North = 0,
    East = 64,
    South = 128,
    West = 192
}

public class RobotSimulator
{
    public RobotSimulator(Direction direction, int x, int y)
    {
        Direction = direction;
        X = x;
        Y = y;
    }

    public Direction Direction { get; set; }

    public int X { get; set; }

    public int Y { get; set; }

    public void Move(string instructions)
    {
        foreach (var item in instructions)
        {
            if (item == 'R')
                MoveR();
            if (item == 'L')
                MoveL();
            if (item == 'A')
                MoveA(Direction);
        }
    }

    private void MoveL() => Direction -= 64;

    private void MoveR() => Direction += 64;

    private void MoveA(Direction direction)
    {
        if (direction == Direction.North)
            Y += 1;
        if (direction == Direction.South)
            Y -= 1;
        if (direction == Direction.East)
            X += 1;
        if (direction == Direction.West)
            X -= 1;
    }
}