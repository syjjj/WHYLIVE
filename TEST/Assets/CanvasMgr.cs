using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasMgr : MonoBehaviour {

	public GameObject canvasprefab;
	List<GameObject> Canvases = new List<GameObject>(); //캔버스프리팹 넣을 리스트

	public GameObject layerprefab; //레이어 프리팹
	List<GameObject> Layers = new List<GameObject>(); //레이어 프리팹 넣을 리스트

	public int count_canvas = 0;


	// Use this for initialization

	void Start () {

		Canvases.Add (canvasprefab);
		Layers.Add (layerprefab);

	}




	// Update is called once per frame

	public void add_canvas () {


		GameObject obj= Instantiate(canvasprefab) as GameObject;
		obj.transform.SetParent(GameObject.Find("mgr").transform,false); //mgr캔버스에 자식으로 추가
		Canvases.Add (obj); //리스트에 추가


		GameObject obj_r= Instantiate(layerprefab) as GameObject;
		obj_r.transform.SetParent(GameObject.Find("LayerContent").transform,false);
		Layers.Add (obj_r);

		count_canvas++;
		obj.transform.GetComponent<Canvas>().uni_num = count_canvas;
		obj_r.transform.GetComponent<LayerMgr>().make_num = count_canvas;
		select_canvas (count_canvas);
	}

	public void delete_canvas () {
		for(int actcheck=1; actcheck <= count_canvas+1; actcheck++)
		{
			if (Canvases [actcheck].transform.GetComponent<Canvas> ().active_canvas == true) {

				Destroy (Canvases [actcheck]);
				Destroy (Layers [actcheck]);


				for(int i=0; i<=count_canvas+1; i++){
					if(Canvases[i] !=null&&i!=0){
						select_canvas(i);
						break;
					}
				}

			}

		}

		
	}

	public void select_canvas (int number) {
		for(int i=1; i <= count_canvas; i++)
		{
			if (Canvases [i] != null) {
				Canvases [i].transform.GetComponent<Canvas> ().active_canvas = false;
			}
		}

		Canvases [number].transform.GetComponent<Canvas> ().active_canvas = true;
	}


}
