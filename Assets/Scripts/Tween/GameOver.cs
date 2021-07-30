using System.Collections;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public CanvasGroup gameOver;
    public Image gameOverImage;
    public CanvasGroup menuRestart;

    private float gameOverDuration = 1f;
    private float menuRestartDuration = 1.5f;
    
    private void OnEnable()
    {
        StartCoroutine(DisplayGameOver());
    }

    private IEnumerator DisplayGameOver()
    {
        Tween gameOverTween = gameOver.DOFade(1.0f, gameOverDuration).SetEase(Ease.Linear);

        yield return gameOverTween.WaitForCompletion();
        gameOverImage.rectTransform.DOLocalMoveX(300, 1);
        menuRestart.DOFade(1.0f, menuRestartDuration).SetEase(Ease.Linear);
    }

    public void TunOffGameOver()
    {
        gameOver.DOFade(0f, gameOverDuration).SetEase(Ease.Linear);
        gameOverImage.rectTransform.DOLocalMoveX(-300, 1);
        menuRestart.DOFade(0f, menuRestartDuration).SetEase(Ease.Linear);
    }
}
