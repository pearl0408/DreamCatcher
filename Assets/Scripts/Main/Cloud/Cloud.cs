using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : Poolable
{
    //Pooling을 할 오브젝트 Cloud에 추가하는 컴포넌트
    private float speed = 30f;     //구름 속도
    private int range_x = 1500;
    Vector2 dir;

    private void Update()
    {
        //매 프레임마다 구름 이동

        transform.Translate(dir * speed * Time.deltaTime);

        if (transform.position.x > range_x)
        {
            Push();
        }
    }

    private void OnEnable()
    {
        //구름이 활성화되면 오른쪽으로 움직이도록 설정하는 함수

        //벡터 방향 설정
        transform.position = Vector2.zero;
        dir = new Vector2(50f, 0).normalized;
    }
}
