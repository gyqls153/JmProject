using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Assertions;

public class JMStateMachine {
    private Dictionary<string, JMState> States = new Dictionary<string, JMState>();

	private JMState CurState;

	private string DefaultStateName;
	private string NextStateName;

	public void SetDefaultStateName(string InDefaultStateName)
	{
		DefaultStateName = InDefaultStateName;
	}

    public void AddState(string InStateName, JMState InState)
    {
        if (States.ContainsKey(InStateName))
        {
            Debug.LogError("Contain State" + InStateName);
        }

		InState.SetStateName(InStateName);
		States.Add(InStateName, InState);
    }

	public void InitStates()
	{
		var enumerator = States.GetEnumerator();
		while(enumerator.MoveNext())
		{
			var State = enumerator.Current.Value;
			State.InitState();
		}

		ChangeState("Idle");
	}

	public JMState GetState(string InStateName)
	{
		if (!States.ContainsKey(InStateName))
		{
			Debug.LogError("Invaild State" + InStateName);
			return null;
		}

		return States[InStateName];
	}

	public bool HasState(string InStateName)
	{
		return GetState(InStateName) != null;
	}

	public void ChangeState(string InStateName)
	{
		if (InStateName.Length > 0 && !HasState(InStateName))
		{
			return;
		}

		NextStateName = InStateName;
	}

	public void Tick(float InDeltaTime)
	{
		while (true)
		{
			if (NextStateName.Length > 0)
			{
				var NextState = GetState(NextStateName);
				
				NextStateName = string.Empty;

				if (CurState != null)
				{
					CurState.EndState();
				}

				CurState = NextState;
				CurState.BeginState();
			}
			
			CurState.Tick(InDeltaTime);

			if (0 >= NextStateName.Length)
				break;
		}
	}
}