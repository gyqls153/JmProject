using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JMCS_B_MoveToSide : JMCS_B_Move
{
	public override void OnPressed()
	{
		base.OnPressed();

		ChangeState("MoveToForward");
	}
}
