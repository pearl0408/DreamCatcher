using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragPoint : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    // ������
    public GameObject LinePref;

    // ������Ʈ
    GameObject Line;
    //public GameObject Canvas;

    // ��ġ
    Vector3 StartPoint, EndPoint;
    private Vector3 mousePos;

    // Start is called before the first frame update
    void Start()
    {
        //StartPoint = Camera.main.ScreenToWorldPoint(this.transform.position);
        StartPoint = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    // ������Ʈ �巡�� ����
    public void OnBeginDrag(PointerEventData eventData)
    {
        Line = Instantiate(LinePref);
        Line.transform.parent = this.gameObject.transform.parent;
        Line.GetComponent<LineRenderer>().sortingOrder = 1;
        Line.GetComponent<LineRenderer>().SetPosition(0, StartPoint);
    }

    // ������Ʈ �巡�� ��
    public void OnDrag(PointerEventData eventData)
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 90;
        Line.GetComponent<LineRenderer>().SetPosition(1, mousePos);

        if (eventData.pointerCurrentRaycast.gameObject.CompareTag("DragPoint"))
        {
            // ������ �ű⼭ ���� �ϼ�
            EndPoint = eventData.pointerCurrentRaycast.gameObject.transform.position;
            Line.GetComponent<LineRenderer>().SetPosition(1, EndPoint);

            // �ٷ� ���ο� �� : �̿� ������
        }
    }

    // ������Ʈ �巡�� ��
    public void OnEndDrag(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject.CompareTag("DragPoint"))
        {
            // ������ �ű⼭ ���� �ϼ�
            //Debug.Log(eventData.pointerCurrentRaycast.gameObject);
            EndPoint = eventData.pointerCurrentRaycast.gameObject.transform.position;
            Line.GetComponent<LineRenderer>().SetPosition(1, EndPoint);
            Line.GetComponent<Line>().addColliderToLine();
        }
        else
        {
            Destroy(Line);
        }
    }
}
