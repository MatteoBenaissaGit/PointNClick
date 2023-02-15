using UnityEngine;

namespace DefaultNamespace
{
    public class ItemPickupActivateCondition : MonoBehaviour
    {
        [SerializeField] private string _NPCName;
        [SerializeField] private string _conditionName;

        public void Activate()
        {
            ValueDontDestroyOnLoad.Instance.ActivateCondition(_NPCName, _conditionName, true);
        }
    }
}