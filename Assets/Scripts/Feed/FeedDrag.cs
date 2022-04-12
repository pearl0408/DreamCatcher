using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FeedDrag : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    //드래그할 오브젝트(먹이)에 컴포넌트로 넣을 클래스

    private static Vector2 defaultPosition;  //드롭하면 다시 보낼 원위치 변수
    [SerializeField] private bool isTriggering;    //횟대와 충돌 중인지 여부



    public void Start()
    {
        isTriggering = false;
    }

    public void SetIsTriggering(bool TorF)
    {
        //횟대 변수를 설정하는 함수

        this.isTriggering = TorF;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //드래그를 시작할 때의 함수

        defaultPosition = this.transform.position;  //처음 위치 저장
    }

    public void OnDrag(PointerEventData eventData)
    {
        //드래그 중일 때의 함수
        Vector2 currentPos = Input.mousePosition;   //마우스 포지션을 따라 오브젝트 이동
        this.transform.position = currentPos;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //드래그가 끝났을 때의 함수
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (isTriggering)
        {
            //횟대와 충돌 중이라면
            int feedNum = this.gameObject.GetComponent<FeedInfo>().GetFeedNumber();     //자신의 고유번호를 가져옴
            GameObject.FindGameObjectWithTag("FeedManager").GetComponent<FeedRackMatch>().SelectFeed(feedNum);    //고유번호 먹이 활성화
        }

        this.transform.position = defaultPosition;      //원위치로 돌아가기
    }
}
