using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimerData
{
    public TimerData(bool _isExisted, string _startTime, float _savedDefaultTime)
    {
        isExisted = _isExisted;
        startTime = _startTime;
        savedDefaultTime = _savedDefaultTime;
    }
    public bool isExisted;      //���� ���̰� �ִ���
    public string startTime;    //���� ���� �ð�
    public float savedDefaultTime;    //�������� ������ ���� �ð�
}
