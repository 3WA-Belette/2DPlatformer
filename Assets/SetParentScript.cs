using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetParentScript : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {

        collision.attachedRigidbody.transform.SetParent(transform);

    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        collision.attachedRigidbody.transform.SetParent(null);

    }

}
