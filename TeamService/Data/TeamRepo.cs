using System;
using System.Collections.Generic;
using System.Linq;
using TeamService.Models;

namespace TeamService.Data
{
    public class TeamRepo : ITeamRepo
    {
        private readonly AppDbContext _context;

        public TeamRepo(AppDbContext context)
        {
            _context = context;
        }

        public void CreateTeam(Team plat)
        {
            if(plat == null)
            {
                throw new ArgumentNullException(nameof(plat));
            }

            _context.Teams.Add(plat);
        }

        public IEnumerable<Team> GetAllTeams()
        {
            return _context.Teams.ToList();
        }

        public Team GetTeamById(int id)
        {
            return _context.Teams.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}