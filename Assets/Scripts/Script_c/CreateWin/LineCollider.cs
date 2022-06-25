using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineCollider : MonoBehaviour
{
    private GameObject Line;

    private Vector3 mousePos;
    // Start is called before the first frame update
    void Start()
    {
        Line = gameObject.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDrag()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 90;
        Line.GetComponent<LineRenderer>().SetPosition(1, mousePos);
    }

    private void OnMouseUp()
    {
        Debug.Log(GetMouseUpObject());
    }

    private void OnMouseDown()
    {
        Line.GetComponent<LineRenderer>().positionCount = 3;
        Line.GetComponent<LineRenderer>().SetPosition(2, Line.GetComponent<LineRenderer>().GetPosition(1));
    }

    private GameObject GetMouseUpObject()
    {
        GameObject target = null;

        Vector3 MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(MousePosition, transform.forward);

        if (hit)
        {
            target = hit.collider.gameObject;
            if (target.name == "LineCollider")
            {
                Destroy(Line);
                return null;
            }
            Line.GetComponent<LineRenderer>().SetPosition(1, target.transform.position);
            Debug.Log(hit.transform.position);
        }
        else
        {
            Line.GetComponent<LineRenderer>().SetPosition(1, Line.GetComponent<LineRenderer>().GetPosition(2));
            Line.GetComponent<LineRenderer>().positionCount = 2;
        }

        return target;
    }


}
