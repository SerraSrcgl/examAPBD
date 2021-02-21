using exam.Models;
using Lab_09.DTOs;
using System;
using System.Linq;

namespace Lab_09.Services
{
    public class SqlArtistService : IArtistDbService
    {

        private readonly s19687Context _context;
        public SqlArtistService(s19687Context context)
        {
            _context = context;
        }

        public void AddArtist(AddArtistRequest request)
        {
            var task = _context.Tasks.Where(a => a.name.Equals(request.name)).FirstOrDefault();

            if (task != null)
            {
                Console.WriteLine("tasks already exists");
            }

            var newArtist = new TaskType
            {
                Name = request.Name
            };

            _context.Add(newTask);


            // deadline cant be pass not 
            var deadline = request.Deadline;

            if (deadline < DateTime.Now)
            {
                Console.WriteLine("deadline date can't be in the past");
            }

            

          var taskTypeId = newTask.idTaskType;
            var teamId = _context.Projects.Where(e => e.Name.Equals(request.Name) && e.deadline.Equals(request.deadline)).FirstOrDefault().IdTeam;

            var TaskType = _context.Tasks.Where(e => e.IdTeam == teamId && e.IdTaskType == taskTypeId).FirstOrDefault();

            if (teamId != null) 
            {
                Console.WriteLine("this task is already assigned to this team");
            }

            var newAssignToTeam = new Task
            {
                IdTaskType = taskTypeId,
                IdTask = taskId
            };

            _context.SaveChanges();
        }

    }
}
