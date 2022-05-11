using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MapSellTypeOptions;

public static class ResourceManager
{
    /// <summary>
    /// 리소스 파일 이름 입니다.
    /// </summary>
    public struct ResourceName
    {
        #region 맵 프리펩 이름 정보
        public static string mapSellPrefab = "DefaultSell";
        public static string mapEditorSellPrefab = "MapEditorSell";
        public static string squarePrefab = "Square";
        public static string lockOpenEffectPrefab = "LockOpen_Effect_Prefab";
        #endregion
    }

    /// <summary>
    /// Resources 클래스의 Load 함수를 래핑한 함수입니다.
    /// 입력받은 경로에 있는 리소스를 반환합니다.
    /// </summary>
    /// <typeparam name="T"> 제네릭 타입은 Object 클래스의 자식이여야 합니다. </typeparam>
    /// <param name="path"> 파일 이름을 포함한 경로입니다. </param>
    /// <returns></returns>
    public static T LoadResource<T>(string path) where T : Object
    {
        return Resources.Load<T>(path);
    }

    /// <summary>
    /// 입력받은 경로의 스프라이트를 읽어 반환합니다.
    /// </summary>
    /// <param name="path"> 파일 경로 </param>
    public static Sprite LoadSprite(string path)
    {
        Sprite spr = LoadResource<Sprite>(path);
        if (spr)
            return spr;
        else
            return null;
    }

    public static RuntimeAnimatorController LoadAnimator(string path)
    {

        RuntimeAnimatorController anim = LoadResource<RuntimeAnimatorController>(path);
        if (anim)
            return anim;
        else
            return null;
    }

    /// <summary>
    /// 입력받은 경로의 프리펩을 읽어 반환합니다.
    /// </summary>
    /// <param name="path"> 파일 경로 </param>
    public static GameObject LoadPrefab(string path)
    {
        GameObject obj = LoadResource<GameObject>(path);
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
            FilePathManager.FileName.prefab, 
            ResourceName.mapSellPrefab)
            );
    }

    /// <summary>
    /// 맵 에디터 셀 프리펩을 반환합니다.
    /// </summary>
    public static GameObject GetMapEditorSell()
    {
        return LoadPrefab(
            FilePathManager.ConnectPath(
            FilePathManager.FileName.prefab, 
            ResourceName.mapEditorSellPrefab)
            );
    }

    /// <summary>
    /// 잠금 블록 오픈 이펙트 프리펩을 반환합니다.
    /// </summary>
    public static GameObject GetLockOpenEffect()
    {
        return LoadPrefab(FilePathManager.ConnectPath(
            FilePathManager.FileName.prefab, 
            FilePathManager.FileName.effect, 
            ResourceName.lockOpenEffectPrefab)
            );

    }

    /// <summary>
    /// 맵 타입에 맞는 스프라이트를 반환합니다.
    /// </summary>
    public static Sprite GetMapSellSprite(MapSellType mapSellType)
    {
        return LoadSprite(FilePathManager.ConnectPath(
            FilePathManager.FileName.sprite, 
            FilePathManager.FileName.mapSell, 
            MapSellType.GetMapSellSpriteName(mapSellType.sellTypeCode)
            ));
    }

    public static RuntimeAnimatorController GetMapSellAnimator(MapSellType mapSellType)
    {
        return LoadAnimator(FilePathManager.ConnectPath(
            FilePathManager.FileName.animation,
            FilePathManager.FileName.animationController,
            MapSellType.GetMapSellAnimatorName(mapSellType.sellTypeCode)
            ));
    }
}
