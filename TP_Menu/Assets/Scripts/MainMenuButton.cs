using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuButton : MonoBehaviour
{
    public Image ImageOutline;
    public TMPro.TextMeshProUGUI Text;
    public Color ColorInitial;
    public Color ColorSelected;

    private bool _hidden = false;

    public void OnPointerEnter()
    {
        if (_hidden) return;

        ImageOutline.DOKill();
        ImageOutline.DOFade(1,0.2f);

        Text.DOKill();
        Text.DOColor(ColorSelected, 0.2f);
    }

    public void OnPointerExit()
    {
        if (_hidden) return;

        ImageOutline.DOKill();
        ImageOutline.DOFade(0, 0.1f);

        Text.DOKill();
        Text.DOColor(ColorInitial, 0.2f);
    }

    public void Hide(float time)
    {
        _hidden = true;

        ImageOutline.DOKill();
        ImageOutline.DOFade(0,time);

        Text.DOKill();
        Text.DOFade(0, time);
    }
}
