using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BulletJournal.Models.ViewModel
{
    public class ViewBjTodo
    {
        public int Id { get; set; }
        [Display(Name = "項目")]
        public string Worktitle { get; set; }
        [Display(Name = "優先度")]
        public string Workrank { get; set; }
        [Display(Name = "完成")] 
        public string Iscompleted { get; set; }
        [Display(Name = "目標日期")]
        public string Targetdate { get; set; }
    }
}
