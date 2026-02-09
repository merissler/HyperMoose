using System.Net;
using System.Reflection;

namespace HyperMoose;

internal static class FileHelper
{
    public static Herd[] GetSavedGroups()
    {
        string directory = GetDataDirectory();
        string file = Path.Combine(directory, "groups.ini");

        if (File.Exists(file))
        {
            var friends = GetSavedFriends().ToDictionary(m => m.IPAddress);
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
                    var ips = members.Select(IPAddress.Parse);

                    foreach (var ip in ips)
                    {
                        var moose = friends.GetValueOrDefault(ip, new Moose(ip));
                        herd.Add(moose);
                    }
                    groups.Add(herd);
                }
            }
            return [.. groups];
        }
        else return [];
    }

    public static Moose[] GetSavedFriends()
    {
        string directory = GetDataDirectory();
        string file = Path.Combine(directory, "friends.ini");

        if (File.Exists(file))
        {
            var friends = new List<Moose>();

            foreach (string line in File.ReadLines(file))
            {
                int valueEnd = line.IndexOf('#');
                string value = valueEnd >= 0 ? line[..valueEnd] : line;

                if (!string.IsNullOrWhiteSpace(value))
                {
                    var options = StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries;
                    string[] tokens = line.Split(':', options);

                    string name = tokens[0].ToUpperInvariant();
                    var ip = IPAddress.Parse(tokens[1]);

                    var moose = new Moose(name, ip);
                    friends.Add(moose);
                }
            }
            return [.. friends];
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
