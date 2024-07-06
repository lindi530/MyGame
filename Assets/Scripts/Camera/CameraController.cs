using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float creamerMovementSpeed = 10f;
    [SerializeField] private Camera cam;
    private Vector3 velocity = Vector3.zero;
    private float scroll = 0f;

    public void Move(Vector3 velocity)
    {
        this.velocity = velocity;
    }

    public void Field(float scroll)
    {
        this.scroll = scroll;
    }
    
    private void ModifyFieldOfView(float _scroll)
    {
        if (scroll != 0)
        {
            cam.fieldOfView = Mathf.Clamp(cam.fieldOfView - _scroll, 25, 90);
        }
    }

    private void CreamerMovement(Vector3 _velocity)
    {
        if (_velocity != Vector3.zero)
        {
            cam.transform.position += _velocity * creamerMovementSpeed * Time.fixedDeltaTime;
        }
    }
    void FixedUpdate()
    {
        CreamerMovement(velocity);
        ModifyFieldOfView(scroll);
    }
}
