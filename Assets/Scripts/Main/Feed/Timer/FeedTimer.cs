using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeedTimer : MonoBehaviour
{
    //���� �ð��� ����ϰ� �����ִ� Ŭ����

    [Header("[Feed Timer]")]
    [SerializeField] private float defaultTime;    //���� �⺻ �ð�(����: ��)
    [SerializeField] private float leftTime;   //���� ���� �ð�(����: ��)
    private System.DateTime startTime;   //���� ���� �ð�
    private System.DateTime currentTime;   //���� �ð�
    private bool isSelected;     //���� ���� ���� ����

    [Space]
    [Header("[Feed Text]")]
    public Text timerText;      //Ÿ�̸� �ؽ�Ʈ

    void Start()
    {
        isSelected = this.gameObject.GetComponent<FeedManager>().GetIsFeedSelected(); //���� ���� ���� ������
        if (isSelected) //���õ� ���̰� �ִٸ�
        {
            leftTime = GetFeedLeftTime();  //���� ���� �ð� ���
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
                //�ʱ�ȭ
                leftTime = 0f;      //���� �ð� 0�ʷ� �ʱ�ȭ
                isSelected = false;     //���� ���õ��� �������� �ʱ�ȭ
                SaveTimerData();   //�ʱ�ȭ ���� ����

                //Ȱ��ȭ/��Ȱ��ȭ ����
                int feedNum = this.gameObject.GetComponent<FeedManager>().GetSelectedFeedNum();     //���� ������ ��ȣ�� ������
                this.gameObject.GetComponent<FeedRackMatch>().SetInactiveRackFeed(feedNum);    //���� ���� ��Ȱ��ȭ
                timerText.gameObject.SetActive(false); //Ÿ�̸� �ؽ�Ʈ ��Ȱ��ȭ
                this.gameObject.GetComponent<FeedPanel>().ActiveSpecialFeedPanel(false);  //Ư�� ���� ����â�� �����ִٸ� ��Ȱ��ȭ
                this.gameObject.GetComponent<BirdImage>().ActiveBirdObject();   //�� ������Ʈ Ȱ��ȭ
            }
        }
    }
   
    public void SetFeedDefaultTime()
    {
        //���� ���� �ҿ� �ð��� �����ϴ� �Լ�(�������� ������ �ð��� �������� ���� ����)

        List<Dictionary<string, object>> data_birdInfo = CSVParser.ReadFromFile("BirdInfo");  //���� �����͸� ������ 
        int selectedBirdNum = GameObject.FindGameObjectWithTag("FeedManager").GetComponent<FeedManager>().GetSelectedBirdNum();    //���� ���õ� �� ��ȣ�� �ҷ���

        int birdStartTime = int.Parse(data_birdInfo[selectedBirdNum]["starttime"].ToString());  //�������� �ش� ���� ���� �ð� �����͸� ������
        int birdEndTime = int.Parse(data_birdInfo[selectedBirdNum]["endtime"].ToString());  //�������� �ش� ���� �� �ð� �����͸� ������
        int randomTime = Random.Range(birdStartTime, birdEndTime + 1);    //�������� �ҿ� �ð��� ����

        defaultTime = leftTime = randomTime;   //���� �ҿ� �ð��� ���� �ð����� ����
    }

    public void SetFeedStartTime()
    {
        //Ÿ�̸� ���� �ð� ����

        startTime = System.DateTime.Now;    //Ÿ�̸� ���� �ð��� ���� �ð����� ����
    }

    public void SetIsFeedSelected(bool TorF)
    {
        //���� ���� ���θ� �����ϴ� �Լ�

        isSelected = TorF;
    }

    private float GetFeedLeftTime()
    {
        //���� ���� �ð� ����ϴ� �Լ�

        currentTime = System.DateTime.Now;    //���� �ð� ����

        System.TimeSpan timeDif = currentTime - startTime; //���� �ð��� ���� �ð��� �� ����(���̸� ���� �󸶳� ��������)
        float difSeconds = (float)timeDif.TotalSeconds; //���� �ð��� �ʷ� ��ȯ
        float left = defaultTime - difSeconds;   //���� ���� �ð� ���

        return left;    //���� ���� �ð� ��ȯ
    }

    public void UseSpecialFeed(float decreaseTime)
    {
        //Ư�� ���� ��� �Լ�

        this.leftTime -= decreaseTime;
    }

    public void SaveTimerData()
    {
        //���� �����Ͱ�(���� ���� ����, Ÿ�̸� ���� �ð�, ���� �⺻ �ð�)���� Ÿ�̸� �����͸� �����ϴ� �Լ�

        TimerData saveTimer = new TimerData(isSelected, startTime.ToString(), defaultTime); //���� �����ͷ� timerData ��ü ����
        GameObject.FindWithTag("GameManager").GetComponent<TimerJSON>().DataSaveText<TimerData>(saveTimer);  //Ÿ�̸� ������ ����
    }

    public void LoadTimerData()
    {
        //����� ������ Ȯ��

        TimerData saveTimer = GameObject.FindWithTag("GameManager").GetComponent<TimerJSON>().GetTimerData();   //���̺� ���Ͽ� ����� Ÿ�̸� �����͸� ������
        this.GetComponent<FeedManager>().SetIsFeedSelected(saveTimer.isExisted);    //���̺������� ���� ���η� ������
        this.startTime = System.Convert.ToDateTime(saveTimer.startTime);    //���̺� ������ ���� �ð����� ������
        this.defaultTime = saveTimer.savedDefaultTime;  //���̺� ������ ���� �⺻ �ð����� ������
    }

}
