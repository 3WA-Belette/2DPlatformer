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
    [SerializeField] float _movingThreshold;

    [SerializeField] Animator _animator;

    Vector2 _playerMovement;

#if UNITY_EDITOR
    private void Reset()
    {
        _root = transform.parent;
        _speed = 2f;
        _movingThreshold = 0.1f;
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
        // Movement
        Vector2 direction = new Vector2(_playerMovement.x, 0);
       _root.transform.Translate(direction * Time.fixedDeltaTime * _speed, Space.World);

        // Animator
        Debug.Log($"Magnitude : {direction.magnitude}");
        if(direction.magnitude > _movingThreshold)        // Si on est en train de bouger
        {
            _animator.SetBool("IsWalking", true);
        }
        else       // Sinon c'est que l'on ne bouge pas donc false
        {
            _animator.SetBool("IsWalking", false);
        }

        // Orientation
        if(direction.x > 0)     // Right
        {
            _root.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if(direction.x < 0)              // Left
        {
            _root.rotation = Quaternion.Euler(0, 180, 0);
        }

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
