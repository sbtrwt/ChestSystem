using ChestSystem.StateMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChestSystem.Chest
{
    public class ChestStateMachine : GenericStateMachine<ChestController>
    {
        public ChestStateMachine(ChestController Owner) : base(Owner)
        {
            this.Owner = Owner;
            CreateStates();
            SetOwner();
        }

        private void CreateStates()
        {
            States.Add(StateMachine.States.EMPTY, new EmptyState<ChestController>(this));
            States.Add(StateMachine.States.LOCKED, new LockedState<ChestController>(this));
            States.Add(StateMachine.States.UNLOCKING, new UnLockingState<ChestController>(this));
            States.Add(StateMachine.States.COLLECTED, new CollectedState<ChestController>(this));
        }
    }
}
