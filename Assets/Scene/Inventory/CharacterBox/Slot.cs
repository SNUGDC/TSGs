using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

namespace TSGs.Inventory
{
	public class Slot : MonoBehaviour, IDropHandler
	{	
		public GameObject item
		{
			get
			{
				if(transform.childCount>0)
					return transform.GetChild(0).gameObject;

				return null;
			}
		}

		public void OnDrop (PointerEventData EventData)
		{
			if (!item) 
			{
				DragController.CharacterBeingDragged.transform.SetParent (transform);
			}

  		}
	}
}