using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdTouch : MonoBehaviour
{
    //��(Bird) ������Ʈ�� ������Ʈ�� ���� Ŭ����
    //�� ��ġ �̺�Ʈ(��ư �̺�Ʈ)


    public void BirdTouchEvent()
    {
        //���� ������ ��ġ�ϸ� ������� �Լ�
        //*���� ���� ���� �����Ϳ� �߰��ǵ��� ���� �ʿ�

        this.gameObject.SetActive(false);       //�� ������Ʈ ��Ȱ��ȭ
        GameObject.FindGameObjectWithTag("FeedManager").GetComponent<FeedManager>().SetIsFeedSelected(false);    //���� ������Ʈ ��Ȱ��ȭ
    }
}
