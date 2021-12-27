using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectService.Data;
using ProjectService.Dtos;
using ProjectService.Models;
 

namespace ProjectService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectRepo _repository;
        private readonly IMapper _mapper;
 

        public ProjectsController(
            IProjectRepo repository, 
            IMapper mapper 
        )
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProjectReadDto>> GetProjects()
        {
            Console.WriteLine("--> Getting Projects....");

            var projectItem = _repository.GetAllProjects();

            return Ok(_mapper.Map<IEnumerable<ProjectReadDto>>(projectItem));
        }

        [HttpGet("{id}", Name = "GetProjectById")]
        public ActionResult<ProjectReadDto> GetProjectById(int id)
        {
            var projectItem = _repository.GetProjectById(id);
            if (projectItem != null)
            {
                return Ok(_mapper.Map<ProjectReadDto>(projectItem));
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<ProjectReadDto>> CreateProject(ProjectCreateDto projectCreateDto)
        {
            var projectModel = _mapper.Map<Project>(projectCreateDto);
            _repository.CreateProject(projectModel);
            _repository.SaveChanges();

            var projectReadDto = _mapper.Map<ProjectReadDto>(projectModel);

            // Send Sync Message
            try
            {
                //await _commandDataClient.SendProjectToCommand(projectReadDto);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"--> Could not send synchronously: {ex.Message}");
            }

            //Send Async Message
            try
            {
                var projectPublishedDto = _mapper.Map<ProjectPublishedDto>(projectReadDto);
                projectPublishedDto.Event = "Project_Published";
                //_messageBusClient.PublishNewProject(projectPublishedDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"--> Could not send asynchronously: {ex.Message}");
            }

            return CreatedAtRoute(nameof(GetProjectById), new { Id = projectReadDto.Id}, projectReadDto);
        }
    }
}