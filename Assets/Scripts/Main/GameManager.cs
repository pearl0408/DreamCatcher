using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // ���� �����͸� �����ϴ� �̱��� ����

    //�̱��� ������ ����ϱ� ���� ���� ����
    public static GameManager instance;

    [Header("Game Data")]

    //�������� ����� ���� ������
    public int dreamMable;  //�� ���� ��
    public int playerGold;     //�÷��̾� ���
    public int specialFeedCount;    //Ư�� ���� ����

    public GoodsContainer loadGoodsData;  //��ǰ(��������) ���� ������

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

        //����ȸ���, ��, �ޱ��� ������ json���� ����
        dreamMable = 3;
        playerGold = 10000;
        specialFeedCount = 3;
    }
}
