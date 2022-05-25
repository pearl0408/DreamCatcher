using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdImage : MonoBehaviour
{

    //새와 깃털 이미지를 수정하는 클래스

    void Start()
    {
        //새를 활성화 했을 때 


    }

    public int SelectBirdType(int feedNum)
    {
        //새 종류를 정하는 함수

        List<int> birdRandom = new List<int>(); //새 등장 확률을 추첨할 리스트
        //int[] birdRandom = new int[10];

        int categoryCnt = SettingCategoryCnt(feedNum); //카테고리(새 종류, 먹이) 시작 번호를 설정함
        List<Dictionary<string, object>> data_birdInfo = CSVParser.ReadFromFile("BirdInfo");  //도감 데이터를 가져옴 
        for (int i = 0; i < 3; i++)
        {
            int appearCnt = int.Parse(data_birdInfo[categoryCnt + i]["probability"].ToString());   //도감에 저장된 해당 먹이의 i번째 새의 등장 확률을 가져옴
            appearCnt /= 10;    //등장 확률을 배열에 입력할 개수로 변환

            for (int j = 0; j < appearCnt; j++)
            {
                birdRandom.Add(i);  //리스트에 i번 새 등장확률만큼 입력
            }
        }

        int randomBird = Random.Range(0, 10);   //랜덤으로 새를 뽑기 위해 난수 생성(0~9 사이의 수 하나)

        Debug.Log(randomBird);
        Debug.Log(birdRandom[randomBird]);
        return birdRandom[randomBird];  //선정된 랜덤 새
    }

    public int SettingCategoryCnt(int feedNum)
    {
        //카테고리 구분 번호를 정하는 함수
        int cnt = 0;

        switch (feedNum)
        {
            case 0:
                cnt = 0;
                break;
            case 1:
                cnt = 4;
                break;
            case 2:
                cnt = 8;
                break;
            case 3:
                cnt = 12;
                break;
            default:
                cnt = 0;
                break;
        }

        return cnt;
    }
}
