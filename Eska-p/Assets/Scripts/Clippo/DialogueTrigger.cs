using UnityEngine;
using System.Collections;

public class DialogueTrigger : MonoBehaviour
{
    public string knotName;
    public string clueName;

    public InkManager inkManager;
    public Player player;

    private bool activated = false;

    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("player");

        if (playerObj != null)
        {
            player = playerObj.GetComponent<Player>();
        }
 
        inkManager = FindFirstObjectByType<InkManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player") && !activated) 
        {
            AudioManager.Instance.PlayCheckpointSound();
            activated = true;
            Clippo.Instance.SetHint(clueName); 
            inkManager.StartDialogue(knotName); 
            player.health = 3; 
            Spawn.Instance.SetCheckpoint(transform.position);
        }
    }
}