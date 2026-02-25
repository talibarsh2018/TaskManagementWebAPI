using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagementAPI.Data;
using TaskManagementAPI.Models;

namespace TaskManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        public TasksController(AppDbContext context)
        {
            _appDbContext = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tasks = await _appDbContext.Tasks.ToListAsync();
            return Ok(tasks);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskItem task)
        {
            _appDbContext.Tasks.Add(task);
            await _appDbContext.SaveChangesAsync();
            return Ok(task);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, [FromBody] TaskItem updatedTask)
        {
            if (id != updatedTask.Id)
            {
                return BadRequest("Task ID mismatch.");
            }

            var record = await _appDbContext.Tasks.FindAsync(id);
            if (record == null)
            {
                return NotFound("Task not found.");
            }

            record.Title = updatedTask.Title;
            record.Description = updatedTask.Description;
            record.DueDate = updatedTask.DueDate;
            record.Status = updatedTask.Status;
            record.Remarks = updatedTask.Remarks;
            record.LastUpdatedOn = DateTime.Now;
            record.LastUpdatedBy = updatedTask.LastUpdatedBy;
            record.CreatedBy = updatedTask.CreatedBy;
            record.LastUpdatedBy = updatedTask.LastUpdatedBy;

            await _appDbContext.SaveChangesAsync();
            return Ok(record);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var task = await _appDbContext.Tasks.FindAsync(id);
            if (task == null)
            {
                return NotFound("Task not found.");
            }

            _appDbContext.Tasks.Remove(task);
            await _appDbContext.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search(string keyword)
        {
            var tasks = await _appDbContext.Tasks
                .Where(t =>
                    (t.Title != null && t.Title.Contains(keyword)) ||
                    (t.Description != null && t.Description.Contains(keyword)) ||
                    (t.CreatedBy != null && t.CreatedBy.Contains(keyword)))
                .ToListAsync();

            return Ok(tasks);
        }

    }
}
