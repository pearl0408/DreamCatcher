using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectChange : MonoBehaviour
{
    //이펙트 오디오 소소의 오디오 클립을 바꾸는 클래스


    public AudioSource EFAudioSource;     //이펙트 오디오 소스
    public AudioClip[] EffectClips;     //이펙트 오디오 클립 배열

    void Start()
    {
        EFAudioSource = this.gameObject.GetComponent<AudioManager>().EFSound;   //이펙트 오디오 소스를 가져옴
    }

    public void PlayEffect_OpenScene()
    {
        //씬 변경 효과음을 실행시키는 함수(이후 가상함수나 다른 효율적인 방식으로 수정)

        EFAudioSource.PlayOneShot(EffectClips[1], 1f);
    }
}
