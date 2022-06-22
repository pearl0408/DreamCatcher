using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCloud : MonoBehaviour
{
    // ������ �����ϴ� ������Ʈ�� �߰��ϴ� ������Ʈ

    [Header("[Cloud Create]")]
    [SerializeField] private float createTime = 30f;     //���� ���� �ð� ����
    [SerializeField] private float range_low = -225f;    //���� ���� ���� ���� ����
    [SerializeField] private float range_high = 175f;    //���� �ְ� ���� ���� ����

    [Space]
    public GameObject CloudPos;   //���� ���� ��ġ ���� ������Ʈ

    void Start()
    {        
        StartCoroutine(StartMakeCloud(createTime));  //���� ���� �ڷ�ƾ ����
    }

    IEnumerator StartMakeCloud(float time)    
    {
        //���� ���� �ڷ�ƾ �Լ�

        bool isInactiveObject;      //��Ȱ��ȭ�� (����)������Ʈ�� �ִ��� ���� ����
        while (true)
        {
            isInactiveObject = ObjectPoolManager.Instance.pool.IsInactiveObject();  //��Ȱ��ȭ�� ������Ʈ�� �ִ��� Ȯ��
            if (isInactiveObject)   //��Ȱ��ȭ�� ������Ʈ�� �ִٸ�
            {
                MakeCloud();    //���� ������Ʈ ����
                yield return new WaitForSeconds(time);    //���� ���� �ð���ŭ ��ٸ�
            }
            else    //��Ȱ��ȭ�� ������Ʈ�� ���ٸ�
            {
                yield return new WaitForSeconds(1f);    //���� ��ٷ� ����
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
