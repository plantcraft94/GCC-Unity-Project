using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PauseManager : MonoBehaviour
{
	public static PauseManager Instance { get; private set; }
	[SerializeField] UnityEvent OnGamePause;
	[SerializeField] UnityEvent OnGameUnPause;
	bool isPaused = false;
	InputAction PauseAction;
	private void Awake()
	{
		if(Instance != null && Instance != this)
		{
			Destroy(gameObject);
			return;
		}
		Instance = this;
		DontDestroyOnLoad(gameObject);
		PauseAction = InputSystem.actions.FindAction("Pause");
	}

	// Start is called before the first frame update
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		Debug.Log("Test");
		if(PauseAction.WasPressedThisFrame())
		{
			Pause();
		}
	}
	public bool GetPauseState()
	{
		return isPaused;
	}
	void Pause()
	{
		if(!isPaused)
		{
			isPaused = true;
			OnGamePause.Invoke();
			Time.timeScale = 0f;
		}
		else
		{
			Time.timeScale = 1f;
			OnGamePause.Invoke();
			isPaused = false;
		}
	}
}
