using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SpriteAnimable : MonoBehaviour
{
    public SpriteRenderer Renderer;
    public List<SpriteAnimation> Animations;

    SpriteAnimation _currentAnimation;
    float _timer;
    int _currentIndex;
    bool _isLoop;
    bool _isDone;
    

    public void PlayAnimation(string name, bool loop)
    {
        _isLoop = loop;
        _isDone = loop;
        _currentIndex = 0;
        SpriteAnimation anim = GetAnimation(name);
        if(anim != null)
        {
            _currentAnimation = anim;
        }
    }

    private SpriteAnimation GetAnimation(string name)
    {
        for(int i = 0; i < Animations.Count; i++)
        {
            if (Animations[i].name.Equals(name)) return Animations[i];
        }
        Debug.LogError("Animation not found");
        return null;
    }

    void Update()
    {
        _timer += Time.deltaTime;

        if( _timer >= _currentAnimation.Framerate)
        {

            if (!_isLoop && _currentIndex == _currentAnimation.Sprites.Count - 1)
            {
                PlayAnimation("Default",true);
                _isDone = true;
            }

            _currentIndex = (_currentIndex + 1) % _currentAnimation.Sprites.Count;
            _timer -= _currentAnimation.Framerate;

            Renderer.sprite = _currentAnimation.Sprites[_currentIndex];
        }
    }

    public bool IsDone()
    {
        return _isDone;
    }




}
