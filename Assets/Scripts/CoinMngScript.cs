using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class CoinMngScript : MonoBehaviour
{
	public TMP_Text coinText;

	public int coinPoint;

	private void Update()
	{
		coinText.text = coinPoint.ToString();
	}
}
