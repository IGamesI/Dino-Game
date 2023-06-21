using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class ScoreHandler : MonoBehaviour
{
    #region Variables
    public int playerScore = 1;
    Label _scoreLabel;
    Button _retryButton;
	#endregion

	#region UnityFunctions
	private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

		_scoreLabel = root.Q<Label>("ScoreCounter");
        _retryButton = root.Q<Button>("RetryButton");

		_scoreLabel.text = playerScore.ToString();
        _retryButton.style.display = DisplayStyle.None;
        _retryButton.clicked += () =>
        {
            RetryGame();
        };

		StartCoroutine(ScoreIncreaseWait());
		StartCoroutine(IncreaseGameSpeedWait());
	}

    private void Update()
    {
		_scoreLabel.text = playerScore.ToString();
	}
	#endregion

	#region CustomFunctions
    public void HandleDeathUI()
    {
        _retryButton.style.display = DisplayStyle.Flex;
    }

	public void RetryGame()
	{
        Time.timeScale = 1;
        SceneManager.LoadScene("MainLevel");
	}

	IEnumerator ScoreIncreaseWait()
    {
        yield return new WaitForSeconds(0.1f);
        playerScore += 1;

        StartCoroutine(ScoreIncreaseWait());
    }

    IEnumerator IncreaseGameSpeedWait()
    {
        yield return new WaitForSeconds(10);
        Time.timeScale += 0.1f;
        StartCoroutine(IncreaseGameSpeedWait());
    }
    #endregion
}
