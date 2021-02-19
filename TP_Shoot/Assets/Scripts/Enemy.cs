using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int life = 5;
    public float speedH = 0.50f;
    public float speedV = 0.50f;
    public float shotTime = 10.0f;
    public bool goLeft = false;
    public int typeDeplacmeent = 1;
    public int Team = 2;

    public Animator anim;
    public GameObject PrefabShot;
    public GameObject borderMin;
    public GameObject borderMax;

    private float timeBeforeChange;
    private float timeBeforeShot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (typeDeplacmeent == 1) deplacement1();
        if (typeDeplacmeent == 2) deplacement2();
        if (PrefabShot != null) Shoot();

    }

    void Shoot()
    {
        timeBeforeShot += 0.01f;
        if (timeBeforeShot >= shotTime && transform.localPosition.y < borderMax.transform.position.y)
        {
            GameObject shot = GameObject.Instantiate(PrefabShot);
            shot.transform.position = transform.position;
            timeBeforeShot = 0;
        }
    }

    void deplacement1()
    {
        Vector3 currentPosition = transform.localPosition;
        Vector3 maxPosition = borderMax.transform.position;
        Vector3 minPosition = borderMin.transform.position;

        // Vers le bas
        currentPosition.y += -speedH * Time.deltaTime;

        timeBeforeChange += 0.01f;
        if (timeBeforeChange >= 10.0f)
        {
            goLeft = !goLeft;
            timeBeforeChange = 0;
        }

        // vers gauche ou droite
        if (goLeft && currentPosition.x > minPosition.x)currentPosition.x -= speedV * Time.deltaTime;
        if (!goLeft && currentPosition.x < maxPosition.x) currentPosition.x += speedV * Time.deltaTime;

        transform.localPosition = currentPosition;
    }

    void deplacement2()
    {
        Vector3 currentPosition = transform.localPosition;
        Vector3 maxPosition = borderMax.transform.position;
        Vector3 minPosition = borderMin.transform.position;

        // Vers le bas
        currentPosition.y += -speedH * Time.deltaTime;

        // vers gauche ou droite
        if (goLeft)
        {
            if (currentPosition.x > minPosition.x) currentPosition.x -= speedV * Time.deltaTime;
            else goLeft = !goLeft;
        }
        else
        {
            if (currentPosition.x < maxPosition.x) currentPosition.x += speedV * Time.deltaTime;
            else goLeft = !goLeft;
        }
            

        transform.localPosition = currentPosition;
    }

    public void OnAnimationEnd()
    {
        Destroy(gameObject);
    }

    public void getHit(int dmg)
    {
        life -= dmg;
        if (life <= 0)
        {
            timeBeforeShot = 0;
            if (anim == null) OnAnimationEnd();
            else anim.SetTrigger("explo");
        }
    }
        
}
