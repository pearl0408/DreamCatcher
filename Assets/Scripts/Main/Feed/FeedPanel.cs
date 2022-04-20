using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedPanel : MonoBehaviour
{
    // 먹이 선택 창, 특제 먹이 사용 창을 여는 클래스

    [Header("Feed Panel")]
    [SerializeField] private GameObject Feed_Panel;     //먹이 선택 패널
    [SerializeField] private GameObject SpecialFeed_Panel;     //특제 먹이 패널

    public void OpenFeedPanel()
    {
        //조건에 따라 먹이 선택 패널 또는 특제 먹이 패널을 여는 함수

        bool isSelected = this.gameObject.GetComponent<FeedManager>().GetIsFeedSelected(); //먹이 선택 여부 가져옴
        if (isSelected)     //이미 선택한 먹이가 있다면
        {
            ActiveSpecialFeedPanel(true);   //특제 먹이 패널 열기
        }
        else
        {
            ActiveFeedPanel(true);  //먹이 선택 패널 열기
        }
    }

    public void ActiveFeedPanel(bool TorF)
    {
        //먹이 선택 패널을 열고 닫는 함수

        Feed_Panel.gameObject.SetActive(TorF);
    }

    public void ActiveSpecialFeedPanel(bool TorF)
    {
        //특제 먹이 패널을 열고 닫는 함수

        SpecialFeed_Panel.gameObject.SetActive(TorF);
    }
}
