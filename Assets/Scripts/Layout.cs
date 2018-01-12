using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Layout : MonoBehaviour {

	private List<GameObject> elem = null;

	private void Awake() {
		elem = new List<GameObject>(200);
		foreach (Transform child in this.transform) {
			elem.Add(child.gameObject);
		}

		// Debug.Log(elem.Count);
		// foreach (var c in elem) {
		// 	Debug.Log(c.name);
		// }
	}
	private void Start () {
	}

	public GameObject this[int pos] {
		get {
			if (elem == null)
				return null;
			return this.elem[pos];
		}
	}

	public void setcolor(int[] pos, int[] pos2, Color m_color)
	{
		foreach (int a in pos2){
			elem[a].GetComponent<Renderer>().material.color = Color.yellow;
		}
		foreach (int a in pos){
			elem[a].GetComponent<Renderer>().material.color = m_color;
		}
	}

	public void hsetcolor(int[] pos, Color m_color)
	{
		foreach (int a in pos){
			elem[a].GetComponent<Renderer>().material.color = m_color;
		}
	}
}