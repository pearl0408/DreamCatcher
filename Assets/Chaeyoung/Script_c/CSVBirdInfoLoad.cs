using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CSVBirdInfoLoad : MonoBehaviour
{
    // UI 오브젝트
    public Text numberTxt, nameTxt, expTxt, timeTxt;
    public Image foodImg, birdImg, featherImg;

    // 이미지
    public Sprite[] birdImgs = new Sprite[16];
    public Sprite[] foodImgs = new Sprite[16];
    public Sprite[] featherImgs = new Sprite[16];

    List<Dictionary<string, object>> data;
    private void Start()
    {
        data = CSVParser.ReadFromFile("BirdInfo");
        LoadCSV(1);
    }

    public void LoadCSV(int index)
    {
        numberTxt.text = "획득 수 "+data[index]["number"]+"마리";
        nameTxt.text = (string)data[index]["name"];
        expTxt.text = (string)data[index]["exp"];
        timeTxt.text = (string)data[index]["time"];

        foodImg.sprite = foodImgs[index];
        birdImg.sprite = birdImgs[index];
        featherImg.sprite = featherImgs[index];
    }
}
