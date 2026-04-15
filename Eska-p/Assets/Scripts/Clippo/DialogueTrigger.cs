using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public string knotName; 
    public InkManager inkManager;
    public GameObject clippo;

    private bool activated = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player") && !activated)
        {
            activated = true;

            clippo.SetActive(true); 
            inkManager.StartDialogue(knotName);
        }
    }
}
