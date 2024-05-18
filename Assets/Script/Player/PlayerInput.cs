using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerInput : MonoBehaviour
{
    Vector3 directionMove;
    public Action<Vector3> OnMove;
    public Action OnShoot;

    void MoveInput()
    {
        Vector3 dir = new Vector3(Input.GetAxisRaw("Horizontal"),0,Input.GetAxisRaw("Vertical"));
        OnMove?.Invoke(dir);
    }

    void Rotate()
    {
        CamDirection.cam.SetDirectionCam();
        transform.rotation = Quaternion.LookRotation(CamDirection.cam.fordwardCam);
    }

    void InputShoot()
    {
        if(Input.GetMouseButtonDown(0))
        {
            OnShoot?.Invoke();
        }
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {

        Rotate();
        MoveInput();
        InputShoot();
    }
}
