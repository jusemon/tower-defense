using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] bool canInstanciate = true;
    [SerializeField][Range(0, 50)] int poolSize = 5;
    [SerializeField][Range(0.1f, 30f)] float spawnTimer = 1f;

    GameObject[] pool;

    void Awake()
    {
        PopulatePool();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private void PopulatePool()
    {
        pool = new GameObject[poolSize];
        for (int index = 0; index < pool.Length; index++)
        {
            pool[index] = Instantiate(enemyPrefab, transform);
            pool[index].SetActive(false);
        }
    }

    void EnableObjectInPool()
    {
        for (int index = 0; index < poolSize; index++)
        {
            if (!pool[index].activeInHierarchy)
            {
                pool[index].SetActive(true);
                return;
            }
        }
    }

    IEnumerator SpawnEnemy()
    {
        while (canInstanciate)
        {
            EnableObjectInPool();
            yield return new WaitForSeconds(spawnTimer);
        }
    }

}
