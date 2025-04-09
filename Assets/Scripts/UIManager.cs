using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameStateManager gameStateRef;

    public void QuitMethod()
    {
        Application.Quit();
    }

    public void PlayMethod()
    {
        gameStateRef.ChangeState(GameStateManager.GameState.Gameplay_State);
    }

    public void ResumeGamePlay()
    {
        gameStateRef.ChangeState(GameStateManager.GameState.Gameplay_State);
    }

    public void BackToMainMenu()
    {
        gameStateRef.ChangeState(GameStateManager.GameState.MainMenu_State);
    }
}
