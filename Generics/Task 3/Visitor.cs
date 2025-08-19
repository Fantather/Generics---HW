using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Generics_HW.Task_3
{
    internal class Visitor (string name, string surname, int tableNumber = -1)
    {
        public string Name { get; set; } = name;
        public string Surname { get; set; } = surname;
        public int ReservedTableNumber { get; set; } = tableNumber;
    }
}
