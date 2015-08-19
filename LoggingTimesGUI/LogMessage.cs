using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using LibGit2Sharp;

namespace LoggingTimesGUI
{
        public class LogMessage : IComparable<LogMessage>
        {
            private double _time;
            public static int DefaultStoryNumber { get; set; }
            public int Story { get; set; }
            public string Message { get; set; }
            public List<string> Commits { get; set; }
            public List<string> Pairs { get; set; }

            public string Time
            {
                get { return _time.ToString(CultureInfo.InvariantCulture); }
                set { _time = double.Parse(value); }
            }

            public DateTimeOffset StartDate { get; set; }

            public LogMessage(Commit commit)
            {
                var message = commit.Message;
                var storyMatch = Regex.Match(message, @"story:(\s*)([0-9]+)");
                if (storyMatch.Success)
                {
                    var group = storyMatch.Groups[2];
                    Story = int.Parse(group.Value);
                    message = message.Remove(storyMatch.Index, storyMatch.Length);
                }
                else
                {
                    Story = DefaultStoryNumber;
                }

                Pairs = new List<string>();
                var pairsMatch = Regex.Match(message, @"#?((pair)|(peer))s?:?(\s)*\[([^\]]+)\]");
                if (pairsMatch.Success)
                {
                    var group = pairsMatch.Groups[5];
                    var pairSpl = group.Value.Split(',');
                    foreach (var s in pairSpl)
                    {
                        Pairs.Add(s.Trim());
                    }
                    message = message.Remove(pairsMatch.Index, pairsMatch.Length);
                }

                Commits = new List<string> {commit.Sha};
                StartDate = commit.Author.When;
                Message = "";
                var messageSpl = message.Split(new [] {"\r\n", "\r", "\n"}, StringSplitOptions.RemoveEmptyEntries);
                foreach (var s in messageSpl)
                {
                    var t = s.Trim();
                    if (string.IsNullOrWhiteSpace(t))
                    {
                        continue;
                    }
                    t = Regex.Replace(t, @"(?<=#)[A-Z]+", c => c.ToString().ToLower());
                    Message += t + " ";
                }

                _time = 0.2;
            }

            public int CompareTo(LogMessage other)
            {
                return StartDate.CompareTo(other.StartDate);
            }

            public override string ToString()
            {
                var str = Message;
                if (Pairs.Count > 0)
                {
                    var pairs = "#pair[" + string.Join(",", Pairs) + "] ";
                    str += pairs;
                }
                var commits = "#commits[" + string.Join(",", Commits) + "] ";
                str += commits;

                return str;
            }

            public void Merge(LogMessage message)
            {
                if (Story != message.Story && message.Story != -1 && Story != -1)
                {
                    throw new Exception("How the hell can you log something for two different stories in one go?");
                }

                if (Story == -1 && message.Story != -1)
                {
                    Story = message.Story;
                }

                _time += message._time;
                Message += message.Message;
                Commits.AddRange(message.Commits.Where(p2 => Commits.All(p1 => p1 != p2)));
                Pairs.AddRange(message.Pairs.Where(p2 => Pairs.All(p1 => p1 != p2)));
            }
        }
}