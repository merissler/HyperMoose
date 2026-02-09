using System.Net;

namespace HyperMoose;

internal class Moose
{
    public string Name { get; set; }
    public IPAddress IPAddress { get; }

    public Moose(IPAddress ip)
    {
        Name = ip.ToString();
        IPAddress = ip;
    }

    public Moose(string name, IPAddress ip)
    {
        Name = name;
        IPAddress = ip;
    }
}
