using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreData : MonoBehaviour
{
    //상점 CSV 파일의 데이터를 가져오는 클래스

    [Header("[Store Product]")]
    public GameObject[] goodsContents;   //상품 오브젝트 배열(횃대, 화분, 상자, 실)
    public SpriteArray[] goodsImages; //상품 이미지 배열
    [SerializeField] private int[] currentCost = new int[4]; //현재 가격

    private GoodsContainer curGoodsData;   //상품 정보
    private TopBarContainer curPlayerData;   //플레이어 데이터 정보

    [Space]
    public GameObject[] soldOut;  //판매 완료 이미지 오브젝트 배열

    private void Start()
    {
        UpdateStoreData();
    }

    public void UpdateStoreData()
    {
        GameManager.instance.ResetGameManager();    //저장 데이터 갱신
        curGoodsData = GameManager.instance.loadGoodsData;   //플레이어의 상품 정보를 가져옴
        curPlayerData = GameManager.instance.loadTopBarData;    //플레이어의 상단바 데이터 정보를 가져옴

        //상점 데이터를 가져오는 함수
        List<Dictionary<string, object>> data_Store = CSVParser.ReadFromFile("Store");  //상점 데이터를 가져옴  

        int productCnt = 1; //상품 카테고리 시작 번호
        for (int i = 0; i < curGoodsData.goodsCount; i++, productCnt += 6)
        {
            int goodsLevel = curGoodsData.goodsList[i].goodsLevel;  //상품 레벨
            goodsContents[i].transform.GetChild(4).GetChild(1).gameObject.GetComponent<Text>().text = data_Store[productCnt + goodsLevel]["Effect"].ToString();   //상품 효과 불러옴
            goodsContents[i].transform.GetChild(6).GetChild(2).gameObject.GetComponent<Text>().text = data_Store[productCnt + goodsLevel]["Gold"].ToString();     //상품 가격 불러옴
            goodsContents[i].transform.GetChild(5).gameObject.GetComponent<Slider>().value = float.Parse(data_Store[productCnt + goodsLevel]["Slider"].ToString());     //상품 슬라이더 값 불러옴
            currentCost[i] = int.Parse(data_Store[productCnt + goodsLevel]["Gold"].ToString());   //구매를 위해 상품별 가격만 따로 저장
            goodsContents[i].transform.GetChild(1).gameObject.GetComponent<Image>().sprite = goodsImages[i].imageList[goodsLevel + 1]; //상품 이미지 불러옴
        }

        //만약 상품 레벨이 최고 레벨이라면 해당 상품 sold out 표시(**소프트코딩으로 바꿀 수 있을지 고민..)
        if (curGoodsData.goodsList[0].goodsLevel == 2)    //횃대 마지막 레벨을 구매했다면
        {
            soldOut[0].SetActive(true);   //구매 막기
        }
        if (curGoodsData.goodsList[1].goodsLevel == 3)    //꽃병 마지막 레벨을 구매했다면
        {
            soldOut[1].SetActive(true);   //구매 막기
        }
        if (curGoodsData.goodsList[2].goodsLevel == 3)    //상자 마지막 레벨을 구매했다면
        {
            soldOut[2].SetActive(true);   //구매 막기
        }
        if (curGoodsData.goodsList[3].goodsLevel == 4)    //실 마지막 레벨을 구매했다면
        {
            soldOut[3].SetActive(true);   //구매 막기
        }
    }

    public void AddGoodsLevel(int goodsIndex)
    {
        curGoodsData.goodsList[goodsIndex].goodsLevel++;    //상품 레벨 증가
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<GoodsJSON>().DataSaveText(curGoodsData);   //변경사항 json으로 저장
    }

    public void SpendGold(int cost)
    {
        curPlayerData.dataList[1].dataNumber -= cost;   //보유 골드 감소
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<TopBarJSON>().DataSaveText(curPlayerData);   //변경사항 json으로 저장
    }

    public void BuyGoods(int goodsNumber)
    {
        //상품 구매 함수

        if (curPlayerData.dataList[1].dataNumber >= currentCost[goodsNumber])      //플레이어 골드가 구매하려는 상품 금액보다 크다면
        {
            //상품 구매
            SpendGold(currentCost[goodsNumber]);  //보유 골드 감소
            AddGoodsLevel(goodsNumber);   //상품 레벨 증가

            //만약 해당 상품의 마지막 레벨을 구매했다면(*이부분 어떻게 소프트코딩으로 바꿀 수 있을지 고민..)
            switch (goodsNumber)
            {
                case 0:
                    if (curGoodsData.goodsList[goodsNumber].goodsLevel == 2)    //횃대 마지막 레벨을 구매했다면
                    {
                        soldOut[goodsNumber].SetActive(true);   //구매 막기
                    }
                    break;
                case 1:
                    if (curGoodsData.goodsList[goodsNumber].goodsLevel == 3)    //꽃병 마지막 레벨을 구매했다면
                    {
                        soldOut[goodsNumber].SetActive(true);   //구매 막기
                    }
                    break;
                case 2:
                    if (curGoodsData.goodsList[goodsNumber].goodsLevel == 3)    //상자 마지막 레벨을 구매했다면
                    {
                        soldOut[goodsNumber].SetActive(true);   //구매 막기
                    }
                    break;
                case 3:
                    if (curGoodsData.goodsList[goodsNumber].goodsLevel == 4)    //실 마지막 레벨을 구매했다면
                    {
                        soldOut[goodsNumber].SetActive(true);   //구매 막기
                    }
                    break;
            }

            GameObject.FindGameObjectWithTag("TopBar").GetComponent<TopBarText>().UpdateText();   //상단바 업데이트
            UpdateStoreData();    //상점 업데이트
        }
    }
}

[System.Serializable]
public class SpriteArray //상품 이미지 배열의 행
{
    //하이어라키 화면에 이차원 배열로 보이기 위해 만든 상품 이미지 클래스

    public Sprite[] imageList;
}