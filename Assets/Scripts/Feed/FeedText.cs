using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeedText : MonoBehaviour
{
    //���� Ÿ�̸Ӹ� �ؽ�Ʈ�� �����ִ� Ŭ����

    [Header("Feed Text")]
    [SerializeField] private Text timerText;      //Ÿ�̸� �ؽ�Ʈ

    public void SetTimerText(string timer)
    {
        //Ÿ�̸� �ؽ�Ʈ�� �����ϴ� �Լ�

        //�ؽ�Ʈ format ���缭 ������ ����
        timerText.text = timer;
    }
}
