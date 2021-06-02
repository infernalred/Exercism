using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class SgfTree
{
    public SgfTree(IDictionary<string, string[]> data, params SgfTree[] children)
    {
        Data = data;
        Children = children;
    }

    public override bool Equals(object obj)
    {
        if (obj == null) return false;
        if (obj == this) return true;
        var tree = obj as SgfTree;
        return tree != null && Equals(tree);
    }

    public bool Equals(SgfTree right)
    {
        var comp1 = this.Data.Count == right.Data.Count && !this.Data.Except(right.Data).Any();
        if (this.Children.Length != right.Children.Length) return false;
        for (int ii = 0; ii < this.Children.Length; ii++)
            if (!this.Children[ii].Equals(right.Children[ii])) return false;
        return true;
    }

    public IDictionary<string, string[]> Data { get; }
    public SgfTree[] Children { get; }
}

public class SgfParser
{
    public static int FindNextSemicolon(string str)
    {
        int level = 0;
        for (int ii = 0; ii < str.Length; ii++)
        {
            if (str[ii] == ';' && level == 0) return ii;
            if (str[ii] == '(') level++;
            else if (str[ii] == ')') level--;
        }
        return -1;
    }
    static string regex_parenthesis = @"(((([\w+\[\]])+(\[((\\[\/\.\*\+\?\|\(\)\[\]\{\}a-z])|\w|\s)+\]))+\)?)|\((?>\((?<c>)|[^()]+|\)(?<-c>))*(?(c)(?!))\))";
    public static SgfTree ParseTree(string input)
    {
        IDictionary<string, string[]> sgfDic = new Dictionary<string, string[]>();
        List<SgfTree> sgfChildTrees = new List<SgfTree>();
        string tinput = input.Trim();
        if (tinput.Length < 3) throw new ArgumentException();
        if (!tinput.StartsWith("(") || !tinput.EndsWith(")")) throw new ArgumentException();
        string innerpartWithSemicolon = input.Substring(1, tinput.Length - 2);
        if (!innerpartWithSemicolon.StartsWith(";")) throw new ArgumentException();
        string innerpart = innerpartWithSemicolon.Substring(1);
        int nextSemicolon = FindNextSemicolon(innerpart);
        string firstpart = (nextSemicolon > 0) ? innerpart.Substring(0, nextSemicolon) : innerpart;
        var matches = Regex.Matches(firstpart, regex_parenthesis, RegexOptions.Multiline);
        if (matches.Count < 1 && innerpart.Length > 0) throw new ArgumentException();
        foreach (Match m in matches)
        {
            if (m.Value.StartsWith("("))
            {
                sgfChildTrees.Add(ParseTree(m.Value));
            }
            else
            {  // key[value][value]s..
                MatchCollection keymatch = Regex.Matches(m.Value, @"(\w+)(\[)");
                foreach (Match mm in keymatch)
                {
                    string propertyName = mm.Groups[1].Value;
                    if (propertyName == propertyName.ToLower() || propertyName != propertyName.ToUpper()) throw new ArgumentException();
                    MatchCollection valuematches = Regex.Matches(m.Value, @"\[(((\\\\[\/\.\*\+\?\|\(\)\[\]\{\}a-z])|\w|\s)+)\]");
                    List<string> values = new List<string>();
                    foreach (Match vmatch in valuematches)
                        values.Add(vmatch.Groups[1].Value);
                    sgfDic[propertyName] = values.ToArray();
                }
            }
        }
        if (nextSemicolon > 0)
        {
            string nextpart = "(" + innerpart.Substring(nextSemicolon) + ")";
            sgfChildTrees.Add(ParseTree(nextpart));
        }
        return new SgfTree(sgfDic, sgfChildTrees.ToArray());
    }
}