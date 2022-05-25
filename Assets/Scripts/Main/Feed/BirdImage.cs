using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdImage : MonoBehaviour
{

    //���� ���� �̹����� �����ϴ� Ŭ����

    void Start()
    {
        //���� Ȱ��ȭ ���� �� 


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

        Debug.Log(randomBird);
        Debug.Log(birdRandom[randomBird]);
        return birdRandom[randomBird];  //������ ���� ��
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
