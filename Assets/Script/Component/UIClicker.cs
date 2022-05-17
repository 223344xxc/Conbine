using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class UIClicker : MonoBehaviour, IPointerClickHandler
{
    private Action onClickEvent;

    public void SetOnClickEvent(Action action){
        onClickEvent += action;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        onClickEvent?.Invoke();
    }
}
