using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlateform : MonoBehaviour
{

    [SerializeField] Rigidbody2D _rb;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _rb.gravityScale = 1;
    }



}
