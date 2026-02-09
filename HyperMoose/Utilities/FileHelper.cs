using System.Reflection;

namespace HyperMoose.Utilities;

internal static class FileHelper
{
    public static Herd[] GetSavedGroups()
    {
        string directory = GetDataDirectory();
        string file = Path.Combine(directory, "groups.ini");

        if (File.Exists(file))
        {
            var groups = new List<Herd>();

            foreach (string line in File.ReadLines(file))
            {
                int valueEnd = line.IndexOf('#');
                string value = valueEnd >= 0 ? line[..valueEnd] : line;

                if (!string.IsNullOrWhiteSpace(value))
                {
                    int nameEnd = value.IndexOf(':');
                    string name = value[..nameEnd].Trim().ToUpperInvariant();

                    int membersStart = nameEnd + 1;
                    var options = StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries;
                    string[] members = value[membersStart..].Split(',', options);

                    var herd = new Herd(name);
                    foreach (string host in members)
                    {
                        var moose = new Moose(host);
                        herd.Add(moose);
                    }
                    groups.Add(herd);
                }
            }
            var individuals = groups
                .Where(herd => herd.Count == 1)
                .ToDictionary(herd => herd[0].Hostname, herd => herd.Name);

            foreach (var herd in groups)
            {
                foreach (var moose in herd)
                {
                    if (individuals.TryGetValue(moose.Hostname, out string? name))
                    {
                        moose.Name = name;
                    }
                }
            }
            return [.. groups];
        }
        else return [];
    }

    public static string GetDataDirectory()
    {
        string localAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        return Path.Combine(localAppData, "HyperMoose");
    }

    public static string GetEmbeddedText(string name)
    {
        var assembly = Assembly.GetExecutingAssembly();
        string qualifiedName = $"{nameof(HyperMoose)}.{name}";

        using var stream = assembly.GetManifestResourceStream(qualifiedName);
        if (stream is not null)
        {
            using var reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }
        else throw new Exception($"Resource not found: '{qualifiedName}'");
    }
}
