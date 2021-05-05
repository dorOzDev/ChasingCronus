using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Core
{
    class ObjectsPooling: MonoBehaviour
    {
        [SerializeField]
        private int initialAmountToPool;

        [SerializeField]
        private GameObject gameObjectPrefab;

        private Stack<GameObject> pooledObjects;


        private void Awake()
        {
            pooledObjects = new Stack<GameObject>();
            InstantiateObjects(initialAmountToPool);
        }

        private void InstantiateObjects(int amount)
        {
            GameObject temp;

            for (int i = 0; i < amount; ++i)
            {
                temp = Instantiate(gameObjectPrefab, transform);
                temp.SetActive(false);
                pooledObjects.Push(temp);
            }
        }

        public List<GameObject> GetGameObjects(int amount)
        {
            if(pooledObjects.Count < amount)
            {
                InstantiateObjects(amount);
            }

            List<GameObject> gameObjectList = new List<GameObject>();
            GameObject temp;

            for (int i = 0; i < amount; ++i)
            {
                temp = pooledObjects.Pop();
                gameObjectList.Add(temp);
            }

            return gameObjectList;
        }
    }
}
