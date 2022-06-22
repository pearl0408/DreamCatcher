using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    //���� ���� ����� �����ϴ� Ŭ����

    //�������, ȿ���� ���� �����̴� ������Ʈ�� ������ ����
    public Slider BGSlider; //������� �����̴�
    public Slider EFSlider; //ȿ���� �����̴�

    //����� ũ�� ���� ������ ����
    private float BGVol;
    private float EFVol;

    //Ÿ��Ʋ �� ������� ������� ������ ����
    public AudioSource BGSound;
    public AudioSource EFSound;

    //������� ���� �� ���
    public Toggle BGToggle;    //������� ���
    public Toggle EffectToggle;    //ȿ���� ���

    //��� ���� ������ ����
    private int BGCheck;
    private int EffectCheck;

    void Start()
    {
        //PlayerPrefs�� ����� ���� ������(���� ����ٸ� 1�� ������)
        BGVol = PlayerPrefs.GetFloat("BGVol", 1f);
        EFVol = PlayerPrefs.GetFloat("EFVol", 1f);
        BGCheck = PlayerPrefs.GetInt("BGCheck", 0);
        EffectCheck = PlayerPrefs.GetInt("EffectCheck", 0);

        //����� ���� �����̴�, ��ۿ� �ݿ���
        BGSlider.value = BGVol;
        EFSlider.value = EFVol;
        BGToggle.isOn = BGCheck == 1 ? true : false;
        EffectToggle.isOn = EffectCheck == 1 ? true : false;

        //�����̴�, ����� ���� Ÿ��Ʋ�� ������� ������� �ݿ���
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
/*        BGSoundSlider();    //������� �����̴��� ����
        EFSoundSlider();    //ȿ���� �����̴��� ����*/
/*        SetBGToggle();  //������� ��� ����
        SetEffectToggle();  //ȿ���� ��� ����*/

        //�����̴��� ���� �ǽð����� ����ȭ�� ������� ������� �ݿ���
/*        BGSound.volume = BGSlider.value;
        EFSound.volume = EFSlider.value;*/
    }

    //BackGround Sound ���� �Լ�
    public void BGSoundSlider()
    {
        //���� �����ϱ� ���� float�� ������ ���� �� PlayerPrefs()�� �̿��Ͽ� ������
        BGVol = BGSlider.value;
        BGSound.volume = BGSlider.value;
        PlayerPrefs.SetFloat("BGVol", BGVol);
    }

    //Effect Sound ���� �Լ�
    public void EFSoundSlider()
    {
        //���� �����ϱ� ���� float�� ������ ���� �� PlayerPrefs()�� �̿��Ͽ� ������
        EFVol = EFSlider.value;
        EFSound.volume = EFSlider.value;
        PlayerPrefs.SetFloat("EFVol", EFVol);
    }

    //ȿ������ �����Ű�� �Լ�
    public void PlayEffectMusic()
    {
        EFSound.Play();
    }

    //������� ���Ұ� �Լ�
    public void SetBGToggle()
    {
        BGCheck = BGToggle.isOn == true ? 1 : 0;
        BGSound.mute = BGCheck == 1 ? true : false;
        PlayerPrefs.SetInt("BGCheck", BGCheck);
    }

    //ȿ���� ���Ұ� �Լ�
    public void SetEffectToggle()
    {
        PlayEffectMusic();  //���

        EffectCheck = EffectToggle.isOn == true ? 1 : 0;
        EFSound.mute = EffectCheck == 1 ? true : false;
        PlayerPrefs.SetInt("EffectCheck", EffectCheck);
    }
}
