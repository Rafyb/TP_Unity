using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public float speed = 5.0f;
    public int damage = 1;
    public int Team = 1;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Destroy(gameObject,3);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPosition = transform.localPosition;
        currentPosition.y += speed * Time.deltaTime;
        transform.localPosition = currentPosition;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if(other.gameObject.tag == "Enemy" && tag == "Player_Bullet")
        {
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            enemy.getHit(damage);
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Player" && tag == "Enemy_Bullet")
        {
            PlayerController player = other.gameObject.GetComponent<PlayerController>();
            player.getHit(damage);
            Destroy(gameObject);
        }


    }
}
