using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject m_WallPrefab;
    [SerializeField]
    private Vector3 m_Position;
    [SerializeField]
    public static bool isCreated = false;

    void Update()
    {
        if (!isCreated)
        {
            isCreated = true;
            Instantiate(m_WallPrefab, m_Position, Quaternion.identity);
        }
    }
}
