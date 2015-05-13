using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Agilefantasy.Common;

namespace Agilefantasy
{
    public class AgilefantClient
    {
        private readonly AgilefantSession _session;

        /// <summary>
        /// Creates a new Agilefant Client
        /// </summary>
        /// <param name="session"></param>
        public AgilefantClient(AgilefantSession session)
        {
            _session = session;
        }

        /// <summary>
        /// Gets a list of sprints for the current user
        /// </summary>
        /// <returns></returns>
        public Task<AgilefantSprintSummary[]> GetSprintSummaries(int backlogId)
        {
            return AgilefantSprintSummary.GetSprints(backlogId, _session);
        }

        /// <summary>
        /// Gets detail about a specific sprint.
        /// </summary>
        /// <param name="sprintId">Id of the sprint to get.</param>
        /// <returns>Sprint details.</returns>
        public Task<AgilefantSprint> GetSprint(int sprintId)
        {
            return AgilefantSprint.GetSprint(sprintId, _session);
        }

        /// <summary>
        /// Gets a list of agilefant users
        /// </summary>
        /// <returns></returns>
        public Task<AgilefantUser[]> GetUsers()
        {
            return AgilefantUser.GetAgilefantUsers(_session);
        }

        /// <summary>
        /// Gets a list of the backlogs for a team
        /// </summary>
        /// <param name="teamNumber"></param>
        /// <returns></returns>
        public Task<AgilefantBacklog[]> GetBacklogs(int teamNumber)
        {
            return AgilefantBacklog.GetAgilefantBacklogs(teamNumber, _session);
        }

        /// <summary>
        /// Gets the time for a user from a team on a backlog for a specific sprint
        /// </summary>
        /// <param name="teamNumber">The team id</param>
        /// <param name="backlogId">The backlog id</param>
        /// <param name="sprintId">The sprint id</param>
        /// <param name="userId">The user id</param>
        /// <returns>The times for the user</returns>
        public Task<AgilefantTime> GetTime(int teamNumber, int backlogId, int sprintId, int userId)
        {
            return AgilefantTime.GetTimes(teamNumber, backlogId, sprintId, userId, _session);
        }

        /// <summary>
        /// Logs time against a backlog item
        /// </summary>
        /// <param name="against">The item to log against</param>
        /// <param name="entryDate">The entry date</param>
        /// <param name="minutesSpent">The minutes spent</param>
        /// <param name="comment">A description of the work effort</param>
        /// <param name="users">The users to log for</param>
        public Task LogTime(IAgilefantLoggable against, DateTime entryDate, int minutesSpent, string comment, IEnumerable<AgilefantUser> users)
        {
            return AgilefantEffortEntry.LogTime(against, entryDate, minutesSpent, comment, users, _session);
        }

        /// <summary>
        /// Gets the effort entries for a backlog item
        /// </summary>
        /// <param name="from">The loggable to get times from</param>
        /// <returns>The effort entries for the task</returns>
        public Task<IEnumerable<AgilefantEffortEntry>> GetEffortEntries(IAgilefantLoggable from)
        {
            return AgilefantEffortEntry.GetEffortEntries(from, _session);
        }

        /// <summary>
        /// Updates an existing effort entry. It *must* have the correct id in order to do what you think
        /// it will
        /// </summary>
        /// <param name="update">The entry to update</param>
        public Task UpdateEffortEntry(AgilefantEffortEntry update)
        {
            return AgilefantEffortEntry.UpdateEffortEntry(update, _session);
        }
    }
}
