using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GroundCellManager : MonoBehaviour,IPointerDownHandler,IPointerUpHandler,IDragHandler
{
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("süeükle" + eventData+" "+transform.name);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log(transform.position);
    }
    
    public void OnPointerUp(PointerEventData eventData)
    {
        
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
