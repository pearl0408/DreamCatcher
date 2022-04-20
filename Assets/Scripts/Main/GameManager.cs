using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // 게임 데이터를 관리하는 싱글톤 패턴

    //싱글톤 패턴을 사용하기 위한 전역 변수
    public static GameManager instance;

    [Header("Game Data")]
    public int SpecialFeedCount;    //특제 먹이 개수

    void Awake()
    {
        // 게임 시작과 동시에 싱글톤 구성

        if (instance)     //싱글톤 변수 instance가 이미 있다면
        {
            DestroyImmediate(gameObject);   //삭제
            return;
        }

        instance = this;    //유일한 인스턴스
        DontDestroyOnLoad(gameObject);  //씬이 바뀌어도 계속 유지시킴

        ResetGameManager();
    }
    public static GameManager GetGameManager()
    {
        return instance;
    }

    public void ResetGameManager()
    {
        //초기화 함수

        SpecialFeedCount = PlayerPrefs.GetInt("SpecialFeed", 3);   //특제 먹이 개수 가져옴(임시로 기본 3개로 설정)
    }
}
