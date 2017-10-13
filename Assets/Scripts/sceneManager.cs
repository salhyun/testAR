using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;


public class sceneManager : MonoBehaviour {

	public GameObject capsule;

	private CameraDevice camDevice;
	private Color capsuleColor;
	private Image camImage;

	private Image.PIXEL_FORMAT pixelFormat = Image.PIXEL_FORMAT.RGB888;

	// Use this for initialization
	void Start () {
		camDevice = CameraDevice.Instance;
		bool enable = camDevice.SetFrameFormat (pixelFormat, true);
		Debug.Log ("camDevice setFormat = " + enable);
	}

	public void updateCamImage()
	{
		bool isActive = camDevice.IsActive ();
		Debug.Log ("camDevice active = " + isActive);

		camImage = camDevice.GetCameraImage (pixelFormat);
		if (camImage != null) {
			Debug.Log ("camera width = " + camImage.Width + ", height = " + camImage.Height);

			Texture2D texImage = new Texture2D (camImage.Width, camImage.Height);
			camImage.CopyToTexture (texImage);
			texImage.Apply ();

			//texImage = Resources.Load ("images/150463757969262") as Texture2D ;

			Material material = capsule.GetComponent<Renderer> ().material;
			material.SetTexture ("_MainTex", texImage as Texture);
		}
		else
			Debug.Log ("camImage : null");

	}

	// Update is called once per frame
	void Update () {


	}
}
