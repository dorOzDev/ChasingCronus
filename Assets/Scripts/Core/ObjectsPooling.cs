using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Core
{
    [CreateAssetMenu(fileName = "Object pooling instance", menuName = "ScriptableObjects/Create object pooling instance")]
    class ObjectsPooling: ScriptableObject
    {
        [SerializeField]
        private int initialAmountToPool;

        [SerializeField]
        private GameObject inactiveCardsHolder;

        [SerializeField]
        private GameObject activeCardsHolder;

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

            for (int i = 0; i < initialAmountToPool; ++i)
            {
                temp = Instantiate(gameObjectPrefab, inactiveCardsHolder.transform);
                temp.transform.parent = inactiveCardsHolder.transform;
                temp.SetActive(false);
                pooledObjects.Push(temp.GetComponent<GameObject>());
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
                temp.transform.parent = activeCardsHolder.transform;
                gameObjectList.Add(temp);
            }

            return gameObjectList;
        }
    }
}
