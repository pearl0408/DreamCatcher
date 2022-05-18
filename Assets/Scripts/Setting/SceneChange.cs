using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{

    public void ChangeMainScene()
    {
        SceneManager.LoadScene("Main");
    }

    public void ChangeMakingScene()
    {
        //SceneManager.LoadScene("Store");
    }
   
    public void ChangeGuideScene()
    {
        //SceneManager.LoadScene("Store");
    }

    public void ChangeStoreScene()
    {
        SceneManager.LoadScene("Store");
    }
}
