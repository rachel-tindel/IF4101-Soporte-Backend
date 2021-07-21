using System;
using System.Collections.Generic;

#nullable disable

namespace Soporte_HelpDesk.Models.Entities
{
    public partial class Supervisor
    {
        public Supervisor()
        {
            Supporters = new HashSet<Supporter>();
        }

        public int IdSupervisor { get; set; }
        public string DescriptionSupervisor { get; set; }
        public string NameSupervisor { get; set; }
        public string FirstSurnameSupervisor { get; set; }
        public string SecondSurnameSupervisor { get; set; }
        public string EmailSupervisor { get; set; }
        public int? IdNote { get; set; }
        public int? IdIssue { get; set; }
        public string Password { get; set; }

        public virtual Issue IdIssueNavigation { get; set; }
        public virtual Note IdNoteNavigation { get; set; }
        public virtual ICollection<Supporter> Supporters { get; set; }
    }
}
