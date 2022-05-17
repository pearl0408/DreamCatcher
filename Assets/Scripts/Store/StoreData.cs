using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreData : MonoBehaviour
{
    //상점 CSV 파일의 데이터를 가져오는 클래스

    [Header("Store Product")]
    [SerializeField] private GameObject[] goodsContents;   //상품 오브젝트 배열(횃대, 화분, 상자, 실)
    [SerializeField] private GoodsContainer curGoodsData;   //상품 정보
    [SerializeField] private SpriteArray[] goodsImages; //상품 이미지 배열


    private int[] currentCost = new int[4]; //현재 가격


    private void OnEnable()
    {
        curGoodsData = GameManager.instance.loadGoodsData;   //플레이어의 상품 정보를 가져옴

        List<Dictionary<string, object>> data_Store = CSVReader.Read("Store");  //상점 데이터를 가져옴  
        UpdateStoreData(data_Store);
    }

    public void UpdateStoreData(List<Dictionary<string, object>> data)
    {
        //상점 데이터를 가져오는 함수
        
        int productCnt = 1; //상품 카테고리 시작 번호
        for (int i = 0; i < curGoodsData.goodsCount; i++, productCnt += 5)
        {
            int goodsLevel = curGoodsData.goodsList[i].goodsLevel;  //상품 레벨
            goodsContents[i].transform.GetChild(4).GetChild(1).gameObject.GetComponent<Text>().text = data[productCnt + goodsLevel]["Effect"].ToString();   //상품 이름 불러옴
            goodsContents[i].transform.GetChild(6).GetChild(2).gameObject.GetComponent<Text>().text = data[productCnt + goodsLevel]["Gold"].ToString();     //상품 가격 불러옴
            currentCost[i] = int.Parse(data[productCnt + goodsLevel]["Gold"].ToString());   //구매를 위해 상품별 가격만 따로 저장
            goodsContents[i].transform.GetChild(1).gameObject.GetComponent<Image>().sprite = goodsImages[i].imageList[goodsLevel]; //상품 이미지 불러옴
        }
    }
    
    public void AddGoodsLevel(int goodsIndex)
    {
        curGoodsData.goodsList[goodsIndex].goodsLevel++;    //상품 레벨 증가
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<GoodsJSON>().DataSaveText(curGoodsData);   //변경사항 json으로 저장
    }

    //*buy 함수들 virtual로 가능한지 확인 후 수정할 예정
    public void BuyRack()
    {
        List<Dictionary<string, object>> data_Store = CSVReader.Read("Store");  //상점 데이터를 가져옴  

        if (GameManager.instance.playerGold >= currentCost[0])      //플레이어 골드가 상품 금액보다 크다면
        {
            //상품 구매(보유 골드 감소, 상품 레벨 증가, 상단바 업데이트, 상점 업데이트)
            GameManager.instance.playerGold -= currentCost[0];  
            AddGoodsLevel(0);
            GameObject.FindGameObjectWithTag("SceneManager").GetComponent<TopBarText>().UpdateText();
            UpdateStoreData(data_Store);
        }
    }

    public void BuyVase()
    {
        List<Dictionary<string, object>> data_Store = CSVReader.Read("Store");  //상점 데이터를 가져옴  

        if (GameManager.instance.playerGold >= currentCost[1])  //플레이어 골드가 상품 금액보다 크다면
        {
            //상품 구매(보유 골드 감소, 상품 레벨 증가, 상단바 업데이트, 상점 업데이트)
            GameManager.instance.playerGold -= currentCost[1];
            AddGoodsLevel(1);
            GameObject.FindGameObjectWithTag("SceneManager").GetComponent<TopBarText>().UpdateText();
            UpdateStoreData(data_Store);
        }
    }

    public void BuyBox()
    {
        List<Dictionary<string, object>> data_Store = CSVReader.Read("Store");  //상점 데이터를 가져옴  

        if (GameManager.instance.playerGold >= currentCost[2])  //플레이어 골드가 상품 금액보다 크다면
        {
            //상품 구매(보유 골드 감소, 상품 레벨 증가, 상단바 업데이트, 상점 업데이트)
            GameManager.instance.playerGold -= currentCost[2];
            AddGoodsLevel(2);
            GameObject.FindGameObjectWithTag("SceneManager").GetComponent<TopBarText>().UpdateText();
            UpdateStoreData(data_Store);
        }
    }

    public void BuyThread()
    {
        List<Dictionary<string, object>> data_Store = CSVReader.Read("Store");  //상점 데이터를 가져옴  


        if (GameManager.instance.playerGold >= currentCost[3])  //플레이어 골드가 상품 금액보다 크다면
        {
            //상품 구매(보유 골드 감소, 상품 레벨 증가, 상단바 업데이트, 상점 업데이트)
            GameManager.instance.playerGold -= currentCost[3];
            AddGoodsLevel(3);
            GameObject.FindGameObjectWithTag("SceneManager").GetComponent<TopBarText>().UpdateText();
            UpdateStoreData(data_Store);
        }
    }
}

[System.Serializable]
public class SpriteArray //상품 이미지 배열의 행
{
    //하이어라키 화면에 이차원 배열로 보이기 위해 만든 상품 이미지 클래스

    public Sprite[] imageList;
}
