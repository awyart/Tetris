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
		foreach (GameObject sq in this.elem) {
			sq.GetComponent<Renderer>().material = (Material)Resources.Load("Texture/YELLOW", typeof(Material));
		}
	}

	public GameObject this[int pos] {
		get {
			if (elem == null)
				return null;
			return this.elem[pos];
		}
	}
}
