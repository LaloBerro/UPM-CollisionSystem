using MVVM.EventBinding.InteraceAdapters;
using UnityEngine;

namespace CollisionSystem.Core.View
{
    public class EventBindingCollisionTriggerView : MonoBehaviour, ICollisionTriggerView
    {
        [Header("References")] 
        [SerializeField] private EventBindingViewModelSO _eventBindingViewModelSo;

        private EventBindingViewModel _eventBindingViewModel;

        private void Awake()
        {
            _eventBindingViewModel = _eventBindingViewModelSo?.GetViewModel();
        }

        public void SetEventBinding(EventBindingViewModel eventBindingViewModel)
        {
            _eventBindingViewModel = eventBindingViewModel;
        }

        public void Collide()
        {
            _eventBindingViewModel.ReactiveCommand.Execute();
        }
    }
}