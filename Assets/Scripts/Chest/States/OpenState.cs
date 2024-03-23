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
            Owner.SetOpenBackground();
            Owner.ShowGemSlot(false);
        }

        public void OnStateExit()
        {
            Owner.ShowChestSlot(false);
            Owner.SetDefaultBackground();
            Owner.ShowGemSlot(true);
        }

        public void Update()
        {
           
        }
    }
}
