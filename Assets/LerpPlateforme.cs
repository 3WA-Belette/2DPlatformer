using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpPlateforme : MonoBehaviour
{
    [SerializeField] Vector3 _destinationPosition;
    [SerializeField, Range(0, 1)] float t;

    Vector3 _initialPosition;

    private void Start()
    {
        _initialPosition = transform.position;
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(_destinationPosition, 1f);
    }

    private void Update()
    {

        transform.position = Vector3.Lerp(_initialPosition, _destinationPosition, t);

    }




}
