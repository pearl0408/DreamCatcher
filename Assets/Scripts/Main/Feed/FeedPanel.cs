using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedPanel : MonoBehaviour
{
    // ���� ���� â, Ư�� ���� ��� â�� ���� Ŭ����

    [Header("Feed Panel")]
    [SerializeField] private GameObject Feed_Panel;     //���� ���� �г�
    [SerializeField] private GameObject SpecialFeed_Panel;     //Ư�� ���� �г�

    public void OpenFeedPanel()
    {
        //���ǿ� ���� ���� ���� �г� �Ǵ� Ư�� ���� �г��� ���� �Լ�

        bool isSelected = this.gameObject.GetComponent<FeedManager>().GetIsFeedSelected(); //���� ���� ���� ������
        if (isSelected)     //�̹� ������ ���̰� �ִٸ�
        {
            ActiveSpecialFeedPanel(true);   //Ư�� ���� �г� ����
        }
        else
        {
            ActiveFeedPanel(true);  //���� ���� �г� ����
        }
    }

    public void ActiveFeedPanel(bool TorF)
    {
        //���� ���� �г��� ���� �ݴ� �Լ�

        Feed_Panel.gameObject.SetActive(TorF);
    }

    public void ActiveSpecialFeedPanel(bool TorF)
    {
        //Ư�� ���� �г��� ���� �ݴ� �Լ�

        SpecialFeed_Panel.gameObject.SetActive(TorF);
    }
}
