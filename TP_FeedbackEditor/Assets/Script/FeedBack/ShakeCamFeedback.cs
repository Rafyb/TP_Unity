using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCam : GameFeedback
{
    public float duration ;
    public float magnitude ;
    
    public override IEnumerator Execute(GameEventInstance gameEvent)
    {
        Camera mainCamera = Camera.main;
        
        Vector3 orignalPosition = mainCamera.transform.position;
        float elapsed = 0f;
        
        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            mainCamera.transform.position = new Vector3(x, y, -10f);
            elapsed += Time.deltaTime;
            yield return 0;
        }
        mainCamera.transform.position = orignalPosition;
    }

    public override Color color()
    {
        return Color.yellow;
    }

    public override string ToString()
    {
        return base.ToString() + " " + duration + " " + magnitude;
    }
}
