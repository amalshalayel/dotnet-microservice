using System.Collections.Generic;
using TeamService.Models;

namespace TeamService.Data
{
    public interface ITeamRepo
    {
        bool SaveChanges();

        IEnumerable<Team> GetAllTeams();
        Team GetTeamById(int id);
        void CreateTeam(Team plat);
    }
}