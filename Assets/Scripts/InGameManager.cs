using UnityEngine;

public class InGameManager : MonoBehaviour
{
    public GameObject deathMenu;

    public void ChangeHealth(int maxHealth, int currentHealth)
    {
        if(currentHealth < 0)
            return;

        if (currentHealth == 0)
        {
            OpenDeathMenu();
        }
    }

    public void OpenDeathMenu()
    {
        Time.timeScale = 0f;
        deathMenu.SetActive(true);
    }
}