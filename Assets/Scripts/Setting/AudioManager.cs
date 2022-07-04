using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    //사운드 관련 기능을 관리하는 클래스

    //싱글톤 패턴을 사용하기 위한 전역 변수
    public static AudioManager instance;

    //배경음악, 효과음 조절 슬라이더 오브젝트를 가져올 변수
    public Slider BGSlider; //배경음악 슬라이더
    public Slider EFSlider; //효과음 슬라이더

    //오디오 크기 값을 저장할 변수
    private float BGVol;
    private float EFVol;

    //타이틀 씬 배경음악 오디오를 가져올 변수
    public AudioSource BGSound;
    public AudioSource EFSound;

    //오디오를 끄고 켤 토글
    public Toggle BGToggle;    //배경음악 토글
    public Toggle EffectToggle;    //효과음 토글

    //토글 값을 저장할 변수
    private int BGCheck;
    private int EffectCheck; 

    void Awake()
    {
        // 게임 시작과 동시에 싱글톤 구성

        if (instance)     //싱글톤 변수 instance가 이미 있다면
        {
            DestroyImmediate(gameObject);   //삭제
            return;
        }

        instance = this;    //유일한 인스턴스
        DontDestroyOnLoad(gameObject);  //씬이 바뀌어도 계속 유지시킴
    }

    private void Start()
    {  
        SettingAudio(); //오디오 설정
        SceneManager.sceneLoaded += LoadedsceneEvent;
    }


    private void LoadedsceneEvent(Scene scene, LoadSceneMode mode)
    {
        //씬이 바뀔 때마다 오디오 설정

        SettingAudio();
    }

    private void Update()
    {
        //실시간 값 변경 적용(update에 넣고 싶지 않은데,,, 마땅한 방법을 못 찾아서 임시로 여기에 적용)
        BGSoundSlider();
        EFSoundSlider();
        SetBGToggle();
        SetEffectToggle();
    }

    private void SettingAudio()
    {
        //슬라이더, 토글 오브젝트 가져옴
        GameObject Slider_Type = GameObject.FindWithTag("TopBar").transform.GetChild(0).GetChild(2).gameObject; //슬라이더 오브젝트 모음
        GameObject Toggle_Type = GameObject.FindWithTag("TopBar").transform.GetChild(0).GetChild(3).gameObject; //토글 오브젝트 모음

        BGSlider = Slider_Type.transform.GetChild(0).gameObject.GetComponent<Slider>();
        EFSlider = Slider_Type.transform.GetChild(1).gameObject.GetComponent<Slider>();
        BGToggle = Toggle_Type.transform.GetChild(1).gameObject.GetComponent<Toggle>();
        EffectToggle = Toggle_Type.transform.GetChild(2).gameObject.GetComponent<Toggle>();


        //PlayerPrefs에 저장된 값을 가져옴(값이 비었다면 1을 가져옴)
        BGVol = PlayerPrefs.GetFloat("BGVol", 1f);
        EFVol = PlayerPrefs.GetFloat("EFVol", 1f);
        BGCheck = PlayerPrefs.GetInt("BGCheck", 0);
        EffectCheck = PlayerPrefs.GetInt("EffectCheck", 0);

        //저장된 값을 슬라이더, 토글에 반영함
        BGSlider.value = BGVol;
        EFSlider.value = EFVol;
        BGToggle.isOn = BGCheck == 1 ? true : false;
        EffectToggle.isOn = EffectCheck == 1 ? true : false;

/*        //슬라이더, 토글의 값을 타이틀씬 배경음악 오디오에 반영함
        BGSound.volume = BGSlider.value;
        EFSound.volume = EFSlider.value;*/

        BGSound.mute = BGCheck == 1 ? true : false;
        EFSound.mute = EffectCheck == 1 ? true : false;
    }

    //BackGround Sound 조절 함수
    public void BGSoundSlider()
    {
        //값을 유지하기 위해 float형 변수에 넣은 후 PlayerPrefs()를 이용하여 저장함
        BGVol = BGSlider.value;
        BGSound.volume = BGSlider.value;
        PlayerPrefs.SetFloat("BGVol", BGVol);
    }

    //Effect Sound 조절 함수
    public void EFSoundSlider()
    {
        //값을 유지하기 위해 float형 변수에 넣은 후 PlayerPrefs()를 이용하여 저장함
        EFVol = EFSlider.value;
        EFSound.volume = EFSlider.value;
        PlayerPrefs.SetFloat("EFVol", EFVol);
    }

    //배경음악 음소거 함수
    public void SetBGToggle()
    {
        BGCheck = BGToggle.isOn == true ? 1 : 0;
        BGSound.mute = BGCheck == 1 ? true : false;
        PlayerPrefs.SetInt("BGCheck", BGCheck);
    }

    //효과음 음소거 함수
    public void SetEffectToggle()
    {
        EffectCheck = EffectToggle.isOn == true ? 1 : 0;
        EFSound.mute = EffectCheck == 1 ? true : false;
        PlayerPrefs.SetInt("EffectCheck", EffectCheck);
    }
}
