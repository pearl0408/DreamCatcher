using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpecialFeed : MonoBehaviour
{
    //스페셜 먹이 개수를 관리하고 사용하는 클래스

    [Header("[Special Feed]")]
    [SerializeField] private int feedCount;    //특제 먹이 개수
    [SerializeField] private int selectCount;    //선택한 먹이 수
    [SerializeField] private float decreaseTime;   //감소시키는 시간

    [SerializeField] private TopBarContainer curPlayerData;   //상품 정보

    [Space]
    [Header("[Feed Text]")]
    [SerializeField] private Text countText;      //먹이 개수 텍스트

    void Start()
    {
        curPlayerData = GameManager.instance.loadTopBarData;    //플레이어의 상단바 데이터 정보를 가져옴
        feedCount = curPlayerData.dataList[2].dataNumber;  //특제 먹이 개수를 가져옴
        selectCount = 0;
        decreaseTime = 300;   //*특제먹이 감소 시간은 추후 수정할 예정

        countText.text = selectCount + "개";
    }

    public void LeftButton()
    {
        //특제 먹이 선택 패널에서 선택 개수 감소 함수

        if (selectCount > 1)
        {
            selectCount--;
            countText.text = selectCount + "개";
        }
    }

    public void RightButton()
    {
        //특제 먹이 선택 패널에서 선택 개수 증가 함수

        if (selectCount < feedCount)
        {
            selectCount++;
            countText.text = selectCount + "개";
        }
    }

    public void selectSpecialFeed()
    {
        if (feedCount >= selectCount)
        {
            float decrease = (float)selectCount * decreaseTime;     //특제 먹이 사용으로 감소하는 시간 계산
            this.gameObject.GetComponent<FeedTimer>().UseSpecialFeed(decrease);     //특제 먹이 사용(남은 시간 감소)

            feedCount = feedCount - selectCount;    //특제 먹이 개수 갱신
            curPlayerData.dataList[2].dataNumber = feedCount;
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<TopBarJSON>().DataSaveText(curPlayerData);   //변경사항 json으로 저장
            GameObject.FindGameObjectWithTag("TopBar").GetComponent<TopBarText>().UpdateText();   //상단바 업데이트

            selectCount = 0;        //선택한 먹이 개수 갱신
            countText.text = selectCount + "개";

            GameObject.FindGameObjectWithTag("GameManager").GetComponent<TopBarText>().SetSpecialFeedText(feedCount);   //상단바 특제 먹이 개수 갱신
        }
    }
}
