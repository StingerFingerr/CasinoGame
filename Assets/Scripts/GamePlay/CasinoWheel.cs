using System;
using System.Collections;
using Services.Progress;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace GamePlay
{
    public class CasinoWheel: MonoBehaviour
    {
        public Button launchButton;
        public Transform wheel;
        public WheelItem[] wheelItems;
        public AnimationCurve rotatingPattern;
        public float spinDuration = 5;
        public float maxAngularSpeed = 500;
        public float correctionSpeed = 10f;
        public float dispersion = 25;

        public void LaunchWheel(Action<int, CoinType> onComplete) => 
            StartCoroutine(SpinAnimation(onComplete));

        private IEnumerator SpinAnimation(Action<int, CoinType> onComplete)
        {
            float timer = 0;
            float maxSpeed = maxAngularSpeed * Random.Range(1 - (dispersion / 100), 1 + (dispersion / 100));
            
            while (timer <= spinDuration)
            {
                timer += Time.deltaTime;

                float angularSpeed = rotatingPattern.Evaluate(timer / spinDuration) * maxSpeed * Time.deltaTime;
                
                wheel.Rotate(Vector3.forward, angularSpeed);
                
                yield return null;
            }

            float currentRotation = wheel.localEulerAngles.z;
            
            float offset = 360f / wheelItems.Length / 2f;
            float sector = 360f / wheelItems.Length;
            
            int itemIndex = (int) (currentRotation / sector);

            float newRotation = itemIndex * sector + offset;

            while (Math.Abs(currentRotation - newRotation) > .1f)
            {
                currentRotation = Mathf.Lerp(currentRotation, newRotation, Time.deltaTime * correctionSpeed);
                wheel.localEulerAngles = Vector3.forward * currentRotation;
                yield return null;
            }

            WheelItem reward = wheelItems[itemIndex];
            onComplete?.Invoke(reward.reward, reward.type);
        }
    }
}