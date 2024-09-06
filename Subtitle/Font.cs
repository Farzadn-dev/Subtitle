using System.Drawing;

namespace Subtitle
{
    public struct Font
    {
        public Font(string face = "Calibri", int size = 25, Color color = default)
        {
            Face = face;
            Size = size;
            Color = color == default? Color.White : color;
        }
        public string Face { get; set; }
        public int Size { get; set; }
        public Color Color { get; set; }
    }
}
