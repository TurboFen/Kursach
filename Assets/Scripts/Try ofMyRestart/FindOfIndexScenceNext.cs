
using UnityEngine;

public static class FindOfIndexScenceNext
{
   
        private static int index_next;
        public static int get_next()
        {
            Debug.Log("Get" + index_next.ToString());
            return index_next;
        }
        public static void set_next(int a)
        {
            index_next = a;
            Debug.Log("Set" + index_next.ToString());
        }
    
}
