using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TeamService.Data;
using TeamService.Dtos;
using TeamService.Models;
namespace TeamService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamRepo _repository;
       

        public TeamsController(ITeamRepo repository )
        {
            _repository = repository; 
        }

        [HttpGet]
        public ActionResult<IEnumerable<TeamReadDto>> GetTeams()
        {
            Console.WriteLine("--> Getting Teams....");

            var teamItem = _repository.GetAllTeams();

            return Ok(teamItem);
        }

        [HttpGet("{id}", Name = "GetTeamById")]
        public ActionResult<TeamReadDto> GetTeamById(int id)
        {
            var teamItem = _repository.GetTeamById(id);
            if (teamItem != null)
            {
                return Ok( teamItem);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<TeamReadDto>> CreateTeam(Team teamModel)
        { 
            _repository.CreateTeam(teamModel);
            _repository.SaveChanges();
             
            return CreatedAtRoute(nameof(GetTeamById), new { Id = teamModel.Id }, teamModel);
        }
    }
}