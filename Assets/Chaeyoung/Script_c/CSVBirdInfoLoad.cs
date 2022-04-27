using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CSVBirdInfoLoad : MonoBehaviour
{
    // 패널
    public GameObject BirdInfoPanel;

    // UI 오브젝트
    public GameObject[] birdColImg = new GameObject[16];
    public Text[] birdColName = new Text[16];

    public Text numberTxt, nameTxt, expTxt, timeTxt;
    public Image foodImg, birdImg, featherImg;
    public Slider numberSlide;

    // 이미지
    public Sprite[] birdImgs = new Sprite[16];
    public Sprite[] foodImgs = new Sprite[4];
    public Sprite[] featherImgs = new Sprite[16];

    List<Dictionary<string, object>> data;
    static string[] headerString;
    private void Start()
    {
        BirdInfoPanel.SetActive(false);
        data = CSVParser.ReadFromFile("BirdInfo");
        // [테스트용]이전에는 data 만 수정
        data[0]["appear"] = "1";
        data[1]["number"] = "7";
        LoadBirdCollection();
        // [테스트용]게임을 끄기 전에 Write를 이용하여 데이터파일 저장
        //CSVParser.Write(headerString, data);
    }

    // 새 전체 appear 정보 표시
    public void LoadBirdCollection()
    {
        for(int i=0; i<16; i++)
        {
            birdColImg[i].GetComponent<Image>().sprite = birdImgs[i];

            // 새가 등장한 적 없다면
            if(data[i]["appear"].ToString()=="0")
            {
                birdColImg[i].GetComponent<Image>().color = new Color(0f, 0f, 0f, 0.5f); // 회색 처리
                birdColImg[i].GetComponent<Button>().interactable = false; // 버튼 비활성화 처리
                birdColName[i].GetComponent<Text>().text = "???"; // 이름 물음표 처리
            }
            else // 새가 등장한 적이 있다면
            {
                birdColName[i].GetComponent<Text>().text = data[i]["name"].ToString();
                birdColImg[i].GetComponent<Button>().interactable = true;
            }
        }
    }

    // 새 개별 정보 로드 : 새를 클릭했을 시 새의 개별 정보창에 데이터를 표시한다.
    public void LoadBirdInfo(int index)
    {
        // 텍스트 설정
        numberTxt.text = "획득 수 "+data[index]["number"]+"마리";
        nameTxt.text = (string)data[index]["name"];
        expTxt.text = (string)data[index]["exp"];
        timeTxt.text = (string)data[index]["time"];

        // 슬라이더 설정
        numberSlide.maxValue = (int)data[index]["maxnum"];
        numberSlide.value = int.Parse(data[index]["number"].ToString());

        // 이미지 설정
        foodImg.sprite = foodImgs[index/4];
        birdImg.sprite = birdImgs[index];
        featherImg.sprite = featherImgs[index];
    }

    // 새 개별 정보 패널 열기
    public void BirdInfo(int index)
    {
        BirdInfoPanel.SetActive(true);
        LoadBirdInfo(index);
    }

    // 새 개별 정보 패널 닫기
    public void BirdInfoBack()
    {
        BirdInfoPanel.SetActive(false);
    }
}
