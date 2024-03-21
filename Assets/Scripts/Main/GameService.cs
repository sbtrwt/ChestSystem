using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChestSystem.Main
{
    public class GameService : MonoBehaviour
    {
        private ServiceLocator serviceLocator;
        [SerializeField] private ServiceLocatorModel ServiceLocatorModel;
        private void Start()
        {
            serviceLocator = new ServiceLocator(ServiceLocatorModel);
            serviceLocator.Start();
        }

    }
}