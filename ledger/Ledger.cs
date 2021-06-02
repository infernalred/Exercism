using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

public class LedgerEntry
{
    public LedgerEntry(DateTime date, string desc, decimal chg)
    {
        Date = date;
        Desc = desc;
        Chg = chg;
    }

    public DateTime Date { get; }
    public string Desc { get; }
    public decimal Chg { get; }
}

public static class Ledger
{
    public static LedgerEntry CreateEntry(string date, string desc, int chng)
    {
        return new LedgerEntry(DateTime.Parse(date, CultureInfo.InvariantCulture), desc, chng / 100.0m);
    }

    private static CultureInfo CreateCulture(string cur, string loc)
    {
        string curSymb = cur == "EUR" ? "€" : "$";
        int curNeg = loc == "nl-NL" ? 12 : 0;
        string datPat = loc == "en-US" ? "MM/dd/yyyy" : "dd/MM/yyyy";

        if ((cur != "USD" && cur != "EUR") || (loc != "nl-NL" && loc != "en-US"))
            throw new ArgumentException("Invalid currency");

        var culture = new CultureInfo(loc);
        culture.NumberFormat.CurrencySymbol = curSymb;
        culture.NumberFormat.CurrencyNegativePattern = curNeg;
        culture.DateTimeFormat.ShortDatePattern = datPat;
        return culture;
    }

    private static string PrintHead(string loc)
    {
        return loc == "en-US" ? "Date       | Description               | Change       " : loc == "nl-NL" ? "Datum      | Omschrijving              | Verandering  " : throw new ArgumentException("Invalid locale");
    }

    private static string Date(IFormatProvider culture, DateTime date) => date.ToString("d", culture);

    private static string Description(string desc)
    {
        return desc.Length > 25 ? desc.Substring(0, 22) + "..." : desc;
    }

    private static string Change(IFormatProvider culture, decimal cgh)
    {
        return cgh.ToString("C", culture) + (cgh < 0.0m ? "" : " ");
    }

    private static string PrintEntry(IFormatProvider culture, LedgerEntry entry)
    {
        return Date(culture, entry.Date) + " | " + string.Format("{0,-25}", Description(entry.Desc)) + " | " + string.Format("{0,13}", Change(culture, entry.Chg));
    }


    private static IEnumerable<LedgerEntry> sort(LedgerEntry[] entries)
    {
        var neg = entries.Where(e => e.Chg < 0).OrderBy(x => x.Date + "@" + x.Desc + "@" + x.Chg);
        var post = entries.Where(e => e.Chg >= 0).OrderBy(x => x.Date + "@" + x.Desc + "@" + x.Chg);

        var result = new List<LedgerEntry>();
        result.AddRange(neg);
        result.AddRange(post);

        return result;
    }

    public static string Format(string currency, string locale, LedgerEntry[] entries)
    {
        var formatted = PrintHead(locale);

        var culture = CreateCulture(currency, locale);

        if (entries.Length > 0)
        {
            var entriesForOutput = sort(entries);

            for (var i = 0; i < entriesForOutput.Count(); i++)
            {
                formatted += "\n" + PrintEntry(culture, entriesForOutput.Skip(i).First());
            }
        }

        return formatted;
    }
}