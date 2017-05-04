using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JMMonoBehaviour : MonoBehaviour {

	// 임시 편의

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			OnPressed();
		}
		else if(Input.GetKeyUp(KeyCode.Space))
		{
			OnReleased();
		}
	}

	public virtual void OnPressed()
	{

	}

	public virtual void OnReleased()
	{

	}
}
