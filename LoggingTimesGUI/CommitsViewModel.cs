using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Text.RegularExpressions;
using LibGit2Sharp;

namespace LoggingTimesGUI
{
    public class CommitsViewModel
    {
        public ObservableCollection<LogMessage> LogMessages { get; set; }

        public CommitsViewModel()
        {
            LogMessages = new ObservableCollection<LogMessage>();
        }

        public void SetUp(string[] args)
        {
            var repo = new Repository(args[0]);

            var branchName = repo.Head.Name;
            var defaultStoryMatch = Regex.Match(branchName, @"^([0-9]+)(/|\\).*$");
            if (defaultStoryMatch.Success)
            {
                LogMessage.DefaultStoryNumber = int.Parse(defaultStoryMatch.Groups[1].Value);
            }
            else
            {
                LogMessage.DefaultStoryNumber = -1;
            }


            var ignored = new List<string>();
            if (File.Exists("ignored.ini"))
            {
                var streamReader = new StreamReader("ignored.ini");
                while (!streamReader.EndOfStream)
                {
                    var commitNumber = streamReader.ReadLine();
                    ignored.Add(commitNumber);
                }
                streamReader.Close();
            }
            var streamWriter = new StreamWriter("ignored.ini", true);
            for (var i = 1; i < args.Length; i++)
            {
                if (ignored.Contains(args[i]))
                {
                    //continue;
                }
                var commit = (Commit)repo.Lookup(args[i]);
                LogMessages.Add(new LogMessage(commit));
                streamWriter.WriteLine(args[i]);
            }
            streamWriter.Close();

            //LogMessages.();
        }

        public void Merge(LogMessage message1, LogMessage message2)
        {
            LogMessages.Remove(message1);
            LogMessages.Remove(message2);
            message1.Merge(message2);
            LogMessages.Add(message1);
        }
    }
}