using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BarMover : MonoBehaviour
{

    private float sensitivity = 5;
    public bool isVertical = false;
    private bool mouseReleased = true;
    public Vector2[] limits = new Vector2[2];
    public GameObject Spot;
    public int entryNumber;
    private int maxMana;
    private int currentMana;
    private Camera mainCamera;
    private GameObject characterButton;
    public Slider characterMana;
    // Use this for initialization
    void Start()
    {
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        characterButton = GameObject.Find("Button (" + entryNumber + ")");
        characterMana = characterButton.transform.GetChild(0).GetComponent<Slider>();
        if (Mathf.Abs(transform.position.x) > Mathf.Epsilon)
        {
            isVertical = true;
        }
        maxMana = 8;
        currentMana = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (mouseReleased)
        {
            StartCoroutine("DragControl");
        }
    }

    void Update()
    {
        BoundaryCheck();
		DrawMana();
    }

    IEnumerator DragControl()
    {
        if (Input.GetMouseButton (0)) {
			mouseReleased = false;
			Vector2 clickedPosition = mainCamera.ScreenToWorldPoint (Input.mousePosition);
			if ( (clickedPosition.x) < 5.4f && clickedPosition.y > -10.5f && clickedPosition.y < -5.4f) {
				GameObject touchPosition = Instantiate (Spot, clickedPosition, Quaternion.identity) as GameObject;
				Vector2 originalPosition = transform.position;
				float xDistance, yDistance;
				float xPosition, yPosition;
				while (Input.GetMouseButton(0)) {
					Vector2 draggedPosition = mainCamera.ScreenToWorldPoint (Input.mousePosition);
					xDistance = (draggedPosition.x - clickedPosition.x) * sensitivity;
					yDistance = (draggedPosition.y - clickedPosition.y) * sensitivity;
					if (isVertical) {
						yPosition = transform.position.y - transform.parent.position.y;
						GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, yDistance);
					} else {
						xPosition = transform.position.x - transform.parent.position.x;
						GetComponent<Rigidbody2D> ().velocity = new Vector2 (xDistance, 0);
					}
					yield return new WaitForSeconds (0.1f);
				}
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
				Destroy (touchPosition);
			}
			mouseReleased = true;
		}
    }

    void BoundaryCheck()
    {
        float xPosition, yPosition;
        if (isVertical)
        {
            if (Mathf.Abs(yPosition = transform.position.y - transform.parent.position.y) > 3.3f)
            {
                Vector2 limit = transform.position;
                limit.y = transform.parent.position.y + (3.3f) * Mathf.Sign(yPosition);
                transform.position = limit;
                if (Mathf.Sign(yPosition) * GetComponent<Rigidbody2D>().velocity.y > 0)
                {
                    GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                }
            }
        }
        else
        {
            if (Mathf.Abs(xPosition = transform.position.x - transform.parent.position.x) > 3.3f)
            {
                Vector2 limit = transform.position;
                limit.x = transform.parent.position.x + 3.3f * Mathf.Sign(xPosition);
                transform.position = limit;
                if (Mathf.Sign(xPosition) * GetComponent<Rigidbody2D>().velocity.x > 0)
                {
                    GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            ManaCharge();
        }
    }

    void ManaCharge()
    {
        currentMana += 1;
        if (currentMana >= maxMana)
        {
            currentMana = 0;
        }
    }

    void DrawMana()
    {
        characterMana.value = (float)currentMana / maxMana;
    }
}
