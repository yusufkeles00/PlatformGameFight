using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishSignScript : MonoBehaviour
{
	public LoadSceneManager loadSceneManager;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			StartCoroutine(EndSceneForNextLevel());
		}
	}

	IEnumerator EndSceneForNextLevel()
	{
		yield return new WaitForSeconds(0.5f);
		loadSceneManager.sceneAnim.SetTrigger("End");
		StartCoroutine(SceneLoadDelay());
	}

	public IEnumerator SceneLoadDelay()
	{
		yield return new WaitForSeconds(1.5f);
		SceneManager.LoadScene(loadSceneManager.sceneNum + 1);
	}
}
