using UnityEngine;
using System.Collections;

public class JMState : JMNonMonoObject{
	private string StateName;
	protected JMMonoObject Owner;
	
	public void SetStateName(string InStateName)
	{
		StateName = InStateName;
	}

	public string GetStateName()
	{
		return StateName;
	}

	public virtual void InitState(JMMonoObject InOwner)
	{
		Owner = InOwner;
	}

	public JMStateMachine GetStateMachine()
	{
		return Owner.GetStateMachine();
	}

	public JMState GetCurState()
	{
		return GetStateMachine().GetCurState();
	}

	public void ChangeState(string ChangeStateName)
	{
		GetStateMachine().ChangeState(ChangeStateName);
	}

	public virtual void BeginState(string InPrevStateName)
	{

	}

	public virtual void EndState(string InNextStateName)
	{

	}

	public virtual void Tick(float InDeltaTime)
	{

	}
}
