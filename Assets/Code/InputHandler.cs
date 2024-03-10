using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour {
    private PlayerControls _playerControls = null;      // PlayerControls Input Actions
    public Vector2 _directionalInput = Vector2.zero;    // Directional input, WASD by default
    public bool _jumpInput = false;                     // Jump input, space by default
    public bool _altInput = false;                      // Alternate input, LeftAlt by default



    /// <summary>
    /// Turns Input Actions Input Map Mappings into more easibly readable values.
    /// </summary>
    private void FixedUpdate()
    {
        _directionalInput = _playerControls.PlayerMap.Directional.ReadValue<Vector2>(); // Directional input to Vector2
        _jumpInput = _playerControls.PlayerMap.Jump.ReadValue<float>() > 0;             // Jump input to boolean
        _altInput = _playerControls.PlayerMap.Alternate.ReadValue<float>() > 0;        // Alt input to boolean
    }



    private void Awake()
    {
        _playerControls = new PlayerControls();
    }
    private void OnEnable()
    {
        _playerControls.PlayerMap.Enable();
    }
    private void OnDisable()
    {
        _playerControls.PlayerMap.Disable();
    }
}
