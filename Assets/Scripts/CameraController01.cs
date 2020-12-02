using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController01 : MonoBehaviour
{
    public GameObject playerCamera;
    public Vector3 posOffset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, playerCamera.transform.position + posOffset, 0.1f);
    }
}
