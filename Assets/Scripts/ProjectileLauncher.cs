using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    [SerializeField]
    private GameObject[] projectiles;
    [SerializeField]
    private Rigidbody CurrentProjecile;
    private float speed = 10f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CurrentProjecile.isKinematic = false;
            CurrentProjecile.AddForce(Vector3.forward * speed, ForceMode.VelocityChange);
        }
    }
}
