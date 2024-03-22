using ChestSystem.StateMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChestSystem.Chest
{
    public class EmptyState<T> : IState where T : ChestController
    {
        public ChestController Owner { get; set; }
        private GenericStateMachine<T> stateMachine;
        public EmptyState(GenericStateMachine<T> stateMachine) => this.stateMachine = stateMachine;
        public void OnStateEnter()
        {
            Owner.ShowEmptySlot(true);
        }

        public void OnStateExit()
        {
            Owner.ShowEmptySlot(false);
        }

        public void Update()
        {
           
        }
    }
}
