using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.InputSystem.XR;
using UnityEngine.Windows.Speech;


public class playercontroller : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float fCaida;
    [SerializeField] private float arribaTime;
    [SerializeField] private float velRotacion;
    [SerializeField] private float Force;
    private Rigidbody rb;
    private CharacterController controller;
    
 

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        MovimientoNormal();
    }

    
    public void MovimientoNormal()
    {
        if (Input.GetKey(KeyCode.W))
        {
            //this.gameObject.transform.Translate(Vector3.forward * speed * Time.deltaTime);
            controller.Move(transform.forward * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            //this.gameObject.transform.Translate(Vector3.back * speed * Time.deltaTime);
            controller.Move(transform.forward * - speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            this.gameObject.transform.Rotate(Vector3.down * velRotacion * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.gameObject.transform.Rotate(Vector3.up * velRotacion * Time.deltaTime);
        }
        

    }

    public void SaltoBoombastic()
    {
        if (Input.GetKey(KeyCode.E))
        {
            controller.Move(transform.up * speed * Time.deltaTime);

        }
    }

}
