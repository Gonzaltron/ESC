using System.Collections.Generic;
using UnityEngine;

public class WordManager : MonoBehaviour
{
    [SerializeField] List<char> word;
    [SerializeField] List<char> CorrectWord1;
    [SerializeField] List<char> CorrectWord2;
    [SerializeField] List<char> CorrectWord3;
    [SerializeField] List<char> CorrectWord4;
    [SerializeField] GameObject door1;
    [SerializeField] GameObject door2;
    [SerializeField] GameObject door3;
    [SerializeField] GameObject door4;
    public static WordManager instance;
    [SerializeField] List<int>CharState;
    int phase;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        phase = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddChar(char character)
    {
        word.Add(character);
        if(word.Count == CorrectWord1.Count && phase == 0)
        {
            CheckLetra();
        }
        else if(word.Count == CorrectWord1.Count && phase == 1)
        {
            CheckLetra();
        }
        else if(word.Count == CorrectWord1.Count && phase == 2)
        {
            CheckLetra();
        }
        else if(word.Count == CorrectWord1.Count && phase == 3)
        {
            CheckLetra();
        }
    }
    public void CheckLetra()
    {
        Debug.LogWarning("Entra");
        for (int i = 0; i< word.Count+1; i++)
        {
            if(phase == 0)
            {
                for(int j = 0; j< CorrectWord1.Count; j++)
                {
                    if(word[i] == CorrectWord1[j] && i == j)
                    {
                        CharState.Add(1);
                    }
                    else if(word[i] == CorrectWord1[j] && i != j)
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
                if(CharState.Count != null)
                {
                    door1.SetActive(false);
                }
                deleteList();
            }
            else if(phase == 1)
            {
                for(int j = 0; j< CorrectWord2.Count; j++)
                {
                    if(word[i] == CorrectWord2[j] && i == j)
                    {
                        CharState.Add(1);
                    }
                    else if(word[i] == CorrectWord2[j] && i != j)
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
                if(CharState.Count != null)
                {
                    door2.SetActive(false);
                }
                deleteList();
            }
            else if(phase == 2)
            {
                for(int j = 0; j< CorrectWord3.Count; j++)
                {
                    if(word[i] == CorrectWord3[j] && i == j)
                    {
                        CharState.Add(1);
                    }
                    else if(word[i] == CorrectWord3[j] && i != j)
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
                if(CharState.Count != null)
                {
                    door3.SetActive(false);
                }
                deleteList();
            }
            else if(phase == 3)
            {
                for(int j = 0; j< CorrectWord4.Count; j++)
                {
                    if(word[i] == CorrectWord4[j] && i == j)
                    {
                        CharState.Add(1);
                    }
                    else if(word[i] == CorrectWord4[j] && i != j)
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
                if(CharState.Count != null)
                {
                    door4.SetActive(false);
                }
                deleteList();
            }
        }
    }

    void deleteList()
    {
        word.Clear();
        CharState.Clear();
    }
}
