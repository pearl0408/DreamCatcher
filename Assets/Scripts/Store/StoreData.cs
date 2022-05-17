using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreData : MonoBehaviour
{
    //���� CSV ������ �����͸� �������� Ŭ����

    [Header("Store Product")]
    [SerializeField] private GameObject[] goodsContents;   //��ǰ ������Ʈ �迭(ȶ��, ȭ��, ����, ��)
    [SerializeField] private GoodsContainer curGoodsData;   //��ǰ ����
    [SerializeField] private SpriteArray[] goodsImages; //��ǰ �̹��� �迭


    private int[] currentCost = new int[4]; //���� ����


    private void OnEnable()
    {
        curGoodsData = GameManager.instance.loadGoodsData;   //�÷��̾��� ��ǰ ������ ������

        List<Dictionary<string, object>> data_Store = CSVReader.Read("Store");  //���� �����͸� ������  
        UpdateStoreData(data_Store);
    }

    public void UpdateStoreData(List<Dictionary<string, object>> data)
    {
        //���� �����͸� �������� �Լ�
        
        int productCnt = 1; //��ǰ ī�װ� ���� ��ȣ
        for (int i = 0; i < curGoodsData.goodsCount; i++, productCnt += 5)
        {
            int goodsLevel = curGoodsData.goodsList[i].goodsLevel;  //��ǰ ����
            goodsContents[i].transform.GetChild(4).GetChild(1).gameObject.GetComponent<Text>().text = data[productCnt + goodsLevel]["Effect"].ToString();   //��ǰ �̸� �ҷ���
            goodsContents[i].transform.GetChild(6).GetChild(2).gameObject.GetComponent<Text>().text = data[productCnt + goodsLevel]["Gold"].ToString();     //��ǰ ���� �ҷ���
            currentCost[i] = int.Parse(data[productCnt + goodsLevel]["Gold"].ToString());   //���Ÿ� ���� ��ǰ�� ���ݸ� ���� ����
            goodsContents[i].transform.GetChild(1).gameObject.GetComponent<Image>().sprite = goodsImages[i].imageList[goodsLevel]; //��ǰ �̹��� �ҷ���
        }
    }
    
    public void AddGoodsLevel(int goodsIndex)
    {
        curGoodsData.goodsList[goodsIndex].goodsLevel++;    //��ǰ ���� ����
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<GoodsJSON>().DataSaveText(curGoodsData);   //������� json���� ����
    }

    //*buy �Լ��� virtual�� �������� Ȯ�� �� ������ ����
    public void BuyRack()
    {
        List<Dictionary<string, object>> data_Store = CSVReader.Read("Store");  //���� �����͸� ������  

        if (GameManager.instance.playerGold >= currentCost[0])      //�÷��̾� ��尡 ��ǰ �ݾ׺��� ũ�ٸ�
        {
            //��ǰ ����(���� ��� ����, ��ǰ ���� ����, ��ܹ� ������Ʈ, ���� ������Ʈ)
            GameManager.instance.playerGold -= currentCost[0];  
            AddGoodsLevel(0);
            GameObject.FindGameObjectWithTag("SceneManager").GetComponent<TopBarText>().UpdateText();
            UpdateStoreData(data_Store);
        }
    }

    public void BuyVase()
    {
        List<Dictionary<string, object>> data_Store = CSVReader.Read("Store");  //���� �����͸� ������  

        if (GameManager.instance.playerGold >= currentCost[1])  //�÷��̾� ��尡 ��ǰ �ݾ׺��� ũ�ٸ�
        {
            //��ǰ ����(���� ��� ����, ��ǰ ���� ����, ��ܹ� ������Ʈ, ���� ������Ʈ)
            GameManager.instance.playerGold -= currentCost[1];
            AddGoodsLevel(1);
            GameObject.FindGameObjectWithTag("SceneManager").GetComponent<TopBarText>().UpdateText();
            UpdateStoreData(data_Store);
        }
    }

    public void BuyBox()
    {
        List<Dictionary<string, object>> data_Store = CSVReader.Read("Store");  //���� �����͸� ������  

        if (GameManager.instance.playerGold >= currentCost[2])  //�÷��̾� ��尡 ��ǰ �ݾ׺��� ũ�ٸ�
        {
            //��ǰ ����(���� ��� ����, ��ǰ ���� ����, ��ܹ� ������Ʈ, ���� ������Ʈ)
            GameManager.instance.playerGold -= currentCost[2];
            AddGoodsLevel(2);
            GameObject.FindGameObjectWithTag("SceneManager").GetComponent<TopBarText>().UpdateText();
            UpdateStoreData(data_Store);
        }
    }

    public void BuyThread()
    {
        List<Dictionary<string, object>> data_Store = CSVReader.Read("Store");  //���� �����͸� ������  


        if (GameManager.instance.playerGold >= currentCost[3])  //�÷��̾� ��尡 ��ǰ �ݾ׺��� ũ�ٸ�
        {
            //��ǰ ����(���� ��� ����, ��ǰ ���� ����, ��ܹ� ������Ʈ, ���� ������Ʈ)
            GameManager.instance.playerGold -= currentCost[3];
            AddGoodsLevel(3);
            GameObject.FindGameObjectWithTag("SceneManager").GetComponent<TopBarText>().UpdateText();
            UpdateStoreData(data_Store);
        }
    }
}

[System.Serializable]
public class SpriteArray //��ǰ �̹��� �迭�� ��
{
    //���̾��Ű ȭ�鿡 ������ �迭�� ���̱� ���� ���� ��ǰ �̹��� Ŭ����

    public Sprite[] imageList;
}
