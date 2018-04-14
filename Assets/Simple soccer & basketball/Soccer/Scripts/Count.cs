using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inactivo2 : MonoBehaviour {

	public Text CountText;
	public Text WinText;
	public RawImage Cajaactiva;

	private int count;

	void Start ()
	{
		count = 0;
		SetCounText ();
		WinText.text = "adsadsadsadsa";
	}

	// Use this for initialization
	void OnTriggerEnter (Collider other) 
	{
		if (other.gameObject.CompareTag ("soccer")) 
		{
			count = count + 1;
			SetCounText ();
		}
	}

	void SetCounText()
	{
		CountText.text = "Aciertos: " + count.ToString();
		if (count >= 6) 
		{
			WinText.text = "!!!!!Ganaste!!!!!";
		}
	}
		

}
