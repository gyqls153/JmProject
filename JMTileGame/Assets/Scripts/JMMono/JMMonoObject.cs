using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JMMonoObject : JMMonoBehaviour
{
	public JMFillStateScript FillStateScript;

	protected JMStateMachine StateMachine;

	public void Init()
	{
		StateMachine = new JMStateMachine();
		FillStateScript.FillStates(StateMachine);
		StateMachine.InitStates(this);
	}

	public virtual void Tick(float InDeltaTime)
	{
		if (StateMachine != null)
		{
			StateMachine.Tick(InDeltaTime);
		}
	}

	public JMStateMachine GetStateMachine()
	{
		return StateMachine;
	}
	

	void OnCollisionEnter2D(Collision2D other)
	{
		OnCollisionEnter2D_Internal(other);
	}

	void OnCollisionStay2D(Collision2D other)
	{
		OnCollisionStay2D_Internal(other);
	}

	void OnCollisionExit2D(Collision2D other)
	{
		OnCollisionExit2D_Internal(other);
	}

	protected virtual void OnCollisionEnter2D_Internal(Collision2D other)
	{
		StateMachine.GetCurState().OnCollisionEnter2D(other);
	}

	protected virtual void OnCollisionStay2D_Internal(Collision2D other)
	{
		StateMachine.GetCurState().OnCollisionStay2D(other);
	}

	protected virtual void OnCollisionExit2D_Internal(Collision2D other)
	{
		StateMachine.GetCurState().OnCollisionExit2D(other);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		OnTriggerEnter2D_Internal(other);
	}

	void OnTriggerStay2D(Collider2D other)
	{
		OnTriggerStay2D_Internal(other);
	}

	void OnTriggerExit2D(Collider2D other)
	{
		OnTriggerExit2D_Internal(other);
	}

	public override void OnPressed()
	{
		GetStateMachine().OnPressed();
	}
	public override void OnReleased()
	{
		GetStateMachine().OnReleased();
	}

	protected virtual void OnTriggerEnter2D_Internal(Collider2D other)
	{
		StateMachine.GetCurState().OnTriggerEnter2D(other);
	}

	protected virtual void OnTriggerStay2D_Internal(Collider2D other)
	{
		StateMachine.GetCurState().OnTriggerStay2D(other);
	}

	protected virtual void OnTriggerExit2D_Internal(Collider2D other)
	{
		StateMachine.GetCurState().OnTriggerExit2D(other);
	}
}
