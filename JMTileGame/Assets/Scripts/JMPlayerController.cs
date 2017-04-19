using UnityEngine;
using System.Collections;

[DisallowMultipleComponent]
public class JMPlayerController : MonoBehaviour {
	public JMFillStateScript FillStateScript;
	
	private JMStateMachine StateMachine;

	void Start()
	{
		var JMGameInstanceObject = GameObject.FindWithTag("JMGameInstance");
		if (JMGameInstanceObject != null)
		{
			JMGameInstanceObject.GetComponent<JMGameInstance>().CacheForObject();
		}
	}

	public void Init()
	{
		StateMachine = new JMStateMachine();
		FillStateScript.FillStates(StateMachine);
		StateMachine.InitStates();
	}
	
	public void Tick(float InDeltaTime)
	{
		if (StateMachine != null)
		{
			StateMachine.Tick(InDeltaTime);
		}
	}
}
