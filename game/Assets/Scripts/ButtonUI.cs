using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonUI : MonoBehaviour
{
    [SerializeField] private string continueGameLevel = "Level1 1";
    public void ContinueGameButton() {
        SceneManager.LoadScene(continueGameLevel);
    }

    public void RateOfFire() {
        PlayerController.fireRateMultiplier *= 1.5f;
    }

    public void ReloadSpeed() {
        PlayerController.reloadSpeedMultiplier *= 1.5f;
    }

    public void HealthRegen() {
        PlayerController.healthRegenMultiplier *= 1.5f;
    }

    public void DamageResistance() {
        PlayerController.damageResistanceMultiplier *= 1.2f;
    }

    public void Multishot() {
        PlayerController.multiShot += 1;
    }

    public void IncreasedDamage() {
        PlayerController.damageMultiplier *= 1.25f;
    }

    public void MovementSpeed() {
        PlayerController.moveSpeed *= 1.25f;
    }


}
