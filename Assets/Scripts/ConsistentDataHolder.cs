using UnityEngine;

namespace CompositionRoot
{
    internal class ConsistentDataHolder
    {
        #region Singleton

        private static ConsistentDataHolder instance;

        public static ConsistentDataHolder Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ConsistentDataHolder();
                }

                return instance;
            }
        }

        public ConsistentDataHolder()
        {
            instance = this;
        }

        #endregion
        
        
    }
}