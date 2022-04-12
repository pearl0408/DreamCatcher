using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedTimer : MonoBehaviour
{
    //먹이 시간을 계산하고 보여주는 클래스(횟대에 놓인 먹이에 넣을 클래스)

    [Header("Feed Time")]
    [SerializeField] private float feedTime;    //먹이 기본 시간
    [SerializeField] private float leftTime;   //먹이 남은 시간(단위: 초)
    [SerializeField] private System.DateTime startTime;   //먹이 시작 시간
    [SerializeField] private System.DateTime currentTime;   //현재 시간


    private bool isSelected;     //먹이 선택 여부 변수
    private GameObject feedManager;
    private GameObject feedText;

    void Start()
    {
        feedManager = GameObject.FindGameObjectWithTag("FeedManager");
        feedText = GameObject.FindGameObjectWithTag("FeedManager");
        UpdateIsFeedSelected(); //먹이 선택여부 가져옴

        feedTime = leftTime = 10f; //임시로 10초로 설정 *데이터 파싱으로 변경할 예정(처음에는 남은 시간==먹이 기본 시간)

        if (isSelected) //선택된 먹이가 있다면 
        {
            GetFeedStartTime();     //먹이 시작 시간을 불러옴 (없다면 먹이 선택할 때 재설정)
            GetFeedLeftTime();      //타이머 남은 시간을 계산함
        }
    }

    void Update()
    {
        //isSelected = feedManager.GetComponent<FeedManager>().IsFeedSelected(); //먹이 선택 여부 가져옴

        //선택된 먹이가 있다면
        if (isSelected)
        {
            //남은 시간이 음수가 아니라면(더 기다려야 한다면)
            if (leftTime > 1)
            {
                leftTime -= Time.deltaTime; //남은 시간 감소
                feedText.GetComponent<FeedText>().SetTimerText(Mathf.Floor(leftTime).ToString());    //타이머 텍스트 갱신 *시, 분, 초 따라 다르게 수정할 예정
            }
            else   //남은 시간이 음수라면(시간이 모두 지났다면)
            {
                leftTime = 0f;
                isSelected = false; //이걸 selected 말고 선택은 되었지만 깃털은 회수 안 된 상태 변수로..
            }
        }
    }

    public void SetFeedStartTime()
    {
        //먹이 시작 시간 설정하는 함수

        this.startTime = System.DateTime.Now;    //현재 시간
        PlayerPrefs.SetString("startTime", startTime.ToString());   //시작 시간 저장 *이후 csv 파싱으로 해야하나?
        PlayerPrefs.Save();
    }

    public void GetFeedStartTime()
    {
        //먹이 시작 시간 불러오는 함수

        string savedTime = PlayerPrefs.GetString("startTime", "");  //저장된 시간 불러옴
        this.startTime = System.Convert.ToDateTime(savedTime);
        PlayerPrefs.Save();
    }

    public void UpdateIsFeedSelected()
    {
        //먹이 선택 여부를 갱신하는 함수

        this.isSelected = feedManager.GetComponent<FeedManager>().IsFeedSelected(); //먹이 선택 여부 가져옴
    }

    private void GetFeedLeftTime()
    {
        //먹이 남은 시간 계산하는 함수

        this.currentTime = System.DateTime.Now;    //현재 시간 설정
        System.TimeSpan timeDif = currentTime - startTime; //시작 시간과 현재 시간의 차 구함(먹이를 놓고 얼마나 지났는지)

        float difSeconds = (float)timeDif.TotalSeconds; //먹이를 놓고 지난 시간을 초로 변환
        leftTime = feedTime - difSeconds;   //먹이 남은 시간 계산
    }
}
