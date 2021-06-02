using System;

public class Clock : IEquatable<Clock>
{
    private readonly int _hours;
    private readonly int _minutes;
    public Clock(int hours, int minutes)
    {
        int minutesInDay = 24 * 60;
        minutes += hours * 60;
        _hours = (minutes % minutesInDay + minutesInDay) % minutesInDay / 60;
        _minutes = (minutes % minutesInDay + minutesInDay) % minutesInDay % 60;
    }

    public Clock Add(int minutesToAdd) => new Clock(_hours, _minutes + minutesToAdd);

    public bool Equals(Clock other) => other._hours == _hours && other._minutes == _minutes;

    public Clock Subtract(int minutesToSubtract) => new Clock(_hours, _minutes - minutesToSubtract);

    public override string ToString() => new string($"{_hours:00}:{_minutes:00}");
}
