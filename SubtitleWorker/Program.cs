using Subtitle;
using System.Drawing;

namespace SubtitleWorker
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            TimeSpan start = new TimeSpan(0, 0, 0, 0, 0);
            SubtitleHandler subtitleHandler = new SubtitleHandler();
            subtitleHandler.AddDialog(new Dialog()
            {
                Start = start,
                End = start = start.Add(TimeSpan.FromSeconds(10)),
                Parts = new HashSet<DialogPart>()
                {
                    new DialogPart()
                    {
                        Text = "Hello ",
                        Font = new Font(color: Color.Red),
                        Tags = [SubtitleTag.Bold,SubtitleTag.Italic]
                    },
                    new DialogPart()
                    {
                        Text = "World!",
                        Font = new Font(color: Color.Blue, size: 30),
                        Tags = [SubtitleTag.Italic]
                    },
                }
            });
            subtitleHandler.AddDialog(new Dialog()
            {
                Start = start = start.Add(TimeSpan.FromSeconds(5)),
                End = start = start.Add(TimeSpan.FromSeconds(15)),
                Parts = new HashSet<DialogPart>()
                {
                    new DialogPart()
                    {
                        Text = "This is the first test\n",
                        Font = new Font(color: Color.Blue, size: 30),
                        Tags = [SubtitleTag.Bold]
                    },
                    new DialogPart()
                    {
                        Text = "Of my new App, named",
                        Font = new Font(color: Color.Yellow, size: 25),
                        Tags = [SubtitleTag.Bold]
                    },
                    new DialogPart()
                    {
                        Text = "Subtitle",
                        Font = new Font(color: Color.IndianRed, size: 30),
                        Tags = [SubtitleTag.Bold,SubtitleTag.Underline]
                    }
                }
            });
            await subtitleHandler.SaveAsync(new StreamWriter("C:\\Users\\Home-PC\\Desktop\\output.srt"));
        }
    }
}
