using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BulletJournal.Models.ViewModel
{
    public class ViewBjWorktarget
    {
        public string Target { get; set; }
        public string Targetdescription { get; set; }
        public string Targetdate { get; set; }
        public IList<ViewBjTodo> Todos { get; set; }
    }
}
