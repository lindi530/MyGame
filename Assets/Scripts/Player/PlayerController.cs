using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 velocity = Vector3.zero;
    private Vector3 direction = Vector3.zero;
    private Vector3 rotatey, rotatex;
    private float weaponRotationTotal = 0f;
    
    [SerializeField] private GameObject weapon;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Camera cam;
    [SerializeField] private float weaponRotationLimit = 80f;
    
    void Start()
    {
    }

    public void Move(Vector3 _velocity)
    {
        velocity = _velocity;
    }

    public void Rotate(Vector3 _rotatey, Vector3 _rotatex)
    {
        rotatey = _rotatey;
        rotatex = _rotatex;
    }

    private void PerformMovement()
    {
        if (velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
    }
    
    private void PerformRotation()
    {
        if (rotatey != Vector3.zero)
        {
            rb.transform.Rotate(rotatey);
        }

        if (rotatex != Vector3.zero)
        {
            weaponRotationTotal += rotatex.x;
            weaponRotationTotal = Mathf.Clamp(weaponRotationTotal, -weaponRotationLimit, weaponRotationLimit);
            weapon.transform.localEulerAngles = new Vector3(weaponRotationTotal, 0f, 0f);
        }
    }
    
    void FixedUpdate()
    {
        PerformMovement();
        PerformRotation();
    }
}
