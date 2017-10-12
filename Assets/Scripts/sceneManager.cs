using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;


public class sceneManager : MonoBehaviour {

	public GameObject capsule;

	private CameraDevice camDevice;
	private Color capsuleColor;
	private Image camImage;

	// Use this for initialization
	void Start () {
		camDevice = CameraDevice.Instance;
		bool enable = camDevice.SetFrameFormat (Image.PIXEL_FORMAT.RGB888, true);
		Debug.Log ("camDevice setFormat = " + enable);
	}

	// Update is called once per frame
	void Update () {

		bool isActive = camDevice.IsActive ();
		Debug.Log ("camDevice active = " + isActive);

		camImage = camDevice.GetCameraImage (Image.PIXEL_FORMAT.RGB888);
		if (camImage != null) {
			Debug.Log ("camera width = " + camImage.Width + ", height = " + camImage.Height);

			Texture2D texImage = new Texture2D (camImage.Width, camImage.Height);
			camImage.CopyToTexture (texImage);

			//texImage = Resources.Load ("images/150463757969262") as Texture2D ;

			Material material = capsule.GetComponent<Renderer> ().material;
			material.SetTexture ("_MainTex", texImage as Texture);
		}
		else
			Debug.Log ("camImage : null");

		/*
		Texture2D texImage = new Texture2D (camImage.Width, camImage.Height);
		camImage.CopyToTexture (texImage);

		Material material = capsule.GetComponent<Renderer> ().material;
		material.SetTexture ("_MainTex", texImage);
		*/
	}
}
