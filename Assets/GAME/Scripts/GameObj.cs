using UnityEngine;

public class GameObj : MonoBehaviour
{
	private void Awake()
	{
		Debug.Log("Awake");	
	}
	private void Start()
	{
		Debug.Log("Start");
	}
	private void OnEnable()
	{
		Debug.Log("Enable");
	}
	private void Update()
	{
		
	}
	private void FixedUpdate()
	{
		
	}
    private void LateUpdate()
    {
        
    }
}
