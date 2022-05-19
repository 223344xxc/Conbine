using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 게임의 모든 시점에 존재하는 오브젝트 입니다.
/// 게임의 흐름을 담당합니다.
/// </summary>
public class GlobalGameManager : MonoBehaviour
{
    private static string mapName;
    private static bool isEditor = false;

    private void Awake()
    {
        InitGlobalGameManager();
    }

    private void InitGlobalGameManager()
    {
        DontDestroyOnLoad(this);
    }

    public void ChangeScene(string sceneName)
    {
        GameSceneManager.LoadScene(sceneName);
    }

    public void LoadGameScene(string mapName)
    {
        SetIsEditor(false);
        SetMapName(mapName);
        ChangeScene("GameScene");
    }

    public void LoadEditorScene()
    {
        SetIsEditor(true);
        ChangeScene("EditorScene");
    }


    public static void SetMapName(string name)
    {
        mapName = name;
    }

    public static string GetMapName()
    {
        return mapName;
    }

    public static void SetIsEditor(bool editor)
    {
        isEditor = editor;
    }

    public static bool GetIsEditor()
    {
        return isEditor;
    }
}
