using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyCheck : MonoBehaviour
{
    [Header("[Buy Check]")]
    [SerializeField] private int selectGoods;  //구매하려고 선택한 상품 번호
    public GameObject[] ButtonObj;  //상품 구매 오브젝트 배열

    [Space]
    public GameObject panel_buyCheck;   //상품 구매 확인 팝업

    private void Start()
    {
        int numberOfGoods = 4;   //상품 총 개수
        for (int i = 0; i < numberOfGoods; i++)
        {
            ButtonObj[i].gameObject.GetComponent<BuyButtonInfo>().SetSelectGoodsNumber(i);    //상품 구매 버튼 오브젝트에 고유 번호 지정
        }
    }

    public void SelectBuyingGoods(int buttonNumber)
    {
        //상품 구매 버튼을 눌러서 버튼 인덱스를 받은 함수

        selectGoods = buttonNumber; //선택한 상품 번호 갱신
        SetActiveBuyCheckPanel();   //상품 구매 확인 팝업 활성화
    }

    public void SelectYesButton()
    {
        //상품 구매 확인 패널에서 확인 버튼(구매 버튼)을 눌러서 구매하는 함수

        this.gameObject.GetComponent<StoreData>().BuyGoods(selectGoods);   //선택한 상품 구매
        SetInActiveBuyCheckPanel(); //상품 구매 확인 팝업 비활성화
    }

    public void SetActiveBuyCheckPanel()
    {
        //상품 구매 확인 패널을 활성화하는 함수

        panel_buyCheck.gameObject.SetActive(true);
    }

    public void SetInActiveBuyCheckPanel()
    {
        //상품 구매 확인 패널을 비활성화하는 함수

        panel_buyCheck.gameObject.SetActive(false);
    }
}
