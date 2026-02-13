using UnityEngine;
using System.Collections.Generic;
using System.Collections;


public class playercontroller : MonoBehaviour
{
    [SerializeField] private float speed;
    private Vector3 movementDirection;
    private Vector3 moveVel;
    private Rigidbody rb;

    void Start()
    {
        
    }

    void Update()
    {
        float hor = Input.GetAxis("Horizontar");
        float ver = Input.GetAxis("Vertical");

        movementDirection = new Vector3(hor, 0f, ver);
        moveVel = transform.forward * speed * movementDirection.sqrMagnitude;

    }
    public void FixedUpdate()
    {
        rb.linearVelocity = moveVel;
        
    }
}
