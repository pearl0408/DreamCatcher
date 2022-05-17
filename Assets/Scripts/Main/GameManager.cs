using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // 게임 데이터를 관리하는 싱글톤 패턴

    //싱글톤 패턴을 사용하기 위한 전역 변수
    public static GameManager instance;

    [Header("Game Data")]

    //공용으로 사용할 게임 데이터
    public int dreamMable;  //꿈 구슬 수
    public int playerGold;     //플레이어 골드
    public int specialFeedCount;    //특제 먹이 개수

    public GoodsContainer loadGoodsData;  //상품(보조도구) 레벨 데이터

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
    }

    public static GameManager GetGameManager()
    {
        return instance;
    }

    public void ResetGameManager()
    {
        //초기화 함수

        loadGoodsData = this.gameObject.GetComponent<GoodsJSON>().GetGoodsData();   //상품 데이터 가져오기

        //스페셜먹이, 돈, 꿈구슬 개수도 json으로 수정
        dreamMable = 3;
        playerGold = 10000;
        specialFeedCount = 3;
    }
}
