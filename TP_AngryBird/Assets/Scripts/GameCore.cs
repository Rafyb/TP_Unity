using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCore : MonoBehaviour
{

    public float forceMin;
    public float forceMax;
    public Rigidbody2D sword;
    public Image swordUI;

    private float m_timerClick;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            m_timerClick += Time.deltaTime;
            swordUI.fillAmount = m_timerClick;
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (m_timerClick > 1) m_timerClick = 1;

            float force = Mathf.Lerp(forceMin, forceMax, m_timerClick);

            sword.simulated = true;
            sword.AddForce(new Vector2(force, force), ForceMode2D.Impulse);

            m_timerClick = 0;
        }

        if(sword.velocity.magnitude > 0.00001f)
        {
            float angle = Mathf.Atan2(sword.velocity.y, sword.velocity.x) * Mathf.Rad2Deg;
            sword.transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    public static Vector2[] PreviewPhysics(Rigidbody2D rigidbody,Vector2 pos, Vector2 velocity, int steps)
    {
        Vector2[] results = new Vector2[steps];

        float timestep = Time.fixedTime;
        Vector2 gravityAccel = Physics2D.gravity * rigidbody.gravityScale * timestep * timestep;
        float drag = 1f - timestep * rigidbody.drag;
        Vector2 moveStep = velocity * timestep;

        for(int i = 0; i < steps; ++i)
        {
            moveStep += gravityAccel;
            moveStep *= drag;
            pos += moveStep;
            results[i] = pos;
        }

        return results;
    }

    private void OnDrawGizmos()
    {
        Vector2[] points = PreviewPhysics(sword, sword.transform.position, new Vector2(forceMin , forceMin), 200);

        foreach(var item in points)
        {
            Gizmos.DrawSphere(item, 0.05f);
        }

        points = PreviewPhysics(sword, sword.transform.position, new Vector2(forceMax, forceMax), 200);

        foreach (var item in points)
        {
            Gizmos.DrawSphere(item, 0.05f);
        }
    }
}
