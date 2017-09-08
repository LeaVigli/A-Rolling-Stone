using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameController2 : MonoBehaviour {

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
        if (Minuteur() > 18 || Minuteur() < 9)
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
