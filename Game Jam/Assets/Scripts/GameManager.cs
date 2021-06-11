using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState State;

    public static event Action<GameState> OnGameStateChanged;

    void Awake() {
        Instance = this;
    }

    void Start(){
        UpdateGameState(GameState)
    }

    public void UpdateGameState(GameState newState){
        State = newState;

        switch (newState){
            case GameState.Victory:
                break;
            case GameState.Lose:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null)
        }

        OnGameStateChanged?.Invoke(newState)
    }
}

public enum GameState{
    Victory,
    Lose
}