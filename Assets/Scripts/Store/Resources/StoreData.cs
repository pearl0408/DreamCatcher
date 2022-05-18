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
    [SerializeField] private TopBarContainer curPlayerData;   //�÷��̾� ������ ����
    [SerializeField] private SpriteArray[] goodsImages; //��ǰ �̹��� �迭


    private int[] currentCost = new int[4]; //���� ����


    private void OnEnable()
    {
        curGoodsData = GameManager.instance.loadGoodsData;   //�÷��̾��� ��ǰ ������ ������
        curPlayerData = GameManager.instance.loadTopBarData;    //�÷��̾��� ��ܹ� ������ ������ ������

        List<Dictionary<string, object>> data_Store = CSVReader.Read("Store");  //���� �����͸� ������  
        UpdateStoreData(data_Store);
    }

    public void UpdateStoreData(List<Dictionary<string, object>> data)
    {
        //���� �����͸� �������� �Լ�
        
        int productCnt = 1; //��ǰ ī�װ� ���� ��ȣ
        for (int i = 0; i < curGoodsData.goodsCount; i++, productCnt += 5)
        {
            int goodsLevel = curGoodsData.goodsList[i].goodsLevel + 1;  //��ǰ ����
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

    public void SpendGold(int cost)
    {
        curPlayerData.dataList[1].dataNumber -= cost;   //���� ��� ���� (����Ʈ�ڵ����� �������� ���)
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<TopBarJSON>().DataSaveText(curPlayerData);   //������� json���� ����
    }

    //*buy �Լ��� virtual�� �������� Ȯ�� �� ������ ����
    public void BuyRack()
    {
        List<Dictionary<string, object>> data_Store = CSVReader.Read("Store");  //���� �����͸� ������  

        if (curPlayerData.dataList[1].dataNumber >= currentCost[0])      //�÷��̾� ��尡 ��ǰ �ݾ׺��� ũ�ٸ�
        {
            //��ǰ ����
            SpendGold(currentCost[0]);  //���� ��� ����
            AddGoodsLevel(0);   //��ǰ ���� ����
            GameObject.FindGameObjectWithTag("SceneManager").GetComponent<TopBarText>().UpdateText();   //��ܹ� ������Ʈ
            UpdateStoreData(data_Store);    //���� ������Ʈ
        }
    }

    public void BuyVase()
    {
        List<Dictionary<string, object>> data_Store = CSVReader.Read("Store");  //���� �����͸� ������  

        if (curPlayerData.dataList[1].dataNumber >= currentCost[1])      //�÷��̾� ��尡 ��ǰ �ݾ׺��� ũ�ٸ�
        {
            //��ǰ ����
            SpendGold(currentCost[1]);  //���� ��� ����
            AddGoodsLevel(1);   //��ǰ ���� ����
            GameObject.FindGameObjectWithTag("SceneManager").GetComponent<TopBarText>().UpdateText();   //��ܹ� ������Ʈ
            UpdateStoreData(data_Store);    //���� ������Ʈ
        }
    }

    public void BuyBox()
    {
        List<Dictionary<string, object>> data_Store = CSVReader.Read("Store");  //���� �����͸� ������  

        if (curPlayerData.dataList[1].dataNumber >= currentCost[2])      //�÷��̾� ��尡 ��ǰ �ݾ׺��� ũ�ٸ�
        {
            //��ǰ ����
            SpendGold(currentCost[2]);  //���� ��� ����
            AddGoodsLevel(2);   //��ǰ ���� ����
            GameObject.FindGameObjectWithTag("SceneManager").GetComponent<TopBarText>().UpdateText();   //��ܹ� ������Ʈ
            UpdateStoreData(data_Store);    //���� ������Ʈ
        }
    }

    public void BuyThread()
    {
        List<Dictionary<string, object>> data_Store = CSVReader.Read("Store");  //���� �����͸� ������  


        if (curPlayerData.dataList[1].dataNumber >= currentCost[3])      //�÷��̾� ��尡 ��ǰ �ݾ׺��� ũ�ٸ�
        {
            //��ǰ ����
            SpendGold(currentCost[3]);  //���� ��� ����
            AddGoodsLevel(3);   //��ǰ ���� ����
            GameObject.FindGameObjectWithTag("TopBar").GetComponent<TopBarText>().UpdateText();   //��ܹ� ������Ʈ
            UpdateStoreData(data_Store);    //���� ������Ʈ
        }
    }
}

[System.Serializable]
public class SpriteArray //��ǰ �̹��� �迭�� ��
{
    //���̾��Ű ȭ�鿡 ������ �迭�� ���̱� ���� ���� ��ǰ �̹��� Ŭ����

    public Sprite[] imageList;
}
