using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HangPoint : MonoBehaviour, IDropHandler
{
    GameObject Line;
    public void OnDrop(PointerEventData eventData)
    {
        Line = eventData.pointerCurrentRaycast.gameObject.transform.parent.gameObject;
        Debug.Log("onDrop HangPoint");
        Debug.Log(Line.name);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
