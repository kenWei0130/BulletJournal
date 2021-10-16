using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BulletJournal.Models.ViewModel
{
    public class ViewBjtodoDetail
    {
        public int Id { get; set; }
        public string Worktitle { get; set; }
        public string Description { get; set; }
        public char Workrankid { get; set; }
        public char Iscompleted { get; set; }
        public string Targetdate { get; set; }
        public int? Worktargetid { get; set; }
    }
}
