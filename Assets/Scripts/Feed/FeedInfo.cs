using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedInfo : MonoBehaviour
{
    //먹이 정보 클래스

    [Header("Feed Information")]
    [SerializeField] private int feedNumber;    //먹이 번호
    //[SerializeField] private int NumberOfFeed;    //먹이 호출된 횟수?(후에 먹이 몇 번 썼는지로 구글 업적 생성해도 ㄱㅊ할듯)


    public void SetFeedNumber(int num)
    {
        this.feedNumber = num;
    }

    public int GetFeedNumber()
    {
        return this.feedNumber;
    }
}
