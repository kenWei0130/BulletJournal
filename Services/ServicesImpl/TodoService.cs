using BulletJournal.Models;
using BulletJournal.Models.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BulletJournal.Services.ServicesImpl
{
    public class TodoService : ITodoService
    {
        private readonly MyPostgresContext _myPostgresContext;
        public TodoService(MyPostgresContext myPostgresContext)
        {
            _myPostgresContext = myPostgresContext;
        }

        public async Task<List<ViewBjTodo>> TodayTodoListAsync() => await _myPostgresContext.BjTodos
                .Where(bjtodo => bjtodo.Iscompleted == '0')
                .OrderBy(bjtodo => bjtodo.Targetdate)
                .ThenByDescending(bjtodo => bjtodo.Workrankid)
                .Join(_myPostgresContext.BjWorkranks,
                todo => todo.Workrankid, rank => rank.Id,
                (todo, rank) => new ViewBjTodo
                {
                    Id = todo.Id,
                    Worktitle = todo.Worktitle,
                    Workrank = rank.Rankname,
                    Iscompleted = todo.Iscompleted == '0' ? "N" : "Y",
                    Targetdate = todo.Targetdate
                })
                .ToListAsync();

        public async Task<ViewBjtodoDetail> TodoDetailAsync(int Id)
        {
            return await _myPostgresContext.BjTodos
                .Where(bjtodo => bjtodo.Id == Id)
                .Select(bjtodo => new ViewBjtodoDetail
                {
                    Id = bjtodo.Id,
                    Worktitle = bjtodo.Worktitle,
                    Description = bjtodo.Description,
                    Workrankid = bjtodo.Workrankid,
                    Iscompleted = bjtodo.Iscompleted,
                    Targetdate = bjtodo.Targetdate,
                    Worktargetid = bjtodo.Worktargetid
                })
                .FirstOrDefaultAsync();
        }

        
    }
}
