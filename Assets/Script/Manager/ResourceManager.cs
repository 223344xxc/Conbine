using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ResourceManager
{
    /// <summary>
    /// 리소스 파일 이름 입니다.
    /// </summary>
    public static class ResourceName
    {
        public static string mapSellPrefab = "DefaultSell";
        public static string mapEditorSellPrefab = "MapEditorSell";
        public static string squarePrefab = "Square";

        public static string lockOpenEffect = "LockOpen_Effect_Prefab";
    }


    /// <summary>
    /// 입력받은 경로의 프리펩을 읽어 반환합니다.
    /// </summary>
    /// <param name="path">
    /// 파일 경로
    /// </param>
    public static GameObject LoadPrefab(string path)
    {
        GameObject obj = Resources.Load<GameObject>(path);
        if (obj)
            return obj;
        else
            return null;
    }

    /// <summary>
    /// 맵 셀 프리팹을 반환합니다.
    /// </summary>
    public static GameObject GetMapSell()
    {
        return LoadPrefab(
            FilePathManager.ConnectPath(
            FilePathManager.FileName.prefab, ResourceName.mapSellPrefab));
    }

    /// <summary>
    /// 맵 에디터 셀 프리펩을 반환합니다.
    /// </summary>
    public static GameObject GetMapEditorSell()
    {
        return LoadPrefab(
            FilePathManager.ConnectPath(
            FilePathManager.FileName.prefab, ResourceName.mapEditorSellPrefab));
    }

    /// <summary>
    /// 잠금 블록 오픈 이펙트 프리펩을 반환합니다.
    /// </summary>
    public static GameObject GetLockOpenEffect()
    {
        return LoadPrefab(FilePathManager.ConnectPath(
            FilePathManager.FileName.prefab, FilePathManager.FileName.effect, ResourceName.lockOpenEffect));

    }
}
