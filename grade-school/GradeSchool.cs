using System;
using System.Collections.Generic;
using System.Linq;

public class GradeSchool
{
    private readonly SortedDictionary<int, SortedSet<string>> students = new SortedDictionary<int, SortedSet<string>>();


    public void Add(string student, int grade) 
    {
        if (!students.ContainsKey(grade))
            students.Add(grade, new SortedSet<string>());
        students[grade].Add(student);
    } 

    public IEnumerable<string> Roster() => students.Values.SelectMany(v => v);

    public IEnumerable<string> Grade(int grade) => students.Count > 0 ? students[grade] : Enumerable.Empty<string>();
}