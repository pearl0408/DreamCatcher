using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdTouch : MonoBehaviour
{
    //새(Bird) 오브젝트에 컴포넌트로 넣을 클래스
    //새 터치 이벤트(버튼 이벤트)

    public void BirdTouchEvent()
    {
        //새나 깃털을 터치하면 도감 데이터에 추가되고 화면에서 사라지는 함수

        List<Dictionary<string, object>> data_birdInfo = CSVParser.ReadFromFile("BirdInfo");  //도감 데이터를 가져옴 

        int selectedBirdNumber = GameObject.FindGameObjectWithTag("FeedManager").GetComponent<FeedManager>().GetSelectedBirdNum();  //선택된 새 번호를 가져옴
        int appearCnt = int.Parse(data_birdInfo[selectedBirdNumber]["appear"].ToString());   //등장 횟수 불러옴

        appearCnt += 1;
        data_birdInfo[selectedBirdNumber]["appear"] = appearCnt.ToString(); //도감에 증가한 등장 횟수 반영
        CSVParser.WriteFromFile("BirdInfo", data_birdInfo); //도감 저장

        this.gameObject.SetActive(false);       //새 오브젝트 비활성화
        GameObject.FindGameObjectWithTag("FeedManager").GetComponent<FeedManager>().SetIsFeedSelected(false);    //먹이 오브젝트 비활성화
    }
}
