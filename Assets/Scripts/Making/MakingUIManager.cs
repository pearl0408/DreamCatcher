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
        // StringWin 활성화, FeatherWin 비활성화
        StringWindow.SetActive(true);
        FeatherWindow.SetActive(false);
        // StringBtn 밝음, FeatherBtn 어둡
        StringBtn.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        FeatherBtn.GetComponent<Image>().color = new Color(0.5943396f, 0.5943396f, 0.5943396f, 1.0f);
    }

    public void FeatherWin()
    {
        // FeatherWin 활성화, StringWin 비활성화
        FeatherWindow.SetActive(true);
        StringWindow.SetActive(false);
        // FeatherBtn 밝음, StringBtn 어둡
        FeatherBtn.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        StringBtn.GetComponent<Image>().color = new Color(0.5943396f, 0.5943396f, 0.5943396f, 1.0f);
    }
}
