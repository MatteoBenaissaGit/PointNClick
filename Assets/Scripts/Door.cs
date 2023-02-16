using System;
using System.Collections;
using System.Collections.Generic;
using SceneTransition;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class Door : MonoBehaviour
{
    [SerializeField] private string _nextScene;
    [SerializeField] private Vector3 _playerPlacement;
    [SerializeField] private float _playerScale = 1;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        PlayerController playerController = col.gameObject.GetComponent<PlayerController>();
        if (playerController != null)
        {
            GameManager.Instance.TransitionManager.LaunchTransitionOut(TransitionType.Slide);
            StartCoroutine(LaunchScene());
        }
    }

    private IEnumerator LaunchScene()
    {
        yield return new WaitForSeconds(1f);
        PlayerPrefs.SetString(GameManager.NextSceneKey, _nextScene);

        PlayerPrefs.SetFloat("positionX", _playerPlacement.x);
        PlayerPrefs.SetFloat("positionY", _playerPlacement.y);
        PlayerPrefs.SetFloat("scale", _playerScale);
        SceneManager.LoadScene("GameCommon");
    }
    
    #if UNITY_EDITOR

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(_playerPlacement, Vector3.one*0.25f);
    }

#endif
}
