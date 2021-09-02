using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner: MonoBehaviour
{
    [SerializeField]
    private Vector3 position;

    [SerializeField]
    protected GameObject prefab;

    [SerializeField]
    protected GameObject SpawnedObj;

    public virtual void Spawn()
    {
        SpawnedObj = Instantiate(prefab, position, Quaternion.identity);
        SpawnedObj.SetActive(true);
    }

    public bool isSpawned()
    {
        return SpawnedObj != null;
    }

    protected virtual void FixedUpdate()
    {
        if (!isSpawned())
        {
            Spawn();
        }
    }
}
