using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopBarText : MonoBehaviour
{
    //��ܹ� ������ �ؽ�Ʈ�� �����ִ� Ŭ����

    [SerializeField] private TopBarContainer curPlayerData;   //�÷��̾� ������ ����

    [Header("Topbar Text")]
    [SerializeField] private Text DreamMarbleText;      //�ޱ��� �ؽ�Ʈ
    [SerializeField] private Text GoldText;      //��� �ؽ�Ʈ
    [SerializeField] private Text SpecialFeedText;      //���� ���� �ؽ�Ʈ

    private void Start()
    {
        UpdateText();
    }

    public void UpdateText()
    {
        //�ؽ�Ʈ���� ������Ʈ �ϴ� �Լ�
        GameManager.instance.ResetGameManager();
        curPlayerData = GameManager.instance.loadTopBarData;    //�÷��̾��� ��ܹ� ������ ������ ������

        DreamMarbleText.text = curPlayerData.dataList[0].dataNumber.ToString();
        GoldText.text = curPlayerData.dataList[1].dataNumber.ToString();    //Ư�� ���� ������ ������
        SpecialFeedText.text = curPlayerData.dataList[2].dataNumber.ToString();    //Ư�� ���� ������ ������
    }

    public void SetDreamMarbleText(int marbleNum)
    {
        //�ޱ��� �ؽ�Ʈ�� �����ϴ� �Լ�

        //���� �����ϵ��� �ؾ��ϳ�?? �� �����ϴ� �Ŷ� ���ϵǵ��� ������ ����

        DreamMarbleText.text = marbleNum.ToString();
    }

    public void SetSpecialFeedText(int feedNum)
    {
        //Ư�� ���� ���� �ؽ�Ʈ�� �����ϴ� �Լ�

        //���� �����ϵ��� �ؾ��ϳ�?? �� �����ϴ� �Ŷ� ���ϵǵ��� ������ ����
        SpecialFeedText.text = feedNum.ToString();
    }

    public void SetGoldText(int GoldNum)
    {
        //��� �ؽ�Ʈ�� �����ϴ� �Լ�

        //���� �����ϵ��� �ؾ��ϳ�?? �� �����ϴ� �Ŷ� ���ϵǵ��� ������ ����
        GoldText.text = GoldNum.ToString();
    }
}
