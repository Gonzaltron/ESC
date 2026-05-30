using Ink.Runtime;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject spawn;
    public GameObject player;
    public static Spawn Instance;
   [SerializeField] private Vector3 lastCheckpoint;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    void Start()
    {
        spawn = GameObject.FindGameObjectWithTag("spawn");
        player = Instantiate(player, spawn.transform.position, Quaternion.identity);
        //player.transform.GetChild(6).GetChild(0).localScale = new Vector3(0.99f, 0.99f, 0.99f);
        lastCheckpoint = spawn.transform.position;
        player.transform.GetChild(6).localScale = new Vector3(100, 50, 100);
        player.transform.GetChild(6).localRotation = Quaternion.Euler(0, 90, 0);
        player.transform.GetChild(6).localPosition = new Vector3 (0, -0.5f, -0.12f);
    }
    public void SetCheckpoint(Vector3 checkpointPosition)
    {
        lastCheckpoint = checkpointPosition;
    }

    public void Respawn()
    {
        player.GetComponent<CharacterController>().enabled = false; // Desactiva el CharacterController para evitar problemas de colisi�n
        player.transform.position = lastCheckpoint + Vector3.up * 1.5f;
        player.GetComponent<CharacterController>().enabled = true;

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
