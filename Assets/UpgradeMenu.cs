using UnityEngine;
using TMPro;


public class UpgradeMenu : MonoBehaviour
{
    public PlayerStats playerStats;
    public TextMeshProUGUI attackText;
    public TextMeshProUGUI maxHealth;
    public TextMeshProUGUI gold;
    private GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gold.text = "Gold : " + gameManager.gold;
        attackText.text = "Attack : " + playerStats.attackPower;
        maxHealth.text = "MaxHealth : " + playerStats.maxHealth;
    }
  
    
    public void UpgradeAttack()
    {
        if(gameManager.gold >= 10)
        {
            playerStats.AddAttack();
            gameManager.gold -= 10;
            gold.text = "Gold : " + gameManager.gold;
            attackText.text = "Attack : " + playerStats.attackPower;
        }
    }
    public void UpgradeMaxHealth()
    {
        if (gameManager.gold >= 10)
        {
            playerStats.AddMaxHealth();
            gameManager.gold -= 10;
            gold.text = "Gold : " + gameManager.gold;
            maxHealth.text = "MaxHealth : " + playerStats.maxHealth;
        }
    }
}
