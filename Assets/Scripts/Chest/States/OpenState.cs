using ChestSystem.StateMachine;
using ChestSystem.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChestSystem.Chest
{
    public class OpenState<T> : IState where T : ChestController
    {
        public ChestController Owner { get; set; }
        private GenericStateMachine<T> stateMachine;
        public OpenState(GenericStateMachine<T> stateMachine) => this.stateMachine = stateMachine;
        public void OnStateEnter()
        {
            Owner.SetStatusText(GlobalConstant.TEXT_OPEN);
        }

        public void OnStateExit()
        {
           
        }

        public void Update()
        {
           
        }
    }
}
