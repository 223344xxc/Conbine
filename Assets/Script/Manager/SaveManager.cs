using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public static class SaveManager
{
    /// <summary>
    /// 맵 데이터 정보 이름 입니다.
    /// </summary>
    public static class MapData
    {
        public const string mapNameDataName = "MapName";
        public const string mapSizeDataName = "MapSize";
        public const string mapSellDataName = "MapSell";
        public const string onSquareDataName = "OnSquare";
    }

    /// <summary>
    /// 데이터 분할 문자 입니다.
    /// </summary>
    public static class DataEndSign
    {
        public const string endLine = "\n";
        public const string dataNameEnd = ":";
        public const string endData = "/";
        public const string connectedData = ",";
    }


    /// <summary>
    /// 입력받은 경로의 파일에 입력받은 문자열을 입력합니다.
    /// </summary>
    /// <param name="path"> 파일 경로 </param>
    /// <param name="str"> 입력할 문자열 </param>
    public static void WriteText(string path, string str)
    {
        string filePath = path;
        
        StreamWriter sw = null;

        if (!File.Exists(filePath))
        {
            sw = new StreamWriter(string.Concat(path, ".txt"));
        }

        sw.WriteLine(str);

        sw.Flush();
        sw.Close();
    }


    /// <summary>
    /// 입력받은 경로의 파일의 내용을 읽어 반환합니다.
    /// </summary>
    /// <param name="path"> 파일 경로 </param>
    public static string ReadText(string path)
    {
        string str;
        StreamReader sr = null;

        if (!File.Exists(path))
        {
            sr = new StreamReader(string.Concat(path, ".txt"));
        }

        str = sr.ReadToEnd();
        sr.Close();

        return str;
    }

    /// <summary>
    /// 입력받은 데이터 라인들을 연결합니다.
    /// </summary>
    /// <param name="datas"> 연결할 데이터 라인 </param>
    public static string ConnectSaveData(params string[] datas)
    {
        StringBuilder stringBuilder = new StringBuilder();
        for(int i = 0; i < datas.Length; i++)
        {
            if (i == 0)
            {
                stringBuilder.Append(datas[i]);
                continue;
            }

            stringBuilder.Append(DataEndSign.endLine);
            stringBuilder.Append(datas[i]);
        }
        return stringBuilder.ToString();
    }

    /// <summary>
    /// 입력받은 데이터들을 연결합니다.
    /// </summary>
    /// <param name="between"> 연결 문자 </param>
    /// <param name="datas"> 연결할 데이터 </param>
    public static string ConnectData(string between, params string[] datas)
    {
        StringBuilder stringBuilder = new StringBuilder();
        for(int i = 0; i < datas.Length; i++)
        {
            if(i == 0)
            {
                stringBuilder.Append(datas[i]);
                continue;
            }

            stringBuilder.Append(between);
            stringBuilder.Append(datas[i]);
        }
        return stringBuilder.ToString();
    }
}
