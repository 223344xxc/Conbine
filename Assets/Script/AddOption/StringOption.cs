using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StringOption
{
    //문자열을 입력받은 문자열을 기준으로 분리합니다
    public static string[] SplitToString(this string str, string splitStr)
    {
        List<string> valueStr = new List<string>();

        int splitIndex = 0;
        int splitSave = 0;
        int readSaveIndex = 0;
        for(int i = 0; i < str.Length; i++)
        {
            if(str[i] == splitStr[splitIndex])
            {
                splitIndex += 1;
                splitSave = i;
            }
            else
            {
                splitIndex = 0;
            }

            if(splitIndex == splitStr.Length)
            {
                //for(; readSaveIndex < )
            }
        }

        return valueStr.ToArray();
    } 
}
