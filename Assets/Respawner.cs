using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawner : MonoBehaviour
{

    [SerializeField] Transform _respawnPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // PlayerTag
        PlayerTag myTag = collision.attachedRigidbody.GetComponent<PlayerTag>();
        if(myTag != null)
        {
            collision.attachedRigidbody.transform.position = _respawnPoint.position;
        }

        // Respawntag
        PlateformTag myPlateformeTag = collision.attachedRigidbody.GetComponent<PlateformTag>();
        if (myPlateformeTag != null)
        {
            myPlateformeTag.Rollback();
        }

    }


}
