using ChestSystem.Event;
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

        protected States currentState;
        protected ChestStateMachine stateMachine;
        protected float unlockingTimeInSec;
        private EventService eventService;
        private ChestType chestType;
        private int gemsRequired;
        private float unlockingTime;
        private ChestService chestService;
        public ChestModel ChestModel { get { return chestModel; } }
        public int GemsRequired { get { return gemsRequired; } }
        public float UnlockingTime { get { return unlockingTime; } }
        public ChestController(ChestModel model, EventService eventService, ChestService chestService)
        {
            this.eventService = eventService;
            this.chestService = chestService;
            chestModel = model;
            chestModel.ChestSO = GetRandomChest();
            unlockingTime = chestModel.ChestSO.OpenTime;
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
        public void SetState(States stateToSet) => currentState = stateToSet;
        public void ShowEmptySlot(bool isShow) => chestView.ShowEmptySlot(isShow);

        public void ShowChestSlot(bool isShow) => chestView.ShowChestSlot(isShow);

        public void ShowGemSlot(bool isShow) => chestView.ShowGemSlot(isShow);

        public void ResetChest() => stateMachine.ChangeState(States.EMPTY);

        public void SetDefaultBackground() => chestView.SetDefaultBackground();


        public void SetChest()
        {
            stateMachine.ChangeState(States.LOCKED);
            chestModel.ChestSO = GetRandomChest();
        }

        public void StartChestTimer()
        {
            stateMachine.ChangeState(States.UNLOCKING);
        }

        public void SetChestOpen()
        {
            stateMachine.ChangeState(States.OPEN);
           
        }


        public void SetOpenBackground() => chestView.SetOpenBackground();


        public void SetTimerText(string text) => chestView.SetTimerText(text);

        public void SetStatusText(string text) => chestView.SetStatusText(text);

        public void SetGemText(string text) => chestView.SetGemText(text);

        public string GetGemText(float timeInSeconds)
        {
            unlockingTime = timeInSeconds;
            gemsRequired = Mathf.CeilToInt(timeInSeconds / 600);

            return string.Format("{0}", gemsRequired);
        }

        public void OpenChestActionPanel() => eventService.OnOpenChestAction.InvokeEvent(this);

        public virtual void UpdateChest() => stateMachine.Update();

        public States GetCurrentState() => currentState;

        public ChestType GetChestType() => chestType;
        public void SetChestType(ChestType chestType) => this.chestType = chestType;
        private ChestSO GetRandomChest()
        {
            int selectIndex = Random.Range(0, chestModel.AllChestSO.Count);
            return chestModel.AllChestSO[selectIndex];
        }
        public Reward GetReward()
        {
            Reward reward = new Reward
            {
                Gold = Random.Range(chestModel.ChestSO.MinGold, chestModel.ChestSO.MaxGold),
                Gem = Random.Range(chestModel.ChestSO.MinGem, chestModel.ChestSO.MaxGem)
            };
            return reward;
        }
        public void DecreaseUnlockingCounter()
        {
            chestService.DecreaseUnlockingChest();
        }

        public struct Reward
        {
            public int Gold;
            public int Gem;
        }
    }
}