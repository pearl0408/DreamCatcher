using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : Poolable
{
    //Pooling�� �� ������Ʈ Cloud�� �߰��ϴ� ������Ʈ

    float speed = 100f;
    Vector2 dir;

    private void Update()
    {
        //�� �����Ӹ��� ���� �̵�

        transform.Translate(dir * speed * Time.deltaTime);
    }

    private void OnEnable()
    {
        //������ Ȱ��ȭ�Ǹ� ���������� �����̵��� �����ϴ� �Լ�

        //���� ���� ����
        transform.position = Vector2.zero;
        dir = new Vector2(100f, 0).normalized;
    }

    private void OnBecameInvisible()
    {
        //ī�޶󿡼� �������� ǥ�õ��� ������ �ٽ� Ǯ�� �ִ� �Լ�

        Push();
    }
}
