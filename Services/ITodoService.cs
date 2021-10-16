using BulletJournal.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BulletJournal.Services
{
    public interface ITodoService
    {
        public Task<List<ViewBjTodo>> TodayTodoListAsync();

        public Task<ViewBjtodoDetail> TodoDetailAsync(int Id);

    }
}
