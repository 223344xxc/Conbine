using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ObjectClicker : MonoBehaviour
{
    private Action onClickDown;
    private Action onClick;
    private Action onClickUp;

    public void BindOnClickDown(Action action)
    {
        onClickDown += action;
    }

    public void BindOnClick(Action action)
    {
        onClick += action;
    }

    public void BindOnClickUp(Action action)
    {
        onClickUp += action;
    }

    /// <summary>
    /// 오브젝트가 클릭되면 호출됩니다.
    /// </summary>
    public void OnClickDown()
    {
        onClickDown?.Invoke();
    }

    /// <summary>
    /// 오브젝트가 클릭중일때 호출됩니다.
    /// </summary>
    public void OnClick()
    {
        onClick?.Invoke();
    }

    /// <summary>
    /// 오브젝트가 클릭해제되면 호출됩니다.
    /// </summary>
    public void OnClickUp()
    {
        onClickUp?.Invoke();
    }
}
