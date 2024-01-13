using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI; // Text 사용하기 위해 추가함

public class UI_Button : MonoBehaviour
{
    Dictionary<Type, UnityEngine.Object[]> _objects = new Dictionary<Type, UnityEngine.Object[]>();

    enum Buttons
    {
        PointButton,
    }

    enum Texts
    {
        PointText,
        ScoreText,
    }

    void Bind<T>(Type type) where T : UnityEngine.Object
    {
        string[] names = Enum.GetNames(type);
        UnityEngine.Object[] objects = new UnityEngine.Object[names.Length];
        _objects.Add(typeof(T), objects);

        for(int i = 0; i < names.Length; i++)
        {
            objects[i] = Util.FindChild<T>(gameObject, names[i], true);
        }
    }

    private void Start()
    {
        Type buttonsType = typeof(Buttons);
        Bind<Button>(typeof(Buttons));
        Bind<Text>(typeof(Texts));
    }

    public void OnButtonClicked()
    {
        // 버튼 누를 때 잘 호출되는지 확인
        // Debug.Log("ButtonClicked");
    }
}
