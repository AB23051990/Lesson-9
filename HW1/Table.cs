using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1
{
    public enum State
    {
        Free = 0,
        Booked = 1
    }
    public class Table
    {
        public State State { get; private set; }
        public int SeatsCount { get; }
        public int Id { get; }

        public Table(int id)
        {
            Id = id; //в учебном примере просто присвоим id при вызове
            State = State.Free; // новый стол всегда свободен
            SeatsCount = Random.Shared.Next(2, 5); //пусть количество мест за каждым столом будет случайным, от 2х до 5ти
        }
        public bool SetState(State state)
        {
            if (state == State)
                return false;

            State = state;
            return true;
        }
       
    }

}
