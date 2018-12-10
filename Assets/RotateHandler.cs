using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateHandler : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.RotateAround(new Vector3(0f, 0.25f, 0),new Vector3(0,1,0), 1f);
    }
}