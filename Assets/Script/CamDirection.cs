using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamDirection : MonoBehaviour
{
    public Vector3 fordwardCam;
    public Vector3 rightCam;
    static public CamDirection cam;

    void Start()
    {
        cam = this;
    }

    public void SetDirectionCam()
    {
        fordwardCam = transform.forward;
        rightCam = transform.right;

        fordwardCam.y = 0;
        rightCam.y = 0;

        fordwardCam = fordwardCam.normalized;
        rightCam = rightCam.normalized;
    }
}
