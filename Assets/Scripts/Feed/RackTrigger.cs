using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RackTrigger : MonoBehaviour
{
    //횟대 트리거 오브젝트에 컴포넌트로 넣을 클래스

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //먹이 오브젝트에 닿았을 때 

        if (collision.gameObject.tag == "Feed")
        {
            collision.gameObject.GetComponent<FeedDrag>().SetIsTriggering(true);    //먹이 닿음 여부 true로 설정
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        //먹이 오브젝트에서 떨어졌을 때 

        if (collision.gameObject.tag == "Feed")
        {
            collision.gameObject.GetComponent<FeedDrag>().SetIsTriggering(false);   //먹이 닿음 여부 false로 설정
        }
    }
}
