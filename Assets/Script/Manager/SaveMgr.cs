using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class SaveMgr
{

    //입력받은 경로의 파일에 입력받은 문자열을 입력합니다
    public static void WriteText(string path, string str)
    {
        string filePath = path;
        StreamWriter sw = null;

        if (!File.Exists(filePath))
        {
            sw = new StreamWriter(path + ".txt");
        }

        sw.WriteLine(str);

        sw.Flush();
        sw.Close();
    }


    //입력받은 경로의 파일의 내용을 읽어 반환합니다
    public static string ReadText(string path)
    {
        return null;
    }
}
