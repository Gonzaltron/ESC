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
    [SerializeField] float raycastDistance;
    [SerializeField] bool grounded;

    private CharacterController controller;
    private Vector3 velVertical;
    RaycastHit hit;
    Vector3 down;
    
 

    void Start()
    {
        down = Vector3.down;
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

        // dibuja el rayo con longitud para verlo en la escena
        Debug.DrawRay(transform.position, down, Color.green, 1f);
        Debug.Log($"SaltoBoombastic fired, grounded={controller.isGrounded}");

        if (Physics.Raycast(transform.position, down, out hit, jumpHeight))
        {
            Debug.Log($"raycast hit {hit.collider.name}");
            keys key = hit.collider.gameObject.GetComponent<keys>();
            if (key != null)
            {
                Debug.Log("hit key component");
                key.addCharacter();          // aquí debería aparecer "manda"
            }
            else
            {
                Debug.Log("No keys component found on collider or parents");
            }
        }
        else
        {
            Debug.Log("raycast missed");
        }
    }
}

}
