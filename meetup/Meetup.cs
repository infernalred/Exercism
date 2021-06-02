using System;
using System.Collections.Generic;
using System.Linq;

public enum Schedule
{
    Teenth,
    First,
    Second,
    Third,
    Fourth,
    Last
}

public class Meetup
{
    private readonly int _month;
    private readonly int _year;
    public Meetup(int month, int year)
    {
        _month = month; _year = year;
    }

    public DateTime Day(DayOfWeek dayOfWeek, Schedule schedule)
    {
        int days = DateTime.DaysInMonth(_year, _month);
        List<DateTime> allDates = new List<DateTime>();
        for (int i = 1; i <= days; i++)
        {
            DateTime date = new DateTime(_year, _month, i);
            if (date.DayOfWeek == dayOfWeek)
                allDates.Add(date);
        }
        if (schedule == Schedule.Last)
            return allDates.Last();
        if (schedule == Schedule.Teenth)
        {
            return allDates.First(d => d.Day >= 13);
        }
            
        return allDates[(int)schedule - 1];
    }
}