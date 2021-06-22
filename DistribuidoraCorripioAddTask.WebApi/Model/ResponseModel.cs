using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DistribuidoraCorripioAddTask.WebApi.Model
{
    public class ResponseModel
    {
        public string Message { get; set; }
        public bool IsSucces { get; set; }
        public object Result { get; set; }
    }
}
