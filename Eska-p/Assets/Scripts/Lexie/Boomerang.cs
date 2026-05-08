using Unity.Cinemachine;
using UnityEngine;

public class Boomerang : MonoBehaviour
{
    [Header("Elementos principales")]
    [SerializeField] GameObject boom;       //boomerang 
    [SerializeField] Transform boomPos;     //Referencia de lugar de que sale y vuelve (Lexi en este caso)
    [SerializeField] Transform boomRot;     //Referencia de rotación
    [SerializeField] float boomDist;    //Distancia del lanzamiento, se puede editar en el editor de unitu
    [SerializeField] float boomSpeed;   //Velocidad, tambien se edita en unity
    [SerializeField] public float damage;  //Daño que hace en los enemigos editar en uniity
    [SerializeField] private LayerMask layMask;     //con los bloques estilo teclas y tal 


    private bool isThrown;  //si el boom va a los enemigos
    private bool isReturning;   //sii el boom esta volviendo a lexi
    private Vector3 DistPos;    //destino lanzamiento
    private BoomerangRotation rotation; //ref script d rotacion





    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {


        if (boom == null)
        {
            boom = transform.Find("Boomerang").gameObject;
        }

        if (boomPos == null)
        {
            boomPos = transform.Find("BoomPos");
        }

        if (boomRot == null)
        {
            boomRot = transform.Find("Rotation");
        }

        //collider de lexi y boomerang para evitar collisiones pq sino se va para atras con el boom

        Collider boomCollider = boom.GetComponent<Collider>();
        Collider lexiCollider = GetComponentInParent<Collider>();
        Physics.IgnoreCollision(boomCollider, lexiCollider);

        //pilla el script de rotacion y lo ignora hasta qe se lance 
        rotation = boom.GetComponent<BoomerangRotation>();
        rotation.enabled = false;


        //boom se pone donde lexi 
        boom.transform.SetParent(boomPos, false);
        boom.transform.localPosition = Vector3.zero;
        boom.transform.localRotation = Quaternion.identity;
        boom.transform.localScale = Vector3.one;    //resetea escala para que no robe la de lexi

    }

    // Update is called once per frame
    void Update()
    {
        Lanzar();

        //boom hacia destino
        if (isThrown)
        {
            Vector3 newPosition = Vector3.MoveTowards(boom.transform.position, DistPos, boomSpeed * Time.deltaTime);
            boom.transform.position = newPosition;
            //vuelve cuando llega a dist
            if (boom.transform.position == DistPos)
            {
                isThrown = false;
                isReturning = true;
            }
        }
        //se mueve de vuelta 
        if (isReturning)
        {
            Vector3 newPos = Vector3.MoveTowards(boom.transform.position, boomPos.position, boomSpeed * Time.deltaTime);        //Basicamente reinicias pos
            boom.transform.position = newPos;

            //recoloca donde lexi y lo pone en posicion 
            if (boom.transform.position == boomPos.position)
            {
                isReturning = false;
                rotation.enabled = false;

                //reasigna parent y resetea transf
                boom.transform.SetParent(boomPos, false);
                boom.transform.localPosition = Vector3.zero;
                boom.transform.rotation = boomRot.rotation;
                boom.transform.localScale = Vector3.one;        //Resetea escala por lo de lexi
            }
        }
    }
    void Lanzar()       //detecta y lanza si no esta lanzado o volviendo
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (isThrown || isReturning) return;    //evita lanzar si esta en movimiento
            {
                Distance();
            }
        }
    }
    //pilla destino con el raycast o usa la dist max si no hay enemigo u otra cosa
    void Distance() 
    {
        RaycastHit hitInfo;
        //si el rayo golpea, esesitio es el punto de impacto
        if (Physics.Raycast(boomPos.transform.position, boomPos.transform.forward, out hitInfo, boomDist, layMask))
        {
            DistPos = hitInfo.point;
      
        }
        else
        {   
            DistPos = boomPos.position + boomPos.forward * boomDist;    //si no hay nada por medio dist max es a donde llega
            
        }
        //Desparentar activa rot y pone como lanzado 
        boom.transform.parent = null;
        rotation.enabled = true;
        isThrown = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        Icono_Accesibilidad icono = other.GetComponent<Icono_Accesibilidad>();
        if (icono != null)
        {
            icono.Die();
        }
    }




}

