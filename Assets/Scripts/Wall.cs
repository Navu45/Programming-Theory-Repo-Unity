using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField]
    private GameObject[] bricks;  
    [SerializeField]
    private float speed = 6;

    void FixedUpdate()
    {
        transform.Translate(Vector3.back * speed * Time.fixedDeltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            foreach(GameObject brick in bricks)
            {
                brick.GetComponent<Rigidbody>().isKinematic = false;
            }

            WallSpawner.isCreated = false;
            Destroy(gameObject, 0.3f);
        }
    }
}
