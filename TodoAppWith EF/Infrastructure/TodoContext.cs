using Microsoft.EntityFrameworkCore;
using TodoAppWith_EF.Models;

namespace TodoAppWith_EF.Infrastructure
{
    public class TodoContext: DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options) : base(options)
        {
        }
        //write your model tables here, note that table name convention should end with "s" eg TodoLists
        public DbSet<TodoList> TodoLists { get; set; }
    }
}
