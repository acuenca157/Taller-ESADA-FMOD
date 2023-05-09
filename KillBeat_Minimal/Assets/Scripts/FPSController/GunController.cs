using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class GunController : MonoBehaviour, IEasyListener
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;
    [SerializeField] private EventReference upgradeEvent;
    private LevelsController lvlController;
    private Camera myCamera;

    private void Start()
    {
        myCamera = Camera.main;
        lvlController = FindAnyObjectByType<LevelsController>();
    }

    public void Shoot() {
        if (lvlController.isInBattle) {
            myCamera.fieldOfView = 68f;
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
        }
    }

    public void upgradeWeapon(int lvl) {
        FMODUnity.RuntimeManager.PlayOneShot(upgradeEvent);
    }

    public void OnBeat(EasyEvent audioEvent) 
	{ 
        Shoot();
	}
    private void Update()
    {
        myCamera.fieldOfView = Mathf.Lerp(myCamera.fieldOfView, 70f, 0.5f);
    }
}
