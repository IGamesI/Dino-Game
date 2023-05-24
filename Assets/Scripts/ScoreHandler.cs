using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ScoreHandler : MonoBehaviour
{
    #region Variables
    public int playerScore = 1;
    Label _scoreLabel;
	#endregion

	#region UnityFunctions
	private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

		_scoreLabel = root.Q<Label>("ScoreCounter");
		_scoreLabel.text = playerScore.ToString();

		StartCoroutine(ScoreIncreaseWait());
		StartCoroutine(IncreaseGameSpeedWait());
	}

    private void Update()
    {
		_scoreLabel.text = playerScore.ToString();
	}
	#endregion

	#region CustomFunctions
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
