using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField]
    private GameObject[] bricks;
    private float speed = 4;

    void FixedUpdate()
    {
        if (transform.position.z < -5)
            Destroy(gameObject);
        transform.Translate(Vector3.back * speed * Time.fixedDeltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            foreach (GameObject brick in bricks)
            {
                brick.GetComponent<Rigidbody>().isKinematic = false;
            }

            Destroy(gameObject, 1f);
        }
    }
}
