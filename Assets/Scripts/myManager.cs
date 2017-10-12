using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myManager : MonoBehaviour {

	public void change_tex()
	{
		GameObject capsule = GameObject.Find ("Capsule");
		Debug.Log ("pressed button. object name = " + capsule.name);

		//capsule.GetComponent<Renderer> ().material.color = Color.green;

		Material material = capsule.GetComponent<Renderer> ().material;

		//material.color = Color.blue;
		material.SetTexture ("_MainTex", Resources.Load ("images/150463757969262") as Texture);
	}
}
