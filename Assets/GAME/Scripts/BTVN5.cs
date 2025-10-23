using System.Collections;
using UnityEngine;

public class BTVN5 : MonoBehaviour
{
	[SerializeField] AnimationCurve animCurve;
	[SerializeField] float MinScale;
	[SerializeField] float MaxScale;
	[SerializeField] float MaxHeight;
	Coroutine Shrink;
	Coroutine Bounce;
	float currentShrinkTime;
	float currentBounceTime;
	[SerializeField] float Shrinkduration = 2f;
	[SerializeField] float Bounceduration = 2f;
	Vector2 startPos;
	Rigidbody2D rb;
    private void Awake()
    {
		rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
	{
		startPos = transform.position;
	}
	private void OnDisable()
	{
		Shrink = null;
		Bounce = null;
	}

	// Update is called once per frame
	void Update()
	{
		if (Shrink == null)
		{
			Shrink = StartCoroutine(ExpandAndShrink());
		}
		if (Bounce == null)
		{
			Bounce = StartCoroutine(BounceUpDown());
		}
	}
	IEnumerator ExpandAndShrink()
	{
		currentShrinkTime = 0f;
		while (currentShrinkTime <= Shrinkduration)
		{
			currentShrinkTime += Time.deltaTime;
			float currentscale = Mathf.Lerp(MinScale, MaxScale, animCurve.Evaluate(currentShrinkTime / Shrinkduration));
			transform.localScale = Vector3.one * currentscale;
			yield return null;
		}
		Shrink = null;
	}
	IEnumerator BounceUpDown()
	{
		currentBounceTime = 0f;
		while (currentBounceTime <= Bounceduration)
		{
			currentBounceTime += Time.deltaTime;
			float currentbounce = Mathf.Lerp(0, MaxHeight, animCurve.Evaluate(currentBounceTime / Bounceduration));
			rb.MovePosition(startPos + new Vector2(-currentbounce, 0));
			yield return null;
		}
		Bounce = null;
	}
}
