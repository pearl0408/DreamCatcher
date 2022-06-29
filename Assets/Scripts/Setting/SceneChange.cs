using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{

    public void ChangeStartScene()
    {
        GameObject.FindWithTag("AudioManager").GetComponent<EffectChange>().PlayEffect_OpenScene();
        SceneManager.LoadScene("Start");
    }
    public void ChangeMainScene()
    {
        GameObject.FindWithTag("AudioManager").GetComponent<EffectChange>().PlayEffect_OpenScene();
        SceneManager.LoadScene("Main");
    }

    public void ChangeMakingScene()
    {
        GameObject.FindWithTag("AudioManager").GetComponent<EffectChange>().PlayEffect_OpenScene();
        SceneManager.LoadScene("Making");
    }
   
    public void ChangeGuideScene()
    {
        GameObject.FindWithTag("AudioManager").GetComponent<EffectChange>().PlayEffect_OpenScene();
        SceneManager.LoadScene("CollectionBook");
    }

    public void ChangeStoreScene()
    {
        GameObject.FindWithTag("AudioManager").GetComponent<EffectChange>().PlayEffect_OpenScene();
        SceneManager.LoadScene("Store");
    }
}
