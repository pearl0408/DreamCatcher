using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FeedDrag : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    //드래그할 오브젝트(먹이)에 컴포넌트로 넣을 클래스

    private static Vector2 defaultPosition;  //드롭하면 다시 보낼 원위치 변수
    [SerializeField]  private bool isHitting;    //히트 중인지 여부(주변에 횟대가 있는지 여부)



    public void Start()
    {
        isHitting = false;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //드래그를 시작할 때, 처음 위치 저장
        defaultPosition = this.transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        //드래그 중일 때, 마우스 포지션을 따라 오브젝트 이동
        Vector2 currentPos = Input.mousePosition;   //*마우스 말고 터치도 되는지 나중에 확인 필요
        this.transform.position = currentPos;

        RaycastHit2D hit = Physics2D.Raycast(currentPos, Vector2.zero, 300f);   //마지막 터치 좌표의 히트 (*잘 안 놓아지는 먹이 수정)
        if (hit.collider != null)   //히트 되었다면
        {
            Debug.Log("히트됨");
            if (hit.collider.gameObject.tag == "Rack")
            {
                Debug.Log(currentPos);
                isHitting = true;
            }
        }
        else
        {
            isHitting = false;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //드래그가 끝났을 때, 먹이 놓고 원위치로 돌아가기
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (isHitting)
        {
            //히트되었다면(마지막 포인트 주변에 횟대가 있다면)
            int feedNum = this.gameObject.GetComponent<FeedInfo>().GetFeedNumber();     //자신의 고유번호를 가져옴
            GameObject.FindGameObjectWithTag("FeedManager").GetComponent<FeedRackMatch>().SelectFeed(feedNum);    //고유번호 오브젝트 활성화
        }

        this.transform.position = defaultPosition;      //원위치로 돌아가기
    }
}
