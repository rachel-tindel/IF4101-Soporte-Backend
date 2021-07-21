using System;
using System.Collections.Generic;

#nullable disable

namespace Soporte_HelpDesk.Models.Entities
{
    public partial class Supporter
    {
        public int IdSoporter { get; set; }
        public string NameSupporter { get; set; }
        public string FirstSurnameSupporter { get; set; }
        public string SecondSurnameSupporter { get; set; }
        public string EmailSupporter { get; set; }
        public int? IdService { get; set; }
        public int? IdSupervisor { get; set; }
        public int? IdIssue { get; set; }
        public int? IdNote { get; set; }
        public string Password { get; set; }

        public virtual Issue IdIssueNavigation { get; set; }
        public virtual Note IdNoteNavigation { get; set; }
        public virtual Servicee IdServiceNavigation { get; set; }
        public virtual Supervisor IdSupervisorNavigation { get; set; }
    }
}
