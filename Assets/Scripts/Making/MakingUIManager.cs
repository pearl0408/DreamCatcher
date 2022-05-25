using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MakingUIManager : MonoBehaviour
{
    public GameObject StringWindow, FeatherWindow;
    public GameObject StringBtn, FeatherBtn;

    // Start is called before the first frame update
    void Start()
    {
        StringWin();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StringWin()
    {
        // StringWin Ȱ��ȭ, FeatherWin ��Ȱ��ȭ
        StringWindow.SetActive(true);
        FeatherWindow.SetActive(false);
        // StringBtn ����, FeatherBtn ���
        StringBtn.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        FeatherBtn.GetComponent<Image>().color = new Color(0.5943396f, 0.5943396f, 0.5943396f, 1.0f);
    }

    public void FeatherWin()
    {
        // FeatherWin Ȱ��ȭ, StringWin ��Ȱ��ȭ
        FeatherWindow.SetActive(true);
        StringWindow.SetActive(false);
        // FeatherBtn ����, StringBtn ���
        FeatherBtn.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        StringBtn.GetComponent<Image>().color = new Color(0.5943396f, 0.5943396f, 0.5943396f, 1.0f);
    }
}
