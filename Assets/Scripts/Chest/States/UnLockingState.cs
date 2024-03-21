using ChestSystem.StateMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChestSystem.Chest
{
    public class UnLockingState<T> : IState where T : ChestController
    {
        public ChestController Owner { get; set; }
        private GenericStateMachine<T> stateMachine;
        public UnLockingState(GenericStateMachine<T> stateMachine) => this.stateMachine = stateMachine;
        public void OnStateEnter()
        {
            
        }

        public void OnStateExit()
        {
           
        }

        public void Update()
        {
           
        }
    }
}
