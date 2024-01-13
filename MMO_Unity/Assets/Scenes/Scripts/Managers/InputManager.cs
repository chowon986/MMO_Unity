using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; // EventSystem 사용하기 위해 추가

public class InputManager
{
    // Action은 delegate임
    public Action KeyAction = null;
    public Action<Define.MouseEvent> MouseAction = null;
    bool _pressed = false;
    public void OnUpdate()
    {
        if(EventSystem.current.IsPointerOverGameObject())
        {
            // 현재 UI 버튼이 클릭된 상태라면
            return;
        }

        if (Input.anyKey && KeyAction != null) // 키가 눌렸으면
            KeyAction.Invoke(); // 눌렸다는 사실을 전파


        if(MouseAction != null)
        {
            if(Input.GetMouseButton(0))
            {
                MouseAction.Invoke(Define.MouseEvent.Press);
                _pressed = true;
            }
            else
            {
                if (_pressed)
                    MouseAction.Invoke(Define.MouseEvent.Click);
                _pressed = false;
            }
        }
    }
}
