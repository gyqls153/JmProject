using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JMFS_Stage : JMFillStateScript
{
	public override void FillStates(JMStateMachine StateMachine)
	{
		base.FillStates(StateMachine);

		StateMachine.AddState("Idle", new JMPS_B_Idle());
	}
}
