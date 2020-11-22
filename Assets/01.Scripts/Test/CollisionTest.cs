using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTest : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Cube Collision");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Cube Trigger");
    }
}
