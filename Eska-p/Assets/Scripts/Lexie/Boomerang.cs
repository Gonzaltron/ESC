using UnityEngine;

public class Boomerang : MonoBehaviour
{
    [Header("Elementos principales")]
    [SerializeField] GameObject boom;
    [SerializeField] Transform boomPos;
    [SerializeField] Transform boomRot;
    [SerializeField] float boomDist;
    [SerializeField] float boomSpeed;
    [SerializeField] float damage;
    [SerializeField] private LayerMask layMask;


    private bool isThrown;
    private bool isReturning;
    private Vector3 DistPos;
    private BoomerangRotation rotation;





    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Collider boomCollider = boom.GetComponent<Collider>();
        Collider lexiCollider = boomPos.GetComponent<Collider>();

        Physics.IgnoreCollision(boomCollider, lexiCollider);

        rotation = boom.GetComponent<BoomerangRotation>();
        rotation.enabled = false;
        transform.SetParent(boomPos, false);
        boom.transform.localPosition = Vector3.zero;
        boom.transform.localRotation = Quaternion.identity;
        boom.transform.localScale = Vector3.one;

    }

    // Update is called once per frame
    void Update()
    {
        Lanzar();

        if (isThrown)
        {
            Vector3 newPosition = Vector3.MoveTowards(boom.transform.position, DistPos, boomSpeed * Time.deltaTime);
            boom.transform.position = newPosition;
            if (boom.transform.position == DistPos)
            {
                isThrown = false;
                isReturning = true;
            }
        }
        if (isReturning)
        {
            Vector3 newPos = Vector3.MoveTowards(boom.transform.position, boomPos.position, boomSpeed * Time.deltaTime);        //Basicamente reinicias pos
            boom.transform.position = newPos;

            if (boom.transform.position == boomPos.position)
            {
                isReturning = false;
                rotation.enabled = false;
                boom.transform.SetParent(boomPos, false);
                boom.transform.localPosition = Vector3.zero;
                boom.transform.rotation = boomRot.rotation;
                boom.transform.localScale = Vector3.one;
            }
        }
    }
    void Lanzar()       //Con todo el tema de la distancia
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (isThrown || isReturning) return;
            {
                Distance();
            }
        }
    }
    void Distance() //Detectar si hay objeto conn el raycast y sino se va a cuenca
    {
        RaycastHit hitInfo;
        if (Physics.Raycast(boomPos.transform.position, boomPos.transform.forward, out hitInfo, boomDist, layMask))
        {
            DistPos = hitInfo.point;
            boom.transform.parent = null;
            rotation.enabled = true;
            isThrown = true;

        }
        else
        {
            DistPos = boomPos.position + boomPos.forward * boomDist;
            boom.transform.parent = null;
            rotation.enabled = true;
            isThrown = true;
        }
    }


}

