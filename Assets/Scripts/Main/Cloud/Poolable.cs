using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poolable : MonoBehaviour
{
    //Pooling�� �� ������Ʈ�� ��ӹ޴� Ŭ����

    protected ObjectPool pool;

    public virtual void Create(ObjectPool pool)
    {
        this.pool = pool;
        gameObject.SetActive(false);    //ó�� ������ ���� ��Ȱ��ȭ(Ǯ �ȿ� �ִ� ����)
    }

    public virtual void Push()
    {
        pool.Push(this);
    }
}
