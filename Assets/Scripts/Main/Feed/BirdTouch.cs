using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdTouch : MonoBehaviour
{
    //새(Bird) 오브젝트에 컴포넌트로 넣을 클래스
    //새 터치 이벤트(버튼 이벤트)


    public void BirdTouchEvent()
    {
        //새나 깃털을 터치하면 사라지는 함수
        //*얻은 깃털 개수 데이터에 추가되도록 수정 필요

        this.gameObject.SetActive(false);       //새 오브젝트 비활성화
        GameObject.FindGameObjectWithTag("FeedManager").GetComponent<FeedManager>().SetIsFeedSelected(false);    //먹이 오브젝트 비활성화
    }
}
