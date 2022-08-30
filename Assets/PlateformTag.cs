using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateformTag : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rb;
    Vector3 _startPosition;

    // Start is called before the first frame update
    void Start()
    {
        _startPosition = transform.position;
    }

    public void Rollback()
    {
        _rb.gravityScale = 0;
        _rb.velocity = Vector3.zero;
        transform.position = _startPosition;
    }

}
