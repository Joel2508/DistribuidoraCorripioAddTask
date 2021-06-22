using DistribuidoraCorripioAddTask.WebApi.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DistribuidoraCorripioAddTask.WebApi.Data
{
    public class SeedDb
    {
        private readonly DataContext dataContext;

        public SeedDb(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task SeedAsync()
        {
            await dataContext.Database.EnsureCreatedAsync();

            await AddTask("Tarea 1");
            await AddTask("Tarea 2");
            await AddTask("Tarea 3");
            await AddTask("Tarea 4");
            await AddTask("Tarea 5");
        }

        private async Task AddTask(string task)
        {


            var taskEntity = await dataContext.TaskEntities.FirstOrDefaultAsync(t => t.TaskDescription == task);
            if (taskEntity == null)
            {
                var taskElement = new TaskEntity
                {
                    TaskDescription = task
                };
                dataContext.TaskEntities.Add(taskElement);
                await dataContext.SaveChangesAsync();
            }
        }
    }
}
