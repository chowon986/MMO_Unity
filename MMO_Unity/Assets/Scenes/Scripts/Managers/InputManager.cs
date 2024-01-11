using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager
{
    // Action�� delegate��
    public Action KeyAction = null;
    public Action<Define.MouseEvent> MouseAction = null;
    bool _pressed = false;
    public void OnUpdate()
    {
        if (Input.anyKey && KeyAction != null) // Ű�� ��������
            KeyAction.Invoke(); // ���ȴٴ� ����� ����


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
