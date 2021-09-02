using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : Spawner
{
    [SerializeField]
    private GameObject[] m_ProjectilePrefabs;
    private int n;

    protected void Start()
    {
        n = 0;
        Spawn();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        if (Input.anyKeyDown)
        {
            if (ChangedProjectile() && SpawnedObj.GetComponent<Rigidbody>().isKinematic != false)
            {
                Destroy(SpawnedObj);
                Spawn();
            }
        }
    }

    private bool ChangedProjectile() // ABSTRACTION
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            n = (n + 1) % 3;
            prefab = m_ProjectilePrefabs[n];
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            n = ((n - 1) % 3) < 0 ? 2 : (n - 1) % 3;
            prefab = m_ProjectilePrefabs[n];
        }
        else return false;
        return true;
    }
}
