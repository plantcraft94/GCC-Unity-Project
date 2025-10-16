using UnityEngine;
using UnityEngine.InputSystem;

public class GizmoDrawer : MonoBehaviour
{
	[Header("Grid")]
	[SerializeField] Vector2Int GridSize;
	[SerializeField] Vector2 CellSize;
	Vector2Int OldCellPos;
	int[,] CellState;
	[Header("PickableObject")]
	Vector3 CurrObjectPos;
	bool hold = false;
	Transform currentPickable;
	bool PickFromInside = false;
	[Header("Mouse Stuff")]
	Camera cam;
	Vector3 mousepos;
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

        CheckForPickableObject(gridx, gridy);
    }

    private void CheckForPickableObject(int gridx, int gridy)
    {
        RaycastHit2D hit = Physics2D.Raycast(mousepos, Vector2.zero);
        if (hold == true)
        {
            currentPickable.position = mousepos;
        }
        if (Input.GetMouseButtonDown(0) && hit.collider != null && hit.collider.CompareTag("Pickable"))
        {
            PickUpObject(gridx, gridy, hit);
        }
        if (Input.GetMouseButtonUp(0) && hold == true)
        {
            hold = false;
            CheckAndPutInGrid(gridx, gridy);
        }
    }

    private void PickUpObject(int gridx, int gridy, RaycastHit2D hit)
	{
		CurrObjectPos = hit.transform.position;
		currentPickable = hit.transform;
		hold = true;
		if (gridx >= 0 && gridx < GridSize.x && gridy >= 0 && gridy < GridSize.y)
		{
			PickFromInside = true;
			Debug.Log($"pi ({gridx}, {gridy}): {CellState[gridx, gridy]}");
			OldCellPos = new Vector2Int(gridx, gridy);
		}
		else
		{
			PickFromInside = false;
		}
	}

	private void CheckAndPutInGrid(int gridx, int gridy)
	{
		if (gridx >= 0 && gridx < GridSize.x && gridy >= 0 && gridy < GridSize.y)
		{
			Debug.Log($"pp ({gridx}, {gridy}): {CellState[gridx, gridy]}");
			if (CellState[gridx, gridy] == 0)
			{
				CellState[gridx, gridy] = 1;
				if(PickFromInside)
				{
					CellState[OldCellPos.x, OldCellPos.y] = 0;
				}
				currentPickable.position = transform.TransformPoint(new Vector2(gridx, gridy) + CellSize / 2);
			}
			else
			{

				currentPickable.position = CurrObjectPos;
			}
			Debug.Log($"pp 2 ({gridx}, {gridy}): {CellState[gridx, gridy]}");
		}
		else
		{

			currentPickable.position = CurrObjectPos;
		}
	}

	private void MousePosWorldToGrid(out int gridx, out int gridy)
	{
		mousepos = Input.mousePosition;
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
