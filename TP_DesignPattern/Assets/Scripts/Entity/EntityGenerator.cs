using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EntityType
{
    Joueur, Ennemi, Tir
}

[Serializable]
public class EntityGenerator
{

    public GameObject prefabJoueur;
    public GameObject prefabEnnemi;
    public GameObject prefabTir;

    public GameObject Create(EntityType type)
    {
        GameObject go = null;
        switch (type)
        {
            case EntityType.Joueur:
                go = GameObject.Instantiate(prefabJoueur);
                break;
            case EntityType.Tir:
                go = GameObject.Instantiate(prefabTir);
                break;
            case EntityType.Ennemi:
                go = GameObject.Instantiate(prefabTir);
                break;
            default:
                Debug.LogError("Undefined constructor for " + type);
                break;
        }
        return go;
    }
    
}
