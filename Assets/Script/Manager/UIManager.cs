using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private GameObject mainUICanvas;
    private GameObject editorUICanvas;
    private GameObject stageUICanvas;

    private void Awake()
    {
        InitUIManager();
    }

    private void InitUIManager()
    {
        mainUICanvas = GameObject.Find("MainUI");
        editorUICanvas = GameObject.Find("EditorUI");
        stageUICanvas = GameObject.Find("StageUI");

        if (!GlobalGameManager.GetIsLogin())
        {
            SetActive_editorUICanvas(false);
            SetActive_stageUICanvas(false);
        }
        else
        {
            SetActive_mainUICanvas(false);
        }

    }

    /// <summary>
    /// 메인 UI 의 ON | OFF 를 전환합니다
    /// </summary>
    public void SetActive_mainUICanvas(bool active)
    {
        mainUICanvas.SetActive(active);
    }

    /// <summary>
    /// 에디터 UI 의 ON | OFF 를 전환합니다
    /// </summary>
    public void SetActive_editorUICanvas(bool active)
    {
        editorUICanvas.SetActive(active);
    }

    /// <summary>
    /// 스테이지 UI 의 ON | OFF 를 전환합니다
    /// </summary>
    public void SetActive_stageUICanvas(bool active)
    {
        stageUICanvas.SetActive(active);
    }
}
