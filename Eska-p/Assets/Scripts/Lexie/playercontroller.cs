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
    [SerializeField] CollisionForTyping childCollision;
    [SerializeField] float sMouse = 800;
    private Vector3 keyInitialPosition;
    private CharacterController controller;
    public Vector3 velVertical;
    RaycastHit hit;
    Vector3 down;
    bool bombastic;
    float bombasticTime;
    Animator animator;
    
 

    void Start()
    {
        down = Vector3.down;
        bombastic = false;
        animator = transform.GetChild(5).gameObject.GetComponent<Animator>();
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
        float rx = Input.GetAxis("Mouse X") * sMouse * Time.deltaTime;
        transform.Rotate(0, rx, 0);
    }

    public Vector3 horizontalVelocity ;
    public void MovimientoNormal()
    {
        horizontalVelocity = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            horizontalVelocity += (transform.forward * speed);
            animator.SetBool("walk", true);
            //this.gameObject.transform.Translate(Vector3.forward * speed * Time.deltaTime);
            //controller.Move(transform.forward * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            //this.gameObject.transform.Translate(Vector3.back * speed * Time.deltaTime);
            //controller.Move(transform.forward * - speed * Time.deltaTime);
            horizontalVelocity -= (transform.forward * speed);
            animator.SetBool("walk", true);
        }
        if (Input.GetKey(KeyCode.A))
        {
           horizontalVelocity -= (transform.right * speed);
            animator.SetBool("walk", true);
        }
        if (Input.GetKey(KeyCode.D))
        {
            horizontalVelocity += (transform.right * speed);
            animator.SetBool("walk", true);
        }

        if(!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D))
        {
            animator.SetBool("walk", false);
        }

        if (controller.isGrounded)
        {
            velVertical.y = -2f;
            if (Input.GetButtonDown("Jump"))
            {
                velVertical.y = jumpHeight;
                CheckGrounded();
            }
        }

        velVertical.y += gravedad * Time.deltaTime;

        controller.Move((horizontalVelocity + velVertical) * Time.deltaTime);
        
    }

    void CheckGrounded()
    {
        while(!grounded)
        {
            continue;
        }
        if(bombastic)
        {
            animator.SetBool("bombasticJump", true);
        }
        else
        {
            animator.SetBool("jump", true);
        }
        StartCoroutine(JumpsFalse());
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

    public void SendChar(GameObject obj)
    {
        Debug.Log("Enviando caracter");
       if(obj.TryGetComponent<keys>(out keys key) && bombastic == true)
        {
            key.addCharacter();
            StartCoroutine(KeyActivated(obj));
            bombastic = false;
            bombasticTime = 0;
        } 
    }
    IEnumerator KeyActivated(GameObject key)
    {
        Vector3 original = key.transform.position;
        key.transform.position = original + Vector3.down * 0.7f;
        yield return new WaitForSeconds(1f);
        key.transform.position = original;
    }
    IEnumerator JumpsFalse()
    {
        yield return new WaitForSeconds(0.5f);
        animator.SetBool("bombasticJump", false);
        animator.SetBool("jump", false);
    }
    //void OnTriggerEnter(Collider other)
    //{
    //    if(other.TryGetComponent<keys>(out keys key) && bombastic == true)
    //    {
    //        key.addCharacter();
    //        bombastic = false;
    //        bombasticTime = 0;
//
    //    }
    //}

}
