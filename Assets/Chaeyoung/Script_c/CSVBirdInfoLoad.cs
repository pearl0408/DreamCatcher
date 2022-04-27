using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CSVBirdInfoLoad : MonoBehaviour
{
    // �г�
    public GameObject BirdInfoPanel;

    // UI ������Ʈ
    public GameObject[] birdColImg = new GameObject[16];
    public Text[] birdColName = new Text[16];

    public Text numberTxt, nameTxt, expTxt, timeTxt;
    public Image foodImg, birdImg, featherImg;
    public Slider numberSlide;

    // �̹���
    public Sprite[] birdImgs = new Sprite[16];
    public Sprite[] foodImgs = new Sprite[4];
    public Sprite[] featherImgs = new Sprite[16];

    List<Dictionary<string, object>> data;
    static string[] headerString;
    private void Start()
    {
        BirdInfoPanel.SetActive(false);
        data = CSVParser.ReadFromFile("BirdInfo");
        // [�׽�Ʈ��]�������� data �� ����
        data[0]["appear"] = "1";
        data[1]["number"] = "7";
        LoadBirdCollection();
        // [�׽�Ʈ��]������ ���� ���� Write�� �̿��Ͽ� ���������� ����
        //CSVParser.Write(headerString, data);
    }

    // �� ��ü appear ���� ǥ��
    public void LoadBirdCollection()
    {
        for(int i=0; i<16; i++)
        {
            birdColImg[i].GetComponent<Image>().sprite = birdImgs[i];

            // ���� ������ �� ���ٸ�
            if(data[i]["appear"].ToString()=="0")
            {
                birdColImg[i].GetComponent<Image>().color = new Color(0f, 0f, 0f, 0.5f); // ȸ�� ó��
                birdColImg[i].GetComponent<Button>().interactable = false; // ��ư ��Ȱ��ȭ ó��
                birdColName[i].GetComponent<Text>().text = "???"; // �̸� ����ǥ ó��
            }
            else // ���� ������ ���� �ִٸ�
            {
                birdColName[i].GetComponent<Text>().text = data[i]["name"].ToString();
                birdColImg[i].GetComponent<Button>().interactable = true;
            }
        }
    }

    // �� ���� ���� �ε� : ���� Ŭ������ �� ���� ���� ����â�� �����͸� ǥ���Ѵ�.
    public void LoadBirdInfo(int index)
    {
        // �ؽ�Ʈ ����
        numberTxt.text = "ȹ�� �� "+data[index]["number"]+"����";
        nameTxt.text = (string)data[index]["name"];
        expTxt.text = (string)data[index]["exp"];
        timeTxt.text = (string)data[index]["time"];

        // �����̴� ����
        numberSlide.maxValue = (int)data[index]["maxnum"];
        numberSlide.value = int.Parse(data[index]["number"].ToString());

        // �̹��� ����
        foodImg.sprite = foodImgs[index/4];
        birdImg.sprite = birdImgs[index];
        featherImg.sprite = featherImgs[index];
    }

    // �� ���� ���� �г� ����
    public void BirdInfo(int index)
    {
        BirdInfoPanel.SetActive(true);
        LoadBirdInfo(index);
    }

    // �� ���� ���� �г� �ݱ�
    public void BirdInfoBack()
    {
        BirdInfoPanel.SetActive(false);
    }
}
