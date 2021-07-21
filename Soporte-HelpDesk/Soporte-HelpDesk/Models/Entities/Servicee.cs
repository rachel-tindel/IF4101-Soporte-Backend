using System;
using System.Collections.Generic;

#nullable disable

namespace Soporte_HelpDesk.Models.Entities
{
    public partial class Servicee
    {
        public Servicee()
        {
            Issues = new HashSet<Issue>();
        }

        public int IdService { get; set; }
        public string NameService { get; set; }

        public virtual ICollection<Issue> Issues { get; set; }
    }
}
