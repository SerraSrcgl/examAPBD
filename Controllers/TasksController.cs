using exam.Models;
using Lab_09.DTOs;
using Lab_09.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace exam.Controllers
{
    [Route("api/tasks")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITasksDbService _service;

        public TasksController(ITasksDbService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult AddTask(AddNewTaskRequest request) 
        {
            _service.AddTask(request);

            var response = new AddNewTaskResponse();

            return Ok(response);
        }
    }
}
