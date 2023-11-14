using System.Collections;
using CollisionSystem.Core.View;
using MVVM.EventBinding.InteraceAdapters;
using NUnit.Framework;
using UniRx;
using UnityEngine;
using UnityEngine.TestTools;

namespace CollisionSystem.Tests.PlayMode
{
    public class CollisionSystemPlayModeTests
    {
        [UnityTest]
        public IEnumerator Collide_OnTriggerEnter_CheckIfTheObjectCollided()
        {
            //Arrange
            GameObject floorGameObject = new GameObject("Floor");
            floorGameObject.transform.position = new Vector3(0, -2, 0);
            floorGameObject.AddComponent<BoxCollider2D>();
            
            EventBindingCollisionTriggerView collisionTriggerView = floorGameObject.AddComponent<EventBindingCollisionTriggerView>();
            EventBindingViewModel eventBindingViewModel = new EventBindingViewModel();
            
            yield return null;
            
            collisionTriggerView.SetEventBinding(eventBindingViewModel);
            
            GameObject collisionDetectorGameObject = new GameObject("Collision Detector");
            collisionDetectorGameObject.transform.position = new Vector3(0, 2, 0);
            collisionDetectorGameObject.AddComponent<BoxCollider2D>().isTrigger = true;
            collisionDetectorGameObject.AddComponent<Rigidbody2D>();

            collisionDetectorGameObject.AddComponent<OnTriggerEnter2DCollisionDetectorView>();

            bool wereCollided = false; 

            eventBindingViewModel.ReactiveCommand.Subscribe(_ =>
            {
                wereCollided = true;
            });

            //Act
            
            yield return new WaitForSeconds(3);

            //Assert

            Assert.AreEqual(true, wereCollided);
        }
    }

}