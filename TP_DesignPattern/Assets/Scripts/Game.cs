using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Game : MonoBehaviour
{
    [Header("Component")]
    public Controller controller;
    public SoundManager soundmanager;
    [SerializeField] public EntityGenerator EntityFactory;

    [Header("Properties")] 
    public float timeRespawn = 1f;
    
    [HideInInspector] private Player _player;
    public Action OnDie;
    public Action OnSpawn;
    
    void Start()
    {
        Spawn();
        
        OnDie += Die;
        OnSpawn += Spawn;
        
        controller.Init(this);
        soundmanager.Init(this);
    }

    private void Die()
    {
        _player.Destroy();
        StartCoroutine(Respawn());
    }

    private IEnumerator Respawn()
    {
        yield return new WaitForSeconds(timeRespawn);
        Spawn();
    }

    private void Spawn()
    {
        _player =  EntityFactory.Create(EntityType.Joueur).GetComponent<Player>();
        _player.Init(this);
    }

    // Update is called once per frame
    void Update()
    {
        foreach (KeyBinding pair in controller.keyBinding)
        {
            if (Input.GetKeyDown(pair.key))
            {
    
                
            }
        }
    }
}
