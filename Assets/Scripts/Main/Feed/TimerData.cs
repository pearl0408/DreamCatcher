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
    public bool isExisted;      //���� ���̰� �ִ���
    public string startTime;    //���� ���� �ð�
    public float savedFeedTime;    //�������� ������ ���� �ð�
}
