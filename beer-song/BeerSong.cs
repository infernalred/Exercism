using System;

public static class BeerSong
{
    public static string Recite(int startBottles, int takeDown)
    {
        string many = "";

        for (;  takeDown > 0; takeDown--)
        {
            many += SongString(startBottles);
            if (takeDown > 1)
                many += "\n\n";
            startBottles--;
        }

        return many;
    }

    public static string SongString(int bottles)
    {
        return bottles > 1 ? $"{bottles} bottles of beer on the wall, {bottles} bottles of beer.\n" +
            $"Take one down and pass it around, {--bottles} {StrBottles(bottles)} of beer on the wall."
            : bottles == 1 ? $"{bottles} bottle of beer on the wall, {bottles} bottle of beer.\n" +
            $"Take it down and pass it around, no more bottles of beer on the wall." 
            : "No more bottles of beer on the wall, no more bottles of beer.\n" +
            "Go to the store and buy some more, 99 bottles of beer on the wall.";
    }

    private static string StrBottles(int bottles) => bottles > 1 ? "bottles" : "bottle";

}