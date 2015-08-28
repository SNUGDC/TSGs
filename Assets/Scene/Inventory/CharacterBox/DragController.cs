using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

namespace TSGs.Inventory
{
	public class DragController : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
	{
		public static GameObject CharacterBeingDragged;
		Vector3 StartPosition;
		Transform StartParent;

		public void OnBeginDrag (PointerEventData EventData)
		{
			CharacterBeingDragged = gameObject;
			StartPosition = transform.position;
			StartParent = transform.parent;
			GetComponent<CanvasGroup> ().blocksRaycasts = false;
		}

		public void OnDrag (PointerEventData EventData)
		{
			transform.position = Input.mousePosition;
		}

		public void OnEndDrag (PointerEventData EventData)
		{
			CharacterBeingDragged = null;
			GetComponent<CanvasGroup> ().blocksRaycasts = true;
			if(transform.parent == StartParent)
			transform.position = StartPosition;
		}
		

	}
}