using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Febucci.UI;
using SceneTransition;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [field: SerializeField] public PlayerController Player { get; private set; }
    [field: SerializeField] public CanvasInventory CanvasInventory { get; private set; }
    [field: SerializeField] public TransitionManager TransitionManager { get; private set; }

    public const string NextSceneKey = "NextScene";
    
    public TMP_Text DialogText;
    public Image DialogBackground;
    [HideInInspector] public float HideTimer;
    public Texture2D CursorBase;
    public Texture2D CursorHover;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
        //text
        DialogBackground.DOFade(0, 0);
        DialogText.text = string.Empty;
    }

    private void Start()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString(NextSceneKey, "Exterior"), LoadSceneMode.Additive);
        PlayerPrefs.DeleteKey(NextSceneKey);
        
        if (PlayerPrefs.HasKey("positionX") && PlayerPrefs.HasKey("positionY"))
        {
            Player.transform.position = new Vector2(PlayerPrefs.GetFloat("positionX"), PlayerPrefs.GetFloat("positionY"));
        }
        if (PlayerPrefs.HasKey("scale"))
        {
            Player.transform.localScale = ValueDontDestroyOnLoad.Instance.PlayerBaseScale * PlayerPrefs.GetFloat("scale");
        }
    }

    private void Update()
    {
        HideTimer -= Time.deltaTime;
        if (HideTimer <= 0 && DialogText.text != string.Empty)
        {
            HideDialog();    
        }
    }

    public void AddItem(Item item)
    {
        CanvasInventory.Instance.AddItem(item);
    }

    public void ShowDialog(string text)
    {
        DialogBackground.DOFade(0.4f, 0.3f);
        print("show dialog");
        DialogText.text = text;
    }
    
    public void HideDialog()
    {
        DialogBackground.DOFade(0, 0.2f);
        print("hideDialog");
        DialogText.text = string.Empty;
    }
}

[Serializable]
public struct NPC
{
    public string Name;
    public string Scene;
    public NPCController NPCController;
}
