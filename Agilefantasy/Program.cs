using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Agilefantasy.Common;

namespace Agilefantasy
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var task = RunTests();
            task.Wait();

#if DEBUG
            Console.ReadKey();
#endif
        }

        private static async Task PostTime()
        {
            throw new NotImplementedException();
            //AgilefantTask.AddTask(new AgilefantBacklog() {Id = 6}, )
        }

        private static async Task RunTests()
        {
            Console.Write("Enter username: ");
            var username = Console.ReadLine();

            Console.Write("Enter password: ");
            var password = Console.ReadLine();

            Console.WriteLine("Attempting to login...");
            try
            {
                var session = await AgilefantSession.Login(username, password);
                Console.WriteLine("Logged in successfully");

                var client = new AgilefantClient(session);

                Console.WriteLine("Attempting to get users..");
                var users = await client.GetUsers();
                Console.WriteLine("Got {0} users!", users.Length);

                Console.WriteLine("Attempting to get backlogs for team 1...");
                var backlogs = await client.GetBacklogs(1);
                Console.WriteLine("Got {0} backlogs", backlogs.Length);

                Console.WriteLine("Attempting to get times for user Jay in sprint 2...");
                var time = await client.GetTime(1, 7, 14, 69);
                Console.WriteLine("Got {0} total hours", time.TotalHours);

                Console.WriteLine("Attempting to get sprints...");
                var sprints = await client.GetSprintSummaries(7);
                Console.WriteLine("Got {0} sprints", sprints.Length);

                Console.WriteLine("Attempting to get sprint details...");
                var sprint = await client.GetSprint(14);
                Console.WriteLine("Got sprint \"{0}\", with {1} stories and {2} tasks on first story.", sprint.Name,
                    sprint.RankedStories.Length, sprint.RankedStories[0].Tasks.Length);

                Console.WriteLine("Attempting to post a 1 hour task to story 1115");
                await AgilefantEffortEntry.LogTime(1115, DateTime.Now - TimeSpan.FromSeconds(20), 60, "A magical", new[] {69,73}, session);
                Console.WriteLine("Done?");

                Console.WriteLine("Getting effort entries for task 1115");
                var entries = await AgilefantEffortEntry.GetEffortEntries(1115, session);
                Console.WriteLine("Got {0} entries!", entries.Count());

                Console.WriteLine("Attempting to update effort entry 3407");
                var entry = new AgilefantEffortEntry(3407, DateTime.Now, 120, "A less magical description", 69);
                await client.UpdateEffortEntry(entry);
                Console.WriteLine("Updated (probably)");

                session.Logout();
            }
            catch (WebException e)
            {
                Console.WriteLine("Failed because of the internet! :'(");
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed (here comes the stack trace..)");
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
        }
    }
}
