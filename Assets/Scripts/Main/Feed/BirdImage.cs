using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BirdImage : MonoBehaviour
{
    //���� ���� �̹����� �����ϴ� Ŭ����
    [Header("Bird Select")]

    //[SerializeField] private int categoryCnt;    //���� ī�װ� ��ȣ
    [SerializeField] private int selectedBirdNum;    //Ȯ���� ���� �������� ������ ���� ��ȣ

    [SerializeField] private GameObject viewBird;   //�������� �� ������Ʈ
    [SerializeField] private Sprite[] birdImage; //���� �̹��� �迭
    [SerializeField] private Sprite[] birdFeatherImage;  //�� ������ �̹��� �迭


    void Start()
    {
        selectedBirdNum = 0;
    }

    public int SelectBirdType(int feedNum)
    {
        //�� ������ ���ϴ� �Լ�

        List<int> birdRandom = new List<int>(); //�� ���� Ȯ���� ��÷�� ����Ʈ
        //int[] birdRandom = new int[10];

        int categoryCnt = SettingCategoryCnt(feedNum); //ī�װ�(�� ����, ����) ���� ��ȣ�� ������
        List<Dictionary<string, object>> data_birdInfo = CSVParser.ReadFromFile("BirdInfo");  //���� �����͸� ������ 
        for (int i = 0; i < 3; i++)
        {
            int appearCnt = int.Parse(data_birdInfo[categoryCnt + i]["probability"].ToString());   //������ ����� �ش� ������ i��° ���� ���� Ȯ���� ������
            appearCnt /= 10;    //���� Ȯ���� �迭�� �Է��� ������ ��ȯ

            for (int j = 0; j < appearCnt; j++)
            {
                birdRandom.Add(i);  //����Ʈ�� i�� �� ����Ȯ����ŭ �Է�
            }
        }

        int randomBird = Random.Range(0, 10);   //�������� ���� �̱� ���� ���� ����(0~9 ������ �� �ϳ�)

        /*        Debug.Log(randomBird);      //���� ����
                Debug.Log(birdRandom[randomBird]);  //���� �� ��ȣ*/

        selectedBirdNum = birdRandom[randomBird] + categoryCnt;
        return selectedBirdNum;  //������ ���� ��
    }

    public void SelectBirdImage()
    {
        //���� �̹����� ���ϴ� �Լ�

        viewBird.gameObject.GetComponent<Image>().sprite = birdImage[selectedBirdNum];  //���� �̹����� �������� ������ ���� ��ȣ �̹����� ����
        viewBird.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = birdFeatherImage[selectedBirdNum]; //�� ������ �̹����� �������� ������ ���� ��ȣ �̹����� ����
    }

    public int SettingCategoryCnt(int feedNum)
    {
        //ī�װ� ���� ��ȣ�� ���ϴ� �Լ�
        int cnt = 0;

        switch (feedNum)
        {
            case 0:
                cnt = 0;
                break;
            case 1:
                cnt = 4;
                break;
            case 2:
                cnt = 8;
                break;
            case 3:
                cnt = 12;
                break;
            default:
                cnt = 0;
                break;
        }

        return cnt;
    }
}
