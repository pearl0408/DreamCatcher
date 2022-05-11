using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

// ��ó: https://bravenewmethod.com/2014/09/13/lightweight-csv-reader-for-unity/
public class CSVParser : MonoBehaviour
{
    static string SPLIT_RE = @",(?=(?:[^""]*""[^""]*"")*(?![^""]*""))"; // ���� �� ĭ�� ������ ����?
    static string LINE_SPLIT_RE = @"\r\n|\n\r|\n|\r"; // ����(���� �� ��)�� ������ ������ ���� ���� �� ������
    static char[] TRIM_CHARS = { '\"' };

    /// <summary>
    /// �ش� csv ������ �о� �Ľ��ؿɴϴ�. Resources ������ ��θ� �Է����� �޽��ϴ�.
    /// </summary>
    public static List<Dictionary<string, object>> ReadFromFile(string fileName)
    {
        TextAsset data = Resources.Load(fileName) as TextAsset;
        return Read(data);
    }

    public static List<Dictionary<string, object>> Read(TextAsset data)
    {
        return Read(data.text);
    }

    public static void WriteFromFile(string fileName, List<Dictionary<string, object>> Mydata)
    {
        TextAsset data = Resources.Load(fileName) as TextAsset;
        Write(fileName, data, Mydata);
    }

    public static void Write(string fileName, TextAsset data, List<Dictionary<string, object>> Mydata)
    {
        // ��� �ҷ�����
        var lines = Regex.Split(data.text, LINE_SPLIT_RE); // ���� �ڸ���
        string[] header = Regex.Split(lines[0], SPLIT_RE); // ��� �ڸ���
        Write(fileName, header, Mydata);
    }

    public static List<Dictionary<string, object>> Read(string data)
    {
        var list = new List<Dictionary<string, object>>(); // ���������� ������ ����Ʈ��

        // ���Խ� ���Ͽ� ���� ���ǵ� ��ġ���� �κ� ���ڿ��� �̷���� �迭�� �Է� ���ڿ��� �����մϴ�.
        // ���� �ڸ���
        var lines = Regex.Split(data, LINE_SPLIT_RE);

        if (lines.Length <= 1) return list;

        // ��� �ڸ���
        var header = Regex.Split(lines[0], SPLIT_RE);

        for (var i = 1; i < lines.Length; i++) // ���� ���� �� ��ŭ(���� ��� �ϳ� �����ϱ� 1����)
        {

            var values = Regex.Split(lines[i], SPLIT_RE); // ��� �Ʒ� ���� �ڸ���
            if (values.Length == 0 || values[0] == "") continue; // ���� ���� ��?

            var entry = new Dictionary<string, object>(); // �������� �ִ� ����Ʈ ����
            for (var j = 0; j < header.Length && j < values.Length; j++) //���� ĭ ����ŭ?
            {
                string value = values[j]; // ĭ �ڸ� �� �� ĭ�� �޾ƿ���

                // �ΰ�����
                // TrimStart(Char[]) : ���� ���ڿ����� �迭�� ������ ���� ������ ���� �׸��� ��� �����մϴ�.
                // TrimEnd(Char[]) : ���� ���ڿ����� �迭�� ������ ���� ������ ���� �׸��� ��� �����մϴ�.
                // Replace(String, String) : ���� �ν��Ͻ��� ������ ���ڿ��� ������ �ٸ� ���ڿ��� ��� �ٲ�� �� ���ڿ��� ��ȯ�մϴ�.
                value = value.TrimStart(TRIM_CHARS).TrimEnd(TRIM_CHARS).Replace("\\", "");
                object finalvalue = value; // �� ���� ����Ʈ�� �����ϴ°� ������Ʈ��

                // ?
                int n;
                float f;
                if (int.TryParse(value, out n)) // �̰� bool������ ������?
                {
                    finalvalue = n; // n���� ������ ���µ� ���� n��...
                }
                else if (float.TryParse(value, out f))
                {
                    finalvalue = f;
                }
                entry[header[j]] = finalvalue;
            }
            list.Add(entry); // ����Ʈ�� ��Ʈ�� �߰�
        }
        return list; // ����Ʈ ����
    }

    // ������ CSV�� �����ϱ�
    public static void Write(string fileName, string[] header, List<Dictionary<string, object>> data)
    {
        
        Debug.Log(header[3]);

        // ������ ������ ����� ����
        List<string[]> rowData = new List<string[]>();

        // ��� �ֱ�->header�� �޾ƿԴ��� �״�� �ֱ�
        string[] rowDataTemp = new string[header.Length];

        for (int k = 0; k < header.Length; k++)
        {
            rowDataTemp[k] = header[k];
        }
        rowData.Add(rowDataTemp);

        // ����� ������ ���� �� ����� �ֱ�
        for (int u = 0; u < data.Count; u++)
        {
            rowDataTemp = new string[header.Length];
            for (int i = 0; i < data[u].Count; i++)
            {
                rowDataTemp[i] = (data[u][header[i]]).ToString();
            }
            rowData.Add(rowDataTemp);
        }

        // ��Ʈ�� �迭�� �̻�?
        string[][] output = new string[data.Count + 1][];

        for (int i = 0; i < output.Length; i++)
        {
            output[i] = rowData[i];
        }

        int length = output.GetLength(0); // �� ��
        string delimiter = ","; // ������

        StringBuilder sb = new StringBuilder();

        // ������ �ֱ�
        for (int index = 0; index < length; index++)
        {
            sb.AppendLine(string.Join(delimiter, output[index]));
        }

        // ���� ��� ����
        string filePath = getPath(fileName);

        // ���� ����
        StreamWriter outStream = System.IO.File.CreateText(filePath);
        outStream.WriteLine(sb);
        outStream.Close();

        Debug.Log(filePath);
    }

    private static string getPath(string fileName)
    {
#if UNITY_EDITOR
        return Application.dataPath + "/Resources/"+fileName+".csv";
#elif UNITY_ANDROID
        return Application.persistentDataPath+"TalkData.csv";
#elif UNITY_IPHONE
        return Application.persistentDataPath+"/"+"TalkData.csv";
#else
        return Application.dataPath +"/"+"TalkData.csv";
#endif
    }
}