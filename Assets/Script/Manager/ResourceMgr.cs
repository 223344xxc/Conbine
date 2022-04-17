using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ResourceMgr
{
    //리소스 파일 이름 입니다
    public static class ResourceName
    {
        public static string mapSellPrefab = "DefaultSell";
        public static string mapEditorSellPrefab = "MapEditorSell";
        public static string squarePrefab = "Square";
    }


    //입력받은 경로의 프리펩을 읽어 반환합니다
    public static GameObject LoadPrefab(string path)
    {
        GameObject obj = Resources.Load<GameObject>(path);
        if (obj)
            return obj;
        else
            return null;
    }

    //맵 셀 프리팹을 반환합니다
    public static GameObject GetMapSell()
    {
        return LoadPrefab(
            FilePathMgr.ConnectPath(
            FilePathMgr.FileName.prefab, ResourceName.mapSellPrefab));
    }
    //맵 에디터 셀 프리펩을 반환합니다
    public static GameObject GetMapEditorSell()
    {
        return LoadPrefab(
            FilePathMgr.ConnectPath(
            FilePathMgr.FileName.prefab, ResourceName.mapEditorSellPrefab));
    }
}
