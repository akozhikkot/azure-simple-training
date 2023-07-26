using Microsoft.EntityFrameworkCore;
using TodoApi.Data;
using TodoApi.Entity;
using TodoApi.Events;
using TodoApi.Messaging;

namespace TodoApi.Services
{
    public class TodoRepository
    {
        private readonly TodoDbContext _context;
        private readonly MessageSender _sender;
        public TodoRepository(TodoDbContext context, MessageSender sender)
        {
            _context = context;
            _sender = sender;
        }
        public IEnumerable<TodoItem> GetAll()
            => _context.TodoItems.AsNoTracking();
        public TodoItem? GetById(string id)
            => _context.TodoItems.AsNoTracking().FirstOrDefault(x => x.Id == id);
        public async Task Add(TodoItem item)
        {
            _context.TodoItems.Add(item);
            await _context.SaveChangesAsync();

            // Raise the event
            await _sender.Send(new TodoItemModifiedEvent(item.Id, true)); 
        }
        public async Task Update(TodoItem item)
        {
            TodoItem? todo = GetById(item.Id);

            if (todo != null)
            {
                todo.Title = item.Title;
                todo.Description = item.Description;
                todo.Completed = item.Completed;
                todo.DueBy = item.DueBy;

                _context.TodoItems.Update(item);
                await _context.SaveChangesAsync();

                // Raise the event
                await _sender.Send(new TodoItemModifiedEvent(item.Id, false));
            }
        }
    }
}
