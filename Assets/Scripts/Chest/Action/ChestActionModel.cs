using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ChestSystem.Chest
{
    [Serializable]
    public class ChestActionModel
    {
        public ChestActionSO ChestActionSO;
        public ChestActionView ChestActionPrefab;
        public GameObject Parent;
    }
}
