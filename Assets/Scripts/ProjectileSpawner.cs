using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : Spawner
{
    [SerializeField]
    private GameObject[] m_ProjectilePrefabs;
    [SerializeField]
    private static GameObject SpawnedProjectile;

    private int n;

    public static Rigidbody GetSpawnedProjectile()
    {
        if (SpawnedProjectile != null)
            return SpawnedProjectile.GetComponent<Rigidbody>();
        return null;
    }

    protected void Start()
    {
        n = 0;
        Spawn(ref SpawnedProjectile);
    }

    protected override void FixedUpdate()
    {
        if (Input.anyKeyDown && SpawnedProjectile != null)
        {
            if (isProjectileChanged() && !isProjectileLaunched())
            {
                Destroy(SpawnedProjectile);
                Spawn(ref SpawnedProjectile);
            }
        }
        else
        {
            Spawn(ref SpawnedProjectile);
        }
    }

    private bool isProjectileChanged() // ABSTRACTION
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

    private bool isProjectileLaunched()
    {
        return SpawnedProjectile.GetComponent<Rigidbody>().isKinematic == false;
    }

    public override bool isSpawned()
    {
        return SpawnedProjectile != null;
    }
}
