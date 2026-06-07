using Ink.Runtime;
using TMPro;
using UnityEngine;
using System.Collections;
public class InkManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public TextAsset inkJSON;
    public GameObject dialoguePanel;
    public static InkManager Instance;
    private Story story;
    private Coroutine typingCoroutine;
    public bool isTyping;
    private float dialogueSpeed = 0.05f;
    private string currentLine;
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

        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }

        ContinueStory();
    }
    public void ContinueStory()
    {
        if (story.canContinue)
        {
            Time.timeScale = 0f;
            dialoguePanel.SetActive(true);
            string text = story.Continue();
            currentLine = text;
            typingCoroutine = StartCoroutine(WriteLine(text));

        }
    }
    public void AutomaticDialogue()
    {
        if (typingCoroutine != null)
            StopCoroutine(typingCoroutine);

        dialogueText.text = currentLine;
        isTyping = false;

    }
 
    public void EndDialogue()
    {
        dialoguePanel.SetActive(false);
        Time.timeScale = 1.0f;
    }
    private IEnumerator WriteLine(string text)
    {
        isTyping = true;
        dialogueText.text = "";
        AudioManager.Instance.PlayClippoSound();
        foreach (char letter in text)
        {
            dialogueText.text += letter;
            yield return new WaitForSecondsRealtime(dialogueSpeed);
        }

        isTyping = false;
    }

}
