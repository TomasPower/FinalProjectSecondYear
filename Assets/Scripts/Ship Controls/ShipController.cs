using UnityEngine;
using Sirenix.OdinInspector;

public class ShipController : MonoBehaviour
{
    [InlineEditor(InlineEditorObjectFieldModes.Boxed)]
    [SerializeField][Required] ShipMovementInput _movementInput;
    
   
    [BoxGroup("Ship movement values")]
    [SerializeField]
    [Range(1000f, 15000f)]
    float _thrustForce = 15000f,
        _pitchForce = 6000f,
        _rollForce = 1000f,
        _yawForce = 2000f;

    Rigidbody _rigidbody;
    [ShowInInspector]
    [Range(-1f, 1f)]

    float _thrustAmount, _pitchAmount, _rollAmount, _yawAmount = 0f;

    IMovementControls ControlInput => _movementInput.MovementControls;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

     void Update()
    {
        _thrustAmount = ControlInput.ThrustAmount;
        _rollAmount = ControlInput.RollAmount;
        _yawAmount = ControlInput.YawAmount;
        _pitchAmount = ControlInput.PitchAmount;

    }

    private void FixedUpdate()
    {
        if (!Mathf.Approximately(0f, _pitchAmount))
        {
            _rigidbody.AddTorque(transform.right * (_pitchForce * _pitchAmount * Time.fixedDeltaTime));
        }

        if (!Mathf.Approximately(0f, _rollAmount))
        {
            _rigidbody.AddTorque(transform.forward * (_rollForce * _rollAmount * Time.fixedDeltaTime));
        }

        if (!Mathf.Approximately(0f, _yawAmount))
        {
            _rigidbody.AddTorque(transform.up * (_yawForce * _yawAmount * Time.fixedDeltaTime));
        }

        if (!Mathf.Approximately(0f, _thrustAmount))
        {
            _rigidbody.AddForce(transform.forward * (_thrustForce * _thrustAmount * Time.fixedDeltaTime));
        }
    }

}
