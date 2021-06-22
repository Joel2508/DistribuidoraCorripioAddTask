using DistribuidoraCorripioAddTask.WebApi.Data.Entities;
using DistribuidoraCorripioAddTask.WebApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DistribuidoraCorripioAddTask.WebApi.Helper
{
    public interface ITaskHelper
    {
        Task<ResponseModel> GetTaskAsync();
        Task<ResponseModel> PostTaskAsync(TaskEntity taskEntity);
        Task<ResponseModel> DeleteTaskAsync(int id);
        Task<ResponseModel> GetByIdTaskAsync(int id);
        Task<ResponseModel> PutTaskAsync(TaskEntity taskEntity);

    }
}
