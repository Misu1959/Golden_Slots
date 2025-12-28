using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_ClickBlocker : MonoBehaviour, IPointerClickHandler
{
    public Action action;


    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.pointerEnter != this.gameObject)
            return;

        action?.Invoke();
    }

}