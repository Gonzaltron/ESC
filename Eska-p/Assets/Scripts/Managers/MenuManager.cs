using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Jugar()
    {
        SceneManager.LoadScene("AllLevels");
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Creditos()
    {
        SceneManager.LoadScene("Creditos");
    }
    public void Salir()
    {
        Application.Quit();
    }

    public void Volver()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
