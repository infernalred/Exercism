using System;
using System.Collections.Generic;
using System.Linq;

public enum Plant
{
    Violets = 'V',
    Radishes = 'R',
    Clover = 'C',
    Grass = 'G'
}

public class KindergartenGarden
{
    private char[] _firstRange { get; set; }
    private char[] _secondRange { get; set; }
    public KindergartenGarden(string diagram)
    {
        var plants = diagram.Split("\n");
        _firstRange = plants[0].ToCharArray();
        _secondRange = plants[1].ToCharArray();
    }

    public IEnumerable<Plant> Plants(string student)
    {
        var index = (char.ToUpper(student.First()) - 65) * 2;

        return new[] {(Plant)_firstRange[index],
        (Plant)_firstRange[index + 1],
        (Plant)_secondRange[index],
        (Plant)_secondRange[index + 1]};
    }
}