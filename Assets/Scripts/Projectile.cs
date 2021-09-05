using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private bool m_Success;
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject, 0.4f);
        if (!collision.gameObject.CompareTag("Ground"))
        {
            m_Success = true;
        }
    }

    private void OnDestroy()
    {
        if (m_Success)
            GameplayManager.Instance.AddPoint();
    }
}
