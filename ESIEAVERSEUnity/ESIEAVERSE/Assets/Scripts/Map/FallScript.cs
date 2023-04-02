using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallScript : MonoBehaviour
{
    public GameObject SpawnPoint;

    void OnTriggerEnter( Collider Col ) // Get Player Back to SpawnPoint
    {
        Col.transform.position = SpawnPoint.transform.position;
    }
}
