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

    // 색
    private Color stringColor;
    private Color[] stringColors = { new Color(1f, 1f, 1f, 1f), new Color(1f, 0.9254903f, 0.4784314f, 1f),
        new Color(0.3333333f, 0.3490196f, 0.4745098f, 1f), new Color(0.6078432f, 0.2235294f, 0.2352941f, 1f),
        new Color(0.3411765f, 0.3411765f, 0.3411765f, 1f) };

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

    public void StringColorSet(int colorNum)
    {
        stringColor = stringColors[colorNum];
    }

    // 오브젝트 드래그 시작
    public void OnBeginDrag(PointerEventData eventData)
    {
        // 라인 생성
        Line = Instantiate(LinePref);
        // 색 변경
        Line.GetComponent<LineRenderer>().startColor = stringColor;
        Line.GetComponent<LineRenderer>().endColor = stringColor;
        // 자식부모 설정
        Line.transform.parent = LinesGroup.gameObject.transform;
        Line.GetComponent<LineRenderer>().sortingOrder = 1;
        // 시작점 설정
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
