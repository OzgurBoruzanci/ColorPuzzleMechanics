using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BoxParentManager : MonoBehaviour,IDragHandler/*,IPointerDownHandler*/
{
    [SerializeField] GameObject childBox;
    [SerializeField] LayerMask gridCellLayer;
    [SerializeField] float maxArea;
    Vector3 targetPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            MousePos();
        }
    }
    //public void OnPointerDown(PointerEventData eventData)
    //{
    //    Debug.Log("a");
    //    Debug.Log(eventData);
    //    //MousePos();
    //}
    public void OnDrag(PointerEventData eventData)
    {
        MousePos();
    }
    void MousePos()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray,out RaycastHit hit,10, gridCellLayer))
        {
            if (hit.collider.GetComponent<GroundCellManager>())
            {
                targetPos = hit.collider.transform.position;
                ScaleControl();
            }
        }
    }
    void ScaleControl()
    {
        
        float distanceX = targetPos.x - transform.position.x;
        float distanceZ = targetPos.z - transform.position.z;

        float scaleX, scaleY, scaleZ;
        scaleX = Mathf.Abs(distanceX)+1;
        scaleY = transform.localScale.y;
        scaleZ = Mathf.Abs(distanceZ)+1;
        float scaleArea = scaleX * scaleY * scaleZ;
        scaleArea = Mathf.Abs(scaleArea);


        if (maxArea>=scaleArea)
        {
            transform.localScale = Vector3.one;
            childBox.transform.localScale = Vector3.one;
            childBox.transform.localPosition = Vector3.zero;
            if (distanceX > 0)
            {
                ScaleControlX(1, distanceX);
            }
            else
            {
                ScaleControlX(-1, distanceX);
            }
            if (distanceZ > 0)
            {
                ScaleControlZ(1, distanceZ);
            }
            else
            {
                ScaleControlZ(-1, distanceZ);
            }
        }

    }
    void ScaleControlX(float childScale, float distance)
    {
        distance = Mathf.Abs(distance) + 1;
        childBox.transform.parent = null;
        transform.position = new Vector3(transform.position.x - (childScale / 2), transform.position.y, transform.position.z);
        childBox.transform.parent = transform;
        transform.localScale = new Vector3(distance, transform.localScale.y, transform.localScale.z);
        childBox.transform.parent = null;
        transform.position = new Vector3(transform.position.x + (childScale / 2), transform.position.y, transform.position.z);
        childBox.transform.parent = transform;
    }
    void ScaleControlZ(float childScale,float distance)
    {
        distance = Mathf.Abs(distance) + 1;
        childBox.transform.parent = null;
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - (childScale / 2));
        childBox.transform.parent = transform;
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, distance);
        childBox.transform.parent = null;
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + (childScale / 2));
        childBox.transform.parent = transform;
    }
    
}
