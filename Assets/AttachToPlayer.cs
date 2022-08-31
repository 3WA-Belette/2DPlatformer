using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachToPlayer : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerTag myPlayer = collision.attachedRigidbody.GetComponent<PlayerTag>();
        if(myPlayer != null)
        {
            collision.attachedRigidbody.transform.SetParent(transform);
            Debug.Log("Cher joueur je suis ton père");
        }
        else
        {
            Debug.Log($"J'ignore {collision.attachedRigidbody.name}");
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        Debug.Log("Je suis encore la");

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.attachedRigidbody.transform.SetParent(null);
    }
}
