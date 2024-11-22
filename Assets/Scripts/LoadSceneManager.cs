using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LoadSceneManager : MonoBehaviour
{
	public PlayerScript player;
	public FinishSignScript finishSign;

	public TMP_Text levelNameText;

	public Animator sceneAnim;

	public int sceneNum;

	private void Start()
	{
		sceneNum = SceneManager.GetActiveScene().buildIndex;
	}

	private void Update()
	{
		if (player.isAlive == false)
		{
			StartCoroutine(EndScene());
		}
		int sceneLvlNum = sceneNum + 1;
		levelNameText.text = "Level-" + sceneLvlNum.ToString();
	}

	public void EndSceneForButton()
	{
		StartCoroutine(EndScene());
	}

	IEnumerator EndScene()
	{
		yield return new WaitForSeconds(2f);
		sceneAnim.SetTrigger("End");
		StartCoroutine("Delay");
	}

	IEnumerator Delay()
	{
		yield return new WaitForSeconds(1.5f);
		SceneManager.LoadScene(sceneNum);
	}
}
