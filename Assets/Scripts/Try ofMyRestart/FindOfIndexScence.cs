using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public  class FindOfIndexScence :MonoBehaviour
{
    public int index;
    public int next_index;
    public void Awake()
    {
        GetOfGameObj.set(index);
        FindOfIndexScenceNext.set_next(next_index);
    }
    
    //public int index;
    //void Start()
    //{
    //    Debug.Log("First"+index.ToString());
    //    DontDestroyOnLoad(this);
    //}

    //public void Restart()
    //{
    //    Debug.Log(index.ToString());
    //    SceneManager.LoadScene(index);
    //}
    //// void Start()
    ////{
    ////    NeedScence(); 
    ////}
    ////public  void NeedScence()
    ////{
    ////    int index;
    ////    index = SceneManager.GetActiveScene().buildIndex;
    ////    DontDestroyOnLoad(this);
    ////}

}
