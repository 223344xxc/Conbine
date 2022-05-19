using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneController : MonoBehaviour
{
    private UIManager uiManager;

    private void Awake()
    {
        InitMainSceneController();
    }


    private void InitMainSceneController()
    {
        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
    }

    public void PressStartButton()
    {
        uiManager.SetActive_mainUICanvas(false);
        uiManager.SetActive_editorUICanvas(true);
        uiManager.SetActive_stageUICanvas(true);
        GlobalGameManager.SetIsLogin(true);
    }
}
