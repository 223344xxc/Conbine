using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StringOption
{
    public static string[] SplitToString(this string str, string splitStr)
    {
        return str.Split(splitStr.ToCharArray());
    }
}
