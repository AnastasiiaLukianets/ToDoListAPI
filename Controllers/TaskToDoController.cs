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
            return Ok(await _taskToDoService.TaskToDoRepository.GetTasksToDo());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<TaskToDo>> GetTaskToDo(int id)
        {
            var result = await _taskToDoService.TaskToDoRepository.GetTaskToDo(id);

            if (result == null)
            {
                return NotFound();
            }

            return result;
        }

        [HttpPost]
        public async Task<ActionResult<List<TaskToDo>>> AddTaskToDo(TaskToDo task)
        {
            if (task == null)
            {
                return BadRequest();
            }

            var createdTaskToDo = await _taskToDoService.TaskToDoRepository.AddTaskToDo(task);

            return CreatedAtAction(nameof(GetTaskToDo),
                new { Id = createdTaskToDo.Id}, createdTaskToDo);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<TaskToDo?>> UpdateTaskToDo(int id, TaskToDo request)
        { 
            if (id != request.Id)
            {
                return BadRequest("Task Id mismatch");
            }

            var taskToDoToUpdate = await _taskToDoService.TaskToDoRepository.GetTaskToDo(request.Id);

            if (taskToDoToUpdate == null)
            {
                return NotFound($"TaskToDo with Id = {request.Id} not found");
            }

            return await _taskToDoService.TaskToDoRepository.UpdateTaskToDo(request);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TaskToDo?>> Delete(int id)
        {
            var taskToDoToDelete = await _taskToDoService.TaskToDoRepository.GetTaskToDo(id);

            if (taskToDoToDelete == null)
            {
                return NotFound($"TaskToDo with Id = {id} not found");
            }

            return await _taskToDoService.TaskToDoRepository.DeleteTaskToDo(id);
        }
    }
}
