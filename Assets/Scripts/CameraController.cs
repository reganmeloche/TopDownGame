using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;


    void Start()
    {
        var myVec = new Vector3(0, 0, 0); // can possibly remove this
        offset = transform.position - myVec;
        
    }

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
