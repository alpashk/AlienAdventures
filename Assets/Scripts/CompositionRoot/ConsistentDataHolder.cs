using UnityEngine;

namespace CompositionRoot
{
    internal class ConsistentDataHolder
    {
        private static ConsistentDataHolder instance;

        public static ConsistentDataHolder Instance => instance;

        private GameObject undestructableObject;

        public GameObject UndestructableObject => undestructableObject;

        public ConsistentDataHolder(GameObject gameObject)
        {
            undestructableObject = gameObject;
            
            instance = this;
        }
    }
}