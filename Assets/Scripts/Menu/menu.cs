using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menu : MonoBehaviour
{
    public Canvas selectLv; 
    public void OpenSelectLvl()
    {
        selectLv.gameObject.SetActive(true);

    }
    public void CloseSelectLvl()
    {
        selectLv.gameObject.SetActive(false);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
