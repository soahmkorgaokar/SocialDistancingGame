using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTarget : MonoBehaviour
{
    public RectTransform arrow;
    public float arrowDeltaValue = 40.0f;
    public Transform target;

    void Start()
    {
        
    }

    void Update()
    {
        UpdateArrow();
    }


    private void UpdateArrow()
    {
        if (target == null)
        {
            return;
        }
        Vector2 screenPos = Camera.main.WorldToScreenPoint(target.position);
        if (screenPos.x <= arrowDeltaValue || screenPos.x >= Screen.width - arrowDeltaValue || screenPos.y <= arrowDeltaValue || screenPos.y >= Screen.height - arrowDeltaValue)
        {
            if (!arrow.gameObject.activeSelf)
            {
                arrow.gameObject.SetActive(true);
            }
            arrow.position = new Vector2(Mathf.Clamp(screenPos.x, arrowDeltaValue, Screen.width - arrowDeltaValue), Mathf.Clamp(screenPos.y, arrowDeltaValue, Screen.height - arrowDeltaValue));
            Vector2 d = new Vector2(arrow.position.x - Screen.width / 2, arrow.position.y - Screen.height / 2);
            d = d.normalized;
            float sinValue = d.y;
            float cosValue = d.x;

            float sinAngle = Mathf.Asin(sinValue) * 180 / Mathf.PI;
            float cosAngle = Mathf.Acos(cosValue) * 180 / Mathf.PI;

            float angle = 0;
            if (sinAngle >= 0)
            {
                angle = cosAngle;
            }
            else
            {
                angle = 360 - cosAngle;
            }
            arrow.rotation = Quaternion.Euler(0, 0, angle);
        }
        else
        {
            if (arrow.gameObject.activeSelf)
            {
                arrow.gameObject.SetActive(false);
            }
        }
    }
}
