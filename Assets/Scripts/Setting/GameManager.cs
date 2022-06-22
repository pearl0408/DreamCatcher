using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // ���� �����͸� �����ϴ� �̱��� ����

    //�̱��� ������ ����ϱ� ���� ���� ����
    public static GameManager instance;

    [Header("[Game Data]")]
    public GoodsContainer loadGoodsData;  //��ǰ(��������) ���� ������
    public TopBarContainer loadTopBarData;  //��ܹ� ������(�ޱ���, ���, Ư������) ���� ������
    public TimerData timerData; //Ÿ�̸� ������(���� ���� ����, ���� ���� �ð�)

    void Awake()
    {
        // ���� ���۰� ���ÿ� �̱��� ����

        if (instance)     //�̱��� ���� instance�� �̹� �ִٸ�
        {
            DestroyImmediate(gameObject);   //����
            return;
        }

        instance = this;    //������ �ν��Ͻ�
        DontDestroyOnLoad(gameObject);  //���� �ٲ� ��� ������Ŵ
    }

    public static GameManager GetGameManager()
    {
        return instance;
    }

    public void ResetGameManager()
    {
        //�ʱ�ȭ �Լ�

        loadGoodsData = this.gameObject.GetComponent<GoodsJSON>().GetGoodsData();   //��ǰ ������ ��������
        loadTopBarData = this.gameObject.GetComponent<TopBarJSON>().GetTopBarData();    //��ܹ� ������ ��������
        timerData = this.gameObject.GetComponent<TimerJSON>().GetTimerData();   //Ÿ�̸� ������ ��������
    }
}
