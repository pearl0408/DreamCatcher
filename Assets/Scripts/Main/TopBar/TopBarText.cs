using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopBarText : MonoBehaviour
{
    //상단바 데이터 텍스트를 보여주는 클래스

    [SerializeField] private TopBarContainer curPlayerData;   //플레이어 데이터 정보

    [Header("Topbar Text")]
    [SerializeField] private Text DreamMarbleText;      //꿈구슬 텍스트
    [SerializeField] private Text GoldText;      //골드 텍스트
    [SerializeField] private Text SpecialFeedText;      //먹이 개수 텍스트

    private void Start()
    {
        UpdateText();
    }

    public void UpdateText()
    {
        //텍스트들을 업데이트 하는 함수
        GameManager.instance.ResetGameManager();
        curPlayerData = GameManager.instance.loadTopBarData;    //플레이어의 상단바 데이터 정보를 가져옴

        DreamMarbleText.text = curPlayerData.dataList[0].dataNumber.ToString();
        GoldText.text = curPlayerData.dataList[1].dataNumber.ToString();    //특제 먹이 개수를 가져옴
        SpecialFeedText.text = curPlayerData.dataList[2].dataNumber.ToString();    //특제 먹이 개수를 가져옴
    }

    public void SetDreamMarbleText(int marbleNum)
    {
        //꿈구슬 텍스트를 수정하는 함수

        //값도 수정하도록 해야하나?? 값 수정하는 거랑 통일되도록 수정할 예정

        DreamMarbleText.text = marbleNum.ToString();
    }

    public void SetSpecialFeedText(int feedNum)
    {
        //특제 먹이 개수 텍스트를 수정하는 함수

        //값도 수정하도록 해야하나?? 값 수정하는 거랑 통일되도록 수정할 예정
        SpecialFeedText.text = feedNum.ToString();
    }

    public void SetGoldText(int GoldNum)
    {
        //골드 텍스트를 수정하는 함수

        //값도 수정하도록 해야하나?? 값 수정하는 거랑 통일되도록 수정할 예정
        GoldText.text = GoldNum.ToString();
    }
}
