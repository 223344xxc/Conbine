using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FilePathManager
{
    //파일 이름 입니다
    public static class FileName
    {
        public const string assetFile = "Assets";
        public const string resourcesFile = "Resources";
        public const string dataFile = "Data";
        public const string mapData = "MapData";
        public const string prefab = "Prefab";
    }

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

            path = string.Concat(path, SaveManager.DataEndSign.endData, paths[i]);
        }
        return path;
    }

    //맵 데이터 파일 경로를 반환합니다
    public static string GetMapDataPath(string fileName)
    {
        return ConnectPath(
            FileName.assetFile, 
            FileName.resourcesFile, 
            FileName.dataFile, 
            FileName.mapData, 
            fileName);
    }
}
