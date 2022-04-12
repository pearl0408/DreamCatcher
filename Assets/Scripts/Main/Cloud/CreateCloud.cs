using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCloud : MonoBehaviour
{
    // 구름을 생성하는 오브젝트에 추가하는 컴포넌트

    public GameObject CloudPos;   //구름 생성 위치 기준 오브젝트
    private float createTime = 30f;     //구름 생성 시간
    private float range_low = -225f;    //구름 최저 생성 높이
    private float range_high = 175f;    //구름 최고 생성 높이

    void Start()
    {
        //구름 생성 코루틴 실행
        StartCoroutine(StartMakeCloud(createTime));
    }

    IEnumerator StartMakeCloud(float time)    
    {
        //구름 생성 코루틴 함수

        bool isInactiveObject;
        while (true)
        {
            isInactiveObject = ObjectPoolManager.Instance.pool.IsInactiveObject();
            if (isInactiveObject)   //비활성화된 오브젝트가 있다면
            {
                MakeCloud();
                yield return new WaitForSeconds(time);    //구름 생성 시간만큼 기다림
            }
            else    //비활성화된 오브젝트가 없다면
            {
                yield return new WaitForSeconds(1f);    //바로 생성
            }
        }
    }

    public void MakeCloud()
    {
        //구름 생성 함수

        GameObject obj = ObjectPoolManager.Instance.pool.Pop();
        obj.transform.position = CloudPos.transform.position;

        RandomPosition(obj);   //랜덤 위치 변경
    }

    private void RandomPosition(GameObject obj)
    {
        //구름 높이 랜덤 변경 함수

        obj.transform.Translate(new Vector2(0f, Random.Range(range_low, range_high)));
    }
}
