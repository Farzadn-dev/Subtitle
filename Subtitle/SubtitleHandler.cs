using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subtitle
{
    public class SubtitleHandler
    {
        /*
         * Tags in Subtitle:
         * 
            <b> : bold text
            <i> : italic text
            <u> : underline text
            <s> : strikethrough text
            <font> : customize text appearance / color, size, face
            <font color="#hexValue"> : set text color / example: "#d4eef3" (light blue)
            <font size="value"> : set text size / example: "12", "20"
            <font face="fontName"> : set font family / example: "Segoe UI", "Arial"
            <sup> : superscript text
            <sub> : subscript text
            <small> : smaller font size text
            <big> : larger font size text
            <mark> : highlight text / default is yellow background
            <tt> : teletype (monospace) text
            <em> : emphasized (italic) text
            <strong> : strong emphasis (bold) text
            <blockquote> : indented text for block quotes
            <code> : inline code text (monospace)
            <pre> : preformatted text (preserves spaces and line breaks)
            <ruby> : ruby annotation (typically used for Asian language subtitles)
            <rb> : base text for ruby annotation
            <rt> : ruby text (small text above the base text)
            <rp> : parentheses for ruby annotation
        
        *********************************************************************************************************

         * Text allinges:
         * 
            {\an1} : align text to bottom-left
            {\an2} : align text to bottom-center
            {\an3} : align text to bottom-right
            {\an4} : align text to middle-left
            {\an5} : align text to middle-center (default alignment)
            {\an6} : align text to middle-right
            {\an7} : align text to top-left
            {\an8} : align text to top-center
            {\an9} : align text to top-right

         */
        ///////////////////////////////////////////////////////////////////////

        public SubtitleHandler()
        {
            Dialogs = new List<Dialog>();
        }


        private List<Dialog> Dialogs { get; init; }
        private Stream _stream = default!;


        public void AddDialog(Dialog dialog) => Dialogs.Add(dialog);

        public void AddDialogAt(Dialog dialog, int index) => Dialogs.Insert(index, dialog);
        public bool RemoveDialog(Dialog dialog) => Dialogs.Remove(dialog);

        public async Task<bool> SaveAsync(StreamWriter sw)
        {
            try
            {
                int count = 1;
                foreach (var dialog in Dialogs)
                {
                    await sw.WriteLineAsync(count.ToString());
                    await sw.WriteLineAsync($"{await TimeSpanFormaterAsync(dialog.Start)} --> {await TimeSpanFormaterAsync(dialog.End)}");
                    await sw.WriteLineAsync(TextBeautifier(dialog));

                    await sw.WriteLineAsync("");
                    count++;
                }

                await sw.DisposeAsync();
                return true;
            }
            catch (Exception)
            {
                await sw.DisposeAsync();
                throw;
            }

        }

        private string TextBeautifier(Dialog dialog)
        {
            StringBuilder result = new StringBuilder();
            foreach (var part in dialog.Parts)
            {
                string temp = part.Text;

                if (part.Font is { })
                    temp = AddFontToDialog(part);

                foreach (var tag in part.Tags)
                    temp = AddTagToText(temp, tag);

                if (part.TextAlign != TextAlign.Default)
                    temp = GetAlignmentCode(part.TextAlign) + temp;

                result.Append(temp);
            }

            return result.ToString();
        }

        //{\anX} 
        private string GetAlignmentCode(TextAlign alignment)
        {
            switch (alignment)
            {
                case TextAlign.BottomLeft:
                    return "{\\an1}";
                case TextAlign.BottomCenter:
                    return "{\\an2}";
                case TextAlign.BottomRight:
                    return "{\\an3}";

                case TextAlign.MiddleLeft:
                    return "{\\an4}";
                case TextAlign.MiddleCenter:
                    return "{\\an5}";
                case TextAlign.MiddleRight:
                    return "{\\an6}";

                case TextAlign.TopLeft:
                    return "{\\an7}";
                case TextAlign.TopCenter:
                    return "{\\an8}";
                case TextAlign.TopRight:
                    return "{\\an9}";

                case TextAlign.Default:
                default:
                    return "{\\an5}"; // Default alignment
            }
        }

        //<font face="face" color="color" size="size">text</font>
        private string AddFontToDialog(DialogPart part)
        {
            StringBuilder result = new StringBuilder();

            result.Append("<font");

            if (!string.IsNullOrEmpty(part.Font.Face))
                result.Append($" face=\"{part.Font.Face}\"");

            if (!part.Font.Color.IsEmpty)
                result.Append($" color=\"{ColorToHex(part.Font.Color)}\"");

            if (part.Font.Size > 0)
                result.Append($" size=\"{part.Font.Size}\"");

            result.Append(">");

            result.Append(part.Text);

            result.Append("</font>");

            return result.ToString();
        }

        private static string ColorToHex(System.Drawing.Color c) => $"#{c.R:X2}{c.G:X2}{c.B:X2}";

        //<tag>text</tag>
        private string AddTagToText(string text, string tag) => $"<{tag}>{text}</{tag}>";

        /* hours:minutes:seconds,milliseconds */
        private async Task<string> TimeSpanFormaterAsync(TimeSpan span) => await Task.FromResult(string.Format("{0:D2}:{1:D2}:{2:D2},{3:D3}", span.Hours, span.Minutes, span.Seconds, span.Milliseconds));
    }
}
