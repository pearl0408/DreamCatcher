using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedManager : MonoBehaviour
{
    // 먹이를 관리하는 클래스

    [Header("Feed Setting")]
    [SerializeField] private int numberOfFeed = 4;     //먹이 개수 
    [SerializeField] private bool isSelected = false;     //먹이 선택 여부 변수

    public void Start()
    {
        //저장 데이터 읽어옴
        //먹이 선택 여부 변수 읽어옴
    }


    public int GetNumberOfFeed()
    {
        //총 먹이 개수를 반환하는 함수

        return numberOfFeed;
    }

    public bool IsFeedSelected()
    {
        //먹이 선택 여부를 반환하는 함수

        return isSelected;
    }

    public void SetIsFeedSelected(bool TorF)
    {
        //먹이 선택 여부를 갱신하는 함수

        this.isSelected = TorF;
        GameObject.FindGameObjectWithTag("FeedManager").GetComponent<FeedTimer>().UpdateIsFeedSelected();    //타이머에 갱신 신호 보냄
    }

    //먹이 선택 여부, 어떤 먹이를 선택했는지 번호, 먹이 놓은 시간 데이터 저장, 로드?
}
