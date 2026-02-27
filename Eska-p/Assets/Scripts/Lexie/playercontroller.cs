using UnityEngine;
using System.Collections.Generic;
using System.Collections;


public class playercontroller : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float Gravity;
    [SerializeField] private float fCaida;
    [SerializeField] private float arribaTime;
    [SerializeField] private float velRotacion;
    

    private Vector3 movementDirection;
    private Vector3 moveVel;
    private Rigidbody rb;
    //private bool onground = false;
    private Vector3 velVertical;
    private CharacterController controlador;
    
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Awake()
    {
        controlador = GetComponent<CharacterController>();
    }

    void Update()
    {
        MovimientoNormal();
        //Gravedad();
        //SaltoBombastic();

    }

    
    public void MovimientoNormal()
    {
        //Teclas
        /*float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        float sal = Input.GetAxis("Jump");

        movementDirection = new Vector3(hor * speed, sal* speed, ver * speed);
        transform.position = movementDirection * speed * Time.deltaTime;
        controlador.Move(movementDirection);*/
        if (Input.GetKey(KeyCode.W))
        {
            //this.gameObject.transform.Translate(Vector3.forward * speed * Time.deltaTime);
            controlador.Move(transform.forward * speed * Time.deltaTime);
            Debug.Log("Alante");
        }
        if (Input.GetKey(KeyCode.S))
        {
            //this.gameObject.transform.Translate(Vector3.back * speed * Time.deltaTime);
            controlador.Move(transform.forward * - speed * Time.deltaTime);
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
    private void Gravedad()
    {
        velVertical.y += Gravity * Time.deltaTime;
        controlador.Move(velVertical * Time.deltaTime);
    }
    /*public IEnumerator SaltoBombastic()
    {
        
        if (Input.GetKeyDown(KeyCode.E) && !onground)
        {
            yield return new WaitForSeconds(arribaTime);
            rb.AddForce(Vector3.down * fCaida, ForceMode.Impulse);

        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        while (collision.gameObject.CompareTag("Ground"))
        {
            onground = true;
            Debug.Log("Esta en el suelo");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        while (collision.gameObject.CompareTag("Ground"))
        {
            onground = false;
            Debug.Log("Esta en el aire");

        }
    }*/

}
