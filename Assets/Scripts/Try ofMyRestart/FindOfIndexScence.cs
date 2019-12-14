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

}
