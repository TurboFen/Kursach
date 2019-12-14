using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public Button level2B;
    public Button level3B;
    static bool count = false;
    int levelComplete;
 
    void Start()
    {
        if (count == false) { count = true;
            level2B.interactable = false;
            level3B.interactable = false;
        }
        if(count)
        levelComplete = PlayerPrefs.GetInt("LevelComplete");
        level2B.interactable = false;
        level3B.interactable = false;
        switch (levelComplete)
        {
            case 1:
                {
                    level2B.interactable = true;
                    break;
                }
            case 2:
                {
                    level2B.interactable = true;
                    level3B.interactable = true;
                    break;
                }
                
        }
    }
    public void LoadTo(int level)
    {
        SceneManager.LoadScene(level);
    }
    public void Reset()
    {
        level2B.interactable = false;
        level3B.interactable = false;
        PlayerPrefs.DeleteAll();
    }
    public void cheat()
    {
        level2B.interactable = true;
        level3B.interactable = true;
    }
 public void Back()
    {
        SceneManager.LoadScene("menu");
    }
}
