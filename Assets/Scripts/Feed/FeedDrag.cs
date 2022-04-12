using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FeedDrag : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    //�巡���� ������Ʈ(����)�� ������Ʈ�� ���� Ŭ����

    private static Vector2 defaultPosition;  //����ϸ� �ٽ� ���� ����ġ ����
    [SerializeField] private bool isTriggering;    //Ƚ��� �浹 ������ ����



    public void Start()
    {
        isTriggering = false;
    }

    public void SetIsTriggering(bool TorF)
    {
        //Ƚ�� ������ �����ϴ� �Լ�

        this.isTriggering = TorF;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //�巡�׸� ������ ���� �Լ�

        defaultPosition = this.transform.position;  //ó�� ��ġ ����
    }

    public void OnDrag(PointerEventData eventData)
    {
        //�巡�� ���� ���� �Լ�
        Vector2 currentPos = Input.mousePosition;   //���콺 �������� ���� ������Ʈ �̵�
        this.transform.position = currentPos;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //�巡�װ� ������ ���� �Լ�
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (isTriggering)
        {
            //Ƚ��� �浹 ���̶��
            int feedNum = this.gameObject.GetComponent<FeedInfo>().GetFeedNumber();     //�ڽ��� ������ȣ�� ������
            GameObject.FindGameObjectWithTag("FeedManager").GetComponent<FeedRackMatch>().SelectFeed(feedNum);    //������ȣ ���� Ȱ��ȭ
        }

        this.transform.position = defaultPosition;      //����ġ�� ���ư���
    }
}
