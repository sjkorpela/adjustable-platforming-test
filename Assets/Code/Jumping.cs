using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour
{
    private InputHandler _input = null;
    private Rigidbody2D _reggie = null;

    public enum JumpType
    {
        basicImpulse,
        basicForce,
        holdingImpulse,
        holdingForce,
        disabled
    }

    public bool _grounded = false;

    [Header ("Jump Settings")]
    [SerializeField] public JumpType _jumpType = JumpType.basicImpulse;
    [SerializeField] public float _maxHeight = 3f;
    [SerializeField] public float _minHeight = 1f;
    [SerializeField] public float _maxJumps = 2f;
    [SerializeField] public float _jumpSpeed = 3f;



    void Awake()
    {
        _input = GetComponent<InputHandler>();
        _reggie = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        if (_input._jumpInput && _grounded)
        {
            switch (_jumpType)
            {
                case JumpType.basicImpulse:
                {
                    _reggie.AddForce(transform.up * _maxHeight, ForceMode2D.Impulse);
                    _grounded = false;
                    return;
                }
                case JumpType.basicForce:
                {
                    _reggie.AddForce(transform.up * _maxHeight, ForceMode2D.Force);
                    _grounded = false;
                    return;
                }
                case JumpType.holdingImpulse:
                {
                    return;
                }
                case JumpType.holdingForce:
                {
                    return;
                }
                case JumpType.disabled:
                {
                    return;
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        _grounded = true;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        _grounded = false;
    }
}
