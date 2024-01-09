using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager
{
    // Action은 delegate임
    public Action KeyAction = null;
    public void OnUpdate()
    {
        if (Input.anyKey == false) // Key가 안 눌렸으면 return
            return;

        if (KeyAction != null) // 키가 눌렸으면
            KeyAction.Invoke(); // 눌렸다는 사실을 전파
    }
}
