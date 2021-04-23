using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Image ImageFade;
    public List<MainMenuButton> Buttons;

    public void OnCLickPlay()
    {
        ImageFade.DOFade(1, 0.8f).OnComplete(FadeComplete);

        for(int i = 0; i < Buttons.Count; i++)
        {
            if (i == 0)
            {
                Buttons[i].Hide(1f);
            }
            else
            {
                Buttons[i].Hide(0.1f);
            }
        }
        
    }

    private void FadeComplete()
    {
        SceneManager.LoadScene("Gameplay");
    }
}
