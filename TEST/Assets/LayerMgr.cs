using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerMgr : MonoBehaviour {

	public int make_num = 0;

	// Use this for initialization
	void Start () {
	}

	void Update () {
	}
	
	// Update is called once per frame
	public void Clicked () {

		GameObject.Find ("EventSystem").GetComponent<CanvasMgr> ().select_canvas (make_num);

	}
}
