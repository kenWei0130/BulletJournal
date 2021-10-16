using System;
using System.Collections.Generic;

#nullable disable

namespace BulletJournal.Models.DAO
{
    public partial class BjTodo
    {
        public int Id { get; set; }
        public string Worktitle { get; set; }
        public string Description { get; set; }
        public char Workrankid { get; set; }
        public char Iscompleted { get; set; }
        public string Createdate { get; set; }
        public string Targetdate { get; set; }
        public int? Worktargetid { get; set; }
    }
}
