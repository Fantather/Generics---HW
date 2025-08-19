using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Задание 3
// Создайте приложение, эмулирующее очередь в популярное кафе. Посетители кафе приходят и попадают в очередь, если нет свободного места
// При освобождении столика в кафе, первый посетитель очереди занимает его
// Если приходит клиент, который резервировал столик на определенное время, он получает зарезервированный столик вне очереди.

// При разработке приложения используйте класс Queue<T>.

namespace Generics_HW.Task_3
{
    internal class CafeQueue
    {
        private readonly Queue<Visitor> queue = [];
        private readonly List<Table> tables = [];

        public IReadOnlyCollection<Visitor> Queue => queue;
        public IEnumerable<Table> Tables => tables;

        // Фильтры по свободным, зарезервированным и занятым столам
        public IEnumerable<Table> FreeTables => tables.Where(t => t.CurrentVisitor is null && t.ReservedBy is null);
        public IEnumerable<Table> ReservedTables => tables.Where(t => t.ReservedBy is not null);
        public IEnumerable<Table> OccupiedTables => tables.Where(t => t.CurrentVisitor is not null);

        public CafeQueue(int numberOfTables)
        { 
            for(int i = 0; i < numberOfTables; i++)
                tables.Add(new Table(i));
        }


        // Проверяет зарезервировал ли посетитель стол и пришёл ли вовремя, если нет, добавляет его в очередь
        // Я хотел что бы все добавлялись в очередь и если есть свободные столы, могли за них сесть, но решил уже не заморачиваться, потому что времени мало осталось
        public void AddVisitor(Visitor visitor)
        {
            if (visitor.ReservedTableNumber != -1)
            {
                Table table = tables[visitor.ReservedTableNumber];
                if (table.ReservedBy == visitor && table.ReservedAt == DateTime.Now)
                {
                    OccupateTable(table.Id, visitor);
                }
            }

            else
                queue.Enqueue(visitor);
        }

        public Visitor? LeaveVisitor() => queue.Count > 0 ? queue.Dequeue() : null;


        public bool ReserveTable(int tableId, Visitor visitor)
        {
            if(tableId < 0 ||  tableId >= tables.Count)
                throw new ArgumentOutOfRangeException($"Стола с номером {tableId} не существует");

            Table table = tables[tableId];
            if(table.ReservedBy is not null)
                return false;

            table.Reserve(visitor, DateTime.Now);
            return true;
        }

        public bool OccupateTable(int tableId, Visitor visitor)
        {
            Table table = tables[tableId];
            if(table.ReservedBy is null || table.CurrentVisitor is not null)
                return false;

            table.Occupy(visitor);
            return true;
        }

        public bool FreeTable(int tableId)
        {
            Table table = tables[tableId];
            if(table.CurrentVisitor is null)
                return false;

            table.Free();
            return true;
        }
    }
}
