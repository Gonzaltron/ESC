using Ink.Runtime;
using TMPro;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Rendering;
public class InkManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public TextAsset inkJSON;
    public GameObject dialoguePanel;
    public static InkManager Instance;
    private Story story;
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        story = new Story(inkJSON.text);
    }
    
    public void StartDialogue(string knotName)
    {
        story.ChoosePathString(knotName);
       
        ContinueStory();
    }

    public void ContinueStory()
    {
        if (story.canContinue)
        {
            Time.timeScale = 0f;
            dialoguePanel.SetActive(true);
            dialogueText.text = story.Continue();
            
        }
    }

    public void EndDialogue()
    {
        Debug.Log("a");
        dialoguePanel.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
