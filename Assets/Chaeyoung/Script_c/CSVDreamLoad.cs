using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CSVDreamLoad : MonoBehaviour
{
    // �г�
    public GameObject DreamInfoPanel;

    // ������
    List<Dictionary<string, object>> data;

    // UI ������Ʈ
    public GameObject[] dreamColImg = new GameObject[16];
    public Text[] dreamColName = new Text[16];

    public Text nameTxt;
    public Image dreamCatcherImg, lineImg, featherImg1, featherImg2, featherImg3;

    // �̹���
    public Sprite[] dreamImgs = new Sprite[16]; // �� ������ �̹���
    public Sprite[] dreamCatcherImgs = new Sprite[16]; // �帲ĳ�� �̹���
    public Sprite[] lineImgs = new Sprite[5]; // �� �̹���
    public Sprite[] featherImgs = new Sprite[12]; // ���� �̹���

    // ��Ÿ
    private string[] featherNames= { "���ѱ�", "���ֺ�ѱ�", "���ۺ�ѱ�", "����", "�����", 
        "��������", "û���ٱ���", "����ٱ���", "�������ٱ���", "�û���", "��", "��Ӹ�����"};

    // Start is called before the first frame update
    private void Start()
    {
        DreamInfoPanel.SetActive(false);
        data = CSVParser.ReadFromFile("DreamInfo");
        LoadDreamCollection();
    }
    public void LoadDreamCollection()
    {
        for (int i = 0; i < 16; i++)
        {
            dreamColImg[i].GetComponent<Image>().sprite = dreamImgs[i];
            dreamColName[i].GetComponent<Text>().text = data[i]["name"].ToString(); // �̸� ����ǥ ó��
        }
    }

    public void LoadDreamInfo(int index)
    {
        // �ؽ�Ʈ ����(�̸�)
        nameTxt.text= data[index]["name"].ToString(); // �̸�

        // �̹��� ����(�帲ĳ��, ��, ����)
        dreamCatcherImg.sprite = dreamCatcherImgs[index]; // �帲ĳ��
        // ��
        if (data[index]["line"].ToString() == "w")
        {
            lineImg.sprite = lineImgs[0];
        }
        else if(data[index]["line"].ToString() == "y")
        {
            lineImg.sprite = lineImgs[1];
        }
        else if(data[index]["line"].ToString() == "b")
        {
            lineImg.sprite = lineImgs[2];
        }
        else if(data[index]["line"].ToString() == "r")
        {
            lineImg.sprite = lineImgs[3];
        }
        else
        {
            lineImg.sprite = lineImgs[4];
        }
        // ����
        for (int i = 0; i < 12; i++)
        {
            if (data[index]["feather1"].ToString() == featherNames[i])
            {
                featherImg1.sprite = featherImgs[i];
                break;
            }
        }
        for (int i = 0; i < 12; i++)
        {
            if (data[index]["feather2"].ToString() == featherNames[i])
            {
                featherImg2.sprite = featherImgs[i];
                break;
            }
        }
        for (int i = 0; i < 12; i++)
        {
            if (data[index]["feather3"].ToString() == featherNames[i])
            {
                featherImg3.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                featherImg3.sprite = featherImgs[i];
                break;
            }
            else if (data[index]["feather3"].ToString() == "����")
            {
                featherImg3.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
                break;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // �� ���� ���� �г� ����
    public void DreamInfo(int index)
    {
        DreamInfoPanel.SetActive(true);
        LoadDreamInfo(index);
    }

    // �� ���� ���� �г� �ݱ�
    public void DreamInfoBack()
    {
        DreamInfoPanel.SetActive(false);
    }

    // �� �������� ����
    public void GoBirdColl()
    {
        //SceneManager.LoadScene("");
    }
}
