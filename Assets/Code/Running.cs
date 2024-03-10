using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Running : MonoBehaviour
{
    private InputHandler _input = null;
    private Rigidbody2D _reggie = null;

    public enum RunType
    {
        basicImpulse,
        basicForce,
        disabled
    }



    [Header ("Jump Settings")]
    [SerializeField] public RunType _runType = RunType.basicForce;
    [SerializeField] public float _runSpeed = 3f;
    [Range(0f, 100f)]
    [SerializeField] public float _airControllability = 100f;




    void Awake()
    {
        _input = GetComponent<InputHandler>();
        _reggie = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        switch (_runType)
        {
            case RunType.basicImpulse:
            {
                _reggie.AddForce(new Vector2(_input._directionalInput.x, 0) * _runSpeed, ForceMode2D.Impulse);
                return;
            }
            case RunType.basicForce:
            {
                _reggie.AddForce(new Vector2(_input._directionalInput.x, 0) * _runSpeed, ForceMode2D.Force);
                return;
            }
            case RunType.disabled:
            {
                return;
            }
        }
    }
}
