using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.InputSystem.XR;
using UnityEngine.Windows.Speech;
using UnityEngine.InputSystem;


public class playercontroller : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float velRotacion;
    [SerializeField] private float jumpHeight;
    [SerializeField] private float gravedad;
    [SerializeField] private float velBombastic;
    [SerializeField] float raycastDistance;
    [SerializeField] bool grounded;

    private CharacterController controller;
    private Vector3 velVertical;
    RaycastHit hit;
    Vector3 down;
    bool bombastic;
    float bombasticTime;
    
 

    void Start()
    {
        down = Vector3.down;
        bombastic = false;
    }
    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        MovimientoNormal();
        if(Input.GetKeyDown(KeyCode.E))
        {
            SaltoBoombastic();
        }
        grounded = controller.isGrounded;
        if(bombastic)
        {
            bombasticTime += Time.deltaTime;
        }
        if(bombasticTime >= 0.5f)
        {
            bombastic = false;
            bombasticTime = 0;
        }
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
    // ejecutar siempre o cuando estés en el suelo, según el comportamiento deseado
        if (!controller.isGrounded)
        {
        // opcional: hacia arriba en lugar de hacia abajo
            velVertical.y = -velBombastic;
            bombastic = true;

        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<keys>(out keys key) && bombastic == true)
        {
            key.addCharacter();
        }
    }

}
