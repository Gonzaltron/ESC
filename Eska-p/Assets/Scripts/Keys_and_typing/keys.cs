using Unity.VisualScripting;
using UnityEngine;

public class keys : MonoBehaviour
{
    [SerializeField] char character;
    [SerializeField] WordManager wordManager;
    bool mandado;
    bool charSent;
    float coolMandado;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mandado = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(mandado)
        {
            coolMandado += Time.deltaTime;
        }
        if (coolMandado >= 0.5f)
        {
            mandado = false;
            Debug.Log(mandado);
            Debug.Log("mandado2");
        }
    }
    
    public void addCharacter()
    {
        if(!mandado)
        {
            wordManager.AddChar(character);
            mandado = true;
            Debug.Log(mandado);
            Debug.Log("mandado");

        }
       
    }

    public void OncollisionExit(Collision collision)
    {
        if (TryGetComponent<Player>(out Player player))
        {
            transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 0.2f, this.transform.position.z);
            charSent = false;
        }
    }
}
