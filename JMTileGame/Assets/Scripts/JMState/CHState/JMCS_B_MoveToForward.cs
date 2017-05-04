using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JMCS_B_MoveToForward : JMCS_B_Move
{
	private string PrevStateName;

	public override void BeginState(string InPrevStateName)
	{
		base.BeginState(InPrevStateName);

		this.PrevStateName = InPrevStateName;
	}

	public override void OnReleased()
	{
		base.OnReleased();

		ChangeState(PrevStateName);
	}
}
