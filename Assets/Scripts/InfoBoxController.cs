using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoBoxController : MonoBehaviour
{
    public Camera mainCam;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector3(1, 2, 0);
    }

    // Update is called once per frame
    void LateUpdate()
    {

    }
}
