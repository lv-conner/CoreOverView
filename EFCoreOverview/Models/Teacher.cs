using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreOverview.Models
{
    public class Teacher
    {
        public Teacher()
        {
            Students = new List<Student>();
        }
        public string TeacherId { get; set; }
        public string Name { get; set; }
        public Sex Sex { get; set; }
        public ICollection<Student> Students { get; protected set; }
    }
}
