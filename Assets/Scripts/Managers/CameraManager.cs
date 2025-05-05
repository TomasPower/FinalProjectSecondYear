using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    enum VirtualCameras
    {
        NoCamera = -1,
        CockpitCamera = 0,
        FollowCamera
        
    }
    [BoxGroup("Virtual cameras")] [SerializeField] [Required]
    List<GameObject> _virtualCameras;


    VirtualCameras CameraKeyPressed
    {
        get
        {
            for (int i = 0; 1 < _virtualCameras.Count; i++)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1 + i)) return (VirtualCameras)i;
            }

            return VirtualCameras.NoCamera;
        }
    }
    void Start()
    {
        SetActiveCamera(VirtualCameras.CockpitCamera);
    }

    void Update()
    {
        SetActiveCamera(CameraKeyPressed);
    }

    private void SetActiveCamera(VirtualCameras activeCamera)
    {
        if(activeCamera == VirtualCameras.NoCamera)
        {
            Debug.Log("No Camera");
            return;
        }
        foreach(GameObject cam in _virtualCameras)
        {
            cam.SetActive(cam.tag.Equals(activeCamera.ToString()));
        }

    }

    
}
