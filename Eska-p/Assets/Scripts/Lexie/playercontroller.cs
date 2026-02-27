using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.InputSystem.XR;


public class playercontroller : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float Gravity;
    [SerializeField] private float fCaida;
    [SerializeField] private float arribaTime;
    [SerializeField] private float velRotacion;
    private float distance;
    private int platLayer;
    

    private Vector3 movementDirection;
    private Vector3 moveVel;
    private Rigidbody rb;
    //private bool onground = false;
    private Vector3 velVertical;
    private CharacterController controller;
    private object player;
    
    
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        controller.detectCollisions = false;
        
    }

    void Update()
    {
        MovimientoNormal();
        //SaltoBombastic();

    }

    
    public void MovimientoNormal()
    {
        if (Input.GetKey(KeyCode.W))
        {
            //this.gameObject.transform.Translate(Vector3.forward * speed * Time.deltaTime);
            controller.Move(transform.forward * speed * Time.deltaTime);
            Debug.Log("Alante");
        }
        if (Input.GetKey(KeyCode.S))
        {
            //this.gameObject.transform.Translate(Vector3.back * speed * Time.deltaTime);
            controller.Move(transform.forward * - speed * Time.deltaTime);
            Debug.Log("Atrás");
        }
        if (Input.GetKey(KeyCode.A))
        {
            this.gameObject.transform.Rotate(Vector3.down * velRotacion * Time.deltaTime);
            Debug.Log("Izquierda");
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.gameObject.transform.Rotate(Vector3.up * velRotacion * Time.deltaTime);
            Debug.Log("Derecha");
        }

        
    }
    
    
    

}
