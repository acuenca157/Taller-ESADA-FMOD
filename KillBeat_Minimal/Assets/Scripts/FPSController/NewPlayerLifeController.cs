using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using FMODUnity;

public class NewPlayerLifeController : MonoBehaviour
{
    [SerializeField] private EventReference damageEvent, dieEvent;
    [SerializeField] private PostProcessVolume volume;
    [SerializeField] private GameObject[] lifeCubes;

    Vignette vignette;
    Grain grain;
    public int totalLife = 100;
    private int actualLife;

    private void Awake()
    {
        actualLife = totalLife;    
    }
    
    // Start is called before the first frame update
    void Start()
    {
        if (volume.profile.TryGetSettings<Vignette>(out var tmp_vignette))
            vignette = tmp_vignette;
        if (volume.profile.TryGetSettings<Grain>(out var tmp_grain))
            grain = tmp_grain;
        updateFX();
    }

    public void damagePlayer(int dmgAmt) {
        FMODUnity.RuntimeManager.PlayOneShot(damageEvent);
        actualLife -= dmgAmt;
        if (actualLife <= 0) {
            die();
        }
        updateFX();
    }

    public void healPlayer (int healAmt) {
        if (actualLife + healAmt > totalLife)
            actualLife = totalLife;
        else
            actualLife += healAmt;
        updateFX();
    }

    private void updateCubes() {
        int roundedLife = (actualLife - actualLife % 10) / 10;
        int i = 0;
        foreach (var cube in lifeCubes)
        {
            if (i > roundedLife)
            {
                cube.SetActive(false);
            }
            else {
                cube.SetActive(true);
            }
            i++;
        }
    }

    private void updateFX() {
        vignette.intensity.value = ((100f - actualLife) / 100f) / 2f;
        grain.intensity.value = ((100f - actualLife) / 100f);
        updateCubes();
    }

    private void die() {
        FMODUnity.RuntimeManager.PlayOneShot(dieEvent);
        FindObjectOfType<Movement>().canMove = false;
        FindObjectOfType<LevelsController>().diePlayer();
    }

    private void Update()
    {
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("health", actualLife);
    }
}
