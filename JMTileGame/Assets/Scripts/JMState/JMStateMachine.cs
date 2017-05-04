using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Assertions;

public class JMStateMachine : JMNonMonoObject{
    private Dictionary<string, JMState> States = new Dictionary<string, JMState>();

	private JMState CurState;
	protected JMMonoObject Owner;

	private string DefaultStateName = "";
	private string NextStateName = "";

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

	public JMState GetCurState()
	{
		return CurState;
	}

	public void InitStates(JMMonoObject InOwner)
	{
		Owner = InOwner;

		var enumerator = States.GetEnumerator();
		while(enumerator.MoveNext())
		{
			var State = enumerator.Current.Value;
			State.InitState(InOwner);
		}

		ChangeState(DefaultStateName);
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

	public override void OnPressed()
	{
		GetCurState().OnPressed();
	}

	public override void OnReleased()
	{
		GetCurState().OnReleased();
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
			if (NextStateName != null && NextStateName.Length > 0)
			{
				var NextState = GetState(NextStateName);

				var LocalNextStateName = NextStateName;
				var LocalCurStateName = string.Empty;

				NextStateName = string.Empty;

				if (CurState != null)
				{
					CurState.EndState(LocalNextStateName);
					LocalCurStateName = CurState.GetStateName();
				}

				CurState = NextState;
				CurState.BeginState(LocalCurStateName);
			}
			
			CurState.Tick(InDeltaTime);

			if (NextStateName == null || 0 >= NextStateName.Length)
				break;
		}
	}
}