using UnityEngine;
using UnityEngine.InputSystem;

public class GizmoDrawer : MonoBehaviour
{
	[SerializeField] Vector2Int GridSize;
	[SerializeField] Vector2 CellSize;
	Camera cam;
	private void Start()
	{
		cam = Camera.main;
	}
	private void Update()
	{

		Vector3 mousepos = Input.mousePosition;
		//vector3 mousepos = Mouse.current.position.ReadValue(); // trong trường hợp Input mới
		mousepos.z = 10f;
		mousepos = cam.ScreenToWorldPoint(mousepos);
		Vector3 pos = mousepos - transform.position ;

		int gridx = Mathf.FloorToInt(pos.x / CellSize.x);
		int gridy = Mathf.FloorToInt(pos.y / CellSize.y);

		if (gridx >= 0 && gridx < GridSize.x && gridy >= 0 && gridy < GridSize.y)
        {    
			if(Input.GetMouseButtonDown(0))
			{
				Debug.Log($"{gridx},{gridy}");
			}
			// if(Mouse.current.leftButton.wasPressedThisFrame)   // trong trường hợp Input mới
			// {
			// 	Debug.Log($"{gridx},{gridy}");
			// }
        }
		
		
	}
	private void OnDrawGizmos()
	{
		transform.position = new Vector3((float)-GridSize.x / 2 * CellSize.x, (float)-GridSize.y / 2 * CellSize.y, transform.position.z);
		Gizmos.color = Color.red;
		for (int i = 0; i < GridSize.x; i++)
		{
			for (int j = 0; j < GridSize.y; j++)
			{
				Gizmos.DrawWireCube(new Vector2(transform.position.x + (i * CellSize.x) + CellSize.x / 2, transform.position.y + (j * CellSize.y) + CellSize.y / 2), CellSize);
			}
		}
	}
}
