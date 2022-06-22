using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : Poolable
{
    //Pooling�� �� ������Ʈ Cloud�� �߰��ϴ� ������Ʈ

    [Header("[Cloud Info]")]
    [SerializeField] private float speed = 30f;     //���� �ӵ� ����
    [SerializeField] private int range_x = 1500;     //x�� �̵� ���� ����
    Vector2 dir;    //���� ���� ����

    private void Update()
    {
        //�� �����Ӹ��� ���� �̵� 
    
        transform.Translate(dir * speed * Time.deltaTime);  //���� �̵�
        if (transform.position.x > range_x)
        {
            Push();
        }
    }

    private void OnEnable()
    {
        //������ Ȱ��ȭ�Ǹ� ���������� �����̵��� �����ϴ� �Լ�

        //���� ���� ����
        transform.position = Vector2.zero;
        dir = new Vector2(50f, 0).normalized;
    }
}
