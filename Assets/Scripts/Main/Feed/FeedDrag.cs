using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FeedDrag : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    //�巡���� ������Ʈ(����)�� ������Ʈ�� ���� Ŭ����

    [Header("Feed Drag")]
    [SerializeField] private bool isTriggering;    //Ƚ��� �浹 ������ ����

    private static Vector2 defaultPosition;  //����ϸ� �ٽ� ���� ����ġ ����



    public void Start()
    {
        isTriggering = false;   //�浹�� ���� �ʱ�ȭ
    }

    public void SetIsTriggering(bool TorF)
    {
        //Ƚ�� �浹�� ���� ������ �����ϴ� �Լ�

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
        Vector2 currentPos = Input.mousePosition;   //���콺 ������ �� ������
        this.transform.position = currentPos;       //���콺 �������� ���� ������Ʈ �̵�
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //�巡�װ� ������ ���� �Լ�
        //Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (isTriggering)   //Ƚ��� �浹 ���̶��
        {
            int feedNum = this.gameObject.GetComponent<FeedInfo>().GetFeedNumber();     //�ڽ��� ������ȣ�� ������
            GameObject.FindGameObjectWithTag("FeedManager").GetComponent<FeedRackMatch>().SelectFeed(feedNum);    //������ȣ ���� Ȱ��ȭ

            //�� ������ ���� �ð� ����
            int randomBird = GameObject.FindGameObjectWithTag("FeedManager").GetComponent<BirdImage>().SelectBirdType(feedNum); //Ȯ���� ���� �������� ���� �� ��ȣ
            GameObject.FindGameObjectWithTag("FeedManager").GetComponent<FeedManager>().SetSelectedBirdNum(randomBird);    //�� ��ȣ ����
            GameObject.FindGameObjectWithTag("FeedManager").GetComponent<BirdImage>().SelectBirdImage();    //�� �̹��� ����(��Ȱ��ȭ ����)
            GameObject.FindGameObjectWithTag("FeedManager").GetComponent<FeedTimer>().SettingFeedTime();    //�� ���� �ð� ����
        }

        this.transform.position = defaultPosition;      //����ġ�� ���ư���
    }
}
