using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChestSystem.Chest
{
    public enum ChestType { None, Common, Rare, Epic, Legendary }
 
    [CreateAssetMenu(fileName = "New Chest", menuName = "Chest")]
    public class ChestSO
    {
        public int ID;
        public ChestType type;
        public Sprite icon;
        public float openTime;

    }
}
