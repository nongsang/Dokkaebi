using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stair : MonoBehaviour
{
    [SerializeField] private ObjectInteraction[] _events = null;
    [SerializeField] private GameObject[] Stairs = null;

    private void Start()
    {
        foreach(var elem in Stairs)
        {
            elem.SetActive(false);
        }

        StartCoroutine(Active());
    }

    IEnumerator Active()
    {
        foreach(var elem in _events)
        {
            yield return new WaitUntil(() => elem.isActive);
        }

        foreach (var elem in Stairs)
        {
            elem.SetActive(true);
        }
    }
}
