﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInfo : MonoBehaviour
{

    public CharacterRoundStats info;

    Health health;


    private void Awake()
    {
        health = GetComponent<Health>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        info.health = health.currentHealth;
    }
}
