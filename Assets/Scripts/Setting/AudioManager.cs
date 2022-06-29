using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    //사운드 관련 기능을 관리하는 클래스

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

    void Start()
    {
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

        //슬라이더, 토글의 값을 타이틀씬 배경음악 오디오에 반영함
        /*        BGSound.volume = BGSlider.value;
                EFSound.volume = EFSlider.value;*/

        BGSound.mute = BGCheck == 1 ? true : false;
        EFSound.mute = EffectCheck == 1 ? true : false;
/*        if (BGCheck == 1)
        {
            BGSound.volume = 0;
        }
        else
        {
            BGSound.volume = BGSlider.value;
        }

        if (EffectCheck == 1)
        {
            EFSound.volume = 0;
        }
        else
        {
            EFSound.volume = EFSlider.value;
        }*/
    }


    void Update()
    {
/*        BGSoundSlider();    //배경음악 슬라이더값 저장
        EFSoundSlider();    //효과음 슬라이더값 저장*/
/*        SetBGToggle();  //배경음악 토글 저장
        SetEffectToggle();  //효과음 토글 저장*/

        //슬라이더의 값을 실시간으로 시작화면 배경음악 오디오에 반영함
/*        BGSound.volume = BGSlider.value;
        EFSound.volume = EFSlider.value;*/
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

    //효과음을 실행시키는 함수
    public void PlayEffectMusic()
    {
        EFSound.Play();
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
        PlayEffectMusic();  //재생

        EffectCheck = EffectToggle.isOn == true ? 1 : 0;
        EFSound.mute = EffectCheck == 1 ? true : false;
        PlayerPrefs.SetInt("EffectCheck", EffectCheck);
    }
}
