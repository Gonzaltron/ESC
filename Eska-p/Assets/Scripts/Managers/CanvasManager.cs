using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] Canvas mainMenu;
    [SerializeField] Canvas game;   
    [SerializeField] Canvas pause;
    Canvas prev;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainMenu.enabled = true;
        game.enabled = false;
        Cursor.visible = true;
        pause.enabled = false;
        Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }

    }
    public void Pause()
    {
        game.enabled = false;
        pause.enabled = true;
        Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void Game()
    {
        mainMenu.enabled = false;
        game.enabled = true;
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("AllLevels");
    }
}
