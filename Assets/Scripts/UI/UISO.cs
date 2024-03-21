using UnityEngine;

namespace ChestSystem.UI
{
    [CreateAssetMenu(fileName = "New UI", menuName = "UI")]
    public class UISO : ScriptableObject
    {
        public int ID;
        public PlayerUIView PlayerUIView;
    }
}
