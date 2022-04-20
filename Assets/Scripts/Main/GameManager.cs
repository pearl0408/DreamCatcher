using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // ���� �����͸� �����ϴ� �̱��� ����

    //�̱��� ������ ����ϱ� ���� ���� ����
    public static GameManager instance;

    [Header("Game Data")]
    public int SpecialFeedCount;    //Ư�� ���� ����

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

        ResetGameManager();
    }
    public static GameManager GetGameManager()
    {
        return instance;
    }

    public void ResetGameManager()
    {
        //�ʱ�ȭ �Լ�

        SpecialFeedCount = PlayerPrefs.GetInt("SpecialFeed", 3);   //Ư�� ���� ���� ������(�ӽ÷� �⺻ 3���� ����)
    }
}
