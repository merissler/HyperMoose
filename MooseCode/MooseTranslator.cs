using System.Text;

namespace MooseCode;

public class MooseTranslator
{
    public const string stomp = "*stomp*";
    public const string MUUUAAAH = "\"MUUUAAAH\"";

    private readonly Dictionary<char, string> _encodings;
    private readonly Dictionary<string, char> _decodings;

    public MooseTranslator()
    {
        _encodings = new()
        {
            ['A'] = stomp + MUUUAAAH,
            ['B'] = MUUUAAAH + stomp + stomp + stomp,
            ['C'] = MUUUAAAH + stomp + MUUUAAAH + stomp,
            ['D'] = MUUUAAAH + stomp + stomp,
            ['E'] = stomp,
            ['F'] = stomp + stomp + MUUUAAAH + stomp,
            ['G'] = MUUUAAAH + MUUUAAAH + stomp,
            ['H'] = stomp + stomp + stomp + stomp,
            ['I'] = stomp + stomp,
            ['J'] = stomp + MUUUAAAH + MUUUAAAH + MUUUAAAH,
            ['K'] = MUUUAAAH + stomp + MUUUAAAH,
            ['L'] = stomp + MUUUAAAH + stomp + stomp,
            ['M'] = MUUUAAAH + MUUUAAAH,
            ['N'] = MUUUAAAH + stomp,
            ['O'] = MUUUAAAH + MUUUAAAH + MUUUAAAH,
            ['P'] = stomp + MUUUAAAH + MUUUAAAH + stomp,
            ['Q'] = MUUUAAAH + MUUUAAAH + stomp + MUUUAAAH,
            ['R'] = stomp + MUUUAAAH + stomp,
            ['S'] = stomp + stomp + stomp,
            ['T'] = MUUUAAAH,
            ['U'] = stomp + stomp + MUUUAAAH,
            ['V'] = stomp + stomp + stomp + MUUUAAAH,
            ['W'] = stomp + MUUUAAAH + MUUUAAAH,
            ['X'] = MUUUAAAH + stomp + stomp + MUUUAAAH,
            ['Y'] = MUUUAAAH + stomp + MUUUAAAH + MUUUAAAH,
            ['Z'] = MUUUAAAH + MUUUAAAH + stomp + stomp,
            [' '] = "/",
        };
        _decodings = _encodings.ToDictionary(item => item.Value, item => item.Key);
    }

    public char[] GetValidCharacters() => [.. _encodings.Keys];

    public string Encode(string value)
    {
        var tokens = new List<string>();
        
        foreach (char c in value)
        {
            if (_encodings.TryGetValue(c, out string? encoded))
            {
                tokens.Add(encoded);
            }
        }
        return string.Join(" ", tokens);
    }

    public string Decode(string value)
    {
        var builder = new StringBuilder();
        var tokens = EnumerateTokens(value);

        foreach (string encoded in tokens)
        {
            string normalized;

            const string MUUAAAH = "\"MUUAAAH\"";
            if (encoded.Contains(MUUAAAH))
            {
                normalized = encoded.Replace(MUUAAAH, MUUUAAAH);
            }
            else normalized = encoded;

            if (_decodings.TryGetValue(normalized, out char decoded))
            {
                builder.Append(decoded);
            }
        }
        return builder.ToString();
    }

    private static IEnumerable<string> EnumerateTokens(string value)
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
}
