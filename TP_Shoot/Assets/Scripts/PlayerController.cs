using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int life = 5;
    public float speed = 3.0f;
    public GameObject PrefabShot;
    public GameObject PrefabBigShot;
    public GameObject borderMin;
    public GameObject borderMax;
    public int Team = 1;

    private bool bonus;
    private float timeBonus = 20.0f;

    void Start(){
        
    }

    
    void Update(){
        Move();
        Shoot();

    }

    void Shoot()
    {
        
        if(timeBonus >= 20.0f)
        {
            bonus = false;
        } else
        {
            timeBonus += 0.01f;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject shot;
            if(bonus) shot = GameObject.Instantiate(PrefabBigShot);
            else shot = GameObject.Instantiate(PrefabShot);
            shot.transform.position = transform.position;
        }
    }


    void Move()
    {
        Vector3 currentPosition = transform.localPosition;
        Vector3 maxPosition = borderMax.transform.position;
        Vector3 minPosition = borderMin.transform.position;

        // On récupere touches appuyées
        if (Input.GetKey(KeyCode.RightArrow)) currentPosition.x += speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.LeftArrow)) currentPosition.x -= speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.UpArrow)) currentPosition.y += speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.DownArrow)) currentPosition.y -= speed * Time.deltaTime;

        if(currentPosition.x < maxPosition.x && currentPosition.x > minPosition.x && currentPosition.y > minPosition.y && currentPosition.y < maxPosition.y) transform.localPosition = currentPosition;
    }

    public void getHit(int value)
    {

        life -= value;
        if(life <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void setBonus(int value)
    {
        bonus = true;
        timeBonus = 0.0f;
    }

}
