using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawner : Spawner // INHERITANCE
{        
    [SerializeField] 
    private int WaitingTime = 3;

    private bool isDelayOver;

    private void Start()
    {
        isDelayOver = true;
    }


    protected override void FixedUpdate() // POLYMORPHISM
    {
        if (!GameplayManager.Instance.GameOver && !isSpawned())
        {
            Spawn();
            StartCoroutine(DelaySpawning());
        }
    }

    IEnumerator DelaySpawning()
    {
        isDelayOver = false;
        yield return new WaitForSeconds(WaitingTime);
        isDelayOver = true;

    }

    public override bool isSpawned() // POLYMORPHISM
    {
        return !isDelayOver;
    }
}
