using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpPlateforme : MonoBehaviour
{
    [SerializeField] Vector3 _destinationPosition;
    [SerializeField] float _movementDuration;

    //[SerializeField, Range(0, 1)] float t;

    Vector3 _initialPosition;
    float _currentMovement;
    bool _isReturn;

    private void Start()
    {
        _initialPosition = transform.position;
        _isReturn = false;
        _currentMovement = 0;
    }

    private void Update()
    {
        // On rempli progressivement notre "sablier"
        _currentMovement += Time.deltaTime;

        // Dès que l'on dépasse la durée visée : on change de mode et on vide notre sablier
        if(_currentMovement >= _movementDuration)
        {
            _isReturn = !_isReturn;
            _currentMovement = 0;
        }
        // Progression du sablier (entre 0 et 1)
        float t = _currentMovement / _movementDuration;

        // ALLER
        if (_isReturn == false)
        {
            transform.position = Vector3.Lerp(_initialPosition, _destinationPosition, t);
        }
        else   // RETOUR
        {
            transform.position = Vector3.Lerp(_destinationPosition, _initialPosition, t);
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
