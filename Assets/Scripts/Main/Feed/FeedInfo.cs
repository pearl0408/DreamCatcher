using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedInfo : MonoBehaviour
{
    //먹이 정보 클래스

    [Header("Feed Information")]
    [SerializeField] private int feedNumber;    //먹이 번호


    public void SetFeedNumber(int num)
    {
        this.feedNumber = num;
    }

    public int GetFeedNumber()
    {
        return this.feedNumber;
    }
}
