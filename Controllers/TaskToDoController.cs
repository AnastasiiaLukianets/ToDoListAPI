using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoListAPI.Services;

namespace ToDoListAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskToDoController : ControllerBase
    {
        private readonly ITaskToDoService _taskToDoService;
        public TaskToDoController(ITaskToDoService taskToDoService)
        {
            _taskToDoService = taskToDoService;
        }

        [HttpGet]
        public async Task<ActionResult<List<TaskToDo>>> GetTasksToDo()
        {
            try
            {
                return Ok(await _taskToDoService.GetTasksToDo());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<TaskToDo>> GetTaskToDo(int id)
        {
            try
            {
                var result = await _taskToDoService.GetTaskToDo(id);

                if (result == null)
                {
                    return NotFound();
                }

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<List<TaskToDo>>> AddTaskToDo(TaskToDo task)
        {
            // new object return
            // 200 -> 201 status code
            try
            {
                if (task == null)
                {
                    return BadRequest();
                }

                var createdTaskToDo = await _taskToDoService.AddTaskToDo(task);

                return CreatedAtAction(nameof(GetTaskToDo),
                    new { Id = createdTaskToDo.Id}, createdTaskToDo);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new TaskToDo record");
            }
        }

        [HttpPut]
        public async Task<ActionResult<TaskToDo>> UpdateTaskToDo(TaskToDo request)
        {
            try 
            { 
                var taskToDoToUpdate = await _taskToDoService.GetTaskToDo(request.Id);

                if (taskToDoToUpdate == null)
                {
                    return NotFound($"TaskToDo with Id = {request.Id} not found");
                }

                return await _taskToDoService.UpdateTaskToDo(request);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TaskToDo>> Delete(int id)
        {
            try
            {
                var taskToDoToDelete = await _taskToDoService.GetTaskToDo(id);

                if (taskToDoToDelete == null)
                {
                    return NotFound($"TaskToDo with Id = {id} not found");
                }

                return await _taskToDoService.DeleteTaskToDo(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }
    }
}
