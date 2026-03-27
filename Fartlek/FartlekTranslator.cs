using System.Text;

namespace Fartlek;

public class FartlekTranslator
{
    public const string fart = "fart-";
    public const string lek = "lek";

    private readonly Dictionary<char, string> _encodings;
    private readonly Dictionary<string, char> _decodings;

    public FartlekTranslator()
    {
        _encodings = new()
        {
            ['A'] = fart + lek,
            ['B'] = lek + fart + fart + fart,
            ['C'] = lek + fart + lek + fart,
            ['D'] = lek + fart + fart,
            ['E'] = fart,
            ['F'] = fart + fart + lek + fart,
            ['G'] = lek + lek + fart,
            ['H'] = fart + fart + fart + fart,
            ['I'] = fart + fart,
            ['J'] = fart + lek + lek + lek,
            ['K'] = lek + fart + lek,
            ['L'] = fart + lek + fart + fart,
            ['M'] = lek + lek,
            ['N'] = lek + fart,
            ['O'] = lek + lek + lek,
            ['P'] = fart + lek + lek + fart,
            ['Q'] = lek + lek + fart + lek,
            ['R'] = fart + lek + fart,
            ['S'] = fart + fart + fart,
            ['T'] = lek,
            ['U'] = fart + fart + lek,
            ['V'] = fart + fart + fart + lek,
            ['W'] = fart + lek + lek,
            ['X'] = lek + fart + fart + lek,
            ['Y'] = lek + fart + lek + lek,
            ['Z'] = lek + lek + fart + fart,
            [' '] = "/",
        };
        _decodings = _encodings.ToDictionary(item => item.Value, item => item.Key);
    }

    public char[] GetValidCharacters() => [.. _encodings.Keys];

    public string Encode(string value)
    {
        var tokens = new List<string>();
        var random = new Random();

        foreach (char c in value)
        {
            if (_encodings.TryGetValue(c, out string? encoded))
            {
                if (random.Next(0, 2) == 1)
                {
                    tokens.Add(encoded.ToUpperInvariant());
                }
                else tokens.Add(encoded);
            }
        }
        return string.Join(" ", tokens);
    }

    public string Decode(string value)
    {
        var builder = new StringBuilder();
        var tokens = EnumerateCharacters(value);

        foreach (string encoded in tokens)
        {
            string normalized = encoded.ToLowerInvariant();

            if (_decodings.TryGetValue(normalized, out char decoded))
            {
                builder.Append(decoded);
            }
        }
        return builder.ToString();
    }

    /// <summary>
    /// Enumerates encoded moose characters separated by whitespace.
    /// </summary>
    public static IEnumerable<string> EnumerateCharacters(string value)
    {
        if (!string.IsNullOrWhiteSpace(value))
        {
            var builder = new StringBuilder();

            for (int index = 0; index < value.Length; index++)
            {
                char c = value[index];

                if (char.IsWhiteSpace(c))
                {
                    if (builder.Length > 0)
                    {
                        string token = builder.ToString();
                        yield return token;

                        builder.Clear();
                    }
                }
                else builder.Append(c);
            }
            if (builder.Length > 0)
            {
                string token = builder.ToString();
                yield return token;
            }
        }
        else yield break;
    }

    /// <summary>
    /// Enumerates individual moose elements within an encoded character.
    /// </summary>
    public static IEnumerable<string> EnumerateElements(string value)
    {
        if (!string.IsNullOrWhiteSpace(value))
        {
            int index = 0;

            while (index < value.Length)
            {
                if (value.AsSpan(index).StartsWith(fart, StringComparison.OrdinalIgnoreCase))
                {
                    yield return fart;
                    index += fart.Length;
                }
                else if (value.AsSpan(index).StartsWith(lek, StringComparison.OrdinalIgnoreCase))
                {
                    yield return lek;
                    index += lek.Length;
                }
                else index++;
            }
        }
        else yield break;
    }
}
