using UnityEngine;
using System.Collections;

public class JMState {
	private string StateName;
	
	public void SetStateName(string InStateName)
	{
		StateName = InStateName;
	}

	public string GetStateName()
	{
		return StateName;
	}

	public virtual void InitState()
	{

	}

	public virtual void BeginState()
	{

	}

	public virtual void EndState()
	{

	}

	public virtual void Tick(float InDeltaTime)
	{

	}
}
