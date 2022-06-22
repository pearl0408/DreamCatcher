using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BirdImage : MonoBehaviour
{
    //새와 깃털 이미지를 수정하는 클래스
    [Header("[Bird Select]")]
    [SerializeField] private int selectedBirdNum = 0;    //확률에 따라 랜덤으로 정해진 새의 번호
    [SerializeField] private bool specialBirdAppear = false;    //특별 새 등장하였는지 여부

    [Space]
    [Header("[Bird Object]")]
    public GameObject viewBird;   //보여지는 새 오브젝트
    public Sprite[] birdImage; //새의 이미지 배열
    public Sprite[] birdFeatherImage;  //새 깃털의 이미지 배열

    public int SelectBirdType(int feedNum)
    {
        //놓인 먹이 정보를 받아서 랜덤으로 새 종류를 정하는 함수

        int categoryCnt = SettingCategoryCnt(feedNum); //카테고리(새 종류, 먹이) 시작 번호를 설정함
        List<Dictionary<string, object>> data_birdInfo = CSVParser.ReadFromFile("BirdInfo");  //도감 데이터를 가져옴 

        //만약 특별 새 나오는 조건을 만족했다면 특별 새 등장
        if (!specialBirdAppear)
        {
            //해당 먹이의 특별 새가 한 번도 등장하지 않았다면

            //해당 먹이의 새 3마리 모두 깃털 개수가 1 이상이라면
            List<int> specialBirdCheck = new List<int>();   //특별 새 특정 조건 달성을 확인할 리스트
            for (int i = 0; i < 3; i++)
            {
                int appearNumber = int.Parse(data_birdInfo[categoryCnt + i]["appear"].ToString()); //등장 횟수를 가져옴
                specialBirdCheck.Add(appearNumber);    //등장 횟수를 저장함
            }

            if (!specialBirdCheck.Contains(0))
            {
                //등장 횟수가 0인 새가 없다면

                //해당 먹이의 특별 새가 한 번도 등장하지 않았다면
                specialBirdAppear = true;   //특별 새 등장
                selectedBirdNum = categoryCnt + 3;  //특별 새로 설정

                int appearCnt = 1;
                data_birdInfo[selectedBirdNum]["appear"] = appearCnt.ToString(); //도감에 증가한 등장 횟수 반영
                CSVParser.WriteFromFile("BirdInfo", data_birdInfo); //도감 저장

                return selectedBirdNum; //특별 새 반환
            }
        }

        //특별 새가 나올 차례가 아니라면(이미 해당 먹이의 특별 새가 등장했거나, 다른 세 마리의 새가 다 등장하지 않았다면)
        List<int> birdRandom = new List<int>(); //새 등장 확률을 추첨할 리스트
        for (int i = 0; i < 3; i++)
        {
            int appearCnt = int.Parse(data_birdInfo[categoryCnt + i]["probability"].ToString());   //도감에 저장된 해당 먹이의 i번째 새의 등장 확률을 가져옴
            for (int j = 0; j < appearCnt; j++)
            {
                birdRandom.Add(i);  //리스트에 i번 새 등장확률만큼 입력
            }
        }

        int randomBird = Random.Range(0, 100);   //랜덤으로 새를 뽑기 위해 난수 생성(0~100 사이의 수 하나)
        selectedBirdNum = birdRandom[randomBird] + categoryCnt;     //선택된 새 번호

        return selectedBirdNum;  //선정된 랜덤 새 반환
    }

    public void SelectBirdImage()
    {
        //새의 이미지를 바꾸는 함수

        viewBird.gameObject.GetComponent<Image>().sprite = birdImage[selectedBirdNum];  //새의 이미지를 랜덤으로 정해진 새의 번호 이미지로 변경
        viewBird.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = birdFeatherImage[selectedBirdNum]; //새 깃털의 이미지를 랜덤으로 정해진 새의 번호 이미지로 변경
    }

    public void ActiveBirdObject()
    {
        //새 오브젝트를 활성화하는 함수

        viewBird.gameObject.SetActive(true);
    }

    public int SettingCategoryCnt(int feedNum)
    {
        //카테고리 구분 번호를 정하는 함수
        int cnt;

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
