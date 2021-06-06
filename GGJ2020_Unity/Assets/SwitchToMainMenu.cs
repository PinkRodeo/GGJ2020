using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class SwitchToMainMenu : MonoBehaviour
{
	void Start()
	{
		// Untill all the global state can be sorted out, this is for the best.
		Debug.Log("Game is exiting");
		GetComponent<Button>().onClick.AddListener(() => Application.Quit());

		//GetComponent<Button>().onClick.AddListener(() => SceneManager.LoadScene(0));
	}
}
