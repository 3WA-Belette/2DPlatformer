using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] InputActionReference _moveInput;
    [SerializeField] InputActionReference _jumpInput;

    [SerializeField] Transform _root;
    [SerializeField] float _speed;

    Vector2 _playerMovement;

#if UNITY_EDITOR
    private void Reset()
    {
        _root = transform.parent;
        _speed = 2f;
        Debug.Log("COUCOU L'EDITEUR");
    }
#endif

    void Start()
    {
        // Move
        _moveInput.action.started += StartMove;
        _moveInput.action.performed += UpdateMove;
        _moveInput.action.canceled += EndMove;
    }
    void FixedUpdate()
    {
        Debug.Log(_playerMovement);

        Vector2 direction = new Vector2(_playerMovement.x, 0);
       _root.transform.Translate(direction * Time.fixedDeltaTime * _speed);
    }


    void StartMove(InputAction.CallbackContext obj)
    {
        _playerMovement = obj.ReadValue<Vector2>();
        //Debug.Log($"Appelé ! {_playerMovement}");
    }
    void UpdateMove(InputAction.CallbackContext obj)
    {
        _playerMovement = obj.ReadValue<Vector2>();
        //Debug.Log($"Joystick UPDATE ! {_playerMovement}");
    }
    void EndMove(InputAction.CallbackContext obj)
    {
        _playerMovement = new Vector2(0, 0);
        //Debug.Log($"Joystick Annulé !");
    }
}
