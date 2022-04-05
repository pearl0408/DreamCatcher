using System;
using System.Collections;
using System.Collections.Generic;
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

    public static List<Dictionary<string, object>> Read(string data)
    {
        Debug.Log("�Ľ� ����");
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
}