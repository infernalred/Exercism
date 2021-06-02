using System;
using System.Linq;
using System.Text;

public class SimpleCipher
{
    private readonly int min = (int)'a';
    private readonly int max = (int)'z';
    private readonly string _key;
    public SimpleCipher()
    {
        Random random = new Random();
        _key = string.Concat(Enumerable.Range(0, 10).Select(x => (char)random.Next(min, max + 1)));
    }

    public SimpleCipher(string key)
    {
        _key = key;
    }

    public string Key => _key;

    public string Encode(string plaintext, bool decode = false)
    {
        StringBuilder s = new StringBuilder();
        for (int i = 0; i < plaintext.Length; i++)
        {
            int offset = decode ? 'a' - _key[i % _key.Length] : _key[i % _key.Length] - 'a';
            char newChar = (char)((((plaintext[i] - 'a' + offset) + 26) % 26) + 'a');
            s.Append(newChar);
        }
        return s.ToString();
    }

    public string Decode(string ciphertext)
    {
        return Encode(ciphertext, true);
    }
}