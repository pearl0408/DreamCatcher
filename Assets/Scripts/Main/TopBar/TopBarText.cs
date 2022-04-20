using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopBarText : MonoBehaviour
{
    //��ܹ� ������ �ؽ�Ʈ�� �����ִ� Ŭ����

    [Header("Topbar Text")]
    [SerializeField] private Text SpecialFeedText;      //���� ���� �ؽ�Ʈ

    private void Start()
    {
        SpecialFeedText.text = GameManager.instance.SpecialFeedCount.ToString();    //Ư�� ���� ������ ������
    }

    public void SetSpecialFeedText(int feedNum)
    {
        //Ư�� ���� ���� �ؽ�Ʈ�� �����ϴ� �Լ�

        SpecialFeedText.text = feedNum.ToString();
    }
}
