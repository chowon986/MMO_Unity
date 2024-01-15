using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Inven : UI_Scene
{
    enum GameObjects
    {
        GridPanel,
    }

    public override void Init()
    {
        base.Init();

        Bind<GameObject>(typeof(GameObjects));
        GameObject gridPanel = Get<GameObject>((int)GameObjects.GridPanel);

        // 인벤토리에 들은 게 있다면 reset
        if(gridPanel != null)
        {
            foreach (Transform child in gridPanel.transform)
                Managers.Resource.Destroy(child.gameObject);
        }

        for (int i = 0; i < 8; i++)
        {
            // 아이템 생성
            GameObject item = Managers.Resource.Instantiate("UI/Scene/UI_Inven_Item");
            item.transform.SetParent(gridPanel.transform);

            // Util.GetOrAddComponent<UI_Inven_Item>(item); 이렇게 하거나 아니면 script를 UI_Inven_Item에 넣어주기
            UI_Inven_Item invenItem = Util.GetOrAddComponent<UI_Inven_Item>(item);
            invenItem.SetInfo($"집행검{i}번");
        }
    }

    void Start()
    {
        Init();
    }

    void Update()
    {
        
    }
}
