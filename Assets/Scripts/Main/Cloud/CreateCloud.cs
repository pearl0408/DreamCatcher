using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCloud : MonoBehaviour
{
    // ������ �����ϴ� ������Ʈ�� �߰��ϴ� ������Ʈ

    public GameObject CloudPos;   //���� ���� ��ġ ���� ������Ʈ
    private float createTime = 30f;     //���� ���� �ð�
    private float range_low = -225f;    //���� ���� ���� ����
    private float range_high = 175f;    //���� �ְ� ���� ����

    void Start()
    {
        //���� ���� �ڷ�ƾ ����
        StartCoroutine(StartMakeCloud(createTime));
    }

    IEnumerator StartMakeCloud(float time)    
    {
        //���� ���� �ڷ�ƾ �Լ�

        bool isInactiveObject;
        while (true)
        {
            isInactiveObject = ObjectPoolManager.Instance.pool.IsInactiveObject();
            if (isInactiveObject)   //��Ȱ��ȭ�� ������Ʈ�� �ִٸ�
            {
                MakeCloud();
                yield return new WaitForSeconds(time);    //���� ���� �ð���ŭ ��ٸ�
            }
            else    //��Ȱ��ȭ�� ������Ʈ�� ���ٸ�
            {
                yield return new WaitForSeconds(1f);    //�ٷ� ����
            }
        }
    }

    public void MakeCloud()
    {
        //���� ���� �Լ�

        GameObject obj = ObjectPoolManager.Instance.pool.Pop();
        obj.transform.position = CloudPos.transform.position;

        RandomPosition(obj);   //���� ��ġ ����
    }

    private void RandomPosition(GameObject obj)
    {
        //���� ���� ���� ���� �Լ�

        obj.transform.Translate(new Vector2(0f, Random.Range(range_low, range_high)));
    }
}
