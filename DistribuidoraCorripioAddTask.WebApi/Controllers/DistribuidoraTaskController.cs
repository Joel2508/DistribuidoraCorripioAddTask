using DistribuidoraCorripioAddTask.WebApi.Data.Entities;
using DistribuidoraCorripioAddTask.WebApi.Helper;
using DistribuidoraCorripioAddTask.WebApi.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DistribuidoraCorripioAddTask.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DistribuidoraTaskController : ControllerBase
    {
        private readonly ITaskHelper _taskHelper;

        public DistribuidoraTaskController(ITaskHelper taskHelper)
        {
            _taskHelper = taskHelper;
        }

        [HttpGet]
        [Route("GetTask")]
        public async Task<IActionResult> GetTask()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ResponseModel
                {
                    IsSucces = false,
                    Message = "Error",
                    Result = null
                });
            }
            return Ok(await _taskHelper.GetTaskAsync());
        }


        [HttpPost]
        [Route("PostTask")]
        public async Task<IActionResult> PostTask(TaskEntity model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ResponseModel
                {
                    IsSucces = false,
                    Message = "Error",
                    Result = null,
                });
            }

            var response = await _taskHelper.PostTaskAsync(model);
            return Ok(response);
        }


        [HttpDelete]
        [Route("DeleteTask")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            return Ok(await _taskHelper.DeleteTaskAsync(id));
        }

        [HttpPut]
        [Route("PutTask")]
        public async Task<IActionResult> PutTask(TaskEntity model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ResponseModel
                {
                    IsSucces = false,
                    Message = "Error",
                    Result = null                     
                });
            }
            var response = await _taskHelper.PutTaskAsync(model);
            return Ok(response);
        }
    }
}
