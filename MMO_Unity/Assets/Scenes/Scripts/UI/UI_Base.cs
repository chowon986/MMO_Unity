using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI; // Text 사용하기 위해 추가함

public abstract class UI_Base : MonoBehaviour
{
    protected Dictionary<Type, UnityEngine.Object[]> _objects = new Dictionary<Type, UnityEngine.Object[]>();

    public abstract void Init();

    protected void Bind<T>(Type type) where T : UnityEngine.Object
    {
        string[] names = Enum.GetNames(type);
        UnityEngine.Object[] objects = new UnityEngine.Object[names.Length];
        _objects.Add(typeof(T), objects);

        for (int i = 0; i < names.Length; i++)
        {
            if (typeof(T) == typeof(GameObject))
                objects[i] = Util.FindChild(gameObject, names[i], true);
            else
                objects[i] = Util.FindChild<T>(gameObject, names[i], true);

            if (objects[i] == null)
                Debug.Log($"Failed to bind({names[i]})");
        }
    }

    protected T Get<T>(int idx) where T : UnityEngine.Object
    {
        // 유니티 오브젝트 배열을 하나 만든다.
        UnityEngine.Object[] objects = null;

        // 배열에 해당 키에 연결된 값을 찾지 못했다면 false 반환
        if (_objects.TryGetValue(typeof(T), out objects) == false)
            return null;

        // 해당 키에 연결된 앖이 있다면 그 중에 특정 인덱스 부분을 반환
        return objects[idx] as T;
    }

    protected Text GetText(int idx) { return Get<Text>(idx); }

    protected Button GetButton(int idx) { return Get<Button>(idx); }

    protected Image GetImage(int idx) { return Get<Image>(idx); }

    public static void AddUIEvent(GameObject go, Action<PointerEventData> action, Define.UIEvent type = Define.UIEvent.Click)
    {
        UI_EventHandler evt = Util.GetOrAddComponent<UI_EventHandler>(go);
        switch (type)
        {
            case Define.UIEvent.Click:
                evt.OnClickHandler -= action;
                evt.OnClickHandler += action;
                break;
            case Define.UIEvent.Drag:
                evt.OnDragHandler -= action;
                evt.OnDragHandler += action;
                break;
        }
    }
}
