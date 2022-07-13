using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimerData
{
    public TimerData(bool _isExisted, string _startTime, float _savedDefaultTime, float _decreaseTime)
    {
        isExisted = _isExisted;
        startTime = _startTime;
        savedDefaultTime = _savedDefaultTime;
        decreaseTime = _decreaseTime;   
    }
    public bool isExisted;      //놓인 먹이가 있는지
    public string startTime;    //먹이 놓은 시간
    public float savedDefaultTime;    //랜덤으로 정해진 먹이 시간
    public float decreaseTime;  //특제 먹이 사용으로 감소된 시간
}
