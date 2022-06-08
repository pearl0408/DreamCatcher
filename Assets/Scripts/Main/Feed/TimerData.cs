using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimerData
{
    public TimerData(bool _isExisted, string _startTime, float _savedFeedTime)
    {
        isExisted = _isExisted;
        startTime = _startTime;
        savedFeedTime = _savedFeedTime;
    }
    public bool isExisted;      //놓인 먹이가 있는지
    public string startTime;    //먹이 놓은 시간
    public float savedFeedTime;    //랜덤으로 정해진 먹이 시간
}
