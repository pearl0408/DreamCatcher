using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainProducts : MonoBehaviour
{
    [Header("[Good Objects]")]
    public Image[] goodsContents;   //상품 오브젝트 배열(이미지 변경을 위해 이미지만)
    public SpriteArray[] goodsImages; //상품 이미지 배열

    private GoodsContainer curGoodsData;   //플레이어의 저장된 상품 레벨 정보

    private void Start()
    {
        ResetMainProducts(); //상품 정보 업데이트
    }

    public void ResetMainProducts()
    {
        //상품을 이미지를 불러오는 함수

        GameManager.instance.ResetGameManager();    //저장 데이터 갱신
        curGoodsData = GameManager.instance.loadGoodsData;  //저장 데이터 가져오기

        for (int i = 0; i < curGoodsData.goodsCount; i++)
        {
            int goodsLevel = curGoodsData.goodsList[i].goodsLevel;  //상품 레벨
            goodsContents[i].gameObject.GetComponent<Image>().sprite = goodsImages[i].imageList[goodsLevel]; //상품 이미지 불러옴
        }
    }
}
