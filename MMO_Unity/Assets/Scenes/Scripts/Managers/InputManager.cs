using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager
{
    // Action�� delegate��
    public Action KeyAction = null;
    public void OnUpdate()
    {
        if (Input.anyKey == false) // Key�� �� �������� return
            return;

        if (KeyAction != null) // Ű�� ��������
            KeyAction.Invoke(); // ���ȴٴ� ����� ����
    }
}
