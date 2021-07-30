using System.Collections;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class WinGame : MonoBehaviour
{
    public CanvasGroup gameVictory;
    public Image gameVictoryImage;
    public CanvasGroup menuCompleted;

    private float gameOverDuration = 1f;
    private float menuCompletedDuration = 1.5f;
    
    private void OnEnable()
    {
        StartCoroutine(DisplayGameOver());
    }

    private IEnumerator DisplayGameOver()
    {
        Tween gameVictoryTween = gameVictory.DOFade(1.0f, gameOverDuration).SetEase(Ease.Linear);

        yield return gameVictoryTween.WaitForCompletion();
        
        gameVictoryImage.rectTransform.DOLocalMoveX(300, 1);
        menuCompleted.DOFade(1.0f, menuCompletedDuration).SetEase(Ease.Linear);
    }
    
    public void TunOffGameVictory()
    {
        gameVictory.DOFade(0f, gameOverDuration).SetEase(Ease.Linear);
        gameVictoryImage.rectTransform.DOLocalMoveX(-300, 1);
        menuCompleted.DOFade(0f, menuCompletedDuration).SetEase(Ease.Linear);
    }
}
