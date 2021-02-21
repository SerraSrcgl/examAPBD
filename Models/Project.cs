using System;
using System.Collections.Generic;

#nullable disable

namespace exam.Models
{
    public partial class Project
    {
        public Project()
        {
            TaskType = new HashSet<Task>();
            TeamMember = new HashSet<TeamMember>();
        }

        public int IdTeam { get; set; }
        public string Name { get; set; }
        public DateTime Deadline { get; set; }

        public virtual ICollection<Task> Task { get; set; }
        public virtual ICollection<TeamMember> TeamMembers { get; set; }
    }
}
