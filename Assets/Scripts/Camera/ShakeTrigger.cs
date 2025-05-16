using JetBrains.Annotations;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    
    public CameraShake cameraShake;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            StartCoroutine(cameraShake.Shake(.15f, .4f));
        }


    }
}
