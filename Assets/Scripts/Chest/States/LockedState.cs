using ChestSystem.StateMachine;
using ChestSystem.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ChestSystem.Chest
{
    public class LockedState<T> : IState where T : ChestController
    {
        public ChestController Owner { get; set; }
        private GenericStateMachine<T> stateMachine;
        public LockedState(GenericStateMachine<T> stateMachine) => this.stateMachine = stateMachine;
        public void OnStateEnter()
        {
            Owner.ShowChestSlot(true);
            Owner.SetStatusText(GlobalConstant.TEXT_LOCKED);
            Owner.SetGemText(Owner.GetGemText(Owner.ChestModel.ChestSO.OpenTime));
            Owner.SetTimerText(FormatTime(Owner.ChestModel.ChestSO.OpenTime));
            Owner.SetChestType(Owner.ChestModel.ChestSO.Type);
        }

        public void OnStateExit()
        {
           
        }

        public void Update()
        {
           
        }

        public string FormatTime(float timeInSeconds)
        {
            int minutes = Mathf.FloorToInt(timeInSeconds / 60);
            int seconds = Mathf.FloorToInt(timeInSeconds % 60);
            return string.Format("{0}:{1:D2}", minutes, seconds);
        }
    }
}
