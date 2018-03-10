using System;
namespace AppGregariaApi.Models
{
    public class Event
    {
        public Event(){ }

        public Event(string name, DateTime date)
        {
            Name = name;
            Date = date;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
    }
}
