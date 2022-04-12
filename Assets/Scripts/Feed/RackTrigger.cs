using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RackTrigger : MonoBehaviour
{
    //Ƚ�� Ʈ���� ������Ʈ�� ������Ʈ�� ���� Ŭ����

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //���� ������Ʈ�� ����� �� 

        if (collision.gameObject.tag == "Feed")
        {
            collision.gameObject.GetComponent<FeedDrag>().SetIsTriggering(true);    //���� ���� ���� true�� ����
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        //���� ������Ʈ���� �������� �� 

        if (collision.gameObject.tag == "Feed")
        {
            collision.gameObject.GetComponent<FeedDrag>().SetIsTriggering(false);   //���� ���� ���� false�� ����
        }
    }
}
