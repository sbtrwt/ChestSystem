using ChestSystem.Event;
using ChestSystem.StateMachine;
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
        public ChestActionController(ChestActionModel model, EventService eventService, ChestService chestService, PlayerService playerService)
        {
            this.eventService = eventService;
            this.chestService = chestService;
            this.playerService = playerService;
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

        public void OnStartTimer() {
            if (chestController?.GetCurrentState() == States.LOCKED)
            { chestController?.StartChestTimer(); }
            OnClose(); 
        }
        public void OnOpenNow() { eventService.OnOpenNow.InvokeEvent(); }
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
                   chestActionView. ShowChestAction(true);
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
            playerService.AddGold(500);
            playerService.AddGem(3);
        }

      
        ~ChestActionController()
        {
            eventService.OnOpenChestAction.RemoveListener(OnOpenChestAction);
        }
    }
}
