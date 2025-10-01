
using UnityEngine;
using System;

public class UserInput : MonoBehaviour
{
    public event Action Clicked;

    private void Update()
    {
        UserActivity();
    }

    private void UserActivity()
    {
        var activity = Input.GetMouseButtonDown((int)MouseButton.Left);     

        if (activity)
        {
            Clicked?.Invoke();
        }
    }
}

