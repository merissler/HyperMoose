namespace HyperMoose;

internal class Moose
{
    public string Name { get; set; }
    public string Hostname { get; }

    public Moose(string host)
    {
        Name = host;
        Hostname = host;
    }

    public Moose(string name, string host)
    {
        Name = name;
        Hostname = host;
    }
}
