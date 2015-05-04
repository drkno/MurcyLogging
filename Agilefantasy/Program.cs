using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

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
                var backlogs = await client.GetBacklogs(7);
                Console.WriteLine("Got {0} backlogs", backlogs.Length);

                Console.WriteLine("Attempting to get times for user Jay in sprint 2...");
                var time = await client.GetTime(1, 7, 14, 69);
                Console.WriteLine("Got {0} total hours", time.TotalHours);

                Console.WriteLine("Attempting to get sprints...");
                var sprints = await client.GetSprints();
                Console.WriteLine("Got {0} sprints", sprints.Length);
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
