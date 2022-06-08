using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class TimerJSON : MonoBehaviour
{
    //���� ���� �ð��� �����ϴ� ��ũ��Ʈ

    private static string fileName = "FeedTimerFile";       //���� �̸�
    private static string path;     //���� ���
    TimerData timerData;    //Ÿ�̸� ������ ����

    void Awake()
    {
        TimerJSON.path = Application.dataPath + "/Saves/";  //���� ��� ����(����Ƽ ������ ����)
        //TimerJSON.path = Application.persistentDataPath;   //pc ���� ���
    }

    public void LoadTimerData()
    {
        //�����͸� �ε��ϴ� �Լ�

        string savePath = path + fileName + ".json";    //���� ���� ���

        if (!File.Exists(savePath))  //������ �������� �ʴ´ٸ�
        {
            this.timerData = new TimerData(false, System.DateTime.Now.ToString(), 0f);  //��ü ����
        }
        else    //������ �����Ѵٸ�
        {
            this.timerData = DataLoadText<TimerData>(); //���� �ε�
        }
    }

    public TimerData GetTimerData()
    {
        //�����͸� ��ȯ�ϴ� �Լ�

        LoadTimerData();
        return timerData;
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
