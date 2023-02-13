using System.Collections;
using System.Collections.Generic;
using SceneTransition;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [field: SerializeField] public PlayerController Player { get; private set; }
    [field: SerializeField] public CanvasInventory CanvasInventory { get; private set; }
    [field: SerializeField] public TransitionManager TransitionManager { get; private set; }
    
    public const string NextSceneKey = "NextScene";


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("Two GameManager");
        }
    }

    private void Start()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString(NextSceneKey, "Exterior"), LoadSceneMode.Additive);
        PlayerPrefs.DeleteKey(NextSceneKey);
        if (PlayerPrefs.HasKey("positionX") && PlayerPrefs.HasKey("positionY"))
        {
            Player.transform.position = new Vector2(PlayerPrefs.GetFloat("positionX"), PlayerPrefs.GetFloat("positionY"));
        }
    }

    public void AddItem(Item item)
    {
        CanvasInventory.AddItem(item);
    }
}
