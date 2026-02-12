namespace HyperMoose.Utilities;

internal static class FontHelper
{
    public static Font ReplaceFontFamily(Font font, string family)
    {
        return new Font(family, font.Size, font.Style, font.Unit, font.GdiCharSet);
    }
}
