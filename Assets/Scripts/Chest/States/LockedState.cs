﻿using ChestSystem.StateMachine;
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
            Owner.SetGemText(Owner.GetGemText(Owner.ChestModel.ChestSO.openTime));
            Owner.SetTimerText(FormatTime(Owner.ChestModel.ChestSO.openTime));
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
            return string.Format("{0}:{1:D2}s", minutes, seconds);
        }
    }
}
