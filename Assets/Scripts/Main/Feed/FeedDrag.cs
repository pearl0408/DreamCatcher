using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FeedDrag : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    //드래그할 오브젝트(먹이)에 컴포넌트로 넣을 클래스

    [Header("[Feed Drag]")]
    [SerializeField] private bool isTriggering;    //횟대와 충돌 중인지 여부
    private static Vector2 defaultPosition;  //드롭하면 다시 보낼 원위치 변수

    public void Start()
    {
        isTriggering = false;   //충돌중 여부 초기화
    }

    public void SetIsTriggering(bool TorF)
    {
        //횟대 충돌중 여부 변수를 설정하는 함수

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
        Vector2 currentPos = Input.mousePosition;   //마우스 포지션 값 가져옴
        this.transform.position = currentPos;       //마우스 포지션을 따라 오브젝트 이동
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //드래그가 끝났을 때의 함수

        if (isTriggering)   //횟대와 충돌 중이라면
        {
            //횃대 먹이 활성화
            int feedNum = this.gameObject.GetComponent<FeedInfo>().GetFeedNumber();     //드래그 중인 먹이의 번호를 가져옴
            GameObject.FindGameObjectWithTag("FeedManager").GetComponent<FeedRackMatch>().SelectFeed(feedNum);    //해당 번호의 횃대 먹이 활성화

            //새 종류 랜덤 설정
            int randomBird = GameObject.FindGameObjectWithTag("FeedManager").GetComponent<BirdSelect>().SelectBirdType(feedNum); //확률에 따라 랜덤으로 해당 먹이의 새를 정함
            GameObject.FindGameObjectWithTag("FeedManager").GetComponent<FeedManager>().SetFeedManager(true, feedNum, randomBird);    //FeedManager 변수 한 번에 설정(먹이 선택 여부, 선택된 먹이 번호, 랜덤으로 정해진 새 번호)
            GameObject.FindGameObjectWithTag("FeedManager").GetComponent<BirdSelect>().SelectBirdImage();    //새 오브젝트 이미지 변경(비활성화 상태)
            
            //먹이 시간 랜덤 설정 및 타이머 설정
            GameObject.FindGameObjectWithTag("FeedManager").GetComponent<FeedTimer>().SetFeedDefaultTime();    //새 먹이 시간 설정(랜덤)
            GameObject.FindGameObjectWithTag("FeedManager").GetComponent<FeedTimer>().SetFeedStartTime();   //타이머 시작 시간 설정
            GameObject.FindGameObjectWithTag("FeedManager").GetComponent<FeedTimer>().SetIsFeedSelected(true);  //타이머 시작(선택된 먹이 있음으로 설정)
            GameObject.FindGameObjectWithTag("FeedManager").GetComponent<FeedTimer>().SaveTimerData();   //타이머 데이터 저장(위에서 설정한 데이터 저장)
        }

        this.transform.position = defaultPosition;      //원위치로 돌아가기
    }
}
