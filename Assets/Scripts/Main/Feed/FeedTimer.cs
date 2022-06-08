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

    TimerData saveTimer;    //타이머 데이터 변수

    [Space]
    [Header("Feed Text")]
    [SerializeField] private Text timerText;      //타이머 텍스트


    private bool isSelected;     //먹이 선택 여부 변수

    public GameObject bird;     //*새 이미지 정하는 곳에서 새 활성화하는 함수 만들어야할듯

    void Start()
    {
        this.isSelected = this.gameObject.GetComponent<FeedManager>().GetIsFeedSelected(); //먹이 선택 여부 가져옴
        if (isSelected) //선택된 먹이가 있다면
        {
            GetFeedLeftTime();  //먹이 남은 시간 계산
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
                leftTime = 0f;
                isSelected = false;
                SaveFeedSaveDate(isSelected, System.DateTime.Now.ToString(), 0f);

                int feedNum = this.gameObject.GetComponent<FeedManager>().GetSelectedFeedNum();     //자신의 고유번호를 가져옴
                this.gameObject.GetComponent<FeedRackMatch>().SetInactiveRackFeed(feedNum);    //고유번호 먹이 비활성화

                bird.gameObject.SetActive(true);    //새 활성화(*새 생성하는 클래스 따로 만들어서 함수로 호출하도록 수정할 예정(이미지 수정해서 활성화로))
                timerText.gameObject.SetActive(false); //타이머 텍스트 비활성화
                this.gameObject.GetComponent<FeedPanel>().ActiveSpecialFeedPanel(false);  //특제 먹이 선택창이 켜져있다면 비활성화
            }
        }
    }

    public void SettingFeedTime()
    {
        //새에 따라서 소요 시간을 설정하는 함수(도감에서 가져옴)

        List<Dictionary<string, object>> data_birdInfo = CSVParser.ReadFromFile("BirdInfo");  //도감 데이터를 가져옴 
        int selectedBirdNum = GameObject.FindGameObjectWithTag("FeedManager").GetComponent<FeedManager>().GetSelectedBirdNum();    //새 번호를 불러옴

        int birdStartTime = int.Parse(data_birdInfo[selectedBirdNum]["starttime"].ToString());  //도감에서 새의 시작 시간 데이터를 가져옴
        int birdEndTime = int.Parse(data_birdInfo[selectedBirdNum]["endtime"].ToString());  //도감에서 새의 끝 시간 데이터를 가져옴

        int randomTime = Random.Range(birdStartTime, birdEndTime + 1);    //랜덤 소요 시간을 정함

        feedTime = leftTime = randomTime;   //랜덤 시간을 먹이 시간으로 설정
    }

    public void SetFeedStartTime()
    {
        //타이머 시작 시간 설정

        this.startTime = System.DateTime.Now;    //현재 시간 가져옴
        string saveStartTime = startTime.ToString();
        SaveFeedSaveDate(isSelected, saveStartTime, feedTime);
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
        float difSeconds = (float)timeDif.TotalSeconds; //지난 시간을 초로 변환

        leftTime = feedTime - difSeconds;   //먹이 남은 시간 계산
    }

    public void UseSpecialFeed(float decreaseTime)
    {
        //특제 먹이 사용 함수

        this.leftTime -= decreaseTime;
    }


    //*이 두 함수는 JSON 함수에 있어야하나..
    public void SaveFeedSaveDate(bool _isSelected, string _startTime, float _savedFeedTime)
    {
        saveTimer = new TimerData(_isSelected, _startTime, _savedFeedTime);
        GameObject.FindWithTag("GameManager").GetComponent<TimerJSON>().DataSaveText<TimerData>(saveTimer);  //타이머 시작 시간 저장
    }

    public void LoadFeedSaveData()
    {
        saveTimer = GameObject.FindWithTag("GameManager").GetComponent<TimerJSON>().GetTimerData();   //세이브 파일에 저장된 타이머 데이터를 가져옴
        this.GetComponent<FeedManager>().SetIsFeedSelected(saveTimer.isExisted);    //세이브파일의 선택 여부를 
        this.startTime = System.Convert.ToDateTime(saveTimer.startTime);    //세이브 파일의 시작 시간을 가져옴
        this.feedTime = saveTimer.savedFeedTime;
    }

}
