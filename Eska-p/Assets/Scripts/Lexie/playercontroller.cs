using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.InputSystem.XR;
using UnityEngine.Windows.Speech;


public class playercontroller : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float velRotacion;
    [SerializeField] private float jumpHeight;
    [SerializeField] private float gravedad;
    [SerializeField] private float velBombastic;

    private CharacterController controller;
    private Vector3 velVertical;
    
    
 

    void Start()
    {
        
    }
    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        MovimientoNormal();
        SaltoBoombastic();
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
        if (controller.isGrounded)
        {
            velVertical.y = -2f;
            if (Input.GetButtonDown("Jump"))
            {
                velVertical.y = jumpHeight;
            }
        }
        velVertical.y += gravedad * Time.deltaTime;
        controller.Move(velVertical * Time.deltaTime);
    }

    public void SaltoBoombastic()
    {
        if (!controller.isGrounded && Input.GetKeyDown(KeyCode.E))
        {
            velVertical.y = -velBombastic;
        }
    }

}
