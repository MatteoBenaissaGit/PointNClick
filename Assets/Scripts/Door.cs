using System;
using System.Collections;
using System.Collections.Generic;
using SceneTransition;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] private string _nextScene;
    [SerializeField] private Vector3 _playerPlacement;

    public void Execute()
    {
        GameManager.Instance.TransitionManager.LaunchTransitionOut(TransitionType.Slide);
        StartCoroutine(LaunchScene());
    }

    private IEnumerator LaunchScene()
    {
        yield return new WaitForSeconds(1f);
        PlayerPrefs.SetString(GameManager.NextSceneKey, _nextScene);

        GameManager.Instance.Player.transform.position = _playerPlacement;
        SceneManager.LoadScene("GameCommon");
    }
    
    #if UNITY_EDITOR

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(_playerPlacement, Vector3.one*0.25f);
    }

#endif
}
