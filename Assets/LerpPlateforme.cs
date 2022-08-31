using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpPlateforme : MonoBehaviour
{
    [SerializeField] Vector3 _destinationPosition;
    [SerializeField] float _movementDuration;

    //[SerializeField, Range(0, 1)] float t;

    Vector3 _initialPosition;
    float _initialTime;
    float _destinationTime;
    float _currentTime;
    bool _isReturn;

    private void Start()
    {
        _initialPosition = transform.position;
        _initialTime = Time.time;
        _destinationTime = _initialTime + _movementDuration;
        _isReturn = false;
    }

    private void Update()
    {
        _currentTime = Time.time;
        float t = (_currentTime - _initialTime) / _movementDuration;

        // ALLER
        if(_isReturn == false)
        {
            transform.position = Vector3.Lerp(_initialPosition, _destinationPosition, t);
        }
        else   // RETOUR
        {
            transform.position = Vector3.Lerp(_destinationPosition, _initialPosition, t);
        }
        // On a fini le mouvement
        if (_currentTime > _destinationTime)
        {
            Debug.Log("AH J'AI FINI");
            if (_isReturn)
            {
                _isReturn = false;
            }
            else
            {
                _isReturn = true;
            }
            // _isReturn = !_isReturn;
            _initialTime = Time.time;
            _destinationTime = _initialTime + _movementDuration;
        }

    }

    #region EDITOR

    private void Reset()
    {
        _movementDuration = 2f;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(_destinationPosition, 1f);
    }

    #endregion

}
