using System.Collections;
using System.Collections.Generic;
using SceneTransition;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] private string _nextScene;

    public void Execute()
    {
        GameManager.Instance.TransitionManager.LaunchTransitionOut(TransitionType.Slide);
        StartCoroutine(LaunchScene());
    }

    private IEnumerator LaunchScene()
    {
        yield return new WaitForSeconds(1f);
        PlayerPrefs.SetString(GameManager.NextSceneKey, _nextScene);
        SceneManager.LoadScene("GameCommon");
    }
}
