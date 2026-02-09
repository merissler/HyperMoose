namespace HyperMoose;

internal class Herd : List<Moose>
{
    public string Name { get; set; }

    public Herd(string name)
    {
        Name = name.ToUpperInvariant();
    }

    public Herd(string name, IEnumerable<Moose> collection) : base(collection)
    {
        Name = name.ToUpperInvariant();
    }
}
