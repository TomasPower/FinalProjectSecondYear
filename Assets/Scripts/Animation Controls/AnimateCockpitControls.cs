using Sirenix.OdinInspector;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AnimateCockpitControls : MonoBehaviour
{
    [BoxGroup("FLight control transforms and ranges")] [Required][SerializeField]
    Transform _joystick;

    [BoxGroup("FLight control transforms and ranges")] [Required] [SerializeField]
    Vector3 _joystickRange = Vector3.zero;

    [BoxGroup("FLight control transforms and ranges")] [Required][SerializeField]
    List<Transform> _throttles;

    [BoxGroup("FLight control transforms and ranges")]  [Required] [SerializeField]

    float _throttleRange = 35f;

    [InlineEditor(InlineEditorObjectFieldModes.Boxed)]  [SerializeField] [Required]

    ShipMovementInput _movementInput;

    IMovementControls ControlInput => _movementInput.MovementControls;
    void Update()
    {
        _joystick.localRotation = Quaternion.Euler(
            ControlInput.PitchAmount * _joystickRange.x,
            ControlInput.YawAmount * _joystickRange.y,
            ControlInput.RollAmount * _joystickRange.z

            );

        Vector3 throttleRotation = _throttles[0].localRotation.eulerAngles;
        throttleRotation.x = ControlInput.ThrustAmount * _throttleRange;
        foreach(Transform throttle in _throttles)
        {
            throttle.localRotation = Quaternion.Euler(throttleRotation);
        }
    }
}
