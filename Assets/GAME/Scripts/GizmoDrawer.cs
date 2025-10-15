using UnityEngine;
using UnityEngine.InputSystem;

public class GizmoDrawer : MonoBehaviour
{
	[SerializeField] Vector2Int GridSize;
	[SerializeField] Vector2 CellSize;
	Camera cam;
	Transform currentPickable;
	Vector3 mousepos;
	Vector3 CurrObjectPos;
	bool hold = false;
	Vector2Int OldCellPos;

	int[,] CellState;
	private void Start()
	{
		cam = Camera.main;
		CellState = new int[GridSize.x, GridSize.y];
		for (int i = 0; i < GridSize.x; i++)
		{
			for (int j = 0; j < GridSize.y; j++)
			{
				CellState[i,j] = 0;
			}
		}
	}
	private void Update()
	{
		int gridx, gridy;
		MousePosWorldToGrid(out gridx, out gridy);

		RaycastHit2D hit = Physics2D.Raycast(mousepos, Vector2.zero);
		Debug.Log(hit.collider);
		if(hold == true)
		{
			
			currentPickable.position = mousepos ;
		}
		if (Input.GetMouseButtonDown(0) && hit.collider != null)
		{
			Debug.Log("Clocked");
			CurrObjectPos = hit.transform.position;
			currentPickable = hit.transform;
			hold = true;
			Debug.Log($"{gridx},{gridy}");
			if (gridx >= 0 && gridx < GridSize.x && gridy >= 0 && gridy < GridSize.y)
			{
				OldCellPos = new Vector2Int(gridx, gridy);
				CellState[gridx, gridy] = 1;
			}
		}
		if(Input.GetMouseButtonUp(0) && hold == true)
		{
			hold = false;
			if (gridx >= 0 && gridx < GridSize.x && gridy >= 0 && gridy < GridSize.y)
			{
				Debug.Log(CellState[gridx, gridy]);
				if(CellState[gridx,gridy] == 0)
				{
					CellState[gridx, gridy] = 1;
					CellState[OldCellPos.x, OldCellPos.y] = 0;
					currentPickable.position = transform.TransformPoint(new Vector2(gridx,gridy) + CellSize/2);
				}
				else
				{
					
					currentPickable.position = CurrObjectPos;
				}
			}
			else
			{
					
				currentPickable.position = CurrObjectPos;
			}
		}
		// if(Mouse.current.leftButton.wasPressedThisFrame)   // trong trường hợp Input mới
		// {
		// 	Debug.Log($"{gridx},{gridy}");
		// }
	}

	private void MousePosWorldToGrid(out int gridx, out int gridy)
	{
		mousepos = Input.mousePosition;
		//vector3 mousepos = Mouse.current.position.ReadValue(); // trong trường hợp Input mới
		mousepos.z = 10f;
		mousepos = cam.ScreenToWorldPoint(mousepos);
		Vector3 pos = mousepos - transform.position;

		gridx = Mathf.FloorToInt(pos.x / CellSize.x);
		gridy = Mathf.FloorToInt(pos.y / CellSize.y);
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
