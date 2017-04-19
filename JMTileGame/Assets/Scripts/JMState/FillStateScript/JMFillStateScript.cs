using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JMFillStateScript : MonoBehaviour {
	public string DefaultStateName;

	public virtual void FillStates(JMStateMachine StateMachine)
	{
		StateMachine.SetDefaultStateName(DefaultStateName);
	}
}
