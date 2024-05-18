using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float velocityMove;
    PlayerInput input;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        input = GetComponent<PlayerInput>();
        input.OnMove += (direction) => Move(direction);
    }

    void Move(Vector3 direction)
    {
        
            direction = SetDirectionMove(direction) * velocityMove;
            direction.y = rb.velocity.y;

            rb.velocity = direction;
        
    }

    Vector3 SetDirectionMove(Vector3 dir)
    {
        CamDirection.cam.SetDirectionCam();
        
        dir = dir.x * CamDirection.cam.rightCam + dir.z * CamDirection.cam.fordwardCam;
        dir = dir.normalized;
        return dir;
    }
}
