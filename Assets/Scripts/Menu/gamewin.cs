using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gamewin : MonoBehaviour
{
    public static gamewin instance = null;
        int sceneIndex;
    int levelComplete;
 void Start()
    {
        int corrent_level = GetOfGameObj.get();
        if (instance==null)
        {
            instance = this;
        }

        // sceneIndex = SceneManager.GetActiveScene().buildIndex; //возможно ошибка
        sceneIndex = GetOfGameObj.get();
        if (corrent_level!=0) {
            levelComplete = PlayerPrefs.GetInt("LevelComplete");
           // PlayerPrefs.SetInt("LevelComplete", sceneIndex);
        }
       
      // levelComplete = PlayerPrefs.GetInt("LevelComplete");
    }
    
    public void isEndGame()
    {

        int sceneIndex = GetOfGameObj.get();
        int scenceNext = FindOfIndexScenceNext.get_next();
        if (scenceNext != 0)
        {
            PlayerPrefs.SetInt("LevelComplete", sceneIndex);
        }
        else
        {
            Invoke("NextLvl", 2f);
        }
        
        //if(sceneIndex == 2)
        //{
        //    Invoke("LoadMainMenu", 2f);
        //}
        //else 
        //        {
        //    if(levelComplete < sceneIndex)
        //    {
        //        PlayerPrefs.SetInt("LevelComplete", sceneIndex);
        //    }
        //    Invoke("NextLvl", 2f);
        //}
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("menu");
    }
    public void NextLvl()
    {
        int next = FindOfIndexScenceNext.get_next();
        if (next == 0) { //Здесь сделать сцену продолжение следует

            SceneManager.LoadScene("menu"); //Пока вернет в меню
        }
        SceneManager.LoadScene(next);
    }
}
