using System;
using System.Collections.Generic;

#nullable disable

namespace Soporte_HelpDesk.Models.Entities
{
    public partial class Issue
    {
        public Issue()
        {
            Supervisors = new HashSet<Supervisor>();
            Supporters = new HashSet<Supporter>();
        }

        public int IdIssue { get; set; }
        public string ReferenceIssue { get; set; }
        public string ClassificationIssue { get; set; }
        public string StatusIssue { get; set; }
        public DateTime IssueTimesTamp { get; set; }
        public string ResolutionCommentIssue { get; set; }
        public int? IdNote { get; set; }
        public int? IdService { get; set; }

        public virtual Note IdNoteNavigation { get; set; }
        public virtual Servicee IdServiceNavigation { get; set; }
        public virtual ICollection<Supervisor> Supervisors { get; set; }
        public virtual ICollection<Supporter> Supporters { get; set; }
    }
}
