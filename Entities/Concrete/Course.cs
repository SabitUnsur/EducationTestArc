using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Course : IEntity
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public int InstructorId { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
