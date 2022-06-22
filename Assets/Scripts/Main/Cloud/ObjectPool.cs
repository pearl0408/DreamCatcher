using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    //Object Pooling�� �����ϴ� Ŭ����
    //��ü ���� -> ��Ȱ��ȭ �� ���ÿ� Ǫ�� -> Ȱ��ȭ �� ��

    [Header ("[Object Setting]")]
    [SerializeField] private Poolable[] poolObj;     //������ ������Ʈ �迭(���� ������Ʈ ���� ����)
    [SerializeField] private int allocateCount = 5;  //������ ������Ʈ ����
    [SerializeField] private int createNum = 0;      //���� ������ ������Ʈ ��ȣ
    private int createNum_start, createNum_end; //���� ������ ������Ʈ ��ȣ ����

    private Stack<Poolable> poolStack = new Stack<Poolable>();

    void Start()
    {
        //���� ������ ������Ʈ ��ȣ�� �ʱ�ȭ(������ 0, ���� �迭�� ��� ����)

        createNum_start = 0;
        createNum_end = poolObj.Length;

        Allocate();
    }

    public void Allocate()
    {
        //������Ʈ Ǯ ���ÿ� ������Ʈ�� �߰��ϴ� �Լ�

        for (int i = 0; i < allocateCount; i++)
        {
            createNum = RandomNumber(createNum_start, createNum_end); //������ ������Ʈ ��ȣ ���� ����
            Poolable allocateObj = Instantiate(poolObj[createNum], this.gameObject.transform);     //������Ʈ Ǯ �� ��ü ����
            allocateObj.Create(this);       //������Ʈ ����
            poolStack.Push(allocateObj);    //������Ʈ Ǯ ���ÿ� �߰�(��Ȱ��ȭ�� ä��)
        }
    }

    public GameObject Pop()
    {
        //������Ʈ Ǯ �� ��ü �� �ϴ� �Լ�

        Poolable obj = poolStack.Pop();     //������Ʈ Ǯ ���ÿ��� ������(������ ������Ʈ ����)
        obj.gameObject.SetActive(true);     //������Ʈ Ȱ��ȭ
        return obj.gameObject;      //������Ʈ ��ȯ
    }

    public void Push(Poolable obj)
    {
        //������Ʈ Ǯ �� ��ü Ǫ���ϴ� �Լ�

        obj.gameObject.SetActive(false);    //������Ʈ ��Ȱ��ȭ
        poolStack.Push(obj);            //������Ʈ Ǯ ���ÿ� �߰�(����)
    }

    public int RandomNumber(int range_start, int range_end)
    {
        //������Ʈ ���� ��ȣ �������� �缳���ϴ� �Լ�

        int number = Random.Range(range_start, range_end); 
        return number;      //���� ���� ��ȯ
    }


    public bool IsInactiveObject()
    {
        //��Ȱ��ȭ�� ������Ʈ ���θ� ��ȯ�ϴ� �Լ�

        bool isInactive = false;     //��Ȱ��ȭ�� ������Ʈ ����
        if (poolStack.Count != 0)  //���̾��Ű â���� ������Ʈ�� ��Ȱ��ȭ �Ǿ��ִٸ�
        {
            isInactive = true;
        }
        return isInactive;
    }
}
