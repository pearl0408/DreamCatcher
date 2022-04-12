using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FeedDrag : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    //�巡���� ������Ʈ(����)�� ������Ʈ�� ���� Ŭ����

    private static Vector2 defaultPosition;  //����ϸ� �ٽ� ���� ����ġ ����
    [SerializeField]  private bool isHitting;    //��Ʈ ������ ����(�ֺ��� Ƚ�밡 �ִ��� ����)



    public void Start()
    {
        isHitting = false;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //�巡�׸� ������ ��, ó�� ��ġ ����
        defaultPosition = this.transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        //�巡�� ���� ��, ���콺 �������� ���� ������Ʈ �̵�
        Vector2 currentPos = Input.mousePosition;   //*���콺 ���� ��ġ�� �Ǵ��� ���߿� Ȯ�� �ʿ�
        this.transform.position = currentPos;

        RaycastHit2D hit = Physics2D.Raycast(currentPos, Vector2.zero, 300f);   //������ ��ġ ��ǥ�� ��Ʈ (*�� �� �������� ���� ����)
        if (hit.collider != null)   //��Ʈ �Ǿ��ٸ�
        {
            Debug.Log("��Ʈ��");
            if (hit.collider.gameObject.tag == "Rack")
            {
                Debug.Log(currentPos);
                isHitting = true;
            }
        }
        else
        {
            isHitting = false;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //�巡�װ� ������ ��, ���� ���� ����ġ�� ���ư���
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (isHitting)
        {
            //��Ʈ�Ǿ��ٸ�(������ ����Ʈ �ֺ��� Ƚ�밡 �ִٸ�)
            int feedNum = this.gameObject.GetComponent<FeedInfo>().GetFeedNumber();     //�ڽ��� ������ȣ�� ������
            GameObject.FindGameObjectWithTag("FeedManager").GetComponent<FeedRackMatch>().SelectFeed(feedNum);    //������ȣ ������Ʈ Ȱ��ȭ
        }

        this.transform.position = defaultPosition;      //����ġ�� ���ư���
    }
}
