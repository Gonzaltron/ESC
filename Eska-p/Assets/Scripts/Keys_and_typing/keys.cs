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
        
    }

    // Update is called once per frame
    void Update()
    {
        if(mandado)
        {
            coolMandado += Time.deltaTime;
        }
    }
    
    public void addCharacter()
    {
        if(!mandado)
        {
            wordManager.AddChar(character);
            mandado = true;
        }
        if(coolMandado >= 0.5f)
        {
            mandado = false;
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
