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



    //*�ӽ÷� ��Ÿ���� ��(���� �ٸ� Ŭ�������� �� ������ȣ�� ���� �̹��� ����ǵ��� ����)
    //*���⼭�� �� �ٸ� Ŭ������ �� ���� �Լ��� ȣ���� ��
    public GameObject bird;

    void Start()
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
                timerText.gameObject.SetActive(true); //�ؽ�Ʈ Ȱ��ȭ
            }

            if (leftTime > 1)   //���� �ð��� 0�� �ƴ϶��(�� ��ٷ��� �Ѵٸ�)
            {
                leftTime -= Time.deltaTime; //�ʸ��� ���� �ð� ����
                timerText.text = Mathf.Floor(leftTime).ToString();    //Ÿ�̸� �ؽ�Ʈ ����(�Ҽ��� ������)
                //*������ �����ϸ� ��, ��, �ʷ� ������ ������ ����)
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

    public void SetFeedStartTime()
    {
        //Ÿ�̸� ���� �ð� ����

        this.startTime = System.DateTime.Now;    //���� �ð� ������
        PlayerPrefs.SetString("startTime", startTime.ToString());   //���� �ð� ���� *���� csv �Ľ����� �ؾ��ϳ�?
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
