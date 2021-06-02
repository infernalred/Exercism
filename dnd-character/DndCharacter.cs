﻿using System;
using System.Linq;

public class DndCharacter
{
    private static Random random = new Random();
    public int Strength { get; }
    public int Dexterity { get; }
    public int Constitution { get; }
    public int Intelligence { get; }
    public int Wisdom { get; }
    public int Charisma { get; }
    public int Hitpoints { get; }

    public DndCharacter(int strength, int dexterity, int constitution, int intelligence, int wisdom, int charisma)
    {
        Strength = strength;
        Dexterity = dexterity;
        Constitution = constitution;
        Intelligence = intelligence;
        Wisdom = wisdom;
        Charisma = charisma;
        Hitpoints = 10 + Modifier(constitution);
    }

    public static int Modifier(int score) => (int)Math.Floor((score - 10) / 2.0);

    public static int Ability() => new[] { random.Next(1, 7), random.Next(1, 7), random.Next(1, 7), random.Next(1, 7) }.OrderByDescending(x => x).Take(3).Sum();


    public static DndCharacter Generate() => new DndCharacter(Ability(), Ability(), Ability(), Ability(), Ability(), Ability());
}
