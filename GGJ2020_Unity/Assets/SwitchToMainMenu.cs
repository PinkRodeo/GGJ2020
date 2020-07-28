using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SwitchToMainMenu : MonoBehaviour
{
	void Awake()
	{
		// TODO: Properly reset all the global state

		// Untill all the global state can be sorted out, this is for the best.
		GetComponent<Button>().onClick.AddListener(() => Application.Quit());
		//GetComponent<Button>().onClick.AddListener(() => SceneManager.LoadScene(0));
	}
}
