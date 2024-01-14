using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public enum PlayerState
    {
        Die,
        Moving,
        Idle,
    }

    PlayerState _state = PlayerState.Idle;

    [SerializeField]
    float _speed = 10.0f;

    Vector3 _destPos;

    void Start()
    {
        // 구독 신청
        Managers.Input.MouseAction -= OnMouseClicked;
        Managers.Input.MouseAction += OnMouseClicked;

        // Managers.Resource.Instantiate("UI/UIButton");
        //Managers.UI.ShowPopupUI<UI_Button>();
        //Managers.UI.ClosePopupUI();
    }

    void UpdateDie()
    {
    }

    void UpdateMoving()
    {
        Vector3 dir = _destPos - transform.position; // 방향 벡터 구하기
        if (dir.magnitude < 0.0001f)
        {
            _state = PlayerState.Idle;
        }
        else
        {
            float moveDist = Mathf.Clamp(_speed * Time.deltaTime, 0, dir.magnitude);
            transform.position += dir.normalized * moveDist;

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 20 * Time.deltaTime);
        }

        Animator anim = GetComponent<Animator>();
        // 현재 게임 상태에 대한 정보를 넘겨주기
        anim.SetFloat("speed", _speed);
    }

    void UpdateIdle()
    {
        Animator anim = GetComponent<Animator>();
        // 현재 게임 상태에 대한 정보를 넘겨주기
        anim.SetFloat("speed", 0);
    }


    void Update()
    {
        switch(_state)
        {
            case PlayerState.Die:
                UpdateDie();
                break;
            case PlayerState.Moving:
                UpdateMoving();
                break;
            case PlayerState.Idle:
                UpdateIdle();
                break;
        }
    }


    void OnMouseClicked(Define.MouseEvent evt)
    {

        if(_state == PlayerState.Die)
        {
            return;
        }

        //Debug.Log(Input.mousePosition); // Screen
        //Debug.Log(Camera.main.ScreenToViewportPoint(Input.mousePosition)); // Viewport


        // 마우스 위치의 x, y, near 거리를 넣어주면 World
        //Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
        //Vector3 dir = mousePos - Camera.main.transform.position; // 카메라에서 화면까지 방향 벡터 구하기
        //dir = dir.normalized;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(Camera.main.transform.position, ray.direction * 100.0f, Color.red, 1.0f);

        //int mask = (1 << 6);
        LayerMask mask = LayerMask.GetMask("Wall") | LayerMask.GetMask("Monster");

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100.0f, mask))
        {
            _destPos = hit.point;
            _state = PlayerState.Moving;
        }
    }

    //void OnRunEvent()
    //{
    //    Debug.Log("뚜벅뚜벅");
    //}
}
