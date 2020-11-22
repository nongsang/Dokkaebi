using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private ObjectInteraction _objectInteraction = null;

    private void FixedUpdate()
    {
        Vector3 origin = transform.position + new Vector3(0.0f, 0.9f, 0.0f);

        RaycastHit hit;

        int _layerMask = 1 << LayerMask.NameToLayer("Interactive");
        if (Physics.Raycast(origin, transform.forward, out hit, 3.0f, _layerMask))
        {
            if (!_objectInteraction)
            {
                _objectInteraction = hit.collider.GetComponent<ObjectInteraction>();
            }
        }
        else
        {
            _objectInteraction = null;
        }
    }

    public void Active()
    {
        if(_objectInteraction)
        {
            _objectInteraction.isActive = true;
        }
    }
}
