using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using To_Do_List_Jagdeep.Models;

namespace To_Do_List_Jagdeep.Context_File
{
    public class TodoListContext : DbContext
    {
        public TodoListContext()
        {
        }

        public TodoListContext(DbContextOptions<TodoListContext> options) : base(options)
        { }

        public DbSet<TodoItem> TodoLists { get; set; }

    }
}
