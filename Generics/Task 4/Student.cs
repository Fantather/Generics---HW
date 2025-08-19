using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics_HW.Task_4
{
    internal class Student (int id, string name, string group)
    {
        public int Id { get; set; } = id;
        public string Name { get; set; } = name;
        public string Group { get; set; } = group;


        public override bool Equals(object? obj) => obj is Student s && s.Id == Id;
        public override int GetHashCode() => Id.GetHashCode();
        
        public void Change(Student student)
        {
            Name = student.Name;
            Group = student.Group;
        }
    }
}
