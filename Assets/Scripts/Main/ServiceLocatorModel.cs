using ChestSystem.Chest;
using ChestSystem.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChestSystem.Main
{
    [Serializable]
    public class ServiceLocatorModel
    {
        public ChestModel ChestModel;
        public UIModel UIModel;
    }
}