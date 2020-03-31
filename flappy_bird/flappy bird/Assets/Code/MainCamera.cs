using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public Transform targetTransform;
    public Transform cameraTransform;

    void Start()
    {
        targetTransform = GameObject.Find("Player").transform;
        cameraTransform = GetComponent<Transform>();
    }

    private void Update()
    {
        var position = cameraTransform.position;
        if (targetTransform != null)
        {
            cameraTransform.position = new Vector3(targetTransform.position.x, 
                position.y, position.z);   
        }
    }
}
