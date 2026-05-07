using System.Security.Cryptography;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public string knotName; 
    public InkManager inkManager;
    public GameObject clippo;
    public Player player;
    private bool activated = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("player").GetComponent<Player>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player") && !activated)
        {
            activated = true;

            clippo.SetActive(true); 
            inkManager.StartDialogue(knotName);
            player.health = 3;
            Spawn.Instance.SetCheckpoint(transform.position);
        }
    }
}
