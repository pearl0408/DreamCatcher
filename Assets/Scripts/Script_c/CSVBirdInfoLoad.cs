using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
        int startTime = int.Parse(data[index]["starttime"].ToString());
        int endTime = int.Parse(data[index]["endtime"].ToString());
        // �ؽ�Ʈ ����(����ð�)
        if (startTime < 3600)
        {
            if (startTime == endTime)
            {

                timeTxt.text = startTime / 60 + "��";
            }
            else
            {
                timeTxt.text = startTime / 60 + "��~" + endTime / 60 + "��";
            }
        }
        else
        {
            if (startTime == endTime)
            {

                timeTxt.text = startTime / 3600 + "�ð�";
            }
            else
            {
                timeTxt.text = startTime / 3600 + "�ð�~" + endTime / 3600 + "�ð�";
            }
        }
        

        // �����̴� ����
        numberSlide.maxValue = (int)data[index]["maxnum"];
        numberSlide.value = int.Parse(data[index]["number"].ToString());

        // �̹��� ����
        foodImg.sprite = foodImgs[index/4];
        birdImg.sprite = birdImgs[index];
        featherImg.sprite = featherImgs[index];
    }

    public void SaveBirdInfo()
    {
        CSVParser.WriteFromFile("BirdInfo", data);
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

    // �� �������� ����
    public void GoDreamCollection()
    {
        SceneManager.LoadScene("CollectionDream");
    }
}
