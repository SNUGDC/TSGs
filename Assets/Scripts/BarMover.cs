using UnityEngine;
using System.Collections;

public class BarMover : MonoBehaviour {

    public float sensitivity = 2;
    public bool isVertical = false;
    private bool mouseReleased = true;
    public Vector2[] limits = new Vector2[2];

    private Camera mainCamera;
	// Use this for initialization
	void Start () {
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        if (Mathf.Abs(transform.position.x) > Mathf.Epsilon)
        {
            isVertical = true;
        }
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {
        if(mouseReleased)
        {
            StartCoroutine("DragControl");
        }
	}

    IEnumerator DragControl()
    {
        if (Input.GetMouseButton(0))
        {
            mouseReleased = false;
            Vector2 clickedPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            Vector2 originalPosition = transform.position;
            float xDistance, yDistance;
            float xPosition, yPosition;
            while (Input.GetMouseButton(0))
            {
                Vector2 draggedPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
                xDistance = (draggedPosition.x - clickedPosition.x) * sensitivity;
                yDistance = (draggedPosition.y - clickedPosition.y) * sensitivity;
                if (isVertical)
                {
                    transform.position = originalPosition + new Vector2(0, yDistance);
                    if(Mathf.Abs(yPosition = transform.position.y - transform.parent.position.y) > 3.3)
                    {
                        Vector2 limit = transform.position;
                        limit.y = transform.parent.position.y + 3.3f * Mathf.Sign(yPosition);
                        transform.position = limit;
                    }
                }
                else
                {
                    transform.position = originalPosition + new Vector2(xDistance, 0);
                    if (Mathf.Abs(xPosition = transform.position.x - transform.parent.position.x) > 3.3)
                    {
                        Vector2 limit = transform.position;
                        limit.x = transform.parent.position.x + 3.3f * Mathf.Sign(xPosition);
                        transform.position = limit;
                    }
                }
                yield return new WaitForSeconds(0.1f);
            }
            mouseReleased = true;
        }
    }

}
