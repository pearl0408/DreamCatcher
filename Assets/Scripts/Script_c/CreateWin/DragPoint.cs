using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragPoint : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    // 프리팹
    public GameObject LinePref;

    // 오브젝트
    GameObject Line;
    public GameObject LinesGroup;
    //public GameObject Canvas;

    // 위치
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

    // 오브젝트 드래그 시작
    public void OnBeginDrag(PointerEventData eventData)
    {
        Line = Instantiate(LinePref);
        Line.transform.parent = LinesGroup.gameObject.transform;
        Line.GetComponent<LineRenderer>().sortingOrder = 1;
        Line.GetComponent<LineRenderer>().SetPosition(0, StartPoint);
    }

    // 오브젝트 드래그 중
    public void OnDrag(PointerEventData eventData)
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 90;
        Line.GetComponent<LineRenderer>().SetPosition(1, mousePos);

        if (eventData.pointerCurrentRaycast.gameObject.CompareTag("DragPoint"))
        {
            // 닿으면 거기서 한줄 완성
            EndPoint = eventData.pointerCurrentRaycast.gameObject.transform.position;
            Line.GetComponent<LineRenderer>().SetPosition(1, EndPoint);

            // 바로 새로운 줄 : 미완 구상중
        }
    }

    // 오브젝트 드래그 끝
    public void OnEndDrag(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject.CompareTag("DragPoint"))
        {
            // 닿으면 거기서 한줄 완성
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
