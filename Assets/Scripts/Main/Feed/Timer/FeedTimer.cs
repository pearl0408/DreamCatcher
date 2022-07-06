using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeedTimer : MonoBehaviour
{
    //먹이 시간을 계산하고 보여주는 클래스

    [Header("[Feed Timer]")]
    [SerializeField] private float defaultTime;    //먹이 기본 시간(단위: 초)
    [SerializeField] private float leftTime;   //먹이 남은 시간(단위: 초)
    [SerializeField] private float decreaseTime;    //특제 먹이 사용으로 감소된 시간(단위: 초)
    private System.DateTime startTime;   //먹이 시작 시간
    private System.DateTime currentTime;   //현재 시간
    private bool isSelected;     //먹이 선택 여부 변수

    [Space]
    [Header("[Feed Text]")]
    public Text timerText;      //타이머 텍스트

    void Start()
    {
        LoadTimerData();    //저장된 데이터를 읽어옴

        if (isSelected) //선택된 먹이가 있다면
        {
            leftTime = GetFeedLeftTime();  //먹이 남은 시간 계산
        }    

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

                //남은 시간으로 시, 분, 초 계산
                int hour = (int)leftTime / 3600; //시
                float left = leftTime % 3600;  //시간을 나누고 남은 시간
                int minute = (int)left / 60; //분  
                left = left % 60;   //분을 나누고 남은 시간
                int second = (int)left; //초

                Mathf.Floor(second).ToString();  //초 소수점 버리기
                timerText.text = string.Format("{0:00}:{1:00}:{2:00}", hour, minute, second);   //텍스트 양식(시:분:초)로 출력
            }
            else   //남은 시간이 0 이하라면(시간이 모두 지났다면)
            {
                //초기화
                leftTime = 0f;      //남은 시간 0초로 초기화
                isSelected = false;     //먹이 선택되지 않음으로 초기화
                SaveTimerData();   //초기화 내용 저장

                //활성화/비활성화 정리
                int feedNum = this.gameObject.GetComponent<FeedManager>().GetSelectedFeedNum();     //놓인 먹이의 번호를 가져옴
                this.gameObject.GetComponent<FeedRackMatch>().SetInactiveRackFeed(feedNum);    //놓인 먹이 비활성화
                timerText.gameObject.SetActive(false); //타이머 텍스트 비활성화
                this.gameObject.GetComponent<FeedPanel>().ActiveSpecialFeedPanel(false);  //특제 먹이 선택창이 켜져있다면 비활성화
                this.gameObject.GetComponent<BirdSelect>().ActiveBirdObject();   //새 오브젝트 활성화
            }
        }
    }
   
    public void SetFeedDefaultTime()
    {
        //새에 따라서 소요 시간을 설정하는 함수(도감에서 가져온 시간을 기준으로 랜덤 설정)

        List<Dictionary<string, object>> data_birdInfo = CSVParser.ReadFromFile("BirdInfo");  //도감 데이터를 가져옴 
        int selectedBirdNum = GameObject.FindGameObjectWithTag("FeedManager").GetComponent<FeedManager>().GetSelectedBirdNum();    //랜덤 선택된 새 번호를 불러옴

        int birdStartTime = int.Parse(data_birdInfo[selectedBirdNum]["starttime"].ToString());  //도감에서 해당 새의 시작 시간 데이터를 가져옴
        int birdEndTime = int.Parse(data_birdInfo[selectedBirdNum]["endtime"].ToString());  //도감에서 해당 새의 끝 시간 데이터를 가져옴
        int randomTime = Random.Range(birdStartTime, birdEndTime + 1);    //랜덤으로 소요 시간을 정함

        defaultTime = leftTime = randomTime;   //랜덤 소요 시간을 먹이 시간으로 설정
    }

    public void SetFeedStartTime()
    {
        //타이머 시작 시간 설정

        startTime = System.DateTime.Now;    //타이머 시작 시간을 현재 시간으로 설정
    }

    public void SetIsFeedSelected(bool TorF)
    {
        //먹이 선택 여부를 갱신하는 함수

        isSelected = TorF;
    }

    private float GetFeedLeftTime()
    {
        //먹이 남은 시간 계산하는 함수

        currentTime = System.DateTime.Now;    //현재 시간 설정

        System.TimeSpan timeDif = currentTime - startTime; //시작 시간과 현재 시간의 차 구함(먹이를 놓고 얼마나 지났는지)
        float difSeconds = (float)timeDif.TotalSeconds; //지난 시간을 초로 변환
        float left = defaultTime - difSeconds;   //먹이 남은 시간 계산
        left -= decreaseTime;   //특제 먹이 사용으로 감소된 시간 차감

        return left;    //먹이 남은 시간 반환
    }

    public void UseSpecialFeed(float _decreaseTime)
    {
        //특제 먹이 사용 함수

        this.decreaseTime += _decreaseTime; //감소 시간 증가(누적 감소 시간)    
        this.leftTime -= _decreaseTime; //현재 남은 시간에 이번 감소 시간 차감

        SaveTimerData();    //데이터값 저장
    }

    public void SaveTimerData()
    {
        //현재 데이터값(먹이 선택 여부, 타이머 시작 시간, 먹이 기본 시간)으로 타이머 데이터를 저장하는 함수

        TimerData saveTimer = new TimerData(isSelected, startTime.ToString(), defaultTime, decreaseTime); //현재 데이터로 timerData 객체 생성
        GameObject.FindWithTag("GameManager").GetComponent<TimerJSON>().DataSaveText<TimerData>(saveTimer);  //타이머 데이터 저장
    }

    public void LoadTimerData()
    {
        //저장된 데이터 확인

        TimerData saveTimer = GameObject.FindWithTag("GameManager").GetComponent<TimerJSON>().GetTimerData();   //세이브 파일에 저장된 타이머 데이터를 가져옴
        this.GetComponent<FeedManager>().SetIsFeedSelected(saveTimer.isExisted);    //세이브파일의 선택 여부로 갱신함
        this.isSelected = saveTimer.isExisted;
        this.startTime = System.Convert.ToDateTime(saveTimer.startTime);    //세이브 파일의 시작 시간으로 갱신함
        this.defaultTime = saveTimer.savedDefaultTime;  //세이브 파일의 먹이 기본 시간으로 갱신함
        this.decreaseTime = saveTimer.decreaseTime; //세이브 파일의 감소 시간으로 갱신함
    }

    public float GetLeftTime()
    {
        //먹이 남은 시간을 반환하는 함수

        return this.leftTime;
    }
}
