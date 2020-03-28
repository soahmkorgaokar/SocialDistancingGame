using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLineDrawing : MonoBehaviour
{

    public float showDistance = 6.0f;
    public GameObject linePrefab;
    public Transform lineTextsContainer;
    public GameObject lineTextPrefab;

    public float dangerDistance = 4.0f;
    public float escapeTime = 3.0f;
    public Slider timeSlider;

    private List<GameObject> lines = new List<GameObject>();
    private List<GameObject> lineTexts = new List<GameObject>();
    private bool isTouching;
    private float touchingTime;

    void Start()
    {
        isTouching = false;
    }

    void Update()
    {
        DrawDistanceLines();
        if (isTouching)
        {
            if (!timeSlider.gameObject.activeSelf)
            {
                timeSlider.gameObject.SetActive(true);
            }
            touchingTime += Time.deltaTime;
            if(touchingTime >= escapeTime)
            {
                //Lose
                //Debug.Log("Lose");
                GameManager.instance.EndGame(false);
            }
        }
        else
        {
            if (timeSlider.gameObject.activeSelf)
            {
                timeSlider.gameObject.SetActive(false);
            }
            touchingTime = 0;
        }
        timeSlider.value = Mathf.Clamp(touchingTime, 0, escapeTime) / escapeTime;
    }

    private void DrawDistanceLines()
    {
        for (int i = 0; i < lines.Count; i++)
        {
            Destroy(lines[i]);
            Destroy(lineTexts[i]);
            lines.RemoveAt(i);
            lineTexts.RemoveAt(i);
            i--;
        }
        isTouching = false;
        Collider[] cos = Physics.OverlapSphere(transform.position, showDistance);
        for (int i = 0; i < cos.Length; i++)
        {
            if (cos[i].tag.Equals("NPC"))
            {
                GameObject l = Instantiate(linePrefab);
                LineRenderer lr = l.GetComponent<LineRenderer>();
                if (lr != null)
                {
                    lr.SetPosition(0, transform.position);
                    lr.SetPosition(1, cos[i].transform.position);
                }
                lines.Add(l);
                Vector3 pos = (transform.position + cos[i].transform.position) / 2;
                Vector3 screenPos = Camera.main.WorldToScreenPoint(pos);
                GameObject t = Instantiate(lineTextPrefab, lineTextsContainer);
                t.transform.position = screenPos;
                if (t.GetComponent<Text>() != null)
                {
                    t.GetComponent<Text>().text = Vector3.Distance(transform.position, cos[i].transform.position).ToString("f2");
                }
                lineTexts.Add(t);
                if (Vector3.Distance(transform.position, cos[i].transform.position) <= dangerDistance)
                {
                    isTouching = true;
                }
            }
        }
    }
}
