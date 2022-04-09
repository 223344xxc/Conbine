using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FilePathMgr
{
    //각 파일들의 이름입니다
    public const string assetFile = "Assets";
    public const string resourcesFile = "Resources";
    public const string dataFile = "Data";
    public const string mapData = "MapData";


    //입력받은 문자열들을 파일 경로로 가공합니다
    public static string ConnectPath(params string[] paths)
    {
        string path = "";

        for(int i = 0; i < paths.Length; i++)
        {
            if (i == 0)
            {
                path = paths[0];
                continue;
            }

            path = path + "/" + paths[i];
        }
        return path;
    }

    //맵 데이터 파일 경로를 반환합니다
    public static string GetMapDataPath(string fileName)
    {
        return ConnectPath(assetFile, resourcesFile, dataFile, mapData, fileName);
    }
}
