namespace Subtitle
{
    public struct SubtitleTag
    {
        // Bold text
        public static string Bold => "b";

        // Italic text
        public static string Italic => "i";

        // Underline text
        public static string Underline => "u";

        // Strikethrough text
        public static string Strikethrough => "s";

        // Superscript text
        public static string Superscript => "sup";

        // Subscript text
        public static string Subscript => "sub";

        // Smaller font size text
        public static string SmallText => "small";

        // Larger font size text
        public static string LargeText => "big";

        // Highlight text
        public static string Highlight => "mark";

        // Teletype (monospace) text
        public static string Monospace => "tt";

        // Emphasized (italic) text
        public static string Emphasized => "em";

        // Strong emphasis (bold) text
        public static string Strong => "strong";

        // Indented text for block quotes
        public static string Blockquote => "blockquote";

        // Inline code text
        public static string InlineCode => "code";

        // Preformatted text (preserves spaces and line breaks)
        public static string Preformatted => "pre";

        // Ruby annotation
        public static string RubyAnnotation => "ruby";

        // Base text for ruby annotation
        public static string RubyBase => "rb";

        // Ruby text (small text above the base text)
        public static string RubyText => "rt";

        // Parentheses for ruby annotation
        public static string RubyParenthesis => "rp";
    }
}
