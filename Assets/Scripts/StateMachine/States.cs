using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChestSystem.StateMachine
{
    public enum States
    {
        EMPTY, 
        LOCKED,
        UNLOCKING,
        OPEN,
        COLLECTED
    }
}
