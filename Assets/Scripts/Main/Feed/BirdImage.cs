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

    [SerializeField] private GameObject viewBird;   //보여지는 새 오브젝트
    [SerializeField] private Sprite[] birdImage; //새의 이미지 배열
    [SerializeField] private Sprite[] birdFeatherImage;  //새 깃털의 이미지 배열


    void Start()
    {
        selectedBirdNum = 0;
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
