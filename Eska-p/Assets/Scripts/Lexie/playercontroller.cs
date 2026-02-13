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
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        movementDirection = new Vector3(hor * speed, 0.0f, ver * speed);
        transform.position += movementDirection * speed * Time.deltaTime;

    }

}
