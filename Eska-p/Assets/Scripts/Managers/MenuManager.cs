using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private 
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
