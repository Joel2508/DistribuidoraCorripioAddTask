using DistribuidoraCorripioAddTask.WebApi.Data;
using DistribuidoraCorripioAddTask.WebApi.Data.Entities;
using DistribuidoraCorripioAddTask.WebApi.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DistribuidoraCorripioAddTask.WebApi.Helper
{
    public class TaskHelper : ITaskHelper
    {
        private readonly DataContext _dataContext;

        public TaskHelper(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<ResponseModel> DeleteTaskAsync(int id)
        {
            var task = await _dataContext.TaskEntities.FindAsync(id);

            if (task == null)
            {
                return new ResponseModel
                {
                    IsSucces = false,
                    Message = "Esta tarea no existe",
                    Result = null
                };
            }

            _dataContext.TaskEntities.Remove(task);
            await _dataContext.SaveChangesAsync();
            return new ResponseModel
            {
                IsSucces = true,
                Message = $"El elemento {task.TaskDescription} ha sido eliminada",
                Result = null
            };
        }

        public async Task<ResponseModel> GetByIdTaskAsync(int id)
        {
            var task = await _dataContext.TaskEntities.FirstOrDefaultAsync(t => t.Id == id);

            if (task == null)
            {
                return new ResponseModel
                {
                    IsSucces = false,
                    Message = "Este registro no se encuentra",
                    Result = task
                };
            }

            return new ResponseModel
            {
                IsSucces = true,
                Message = "Ok",
                Result = task
            };
        }

        public async Task<ResponseModel> GetTaskAsync()
        {
            return new ResponseModel
            {
                IsSucces = true,
                Message ="Ok",
                Result = await _dataContext.TaskEntities.ToListAsync()
            };
        }

        public async Task<ResponseModel> PostTaskAsync(TaskEntity taskEntity)
        {
            _dataContext.TaskEntities.Add(taskEntity);
            await _dataContext.SaveChangesAsync();
            return new ResponseModel
            {
                IsSucces = true,
                Message = "Se registro esta tarea",
                Result = null,
            };
        }

        public async Task<ResponseModel> PutTaskAsync(TaskEntity taskEntity)
        {
            var taskUpdate = await _dataContext.TaskEntities.FirstOrDefaultAsync(t => t.Id == taskEntity.Id);

            if (taskUpdate == null)
            {
                return new ResponseModel
                {
                    IsSucces = false,
                    Message = "No se pudo actualizar esta tarea.",
                    Result = null
                };
            }
            
            taskUpdate.TaskDescription = taskEntity.TaskDescription;

            _dataContext.TaskEntities.Update(taskUpdate);
            await _dataContext.SaveChangesAsync();

            return new ResponseModel
            {
                IsSucces = true,
                Message = "Se actualizo esta tarea",
                Result = null
            };
        }
    }
}
