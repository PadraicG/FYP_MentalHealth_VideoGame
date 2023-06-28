using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//when something get into the alta, make the runes glow

namespace Cainos.PixelArtTopDown_Basic
{

    public class PropsAltar : MonoBehaviour
    {
        [SerializeField] private AudioSource RuneSoundEffect;

        public List<SpriteRenderer> runes;
        public float lerpSpeed;

        private Color curColor;
        private Color targetColor;

        [SerializeField] private GameObject LadyOfHope2;

        private void OnTriggerEnter2D(Collider2D other)
        {
            targetColor = new Color(1, 1, 1, 1);
            Vector3 spawnPosition = new Vector3(-9, 3, 0);
            Quaternion spawnRotation = Quaternion.identity; // No rotation
            Instantiate(LadyOfHope2, spawnPosition, spawnRotation);
            LadyOfHope2.SetActive(true);
            RuneSoundEffect.Play();

        }


        private void Update()
        {
            curColor = Color.Lerp(curColor, targetColor, lerpSpeed * Time.deltaTime);

            foreach (var r in runes)
            {
                r.color = curColor;
            }
        }
    }
}
