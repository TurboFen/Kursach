
using UnityEngine;

public static class GetOfGameObj
{
    private static int index;
    public static int get()
    {
        Debug.Log("Get"+index.ToString());
        return index;
    }
    public static void set(int a)
    {
        index = a;
        Debug.Log("Set"+index.ToString());
    }
}


