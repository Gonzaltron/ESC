using Unity.VisualScripting;
using UnityEngine;

public class keys : MonoBehaviour
{
    [SerializeField] char character;
    [SerializeField] WordManager wordManager;
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
        Debug.Log("Character ");
        if(CompareTag("Borrar1"))
        {
            wordManager.RemoveOne();
        }
        else if(CompareTag("BorrarTodo"))
        {
            wordManager.DeleteList();
        }
        else if (CompareTag("ESC"))
        {
            wordManager.Pause();
        }
        else
        {
            wordManager.AddChar(character);
        }
    }
}
