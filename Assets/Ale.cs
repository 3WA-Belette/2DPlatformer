using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ale : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Methode 1 - Tag
        //if(collision.attachedRigidbody.gameObject.CompareTag("Player"))
        //{
        //    Debug.Log(" UN JOUEUR !");
        //}


        // Methode 2
        PlayerTag foundTag = collision.attachedRigidbody.GetComponent<PlayerTag>();
        if (foundTag != null)
        {
            Debug.Log("UN JOUEUR AGAIN !");
            GameObject.Destroy(gameObject);




        }

    }



}
