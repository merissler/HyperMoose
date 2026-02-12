namespace HyperMoose.Models;

internal class MooseMessage(string encoded, string? font)
{
    public string MooseCode { get; set; } = encoded;
    public string? FontFamily { get; set; } = font;

    public string? Serialize()
    {
        if (!string.IsNullOrWhiteSpace(MooseCode))
        {
            string[] values = [FontFamily ?? string.Empty, MooseCode];
            var parts = values.Where(v => !string.IsNullOrWhiteSpace(v));

            if (parts.Any())
            {
                return string.Join("|", parts);
            }
            else return null;
        }
        else return null;
    }

    public static MooseMessage? Deserialize(string? value)
    {
        if (!string.IsNullOrWhiteSpace(value))
        {
            string[] parts = value.Split('|', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            if (parts.Length >= 2)
            {
                string font = parts[0];
                string message = parts[1];
                return new MooseMessage(message, font);
            }
            else
            {
                string message = parts[0];
                return new(message, null);
            }
        }
        else return null;
    }
}
