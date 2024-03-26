using ChestSystem.Event;
using ChestSystem.Main;
using ChestSystem.StateMachine;
using ChestSystem.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChestSystem.Chest
{
    public class ChestActionController
    {
        private ChestActionModel chestActionModel;
        private ChestActionView chestActionView;
        private EventService eventService;
        private ChestController chestController;
        private ChestService chestService;
        private PlayerService playerService;
        private UIService uIService;
        public ChestActionController(ChestActionModel model, EventService eventService, ChestService chestService, PlayerService playerService, UIService uiService)
        {
            this.eventService = eventService;
            this.chestService = chestService;
            this.playerService = playerService;
            this.uIService = uiService;
            chestActionModel = model;
            InitView();
            if (model?.Parent)
            { SetParent(model.Parent); }

            SubscriveEvent();

        }

        private void SubscriveEvent()
        {
            eventService.OnOpenChestAction.AddListener(OnOpenChestAction);
        }
        private void InitView()
        {
            chestActionView = Object.Instantiate(chestActionModel.ChestActionPrefab);
            chestActionView.SetController(this);
        }
        public void SetParent(GameObject parent)
        {
            chestActionModel.Parent = parent;
            chestActionView.SetParent(parent);
        }
        public void ShowChestActionView(bool isShow)
        {
            chestActionView.gameObject.SetActive(isShow);
        }

        public void OnStartTimer()
        {
            if (chestController?.GetCurrentState() == States.LOCKED)
            { chestController?.StartChestTimer(); }
            OnClose();
        }
        public void OnOpenNow()
        {
            

            if (playerService.Gems >= chestController.GemsRequired)
            {
                playerService.AddGem(-chestController.GemsRequired);
                chestController.SetChestOpen();
            }
            else
            {
                uIService.SetMessageText(GlobalConstant.TEXT_NOGEMS);
            }
            OnClose();
        }
        public void OnClose()
        {
            this.chestController = null;
            ShowChestActionView(false);
        }
        public void OnOpenChestAction(ChestController chestController)
        {
            this.chestController = chestController;
            ShowChestActionView(true);

            States state = chestController.GetCurrentState();
            switch (state)
            {
                case States.LOCKED:
                    chestActionView.ShowChestAction(true);
                    chestActionView.ShowChestCollection(false);
                    break;
                case States.OPEN:
                    chestActionView.ShowChestAction(false);
                    chestActionView.ShowChestCollection(true);
                    OnCollection();
                    this.chestService.ReturnChestToPool(chestController);
                    break;
            }
        }
        private void OnCollection()
        {
            ChestController.Reward reward = chestController.GetReward();
            playerService.AddGold(reward.Gold);
            playerService.AddGem(reward.Gem);
            chestActionView.SetCollectionText($"You got {reward.Gold} gold and {reward.Gem} gem.");
        }


        ~ChestActionController()
        {
            eventService.OnOpenChestAction.RemoveListener(OnOpenChestAction);
        }
    }
}
