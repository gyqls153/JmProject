using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JMPS_B_Idle : JMPlayerState {
    
	public override void Tick(float InDeltaTime)
	{
		base.Tick(InDeltaTime);

        Debug.Log("Test");

        Vector3 ScreenPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        GameObject.Find("Player").transform.Translate(new Vector3(0, 1, 0) * InDeltaTime);
        Vector3 NewPosition = GameObject.Find("Player").transform.position;
        NewPosition.x = ScreenPos.x;
        GameObject.Find("Player").transform.position = NewPosition;
        GameObject.Find("MainCamera").transform.Translate(new Vector3(0, 1, 0) * InDeltaTime);
    }
}
