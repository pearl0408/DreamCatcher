using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MakingUIManager : MonoBehaviour
{
    // 창 관리
    public GameObject StringWindow, FeatherWindow;
    public GameObject StringBtn, FeatherBtn;

    // 실 색 관리
    public Image StringRing;
    public GameObject Lines;
    public Sprite[] StringRingImgs;
    private Color[] stringColors = { new Color(1f, 1f, 1f, 1f), new Color(1f, 0.9254903f, 0.4784314f, 1f), 
        new Color(0.3333333f, 0.3490196f, 0.4745098f, 1f), new Color(0.6078432f, 0.2235294f, 0.2352941f, 1f), 
        new Color(0.3411765f, 0.3411765f, 0.3411765f, 1f) };
    public GameObject points;

    // Start is called before the first frame update
    void Start()
    {
        StringWin();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 실창 활성화
    public void StringWin()
    {
        // StringWin 활성화, FeatherWin 비활성화
        StringWindow.SetActive(true);
        FeatherWindow.SetActive(false);
        // StringBtn 밝음, FeatherBtn 어둡
        StringBtn.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        FeatherBtn.GetComponent<Image>().color = new Color(0.5943396f, 0.5943396f, 0.5943396f, 1.0f);
    }

    // 깃털창 활성화
    public void FeatherWin()
    {
        // FeatherWin 활성화, StringWin 비활성화
        FeatherWindow.SetActive(true);
        StringWindow.SetActive(false);
        // FeatherBtn 밝음, StringBtn 어둡
        FeatherBtn.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        StringBtn.GetComponent<Image>().color = new Color(0.5943396f, 0.5943396f, 0.5943396f, 1.0f);
    }
    
    // 깃털창 드림캐쳐 변화
    public void DreamcatcherSizeChange()
    {

    }

    // 실 색변경
    public void StringColorChange(int colorNum)
    {
        // 있던 것들 변경
        StringRing.sprite = StringRingImgs[colorNum]; // 링 색 변경
        for(int i=0; i<Lines.transform.childCount; i++)
        {
            Lines.transform.GetChild(i).gameObject.GetComponent<LineRenderer>().startColor = stringColors[colorNum];
            Lines.transform.GetChild(i).gameObject.GetComponent<LineRenderer>().endColor = stringColors[colorNum];
        }

        // 실 정보 변경
        for(int i=0; i<points.transform.childCount; i++)
        {
            points.transform.GetChild(i).gameObject.GetComponent<DragPoint>().StringColorSet(colorNum);
        }
    }
}
