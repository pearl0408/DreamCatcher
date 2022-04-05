using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

// 출처: https://bravenewmethod.com/2014/09/13/lightweight-csv-reader-for-unity/
public class CSVParser : MonoBehaviour
{
    static string SPLIT_RE = @",(?=(?:[^""]*""[^""]*"")*(?![^""]*""))"; // 엑셀 한 칸을 나누는 기준?
    static string LINE_SPLIT_RE = @"\r\n|\n\r|\n|\r"; // 라인(엑셀 한 줄)을 나누는 기준을 적어 놓은 것 같은데
    static char[] TRIM_CHARS = { '\"' };

    /// <summary>
    /// 해당 csv 파일을 읽어 파싱해옵니다. Resources 하위의 경로를 입력으로 받습니다.
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
        Debug.Log("파싱 시작");
        var list = new List<Dictionary<string, object>>(); // 마지막으로 리턴할 리스트임

        // 정규식 패턴에 의해 정의된 위치에서 부분 문자열로 이루어진 배열로 입력 문자열을 분할합니다.
        // 라인 자르기
        var lines = Regex.Split(data, LINE_SPLIT_RE);

        if (lines.Length <= 1) return list;

        // 헤더 자르기
        var header = Regex.Split(lines[0], SPLIT_RE);

        for (var i = 1; i < lines.Length; i++) // 엑셀 라인 수 만큼(위에 헤더 하나 없으니까 1부터)
        {

            var values = Regex.Split(lines[i], SPLIT_RE); // 헤더 아래 내용 자르기
            if (values.Length == 0 || values[0] == "") continue; // 값이 없을 때?

            var entry = new Dictionary<string, object>(); // 마지막에 있는 리스트 파츠
            for (var j = 0; j < header.Length && j < values.Length; j++) //엑셀 칸 수만큼?
            {
                string value = values[j]; // 칸 자른 거 한 칸씩 받아오기

                // 부가설명
                // TrimStart(Char[]) : 현재 문자열에서 배열에 지정된 문자 집합의 선행 항목을 모두 제거합니다.
                // TrimEnd(Char[]) : 현재 문자열에서 배열에 지정된 문자 집합의 후행 항목을 모두 제거합니다.
                // Replace(String, String) : 현재 인스턴스의 지정된 문자열이 지정된 다른 문자열로 모두 바뀌는 새 문자열을 반환합니다.
                value = value.TrimStart(TRIM_CHARS).TrimEnd(TRIM_CHARS).Replace("\\", "");
                object finalvalue = value; // 아 위에 리스트에 들어가야하는게 오브젝트네

                // ?
                int n;
                float f;
                if (int.TryParse(value, out n)) // 이게 bool형으로 나오나?
                {
                    finalvalue = n; // n으로 받은게 없는데 어케 n이...
                }
                else if (float.TryParse(value, out f))
                {
                    finalvalue = f;
                }
                entry[header[j]] = finalvalue;
            }
            list.Add(entry); // 리스트에 엔트리 추가
        }
        return list; // 리스트 리턴
    }
}