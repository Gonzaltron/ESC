using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{

    public GameObject pauseCanvas;
    public GameObject gameCanvas;

    public void Awake()
    {
        pauseCanvas.SetActive(false);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        Time.timeScale = 0;
    }

    private bool isPaused = false;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused) Seguir();
            else Pause();
        }

    }
    public void Pause()
    {
        isPaused = true;
        Time.timeScale = 0f;           // Para el juego
        pauseCanvas.SetActive(true);
        if (gameCanvas != null) gameCanvas.SetActive(false);
    }
    public void Seguir()
    {
        isPaused = false;
        Time.timeScale = 1f;           
        pauseCanvas.SetActive(false);
        if (gameCanvas != null) gameCanvas.SetActive(true);
    }
    public void Empezar()
    {
        Time.timeScale = 1f;           //Resetea el juego desde 0
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void MainMenu()
    {
        Time.timeScale = 1f;    
        SceneManager.LoadScene("MainMenu");
    }
}
