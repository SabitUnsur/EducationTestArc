using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class QuizContent : IEntity
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public string Question { get; set; }// ? array olabilir.
        public string Answer { get; set; }// ? array olabilir.
    }
}
