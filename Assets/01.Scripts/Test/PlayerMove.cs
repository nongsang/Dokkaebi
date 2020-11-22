using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Player collider");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player Trigger");
    }
}
