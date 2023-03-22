using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity; 

namespace ProjectCRUDCodeFirstApproach.Models
{
    public class ServiceContext : DbContext
    {
        public DbSet<Todo> Todos { get; set; }
    }
}