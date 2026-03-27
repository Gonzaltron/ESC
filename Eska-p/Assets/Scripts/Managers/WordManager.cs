using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WordManager : MonoBehaviour
{
    [SerializeField] List<char> word;
    [SerializeField] List<char> CorrectWord;
    [SerializeField] GameObject door;
    [SerializeField] List<int>CharState;
    [SerializeField] List <TextMeshProUGUI> charWall;
    int index;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddChar(char character)
    {
        word.Add(character);
        charWall[index].text = character.ToString();
        index ++;
        if(word.Count == CorrectWord.Count)
        {
            CheckLetra();
        }
    }
    public void CheckLetra()
    {
        for (int i = 0; i< word.Count+1; i++)
        {
            
                for(int j = 0; j< CorrectWord.Count; j++)
                {
                    if(word[i] == CorrectWord[j] && i == j)
                    {
                        CharState.Add(1);
                    }
                    else if(word[i] == CorrectWord[j] && i != j)
                    {
                        CharState.Add(2);
                    }
                    else
                    {
                        CharState.Add(0);
                    }
                }
                
                for(int j = 0; i<CharState.Count; i++)
                {
                    if(CharState[j] != 1)
                    {
                        deleteList();
                    }
                }
                if(CharState.Count == CorrectWord.Count)
                {
                    door.SetActive(false);
                }
                deleteList();
            
        }
    }

    void deleteList()
    {
        word.Clear();
        CharState.Clear();
        for(int i = 0; i < charWall.Count; i++)
        {
            charWall[i].text = " ";
        }
        index = 0;
    }
}
