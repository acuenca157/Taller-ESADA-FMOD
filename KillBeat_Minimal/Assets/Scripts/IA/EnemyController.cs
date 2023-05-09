using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;
// using FMODUnity;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float vidaBase = 100f;
    private Transform playerTransform;
    private NewPlayerLifeController playerLifeController;
    private float vidaActual;
    private NavMeshAgent navMeshAgent;
    private SpriteRenderer sprite;
    private LevelsController lvlController;
    [SerializeField] private int damageAmt = 5;
    [SerializeField] private float damageWaitTime = 0.5f;
    [Range(0f, 5f)] [SerializeField] private float attackRadio = 2f;
    [Range(0f, 10f)] [SerializeField] private float seeRadio = 5f;
    // [SerializeField] private EventReference eventMuere, eventDamage;
    [HideInInspector] public bool seenPlayer = false;

    private bool muerto = false;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        playerLifeController = playerTransform.GetComponent<NewPlayerLifeController>();
        lvlController = FindAnyObjectByType<LevelsController>();
        vidaActual = vidaBase;
        navMeshAgent = GetComponent<NavMeshAgent>();
        StartCoroutine(damagePlayer());
    }

    private void Update()
    {
        if (Vector3.Distance(this.transform.position, playerLifeController.transform.position) < seeRadio && !seenPlayer)
            seenPlayer = true;
        if (!muerto && seenPlayer)
            navMeshAgent.destination = playerLifeController.transform.position;
    }

    public void recibirDamage( float damage ) {
        if (!muerto)
        {
            seenPlayer = true;
            // FMODUnity.RuntimeManager.PlayOneShotAttached(eventDamage, this.transform.gameObject);
            vidaActual -= damage;
            if (vidaActual <= 0)
            {
                // FMODUnity.RuntimeManager.PlayOneShotAttached(eventMuere, this.transform.gameObject);
                muerto = true;
                lvlController.killEnemy();
                Destroy(this.gameObject);
            }
        }
    }

    IEnumerator damagePlayer() {
        while (!muerto) {
            float distance = Vector3.Distance(this.transform.position, playerLifeController.transform.position);
            if (distance <= attackRadio) {
                playerLifeController.damagePlayer(damageAmt);
            }
            yield return new WaitForSeconds(damageWaitTime);
        }
        yield return new WaitForEndOfFrame();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, attackRadio);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, seeRadio);
    }
}
