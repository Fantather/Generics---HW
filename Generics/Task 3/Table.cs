using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics_HW.Task_3
{
    internal class Table(int tableNumber)
    {
        public int Id { get; set; } = tableNumber;

        public Visitor? CurrentVisitor { get; private set; } = null;
        public Visitor? ReservedBy { get; private set; } = null;
        public DateTime? ReservedAt { get; private set; } = null;

        public void Occupy(Visitor currentVisitor)
        {
            if (CurrentVisitor != null)
            {
                throw new TableReservationException($"Стол {Id} уже занят", Id);
            }
            
            CurrentVisitor = currentVisitor;
        }

        public void Reserve(Visitor reservedBy, DateTime reservedAt)
        {
            if (reservedAt < DateTime.Now)
                throw new ArgumentOutOfRangeException($"Дата резервации {reservedAt} раньше текущего времени");

            ReservedBy = reservedBy;
            ReservedAt = reservedAt;
        }

        public void Free()
        {
            ReservedBy = null;
        }

        public void CancelReservation()
        {
            ReservedBy = null;
            ReservedAt = null;
        }
    }
}
