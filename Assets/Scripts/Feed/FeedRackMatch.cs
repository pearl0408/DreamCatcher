using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FeedRackMatch : MonoBehaviour
{
    //먹이 드래그 이벤트와 횟대 먹이를 연결하는 클래스

    [Header("Feed Objects")]
    [SerializeField] private GameObject[] FeedObj;     //드래그 이벤트 추가할 먹이 오브젝트 배열
    [SerializeField] private GameObject[] RackFeedObj;     //횟대의 먹이 오브젝트 배열
    [SerializeField] private GameObject Feed_Panel;     //먹이 패널

    private int numberOfFeed;     //먹이 개수 
    private bool isSelected;     //먹이 선택 여부 변수
    //private int selectNum;     //선택한 먹이 번호
    private GameObject feedManager;
    private GameObject feedTimer;

    private void Start()
    {
        feedManager = GameObject.FindGameObjectWithTag("FeedManager");
        feedTimer = GameObject.FindGameObjectWithTag("FeedManager");

        numberOfFeed = feedManager.GetComponent<FeedManager>().GetNumberOfFeed();   //먹이 총 개수 가져옴
        isSelected = feedManager.GetComponent<FeedManager>().IsFeedSelected(); //먹이 선택 여부 가져옴

        for (int i = 0; i < numberOfFeed; i++)
        {
            SetFeedNum(FeedObj[i].gameObject, i);  //먹이 오브젝트에 고유 번호 지정

            //먹이 선택 버튼 이벤트 추가
            //먹이를 선택하면 1. 먹이 번호 가져옴, 2. 먹이를 횟대에 놓음
            //int index = i;          //먹이 번호 지정하는 인덱스(i로 바로 넣으면 오류남)
            //FeedObj[i].onClick.AddListener(delegate { GetFeedNum(index); SelectFeed(); });
            //
            //드래그 이벤트 추가
            //드래그 해서 지정 위치에 놓으면 1. 먹이 번호 가져옴, 2. 먹이를 횟대에 놓음
        }
    }


    private void SetFeedNum(GameObject obj, int num)
    {
        //먹이 오브젝트에 고유 번호 지정하는 함수

        obj.GetComponent<FeedInfo>().SetFeedNumber(num);
    }

/*    private void GetFeedNum(int num)
    {
        //먹이 오브젝트의 고유 번호 반환하는 함수

        this.selectNum = FeedObj[num].gameObject.GetComponent<FeedInfo>().GetFeedNumber();
    }*/

    public void SelectFeed(int feedNum)
    {
        //먹이를  선택하는 함수

        //int feedNum = selectNum;    //먹이 고유 번호 가져오기

        if (!isSelected)    //만약 선택된 먹이가 없다면
        {
            SetActiveRackFeed(feedNum);     //횟대 먹이 활성화
            isSelected = true;          
            feedManager.GetComponent<FeedManager>().SetIsFeedSelected(isSelected);  //먹이 선택 여부 갱신
            feedTimer.GetComponent<FeedTimer>().SetFeedStartTime();   //먹이 놓은 시간 설정

            SetInActiveFeedingPanel();  //패널 닫음
        }
    }

    private void SetActiveRackFeed(int num)
    {
        //횟대의 먹이를 활성화하는 함수

        RackFeedObj[num].SetActive(true);
    }

    private void SetInActiveFeedingPanel()
    {
        //먹이 선택 패널을 비활성화하는 함수

        Feed_Panel.SetActive(false);
    }
}
