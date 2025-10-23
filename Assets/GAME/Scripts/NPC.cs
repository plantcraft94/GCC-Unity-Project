using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
	[SerializeField] GameObject prompt;
	bool showedPrompt = false;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
	{
		prompt.SetActive(false);
	}

	// Update is called once per frame
	void Update()
	{
		
	}
	public void ShowPrompt()
	{
		if(!showedPrompt)
		{
			StartCoroutine(Prompt());
		}
	}
	IEnumerator Prompt()
	{
		showedPrompt = true;
		prompt.SetActive(true);
		yield return new WaitForSeconds(2f);
		prompt.SetActive(false);
	}
	
}
