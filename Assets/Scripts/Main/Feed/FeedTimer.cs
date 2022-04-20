using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeedTimer : MonoBehaviour
{
    //먹이 시간을 계산하고 보여주는 클래스

    [Header("Feed Timer")]
    [SerializeField] private float feedTime;    //먹이 기본 시간
    [SerializeField] private float leftTime;   //먹이 남은 시간(단위: 초)
    [SerializeField] private System.DateTime startTime;   //먹이 시작 시간
    [SerializeField] private System.DateTime currentTime;   //현재 시간

    [Space]
    [Header("Feed Text")]
    [SerializeField] private Text timerText;      //타이머 텍스트


    private bool isSelected;     //먹이 선택 여부 변수



    //*임시로 나타나는 새(이후 다른 클래스에서 새 고유번호에 따라 이미지 변경되도록 수정)
    //*여기서는 그 다른 클래스의 새 생성 함수만 호출할 것
    public GameObject bird;

    void Start()
    {
        this.isSelected = this.gameObject.GetComponent<FeedManager>().GetIsFeedSelected(); //먹이 선택 여부 가져옴
        if (isSelected) //선택된 먹이가 있다면
        {
            GetFeedLeftTime();  //먹이 남은 시간 계산
        }    

        feedTime = leftTime = 30f; //임시로 10초로 설정 *데이터 파싱으로 변경할 예정(처음에는 남은 시간==먹이 기본 시간)
    }

    void Update()
    {
        if (isSelected)     //선택된 먹이가 있다면
        {
            if (!timerText.gameObject.activeSelf)   //만약 타이머 텍스트가 비활성화 되어 있다면
            {
                timerText.gameObject.SetActive(true); //텍스트 활성화
            }

            if (leftTime > 1)   //남은 시간이 0이 아니라면(더 기다려야 한다면)
            {
                leftTime -= Time.deltaTime; //초마다 남은 시간 감소
                timerText.text = Mathf.Floor(leftTime).ToString();    //타이머 텍스트 갱신(소수점 버리기)
                //*데이터 연동하며 시, 분, 초로 나오게 수정할 예정)
            }
            else   //남은 시간이 0 이하라면(시간이 모두 지났다면)
            {
                leftTime = 10f;     //남은 시간 초기화(임시)(*데이터 연동할 때 남은 시간 재설정 함수 만들어서 먹이 놓을 때 호출)
                isSelected = false;

                int feedNum = this.gameObject.GetComponent<FeedManager>().GetSelectedFeedNum();     //자신의 고유번호를 가져옴
                this.gameObject.GetComponent<FeedRackMatch>().SetInactiveRackFeed(feedNum);    //고유번호 먹이 비활성화

                bird.gameObject.SetActive(true);    //새 활성화(*새 생성하는 클래스 따로 만들어서 함수로 호출하도록 수정할 예정(이미지 수정해서 활성화로))
                timerText.gameObject.SetActive(false); //타이머 텍스트 비활성화
                this.gameObject.GetComponent<FeedPanel>().ActiveSpecialFeedPanel(false);  //특제 먹이 선택창이 켜져있다면 비활성화
            }
        }
    }

    public void SetFeedStartTime()
    {
        //타이머 시작 시간 설정

        this.startTime = System.DateTime.Now;    //현재 시간 가져옴
        PlayerPrefs.SetString("startTime", startTime.ToString());   //시작 시간 저장 *이후 csv 파싱으로 해야하나?
        PlayerPrefs.Save();
    }

    public void SetIsFeedSelected(bool TorF)
    {
        //먹이 선택 여부를 갱신하는 함수

        this.isSelected = TorF;
    }

    private void GetFeedLeftTime()
    {
        //먹이 남은 시간 계산하는 함수

        this.currentTime = System.DateTime.Now;    //현재 시간 설정
        System.TimeSpan timeDif = currentTime - startTime; //시작 시간과 현재 시간의 차 구함(먹이를 놓고 얼마나 지났는지)

        float difSeconds = (float)timeDif.TotalSeconds; //먹이를 놓고 지난 시간을 초로 변환
        leftTime = feedTime - difSeconds;   //먹이 남은 시간 계산
    }

    public void UseSpecialFeed(float decreaseTime)
    {
        //특제 먹이 사용 함수

        this.leftTime -= decreaseTime;
    }

}
