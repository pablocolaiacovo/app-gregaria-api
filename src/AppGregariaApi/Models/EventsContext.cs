using System;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace AppGregariaApi.Models
{
    public class EventsContext : DbContext
    {
        public EventsContext(DbContextOptions<EventsContext> options) : base(options)
        {
        }

        public DbSet<Event> Events { get; set; }
    }
}
