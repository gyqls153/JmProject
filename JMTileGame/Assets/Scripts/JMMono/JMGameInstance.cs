using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[DisallowMultipleComponent]
public class JMGameInstance : JMMonoBehaviour
{

	private static JMGameInstance GameInstance;
	
	private JMPlayerController PlayerController;

	public static JMGameInstance GetGameInstance()
	{
		return GameInstance;
	}

	public JMPlayerController GetPlayerController()
	{
		return PlayerController;
	}

	public void CacheForObject()
	{
		var PlayerControllerObject = GameObject.FindWithTag("JMPlayerController");
		if (PlayerControllerObject != null)
		{
			PlayerController = PlayerControllerObject.GetComponent<JMPlayerController>();
		}

		GameInstance = this;
	}

	void Awake()
	{
		DontDestroyOnLoad(this.gameObject);
	}

	void Start()
	{
		LoadScene("Stage1");
	}

	// Update is called once per frame
	void Update () {
		if (PlayerController != null)
		{
			PlayerController.Tick(Time.deltaTime);
		}
	}

	void LoadScene(string InSceneName) {
		SceneManager.LoadScene(InSceneName);
	}
}
