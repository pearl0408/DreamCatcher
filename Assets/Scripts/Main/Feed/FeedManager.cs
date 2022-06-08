using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedManager : MonoBehaviour
{
    // 먹이를 관리하는 클래스

    [Header("Feed Setting")]
    [SerializeField] private int numberOfFeed = 4;      //총 먹이 개수 
    [SerializeField] private bool isSelected;   //먹이 선택 여부 변수
    [SerializeField] private int selectedFeedNum;       //선택된 먹이 번호
    [SerializeField] private int selectedBirdNum;       //선택된 새 번호

    public void Start()
    {

        //isSelected = false;
        this.GetComponent<FeedTimer>().LoadFeedSaveData();  //먹이 저장 데이터 읽어옴
    }


    public int GetNumberOfFeed()
    {
        //총 먹이 개수를 반환하는 함수

        return numberOfFeed;
    }

    public bool GetIsFeedSelected()
    {
        //먹이 선택 여부를 반환하는 함수

        return isSelected;
    }

    public void SetIsFeedSelected(bool TorF)
    {
        //먹이 선택 여부를 갱신하는 함수

        this.isSelected = TorF;
        this.gameObject.GetComponent<FeedTimer>().SetIsFeedSelected(TorF);      //타이머 클래스의 먹이 선택 여부도 갱신
    }

    public int GetSelectedFeedNum()
    {
        //선택된 먹이 번호를 반환하는 함수

        return selectedFeedNum;
    }

    public void SetSelectedFeedNum(int num)
    {
        //선택된 먹이 번호를 설정하는 함수

        selectedFeedNum = num;
    }

    public int GetSelectedBirdNum()
    {
        //선택된 새의 번호를 반환하는 함수

        return selectedBirdNum;
    }

    public void SetSelectedBirdNum(int num)
    {
        //선택된 새의 번호를 설정하는 함수

        selectedBirdNum = num;
    }
}
