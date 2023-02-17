using System;
using System.Collections;
using System.Collections.Generic;
using SceneTransition;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class ObjectHitChangeScene : MonoBehaviour, IInteractable
{
    [SerializeField] private float _timeBeforeChangingScene;
    [SerializeField] private string _sceneName;

    private float _timer = 2f;
    private bool _canTime;

    private void Start()
    {
        _canTime = false;
    }

    private void Update()
    {
        if (_canTime)
        {
            _timer -= Time.deltaTime;
            if (_timer <= 0)
            {
                Change();
            }
        }
    }

    public void Execute()
    {
        _canTime = true;
        GameManager.Instance.TransitionManager.LaunchTransitionOut(TransitionType.Slide);
    }

    private void Change()
    {
        SceneManager.LoadScene(_sceneName);
    }
}
