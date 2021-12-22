using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CompositionRoot
{
    public class CompositionRootMain : MonoBehaviour
    {
        private void Awake()
        {
            GameObject undestructableObject = new GameObject("NeededDataHolder");
            GameObject.DontDestroyOnLoad(undestructableObject);

            ConsistentDataHolder consistentDataHolder = new ConsistentDataHolder(undestructableObject);
        }
    }
}
