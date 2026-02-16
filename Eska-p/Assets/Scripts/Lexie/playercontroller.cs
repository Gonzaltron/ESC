using UnityEngine;
using System.Collections.Generic;
using System.Collections;


public class playercontroller : MonoBehaviour
{
    [SerializeField] private float speed;
    private Vector3 movementDirection;
    private Vector3 moveVel;
    private Rigidbody rb;
    private bool onground = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        float sal = Input.GetAxis("Jump");

        movementDirection = new Vector3(hor * speed, sal * speed, ver * speed);
        transform.position += movementDirection * speed * Time.deltaTime;

    }


}
