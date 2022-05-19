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
    private static bool isLogin = false;

    private void Awake()
    {
        InitGlobalGameManager();
    }

    private void InitGlobalGameManager()
    {
        DontDestroyOnLoad(gameObject);
    }

    /// <summary>
    /// 씬을 전환합니다. 
    /// </summary>
    /// <param name="sceneName"> 씬 이름 </param>
    public void ChangeScene(string sceneName)
    {
        GameSceneManager.LoadScene(sceneName);
    }


    /// <summary>
    /// 게임씬을 로딩합니다.
    /// </summary>
    /// <param name="mapName"> 전환할 게임씬에서 로드할 맵 이름 </param>
    public void LoadGameScene(string mapName)
    {
        SetIsEditor(false);
        SetMapName(mapName);
        ChangeScene("GameScene");
    }

    /// <summary>
    /// 에디터 씬을 로딩합니다.
    /// </summary>
    public void LoadEditorScene()
    {
        SetIsEditor(true);
        ChangeScene("EditorScene");
    }

    /// <summary>
    /// 메인 씬을 로딩합니다.
    /// </summary>
    public void LoadMainScene()
    {
        SetIsEditor(false);
        SetMapName("");
        ChangeScene("MainScene");
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

    public static void SetIsLogin(bool login)
    {
        isLogin = login;
    }

    public static bool GetIsLogin()
    {
        return isLogin;
    }
}
