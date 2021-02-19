using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Cube : MonoBehaviour
{
    public Vector3 TopOffset = new Vector3(0.5f, 1f, -0.5f);
    public List<Cube> Neighbours = new List<Cube>();


    private void OnMouseDown()
    {
        transform.DOLocalMoveY(transform.localPosition.y - 0.1f, 0.1f).SetLoops(2, LoopType.Yoyo);

        

        if (!GameCore.Instance.isMoving)
        {
            GameCore.Instance.GeneratePath(this);
            GameCore.Instance.Move();
        }


    }

    // Debug

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position+ TopOffset, 0.2f);
    }

    private void OnDrawGizmosSelected()
    {
        foreach(var item in Neighbours)
        {
            Debug.DrawLine(transform.position + TopOffset, item.transform.position + item.TopOffset, Color.red);
        }
    }
}
