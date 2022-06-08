using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BirdImage : MonoBehaviour
{
    //새와 깃털 이미지를 수정하는 클래스
    [Header("Bird Select")]

    //[SerializeField] private int categoryCnt;    //먹이 카테고리 번호
    [SerializeField] private int selectedBirdNum;    //확률에 따라 랜덤으로 정해진 새의 번호
    [SerializeField] private bool isSpecialBird;    //특별 새 등장 조건을 달성했는지

    [SerializeField] private GameObject viewBird;   //보여지는 새 오브젝트
    [SerializeField] private Sprite[] birdImage; //새의 이미지 배열
    [SerializeField] private Sprite[] birdFeatherImage;  //새 깃털의 이미지 배열


    void Start()
    {
        selectedBirdNum = 0;
        isSpecialBird = true;
    }

    public int SelectBirdType(int feedNum)
    {
        //새 종류를 정하는 함수

        int categoryCnt = SettingCategoryCnt(feedNum); //카테고리(새 종류, 먹이) 시작 번호를 설정함
        List<Dictionary<string, object>> data_birdInfo = CSVParser.ReadFromFile("BirdInfo");  //도감 데이터를 가져옴 

/*        //만약 특별 새 나오는 조건을 만족했다면 특별 새로 지정 (**코드 수정 필요. 너무 번거로움)
        //해당 먹이의 새 3마리 모두 깃털 개수가 1 이상이라면
        List<int> specialBirdCheck = new List<int>();   //특별 새 특정 조건 달성을 확인할 리스트
        for (int i = 0; i < 3; i++)
        {
            int featherNumber = int.Parse(data_birdInfo[categoryCnt + i]["number"].ToString()); //깃털 개수를 가져옴
            specialBirdCheck.Add(featherNumber);    //깃털 개수를 저장함
        }

        if (specialBirdCheck.Contains(0))
        {
            //하나라도 깃털 개수가 0이라면 특별 새 X
            isSpecialBird = false;

            //특별 새 한 번이라도 나왔는지 확인(도감의 특별새의 appear 확인)
            
            //만약 한 번도 안 나왔고, 깃털 개수도 0이 없다면 특별 새로 지정
        }*/
        

        //**
        List<int> birdRandom = new List<int>(); //새 등장 확률을 추첨할 리스트
        //int[] birdRandom = new int[10];

        for (int i = 0; i < 3; i++)
        {
            int appearCnt = int.Parse(data_birdInfo[categoryCnt + i]["probability"].ToString());   //도감에 저장된 해당 먹이의 i번째 새의 등장 확률을 가져옴

            //10단위
          /*appearCnt /= 10;    //등장 확률을 배열에 입력할 개수로 변환
            for (int j = 0; j < appearCnt; j++)
            {
                birdRandom.Add(i);  //리스트에 i번 새 등장확률만큼 입력
            }*/

            //100단위
            for (int j = 0; j < appearCnt; j++)
            {
                birdRandom.Add(i);  //리스트에 i번 새 등장확률만큼 입력
            }
        }

        //int randomBird = Random.Range(0, 10);   //랜덤으로 새를 뽑기 위해 난수 생성(0~9 사이의 수 하나)
        int randomBird = Random.Range(0, 100);   //랜덤으로 새를 뽑기 위해 난수 생성(0~100 사이의 수 하나)

        /*        Debug.Log(randomBird);      //랜덤 숫자
                Debug.Log(birdRandom[randomBird]);  //뽑힌 새 번호*/

        selectedBirdNum = birdRandom[randomBird] + categoryCnt;
        return selectedBirdNum;  //선정된 랜덤 새
    }

    public void SelectBirdImage()
    {
        //새의 이미지를 정하는 함수

        viewBird.gameObject.GetComponent<Image>().sprite = birdImage[selectedBirdNum];  //새의 이미지를 랜덤으로 정해진 새의 번호 이미지로 변경
        viewBird.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = birdFeatherImage[selectedBirdNum]; //새 깃털의 이미지를 랜덤으로 정해진 새의 번호 이미지로 변경
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
