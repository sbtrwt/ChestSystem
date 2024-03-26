using System;
using System.Collections.Generic;
using UnityEngine;

namespace ChestSystem.Chest
{
    [Serializable]
    public class ChestModel
    {
        public ChestView ChestPrefab;
        public ChestSO ChestSO;
        public List<ChestSO> AllChestSO;
        public GameObject Parent;
        public ChestActionModel ChestActionModel;
        public int MaxUnlockingChestCount;
    }
}
