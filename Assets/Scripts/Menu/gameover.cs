using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameover : MonoBehaviour
{
  
public void LoadMenu()
    {
        SceneManager.LoadScene("menu");
    }
    public void Restart()
    {
        int b;
       b = GetOfGameObj.get();

       // SceneManager.GetActiveScene();
        SceneManager.LoadScene(b);
       
    }
}
