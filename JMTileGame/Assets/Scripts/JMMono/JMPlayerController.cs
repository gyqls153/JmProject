using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[DisallowMultipleComponent]
public class JMPlayerController : JMMonoObject
{
	private List<JMMonoObject> MonoObjects = new List<JMMonoObject>();

	void Start()
	{
		var JMGameInstanceObject = GameObject.FindWithTag("JMGameInstance");
		if (JMGameInstanceObject != null)
		{
			JMGameInstanceObject.GetComponent<JMGameInstance>().CacheForObject();
		}

		Init();

		JMMonoObject[] Objects = GameObject.FindObjectsOfType<JMMonoObject>();
		foreach(var Obj in Objects)
		{
			if (Obj == this)
				continue;

			Obj.Init();
			MonoObjects.Add(Obj);
		}
	}

	// 임시 편의
	void Update()
	{
		Tick(Time.deltaTime);
	}

	public override void Tick(float InDeltaTime)
	{
		base.Tick(InDeltaTime);

		foreach (var Obj in MonoObjects)
		{
			Obj.Tick(InDeltaTime);
		}
	}
}
