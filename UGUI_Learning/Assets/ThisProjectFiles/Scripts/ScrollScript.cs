using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScrollScript : MonoBehaviour,IBeginDragHandler,IEndDragHandler{

    private int pageCount = 4;

    public ScrollRect scroll;

    public float[] horizontalNormalizedPositionX;

    private bool isDraging = false;

    private float targetHorizontalPosX;

    public float smoothSpeed = 8;

    public Toggle[] toggleArray;

    void Start()
    {
        horizontalNormalizedPositionX = new float[pageCount];

        for (int i = 0; i < pageCount; i++)
        {
            if (i == 0)
            {
                horizontalNormalizedPositionX[i] = 0;
            }
            else if (i == pageCount - 1)
            {
                horizontalNormalizedPositionX[i] = 1;
            }
            else
            {
                if (pageCount - 1 != 0)
                {
                    horizontalNormalizedPositionX[i] = 1f / (pageCount - 1) * i;
                }
            }
        }

    }
    

    void Update()
    {
        if (!isDraging)
        {
            scroll.horizontalNormalizedPosition = Mathf.Lerp(scroll.horizontalNormalizedPosition, targetHorizontalPosX, Time.deltaTime * smoothSpeed);
        }
    }



    public void OnBeginDrag(PointerEventData eventData)
    {
        isDraging = true;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isDraging = false;

        Debug.Log(scroll.horizontalNormalizedPosition);

        float posX = scroll.horizontalNormalizedPosition;
        int index = 0;
        float offset = Mathf.Abs(horizontalNormalizedPositionX[index] - posX);

        Debug.Log("offset is " + offset);

        for (int i = 1; i < pageCount; i++)
        {
            float offsetTemp = Mathf.Abs(horizontalNormalizedPositionX[i] - posX);
            
            if (offsetTemp < offset)
            {

                Debug.Log("offsetTemp is " + offsetTemp);
                index = i;
                offset = offsetTemp;
            }
        }

        targetHorizontalPosX = horizontalNormalizedPositionX[index];

        toggleArray[index].isOn = true;

        //scroll.horizontalNormalizedPosition = horizontalNormalizedPositionX[index];
    }

  
    public void SelectPageAndSetToggle(int index)
    {
        targetHorizontalPosX = horizontalNormalizedPositionX[index];
    }


}
