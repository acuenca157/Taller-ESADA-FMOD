using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using FMODUnity;

//public class GunController : MonoBehaviour, IEasyListener
public class GunController : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;
    private LevelsController lvlController;
    private Camera myCamera;

    private void Start()
    {
        myCamera = Camera.main;
        lvlController = FindAnyObjectByType<LevelsController>();

        StartCoroutine(shootLoop());
    }

    //public void OnBeat(EasyEvent audioEvent)
    //{
    //    Shoot();
    //}

    private IEnumerator shootLoop()
    {
        while (true)
        {
            Shoot();
            yield return new WaitForSeconds(0.3f);
        }
    }

    public void Shoot() {
        if (lvlController.isInBattle) {
            myCamera.fieldOfView = 68f;
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
        }
    }

    private void Update()
    {
        myCamera.fieldOfView = Mathf.Lerp(myCamera.fieldOfView, 70f, 0.5f);
    }

    
}
