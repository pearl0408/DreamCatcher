using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedTimer : MonoBehaviour
{
    //���� �ð��� ����ϰ� �����ִ� Ŭ����(Ƚ�뿡 ���� ���̿� ���� Ŭ����)

    [Header("Feed Time")]
    [SerializeField] private float feedTime;    //���� �⺻ �ð�
    [SerializeField] private float leftTime;   //���� ���� �ð�(����: ��)
    [SerializeField] private System.DateTime startTime;   //���� ���� �ð�
    [SerializeField] private System.DateTime currentTime;   //���� �ð�


    private bool isSelected;     //���� ���� ���� ����
    private GameObject feedManager;
    private GameObject feedText;

    void Start()
    {
        feedManager = GameObject.FindGameObjectWithTag("FeedManager");
        feedText = GameObject.FindGameObjectWithTag("FeedManager");
        UpdateIsFeedSelected(); //���� ���ÿ��� ������

        feedTime = leftTime = 10f; //�ӽ÷� 10�ʷ� ���� *������ �Ľ����� ������ ����(ó������ ���� �ð�==���� �⺻ �ð�)

        if (isSelected) //���õ� ���̰� �ִٸ� 
        {
            GetFeedStartTime();     //���� ���� �ð��� �ҷ��� (���ٸ� ���� ������ �� �缳��)
            GetFeedLeftTime();      //Ÿ�̸� ���� �ð��� �����
        }
    }

    void Update()
    {
        //isSelected = feedManager.GetComponent<FeedManager>().IsFeedSelected(); //���� ���� ���� ������

        //���õ� ���̰� �ִٸ�
        if (isSelected)
        {
            //���� �ð��� ������ �ƴ϶��(�� ��ٷ��� �Ѵٸ�)
            if (leftTime > 1)
            {
                leftTime -= Time.deltaTime; //���� �ð� ����
                feedText.GetComponent<FeedText>().SetTimerText(Mathf.Floor(leftTime).ToString());    //Ÿ�̸� �ؽ�Ʈ ���� *��, ��, �� ���� �ٸ��� ������ ����
            }
            else   //���� �ð��� �������(�ð��� ��� �����ٸ�)
            {
                leftTime = 0f;
                isSelected = false; //�̰� selected ���� ������ �Ǿ����� ������ ȸ�� �� �� ���� ������..
            }
        }
    }

    public void SetFeedStartTime()
    {
        //���� ���� �ð� �����ϴ� �Լ�

        this.startTime = System.DateTime.Now;    //���� �ð�
        PlayerPrefs.SetString("startTime", startTime.ToString());   //���� �ð� ���� *���� csv �Ľ����� �ؾ��ϳ�?
        PlayerPrefs.Save();
    }

    public void GetFeedStartTime()
    {
        //���� ���� �ð� �ҷ����� �Լ�

        string savedTime = PlayerPrefs.GetString("startTime", "");  //����� �ð� �ҷ���
        this.startTime = System.Convert.ToDateTime(savedTime);
        PlayerPrefs.Save();
    }

    public void UpdateIsFeedSelected()
    {
        //���� ���� ���θ� �����ϴ� �Լ�

        this.isSelected = feedManager.GetComponent<FeedManager>().IsFeedSelected(); //���� ���� ���� ������
    }

    private void GetFeedLeftTime()
    {
        //���� ���� �ð� ����ϴ� �Լ�

        this.currentTime = System.DateTime.Now;    //���� �ð� ����
        System.TimeSpan timeDif = currentTime - startTime; //���� �ð��� ���� �ð��� �� ����(���̸� ���� �󸶳� ��������)

        float difSeconds = (float)timeDif.TotalSeconds; //���̸� ���� ���� �ð��� �ʷ� ��ȯ
        leftTime = feedTime - difSeconds;   //���� ���� �ð� ���
    }
}
