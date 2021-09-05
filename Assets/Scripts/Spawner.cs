using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner: MonoBehaviour
{
    [SerializeField]
    private Vector3 position;

    [SerializeField]
    protected GameObject prefab;

    public virtual void Spawn()
    {
        if (!isSpawned())
        {
            Instantiate(prefab, position, Quaternion.identity);
        }
    }

    public virtual void Spawn(ref GameObject GameObjRef)
    {
        if (!isSpawned())
        {
            GameObjRef = Instantiate(prefab, position, Quaternion.identity);
        }
    }

    public abstract bool isSpawned();

    protected virtual void FixedUpdate()
    {
        Spawn();
    }
}
