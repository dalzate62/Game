using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoobaPool : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;

    [SerializeField] private Queue<GameObject> _asteroidPool;

    [SerializeField] private int poolSize;

    [SerializeField] private bool _flag;

    #region UpdateMethods

    // Start is called before the first frame update

    void Start()
    {
        //poolSize = 5;
        _asteroidPool = new Queue<GameObject>();
        _asteroidPool.Clear();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(_enemyPrefab);
            _asteroidPool.Enqueue(obj);
            obj.SetActive(false);
            _flag = false;
        }

    }

    #endregion

    public GameObject GetEnemyInstance()
    {
        if (_asteroidPool.Count > 0)
        {
            GameObject obj = _asteroidPool.Dequeue();
            obj.SetActive(true);
            _flag = true;
            return obj;

        }
        else
        {
            //GameObject obj = Instantiate(_asteroidPrefab);
            return null;
        }
    }

    public void ReturnEnemyInstanceToPool(GameObject obj)
    {
        if (_asteroidPool.Count <= poolSize && _flag)
        {
            _asteroidPool.Enqueue(obj);
            obj.SetActive(false);
            _flag = false;
        }
    }
}
