using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BulletJournal.Models.ViewModel
{
    public class ViewBjTodo
    {
        public string Worktitle { get; set; }
        public char Workrankid { get; set; }
        public char Iscompleted { get; set; }
        public string Targetdate { get; set; }
    }
}
