using System.Collections.Generic;
using UnityEngine;

public class WordManager : MonoBehaviour
{
    [SerializeField] List<char> word;
    [SerializeField] List<char> CorrectWord;
    List<int>CharState;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddChar(char character)
    {
        word.Add(character);
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
        }
    }

    void deleteList()
    {
        word.Clear();
        CharState.Clear();
    }
}
