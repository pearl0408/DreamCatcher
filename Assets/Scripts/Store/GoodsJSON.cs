using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GoodsJSON : MonoBehaviour
{
    private static string fileName = "GoodsDataFile";       //���� �̸�
    GoodsContainer goodsContainer;  //��ǰ ������ ����

    public void LoadGoodsData()
    {
        //�����͸� �ε��ϴ� �Լ�

        string savePath = getPath(fileName);    //���� ���� ���

        if (!File.Exists(savePath))  //������ �������� �ʴ´ٸ�
        {
            this.goodsContainer = new GoodsContainer();  //��ü ����
        }
        else    //������ �����Ѵٸ�
        {
            this.goodsContainer = DataLoadText<GoodsContainer>(); //���� �ε�
        }
    }

    public GoodsContainer GetGoodsData()
    {
        //�����͸� ��ȯ�ϴ� �Լ�

        LoadGoodsData();
        return goodsContainer;
    }

    public void DataSaveText<T>(T data)
    {
        //�����͸� Json���� �����ϴ� �Լ�

        try
        {
            string savePath = getPath(fileName);    //���� ���� ���
            string saveJson = JsonUtility.ToJson(data, true);

            File.WriteAllText(savePath, saveJson);
        }
        catch (FileNotFoundException e)
        {
            Debug.Log("The file was not found:" + e.Message);
        }
        catch (DirectoryNotFoundException e)
        {
            Debug.Log("The directory was not found: " + e.Message);
        }
        catch (IOException e)
        {
            Debug.Log("The file could not be opened:" + e.Message);
        }
    }

    public T DataLoadText<T>()
    {
        //Json �����͸� �ҷ����� �Լ�

        try
        {
            string savePath = getPath(fileName);    //���� ���� ���
            string loadJson = File.ReadAllText(savePath);

            T t = JsonUtility.FromJson<T>(loadJson);
            return t;
        }
        catch (FileNotFoundException e)
        {
            Debug.Log("The file was not found:" + e.Message);
        }
        catch (DirectoryNotFoundException e)
        {
            Debug.Log("The directory was not found: " + e.Message);
        }
        catch (IOException e)
        {
            Debug.Log("The file could not be opened:" + e.Message);
        }
        return default;
    }

    private static string getPath(string fileName)
    {
#if UNITY_EDITOR
        return Application.dataPath + "/Saves/" + fileName + ".json";
#elif UNITY_ANDROID
        return Application.persistentDataPath+"TalkData.csv";
#elif UNITY_IPHONE
        return Application.persistentDataPath+"/"+"TalkData.csv";
#else
        return Application.dataPath +"/"+"TalkData.csv";
#endif
    }
}
