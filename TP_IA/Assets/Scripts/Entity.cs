using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EntityType
{
    Monster,Player
}

public class Entity : MonoBehaviour
{
    public EntityType type;

    [Header("Stats")]
    public float speed = 5f;

    SpriteAnimable _animations;
    Vector3 _initialPos;
    bool _isMoving;

    public Vector3 GetInitialPos()
    {
        return _initialPos;
    }

    void Start()
    {
        _initialPos = transform.position;

        _isMoving = false;

        _animations = gameObject.GetComponent<SpriteAnimable>();
        _animations.PlayAnimation("Default", true);
        
    }


    public void PlayAction(string name)
    {
        bool loop = false;
        switch (name)
        {
            case "Walk":
                loop = true;
                break;
            case "Default":
                loop = true;
                break;
        }
        PlayAnimation(name, loop);
    }


    /// <summary>
    /// Moving
    /// </summary>

    public bool IsMoving()
    {
        return _isMoving;
    }

    public void MoveToInit()
    {
        Move(_initialPos);
    }

    public void Move(Vector3 newPos)
    {
        GetComponent<SpriteRenderer>().flipX = newPos.x < transform.position.x;

        _isMoving = true;

        transform.DOKill();
        transform.DOMove(newPos, 1/speed).OnComplete(() => { _isMoving = false; });
    }

    /// <summary>
    /// Animation
    /// </summary>

    public bool AnimationIsDone()
    {
        return _animations == null || _animations.IsDone();
    }

    public void PlayAnimation(string name, bool loop)
    {
        _animations?.PlayAnimation(name, loop);
    }




}
