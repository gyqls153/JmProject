using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JMFS_MyPlayer : JMFillStateScript
{
	public override void FillStates(JMStateMachine StateMachine)
	{
		base.FillStates(StateMachine);

		StateMachine.AddState("Idle", new JMCS_B_Idle());
		StateMachine.AddState("MoveToLeft", new JMCS_B_MoveToLeft());
		StateMachine.AddState("MoveToRight", new JMCS_B_MoveToRight());
		StateMachine.AddState("MoveToForward", new JMCS_B_MoveToForward());
	}
}
