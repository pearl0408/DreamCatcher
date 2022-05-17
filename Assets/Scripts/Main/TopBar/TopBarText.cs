using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopBarText : MonoBehaviour
{
    //��ܹ� ������ �ؽ�Ʈ�� �����ִ� Ŭ����

    [Header("Topbar Text")]
    [SerializeField] private Text SpecialFeedText;      //���� ���� �ؽ�Ʈ
    [SerializeField] private Text MoneyText;      //��� �ؽ�Ʈ

    private void Start()
    {
        UpdateText();
    }

    public void UpdateText()
    {
        //�ؽ�Ʈ���� ������Ʈ �ϴ� �Լ�

        SpecialFeedText.text = GameManager.instance.specialFeedCount.ToString();    //Ư�� ���� ������ ������
        MoneyText.text = GameManager.instance.playerGold.ToString();    //Ư�� ���� ������ ������
    }

    public void SetSpecialFeedText(int feedNum)
    {
        //Ư�� ���� ���� �ؽ�Ʈ�� �����ϴ� �Լ�

        SpecialFeedText.text = feedNum.ToString();
    }

    public void SetMoneyText(int GoldNum)
    {
        //��� �ؽ�Ʈ�� �����ϴ� �Լ�

        MoneyText.text = GoldNum.ToString();
    }
}
