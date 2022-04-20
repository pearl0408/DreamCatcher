using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopBarText : MonoBehaviour
{
    //상단바 데이터 텍스트를 보여주는 클래스

    [Header("Topbar Text")]
    [SerializeField] private Text SpecialFeedText;      //먹이 개수 텍스트

    private void Start()
    {
        SpecialFeedText.text = GameManager.instance.SpecialFeedCount.ToString();    //특제 먹이 개수를 가져옴
    }

    public void SetSpecialFeedText(int feedNum)
    {
        //특제 먹이 개수 텍스트를 수정하는 함수

        SpecialFeedText.text = feedNum.ToString();
    }
}
