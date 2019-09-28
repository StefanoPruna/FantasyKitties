using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UVScroll : MonoBehaviour {

	public Vector2 speed;//Vector2 to make sure you can modify x and y

	void LateUpdate(){
		GetComponent<Renderer> ().material.mainTextureOffset = speed * Time.time;
	}
}
