using System;
using System.Collections.Generic;

#nullable disable

namespace exam.Models
{
    public partial class Task
    {
        public int IdTask { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int IdTaskType { get; set; }
        public int IdTeam { get; set; }
        public DateTime Deadline { get; set; }

        public int idAssignedTo { get; set; }
        public int idCreator { get; set; }

        public virtual TaskType IdTaskNavigation { get; set; }
        public virtual Project IdTeamNavigation { get; set; }
    }
}
