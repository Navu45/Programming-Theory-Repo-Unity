using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    [SerializeField] 
    private Rigidbody projectile;
    [SerializeField]
    private float speed = 10000f;
    [SerializeField]
    private bool isDelayOver;

    private float DelayTime;

    void Start()
    {
        isDelayOver = true;
        DelayTime = 1.5f;
    }

    void Update()
    {
        if (!GameplayManager.Instance.GameOver)
        {
            if (projectile == null)
            {
                projectile = ProjectileSpawner.GetSpawnedProjectile();
            }

            if (projectile != null && isDelayOver && Input.GetKeyDown(KeyCode.Space))
            {
                Launch();
                StartCoroutine(DelayLaunching());
            }
        }
        else
        {
            DropTheProjectile();
        }
    }

    IEnumerator DelayLaunching()
    {
        isDelayOver = false;
        yield return new WaitForSeconds(DelayTime);
        isDelayOver = true;
    }

    void Launch() // ABSTRACTION
    {
        projectile.isKinematic = false;
        projectile.useGravity = true;
        projectile.AddForce(new Vector3(0, 0.5f, 1) * speed, ForceMode.VelocityChange);
    }

    void DropTheProjectile() // ABSTRACTION
    {
        if (projectile != null)
        {
            projectile.isKinematic = false;
            projectile.useGravity = true;
        }
    }
}
