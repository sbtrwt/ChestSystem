using ChestSystem.StateMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ChestSystem.Chest
{
    public class UnLockingState<T> : IState where T : ChestController
    {
        public ChestController Owner { get; set; }
        private GenericStateMachine<T> stateMachine;
        private float unlockingTime = 0;
        public UnLockingState(GenericStateMachine<T> stateMachine) => this.stateMachine = stateMachine;
        public void OnStateEnter()
        {
            unlockingTime = Owner.UnlockingTime;
            Owner.SetStatusText("");
        }

        public void OnStateExit()
        {
            unlockingTime = 0;
        }

        public void Update()
        {
            unlockingTime -= Time.deltaTime;

            Owner.SetTimerText(FormatTime(unlockingTime));
            Owner.SetGemText(Owner.GetGemText(unlockingTime));
            if (unlockingTime <= 0)
            {
                Owner.DecreaseUnlockingCounter();
                Owner.SetTimerText("");
                Owner.SetChestOpen();
            }
        }

        public string FormatTime(float timeInSeconds)
        {
            int minutes = Mathf.FloorToInt(timeInSeconds / 60);
            int seconds = Mathf.FloorToInt(timeInSeconds % 60);
            return string.Format("{0}:{1:D2}", minutes, seconds);
        }

       
    }
}
