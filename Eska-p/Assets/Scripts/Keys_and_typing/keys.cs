using Unity.VisualScripting;
using UnityEngine;

public class keys : MonoBehaviour
{
    [SerializeField] char character;
    [SerializeField] WordManager wordManager;
    bool charSent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void addCharacter()
    {
        Debug.Log("manda");
        wordManager.AddChar(character);
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
