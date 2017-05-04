using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JMCS_B_MoveToLeft : JMCS_B_MoveToSide
{
	public override void Move(float InDeltaTime)
	{
		base.Move(InDeltaTime);
		
		MoveVector += (new Vector3(-Constant.SideSpeed, 0, 0) * InDeltaTime);
	}

	public override void OnTriggerEnter2D(Collider2D other)
	{
		base.OnTriggerEnter2D(other);

		ChangeState("MoveToRight");
	}
}
