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
            InitView();
            if (model?.Parent)
                SetParent(model.Parent);
        }
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
    }
}