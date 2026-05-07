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
        lastCheckpoint = spawn.transform.position;
    }
    public void SetCheckpoint(Vector3 checkpointPosition)
    {
        lastCheckpoint = checkpointPosition;
    }

    public void Respawn()
    {
        player.transform.position = lastCheckpoint + Vector3.up * 1.5f;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
