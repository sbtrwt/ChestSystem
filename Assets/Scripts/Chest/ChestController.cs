using ChestSystem.StateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ChestSystem.Chest
{
    public class ChestController
    {
        protected ChestModel chestModel;
        protected ChestView chestView;

        protected ChestState currentState;
        protected ChestStateMachine stateMachine;
        public ChestController(ChestModel model)
        {
            chestModel = model;
            InitView();
            if (model?.Parent)
            { SetParent(model.Parent); }
            CreateStateMachine();
            stateMachine.ChangeState(States.EMPTY);
        }
        private void CreateStateMachine() => stateMachine = new ChestStateMachine(this);
        private void InitView()
        {
            chestView = Object.Instantiate(chestModel.ChestPrefab);
            chestView.SetController(this);
        }
        public void SetParent(GameObject parent)
        {
            chestModel.Parent = parent;
            chestView.SetParent(parent);
        }
        public void SetState(ChestState stateToSet) => currentState = stateToSet;
        public void ShowEmptySlot(bool isShow)
        {
            chestView.ShowEmptySlot(isShow);
        }
        public void ShowChestSlot(bool isShow)
        {
            chestView.ShowChestSlot(isShow);
        }
        public void ResetChest()
        {
            stateMachine.ChangeState(States.EMPTY);
        }
        public void SetChest()
        {
            stateMachine.ChangeState(States.LOCKED);
        }
        public enum ChestState
        {
            ACTIVE,
            DEACTIVE
        }
    }
}