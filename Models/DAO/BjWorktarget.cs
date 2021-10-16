using System;
using System.Collections.Generic;

#nullable disable

namespace BulletJournal.Models.DAO
{
    public partial class BjWorktarget
    {
        public int Id { get; set; }
        public string Target { get; set; }
        public string Targetdescription { get; set; }
        public string Targetdate { get; set; }
    }
}
