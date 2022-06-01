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

    [Space]
    [Header("Feed Text")]
    [SerializeField] private Text timerText;      //Ÿ�̸� �ؽ�Ʈ


    private bool isSelected;     //���� ���� ���� ����

    public GameObject bird;     //*�� �̹��� ���ϴ� ������ �� Ȱ��ȭ�ϴ� �Լ� �������ҵ�

    void OnEnable()
    {
        this.isSelected = this.gameObject.GetComponent<FeedManager>().GetIsFeedSelected(); //���� ���� ���� ������
        if (isSelected) //���õ� ���̰� �ִٸ�
        {
            GetFeedLeftTime();  //���� ���� �ð� ���
        }    

        feedTime = leftTime = 30f; //�ӽ÷� 10�ʷ� ���� *������ �Ľ����� ������ ����(ó������ ���� �ð�==���� �⺻ �ð�)
    }

    void Update()
    {
        if (isSelected)     //���õ� ���̰� �ִٸ�
        {
            if (!timerText.gameObject.activeSelf)   //���� Ÿ�̸� �ؽ�Ʈ�� ��Ȱ��ȭ �Ǿ� �ִٸ�
            {
                //SettingFeedTime();  //���� �ð� ����
                timerText.gameObject.SetActive(true); //�ؽ�Ʈ Ȱ��ȭ
            }

            if (leftTime > 1)   //���� �ð��� 0�� �ƴ϶��(�� ��ٷ��� �Ѵٸ�)
            {
                leftTime -= Time.deltaTime; //�ʸ��� ���� �ð� ����
                //timerText.text = Mathf.Floor(leftTime).ToString();    //Ÿ�̸� �ؽ�Ʈ ����(�Ҽ��� ������)
                //*������ �����ϸ� ��, ��, �ʷ� ������ ������ ����)

                //��:��:�ʷ� ������
                int hour = (int)leftTime / 3600; //��
                float left = leftTime % 3600;  //�ð��� ������ ���� �ð�
                int minute = (int)left / 60; //��  
                left = left % 60;   //���� ������ ���� �ð�
                int second = (int)left; //��

                Mathf.Floor(second).ToString();  //�� �Ҽ��� ������

                if (minute < 10)
                {
                    timerText.text = hour + ":0" + minute + ":" + second;
                }
                else
                {
                    timerText.text = hour + ":" + minute + ":" + second;
                }

            }
            else   //���� �ð��� 0 ���϶��(�ð��� ��� �����ٸ�)
            {
                leftTime = 10f;     //���� �ð� �ʱ�ȭ(�ӽ�)(*������ ������ �� ���� �ð� �缳�� �Լ� ���� ���� ���� �� ȣ��)
                isSelected = false;

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
        Debug.Log("startTime: " + birdStartTime);
        int birdEndTime = int.Parse(data_birdInfo[selectedBirdNum]["endtime"].ToString());  //�������� ���� �� �ð� �����͸� ������
        Debug.Log("endTime: " + birdEndTime);

        int randomTime = Random.Range(birdStartTime, birdEndTime + 1);    //���� �ҿ� �ð��� ����
        Debug.Log("rabdomTime: " + randomTime);

        feedTime = leftTime = randomTime;   //���� �ð��� ����
    }

    public void SetFeedStartTime()
    {
        //Ÿ�̸� ���� �ð� ����

        this.startTime = System.DateTime.Now;    //���� �ð� ������
        PlayerPrefs.SetString("startTime", startTime.ToString());   //���� �ð� ���� *���� JSON���� �ؾ��ϳ�?
        PlayerPrefs.Save();
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

        float difSeconds = (float)timeDif.TotalSeconds; //���̸� ���� ���� �ð��� �ʷ� ��ȯ
        leftTime = feedTime - difSeconds;   //���� ���� �ð� ���
    }

    public void UseSpecialFeed(float decreaseTime)
    {
        //Ư�� ���� ��� �Լ�

        this.leftTime -= decreaseTime;
    }

}
