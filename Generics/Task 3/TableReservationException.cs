using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics_HW.Task_3
{
    internal class TableReservationException(string message, int tableId) : Exception(message)
    {
        public int TableId { get; } = tableId;
    }
}
