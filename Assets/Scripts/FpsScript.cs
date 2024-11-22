using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class FpsScript : MonoBehaviour
{
    [SerializeField] private TMP_Text fpsText;
    [SerializeField] private float hudRefreshRate = 1f;

    private float timer;

	private void Start()
	{
        Application.targetFrameRate = 120;	
	}

	private void Update()
    {
        if (Time.unscaledTime > timer)
        {
            int fps = (int)(1f / Time.unscaledDeltaTime);
            fpsText.text = "FPS: " + fps; 
            timer = Time.unscaledTime + hudRefreshRate;
        }
    }
}
