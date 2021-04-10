using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FagElGamous.Models
{
    public partial class Photos
    {
        public int PhotoId { get; set; }
        public string Description { get; set; }
        public string Filestring { get; set; }
        public int? BurialId { get; set; }

        public virtual BurialRecords Burial { get; set; }
    }
}
