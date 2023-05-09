using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using FMODUnity;

public class LevelsController : MonoBehaviour
{
    [HideInInspector] public bool isInBattle = true;
    [HideInInspector] public int weaponLevel = 0;
    // [SerializeField] private EventReference eventUpgrade;
    [SerializeField] private int totalEnemies;
    [SerializeField] private GameObject[] entryGates, exitGates;
    [SerializeField] private GameObject diePanel, winPannel, playPanel, camWeapon, flyCubes;
    [SerializeField] private GameObject[] enemiesBlocks;
    private Movement movementController;
    private NewPlayerLifeController playerLifeController;
    private EasyRhythmAudioManagerCustom rythmController;
    private int enemiesLeft;

    private void Start()
    {
        weaponLevel = 0;
        movementController = FindObjectOfType<Movement>();
        rythmController = FindObjectOfType<EasyRhythmAudioManagerCustom>();
        // rythmController.changeMusic("lobby");
        playerLifeController = FindObjectOfType<NewPlayerLifeController>();
        totalEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        enemiesLeft = totalEnemies;
        movementController.canMove = false;
        isInBattle = false;
        diePanel.SetActive(false);
        winPannel.SetActive(false);
        playPanel.SetActive(true);
        camWeapon.SetActive(false);
        flyCubes.SetActive(true);
    }

    public void startPlay() {
        isInBattle = true;
        movementController.canMove = true;
        // rythmController.changeMusic("weapon_0" + (weaponLevel + 1));
        playPanel.SetActive(false);
        camWeapon.SetActive(true);
        flyCubes.SetActive(false);
    }

    public void killEnemy() {
        enemiesLeft--;
        if (enemiesLeft <= 0)
            endLVL();
    }

    private void endLVL() {
        isInBattle = false;
        winPannel.SetActive(true);
        // rythmController.changeMusic("none");
    }

    public void pickedWeapon() {
        weaponLevel++;
        // FMODUnity.RuntimeManager.PlayOneShot(eventUpgrade);
        // rythmController.changeMusic("weapon_0" + (weaponLevel + 1));
    }

    public void pickedHeal()
    {
        playerLifeController.healPlayer(1000);
        // FMODUnity.RuntimeManager.PlayOneShot(eventUpgrade);
    }

    public void diePlayer() {
        // rythmController.changeMusic("died");
        diePanel.SetActive(true);
        isInBattle = false;
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            Destroy(enemy);
        }
    }

    public void quitGame() {
        Application.Quit();
    }
}
