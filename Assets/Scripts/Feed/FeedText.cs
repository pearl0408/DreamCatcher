using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeedText : MonoBehaviour
{
    //먹이 타이머를 텍스트로 보여주는 클래스

    [Header("Feed Text")]
    [SerializeField] private Text timerText;      //타이머 텍스트

    public void SetTimerText(string timer)
    {
        //타이머 텍스트를 변경하는 함수

        //텍스트 format 맞춰서 나오게 설정
        timerText.text = timer;
    }
}
