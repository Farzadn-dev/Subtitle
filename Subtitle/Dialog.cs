namespace Subtitle
{
    public struct DialogPart
    {
        public DialogPart(string text)
        {
            Text = text;

            TextAlign = TextAlign.Default;
            Tags = new List<string>();
        }
        public DialogPart(string text, Font font) : this(text)
        {
            Font = font;
        }
        public DialogPart(string text, TextAlign textAlign) : this(text)
        {
            TextAlign = textAlign;
        }
        public DialogPart(string text, params string[] tags) : this(text)
        {
            Tags = tags.ToList();
        }
        public DialogPart(string text, Font font, TextAlign textAlign) : this(text)
        {
            Font = font;
            TextAlign = textAlign;
        }
        public DialogPart(string text, Font font, TextAlign textAlign, params string[] tags) : this(text)
        {
            Font = font;
            TextAlign = textAlign;
            Tags = tags.ToList();
        }

        public string Text { get; set; }

        public Font Font { get; set; }
        public TextAlign TextAlign { get; set; }
        public List<string> Tags { get; set; }
    }
    public struct Dialog
    {
        public HashSet<DialogPart> Parts { get; set; }
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }
    }
}
