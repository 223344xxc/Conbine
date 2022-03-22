using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Report
{
#if UNITY_EDITOR
    public static void Log(this object obj) 
    { 
        Debug.Log(obj.ToString());
    }

    public static void LogError(this object obj)
    {
        Debug.LogError(obj.ToString());
    }
#endif
}
