using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreOverview.Models
{
    public class Student
    {
        public string StudentId { get; set; }
        public string Name { get; set; }
        public Sex Sex { get; set; }
        public Teacher Teacher { get; set; }
        public string TeacherId { get; set; }
    }

    public enum Sex
    {
        Girl,
        Boy
    }
}
