﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public static class FilePathManager
{
    /// <summary>
    /// 파일 이름 입니다.
    /// </summary>
    public struct FileName
    {
        public const string assetFile = "Assets";

        public const string resourcesFile = "Resources";

        public const string dataFile = "Data";
        public const string prefab = "Prefab";
        public const string animation = "Animation";

        public const string mapData = "MapData";
        public const string effect = "Effect";
        public const string sprite = "Sprite";
        public const string animationController = "AnimationController";

        public const string mapSell = "MapSell";
    }

    /// <summary>
    /// 입력받은 문자열들을 파일 경로로 가공합니다.
    /// </summary>
    /// <param name="paths"> 연결할 경로들 </param>
    /// <returns></returns>
    public static string ConnectPath(params string[] paths)
    {
        StringBuilder stringBuilder = new StringBuilder();

        for(int i = 0; i < paths.Length; i++)
        {
            if (i == 0)
            {
                stringBuilder.Append(paths[0]);
                continue;
            }

            stringBuilder.Append(SaveManager.DataEndSign.endData);
            stringBuilder.Append(paths[i]);
        }

        return stringBuilder.ToString();
    }

    /// <summary>
    /// 맵 데이터 파일 경로를 반환합니다.
    /// </summary>
    /// <param name="fileName"> 파일 이름 </param>
    /// <returns></returns>
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
