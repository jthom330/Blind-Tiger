using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{

    [Header("Cameras")] 
    
    public CinemachineVirtualCamera poker;
    public CinemachineVirtualCamera slots;
    public CinemachineVirtualCamera blackJack;
    
    //TODO: Remove after figuring out head shake 
    public bool moving;

    private CinemachineVirtualCamera[] _cameraCollection;
    private void Start()
    {
        _cameraCollection = new CinemachineVirtualCamera[] { poker, slots, blackJack };
    }

    public void ChangeView(CinemachineVirtualCamera newView)
    {
        newView.Priority = 1;

        foreach (var cam in _cameraCollection)
        {
            //TODO: can wait and disable, if we need better performance
            cam.Priority = 0;
        }
    }
}