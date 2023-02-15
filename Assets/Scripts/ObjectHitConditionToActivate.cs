﻿using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class ObjectHitConditionToActivate : MonoBehaviour, IInteractable
    {
        [SerializeField] private string _name;
        [SerializeField, TextArea] private string _dialogLocked;
        [SerializeField] private string _condition;
        [SerializeField, TextArea] private string _dialogUnlocked;
        [SerializeField] private bool _dropItemWhenUncloked;
        [SerializeField] private ObjectHitDropItem _objectHitDropItem;
        [SerializeField] private bool _changeSpriteWhenUnlocked;
        [SerializeField] private ObjectHitChangeSprite _objectHitChangeSprite;

        private int _index;

        public void Execute()
        {
            Condition condition = ValueDontDestroyOnLoad.Instance.ConditionsList
                .Find(x => x.Name == _name).Conditions
                .Find(x => x.Name == _condition);
         
            string index = _index == 0 ? " " : "  ";
            _index = _index == 0 ? 1 : 0;
            string text = condition.IsTrue ? _dialogUnlocked + index : _dialogLocked + index;
            
            GameManager.Instance.ShowDialog(text);
            StartCoroutine(GameManager.Instance.HideDialog(2));

            if (condition.IsTrue)
            {
                if (_dropItemWhenUncloked)
                {
                    _objectHitDropItem.DropItem();
                }

                if (_changeSpriteWhenUnlocked)
                {
                    _objectHitChangeSprite.ChangeSprite();
                }
            }
        }
    }
}