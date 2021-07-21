using System;
using System.Collections.Generic;

#nullable disable

namespace Soporte_HelpDesk.Models.Entities
{
    public partial class Note
    {
        public Note()
        {
            Issues = new HashSet<Issue>();
            Supervisors = new HashSet<Supervisor>();
            Supporters = new HashSet<Supporter>();
        }

        public int IdNote { get; set; }
        public string DescriptionNote { get; set; }
        public DateTime NoteTimeTamp { get; set; }

        public virtual ICollection<Issue> Issues { get; set; }
        public virtual ICollection<Supervisor> Supervisors { get; set; }
        public virtual ICollection<Supporter> Supporters { get; set; }
    }
}
