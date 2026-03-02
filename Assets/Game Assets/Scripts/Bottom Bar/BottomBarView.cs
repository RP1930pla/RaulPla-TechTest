using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class BottomBarView : MonoBehaviour
{

    List<BottomBarButton> buttons;

    void Closed() 
    {

    }

    void CheckForNoContent() 
    {

    }

    public void ContentActivated() 
    {
        Debug.Log("Content Activated");
    }

    public void Subscribe(BottomBarButton button)
    {
        if (buttons == null) 
        {
            buttons = new List<BottomBarButton>();
        }

        buttons.Add(button);
    }

    public void Unsubscribe(BottomBarButton button) 
    {
        if (buttons == null)
        {
            buttons = new List<BottomBarButton>();
        }

        buttons.Remove(button);
    }

    public void CloseOtherEnabledButtons() 
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            if (buttons[i].enabled) 
            {
                buttons[i].CloseButton();
            }
        }
    }

}
