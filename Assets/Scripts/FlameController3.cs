using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameController3 : MonoBehaviour {

    public ParticleSystem flames;
    public GameObject collision;
    private float minuterie;

    // Use this for initialization
    void Start()
    {
        minuterie = 0.0f;
    }

    void Update()
    {
        DisapearFlame();
    }

    private float Minuteur()
    {
        minuterie += Time.deltaTime;
        return minuterie;
    }

    private void DisapearFlame()
    {
        if (Minuteur() > 20 || Minuteur() < 11)
        {
            flames.Play();
            collision.SetActive(true);
            if (Minuteur() > 22)
            {
                minuterie = 0;
            }
        }
        else
        {
            flames.Stop();
            collision.SetActive(false);
        }
    }
}
