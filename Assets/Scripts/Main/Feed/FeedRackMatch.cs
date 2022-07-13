using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FeedRackMatch : MonoBehaviour
{
    //먹이 드래그 이벤트와 횟대 먹이를 연결하는 클래스

    [Header("[Feed Objects]")]
    public GameObject[] FeedObj;     //드래그 이벤트 추가할 먹이 오브젝트 배열
    public GameObject[] RackFeedObj;     //횟대의 먹이 오브젝트 배열


    private void Start()
    {
        int numberOfFeed = 4;   //먹이 총 개수
        for (int i = 0; i < numberOfFeed; i++)
        {
            FeedObj[i].gameObject.GetComponent<FeedInfo>().SetFeedNumber(i);    //먹이 오브젝트에 고유 번호 지정
        }
    }

    public void SelectFeed(int feedNum)
    {
        //먹이를 선택하는 함수

        bool isSelected = this.gameObject.GetComponent<FeedManager>().GetIsFeedSelected(); //먹이 선택 여부 가져옴
        if (!isSelected)    //만약 선택된 먹이가 없다면
        {
            SetActiveRackFeed(feedNum);     //횟대 먹이 활성화        
            this.gameObject.GetComponent<FeedPanel>().ActiveFeedPanel(false);    //먹이 패널을 닫음
        }
    }

    private void SetActiveRackFeed(int num)
    {
        //횟대의 먹이를 활성화하는 함수

        RackFeedObj[num].SetActive(true);
    }

    public void SetInactiveRackFeed(int num)
    {
        //횟대의 먹이를 비활성화 하는 함수

        RackFeedObj[num].SetActive(false);
    }
}
