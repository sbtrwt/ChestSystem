using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ChestSystem.Chest
{
    public class ChestController
    {
        private ChestModel chestModel;
        private ChestView chestView;
        public ChestController(ChestModel model)
        {
            chestModel = model;
        }
        private void InitView()
        {
            chestView = Object.Instantiate(chestModel.ChestPrefab);
            chestView.SetController(this);
        }
    }
}