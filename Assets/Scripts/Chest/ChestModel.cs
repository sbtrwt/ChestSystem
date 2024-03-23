using System;
using UnityEngine;

namespace ChestSystem.Chest
{
    [Serializable]
    public class ChestModel
    {
        public ChestView ChestPrefab;
        public ChestSO ChestSO;
        public GameObject Parent;
        public ChestActionModel ChestActionModel;
    }
}
