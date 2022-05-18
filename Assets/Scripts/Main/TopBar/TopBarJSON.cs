using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class TopBarJSON : MonoBehaviour
{
    private static string fileName = "TopBarDataFile";       //���� �̸�
    private static string path;     //���� ���
    TopBarContainer dataContainer;  //��ǰ ������ ����

    private void Awake()
    {
        //GoodsJSON.path = Application.dataPath + "/Saves/";  //���� ��� ����
    }

    public void LoadTopBarData()
    {
        //�����͸� �ε��ϴ� �Լ�

        string savePath = path + fileName + ".json";    //���� ���� ���

        if (!File.Exists(savePath))  //������ �������� �ʴ´ٸ�
        {
            this.dataContainer = new TopBarContainer();  //��ü ����
        }
        else    //������ �����Ѵٸ�
        {
            this.dataContainer = DataLoadText<TopBarContainer>(); //���� �ε�
        }
    }

    public TopBarContainer GetTopBarData()
    {
        //�����͸� ��ȯ�ϴ� �Լ�

        LoadTopBarData();
        return dataContainer;
    }

    public void DataSaveText<T>(T data)
    {
        //�����͸� Json���� �����ϴ� �Լ�

        try
        {
            string savePath = path + fileName + ".json";        //���� ���� ���
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
            string savePath = path + fileName + ".json";        //���� ���� ���
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
}
