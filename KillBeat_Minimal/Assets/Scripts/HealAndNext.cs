using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class HealAndNext : MonoBehaviour
{
    [SerializeField] private float pickupRange = 2f;
    Transform playerTransform;
    GunController gunController;
    LevelsController levelController;
    [SerializeField] private EventReference healEvent;
    [SerializeField] private GameObject text;

    private void Start()
    {
        playerTransform = FindObjectOfType<Movement>().transform;
        gunController = playerTransform.GetComponentInChildren<GunController>();
        levelController = FindObjectOfType<LevelsController>();
    }

    // Update is called once per frame
    void Update()
    {
        text.SetActive(false);
        if (Vector3.Distance(this.transform.position, playerTransform.position) <= pickupRange)
        {
            text.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                FMODUnity.RuntimeManager.PlayOneShot(healEvent);
                levelController.pickedHeal();
                Destroy(this.gameObject);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(this.transform.position, pickupRange);
    }
}
