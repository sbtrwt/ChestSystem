﻿using ChestSystem.Chest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChestSystem.StateMachine
{

    public class GenericStateMachine<T> where T : ChestController
    {
        protected T Owner;
        protected IState currentState;
        protected Dictionary<States, IState> States = new Dictionary<States, IState>();

        public GenericStateMachine(T Owner) => this.Owner = Owner;

        public void Update() => currentState?.Update();

        protected void ChangeState(IState newState)
        {
            currentState?.OnStateExit();
            currentState = newState;
            currentState?.OnStateEnter();
        }

        public void ChangeState(States newState) => ChangeState(States[newState]);

        protected void SetOwner()
        {
            foreach (IState state in States.Values)
            {
                state.Owner = Owner;
            }
        }
    }
}
