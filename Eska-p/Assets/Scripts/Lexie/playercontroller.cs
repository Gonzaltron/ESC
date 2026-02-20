using UnityEngine;
using System.Collections.Generic;
using System.Collections;


public class playercontroller : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float Gravity;
    [SerializeField] private float fCaida;
    [SerializeField] private float arribaTime;


    private Vector3 movementDirection;
    private Vector3 moveVel;
    private Rigidbody rb;
    private bool onground = false;
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
        Gravedad();
        SaltoBombastic();

    }

    
    private void MovimientoNormal()
    {
        //Teclas
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        float sal = Input.GetAxis("Jump");

        movementDirection = new Vector3(hor * speed, sal* speed, ver * speed);
        transform.position = movementDirection * speed * Time.deltaTime;
        controlador.Move(movementDirection);
    }
    private void Gravedad()
    {
        velVertical.y += Gravity * Time.deltaTime;
        controlador.Move(velVertical * Time.deltaTime);
    }
    private IEnumerator SaltoBombastic()
    {
        
        if (Input.GetKeyDown(KeyCode.E) && !onground)
        {
            yield return new WaitForSeconds(arribaTime);
            rb.AddForce(Vector3.down * fCaida, ForceMode.Impulse);

        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onground = true;
            Debug.Log("Esta en el suelo");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onground = false;
            Debug.Log("Esta en el aire");

        }
    }

}
