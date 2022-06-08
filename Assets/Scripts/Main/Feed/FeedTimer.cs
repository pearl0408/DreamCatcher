using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeedTimer : MonoBehaviour
{
    //���� �ð��� ����ϰ� �����ִ� Ŭ����

    [Header("Feed Timer")]
    [SerializeField] private float feedTime;    //���� �⺻ �ð�
    [SerializeField] private float leftTime;   //���� ���� �ð�(����: ��)
    [SerializeField] private System.DateTime startTime;   //���� ���� �ð�
    [SerializeField] private System.DateTime currentTime;   //���� �ð�

    TimerData saveTimer;    //Ÿ�̸� ������ ����

    [Space]
    [Header("Feed Text")]
    [SerializeField] private Text timerText;      //Ÿ�̸� �ؽ�Ʈ


    private bool isSelected;     //���� ���� ���� ����

    public GameObject bird;     //*�� �̹��� ���ϴ� ������ �� Ȱ��ȭ�ϴ� �Լ� �������ҵ�

    void Start()
    {
        this.isSelected = this.gameObject.GetComponent<FeedManager>().GetIsFeedSelected(); //���� ���� ���� ������
        if (isSelected) //���õ� ���̰� �ִٸ�
        {
            GetFeedLeftTime();  //���� ���� �ð� ���
        }    

    }

    void Update()
    {
        if (isSelected)     //���õ� ���̰� �ִٸ�
        {
            if (!timerText.gameObject.activeSelf)   //���� Ÿ�̸� �ؽ�Ʈ�� ��Ȱ��ȭ �Ǿ� �ִٸ�
            {
                timerText.gameObject.SetActive(true); //�ؽ�Ʈ Ȱ��ȭ
            }

            if (leftTime > 1)   //���� �ð��� 0�� �ƴ϶��(�� ��ٷ��� �Ѵٸ�)
            {
                leftTime -= Time.deltaTime; //�ʸ��� ���� �ð� ����

                //���� �ð����� ��, ��, �� ���
                int hour = (int)leftTime / 3600; //��
                float left = leftTime % 3600;  //�ð��� ������ ���� �ð�
                int minute = (int)left / 60; //��  
                left = left % 60;   //���� ������ ���� �ð�
                int second = (int)left; //��

                Mathf.Floor(second).ToString();  //�� �Ҽ��� ������
                timerText.text = string.Format("{0:00}:{1:00}:{2:00}", hour, minute, second);   //�ؽ�Ʈ ���(��:��:��)�� ���
            }
            else   //���� �ð��� 0 ���϶��(�ð��� ��� �����ٸ�)
            {
                leftTime = 0f;
                isSelected = false;
                SaveFeedSaveDate(isSelected, System.DateTime.Now.ToString(), 0f);

                int feedNum = this.gameObject.GetComponent<FeedManager>().GetSelectedFeedNum();     //�ڽ��� ������ȣ�� ������
                this.gameObject.GetComponent<FeedRackMatch>().SetInactiveRackFeed(feedNum);    //������ȣ ���� ��Ȱ��ȭ

                bird.gameObject.SetActive(true);    //�� Ȱ��ȭ(*�� �����ϴ� Ŭ���� ���� ���� �Լ��� ȣ���ϵ��� ������ ����(�̹��� �����ؼ� Ȱ��ȭ��))
                timerText.gameObject.SetActive(false); //Ÿ�̸� �ؽ�Ʈ ��Ȱ��ȭ
                this.gameObject.GetComponent<FeedPanel>().ActiveSpecialFeedPanel(false);  //Ư�� ���� ����â�� �����ִٸ� ��Ȱ��ȭ
            }
        }
    }

    public void SettingFeedTime()
    {
        //���� ���� �ҿ� �ð��� �����ϴ� �Լ�(�������� ������)

        List<Dictionary<string, object>> data_birdInfo = CSVParser.ReadFromFile("BirdInfo");  //���� �����͸� ������ 
        int selectedBirdNum = GameObject.FindGameObjectWithTag("FeedManager").GetComponent<FeedManager>().GetSelectedBirdNum();    //�� ��ȣ�� �ҷ���

        int birdStartTime = int.Parse(data_birdInfo[selectedBirdNum]["starttime"].ToString());  //�������� ���� ���� �ð� �����͸� ������
        int birdEndTime = int.Parse(data_birdInfo[selectedBirdNum]["endtime"].ToString());  //�������� ���� �� �ð� �����͸� ������

        int randomTime = Random.Range(birdStartTime, birdEndTime + 1);    //���� �ҿ� �ð��� ����

        feedTime = leftTime = randomTime;   //���� �ð��� ���� �ð����� ����
    }

    public void SetFeedStartTime()
    {
        //Ÿ�̸� ���� �ð� ����

        this.startTime = System.DateTime.Now;    //���� �ð� ������
        string saveStartTime = startTime.ToString();
        SaveFeedSaveDate(isSelected, saveStartTime, feedTime);
    }

    public void SetIsFeedSelected(bool TorF)
    {
        //���� ���� ���θ� �����ϴ� �Լ�

        this.isSelected = TorF;
    }

    private void GetFeedLeftTime()
    {
        //���� ���� �ð� ����ϴ� �Լ�

        this.currentTime = System.DateTime.Now;    //���� �ð� ����

        System.TimeSpan timeDif = currentTime - startTime; //���� �ð��� ���� �ð��� �� ����(���̸� ���� �󸶳� ��������)
        float difSeconds = (float)timeDif.TotalSeconds; //���� �ð��� �ʷ� ��ȯ

        leftTime = feedTime - difSeconds;   //���� ���� �ð� ���
    }

    public void UseSpecialFeed(float decreaseTime)
    {
        //Ư�� ���� ��� �Լ�

        this.leftTime -= decreaseTime;
    }


    //*�� �� �Լ��� JSON �Լ��� �־���ϳ�..
    public void SaveFeedSaveDate(bool _isSelected, string _startTime, float _savedFeedTime)
    {
        saveTimer = new TimerData(_isSelected, _startTime, _savedFeedTime);
        GameObject.FindWithTag("GameManager").GetComponent<TimerJSON>().DataSaveText<TimerData>(saveTimer);  //Ÿ�̸� ���� �ð� ����
    }

    public void LoadFeedSaveData()
    {
        saveTimer = GameObject.FindWithTag("GameManager").GetComponent<TimerJSON>().GetTimerData();   //���̺� ���Ͽ� ����� Ÿ�̸� �����͸� ������
        this.GetComponent<FeedManager>().SetIsFeedSelected(saveTimer.isExisted);    //���̺������� ���� ���θ� 
        this.startTime = System.Convert.ToDateTime(saveTimer.startTime);    //���̺� ������ ���� �ð��� ������
        this.feedTime = saveTimer.savedFeedTime;
    }

}
