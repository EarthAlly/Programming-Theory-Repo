using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Animals.Base
{
    public class Animal : MonoBehaviour
    {
        private GameObject canvas;
    
        private Button playSoundButton;
        private Button walkButton;
        private Button jumpButton;
        private Button talkButton;
    
        private TMP_InputField talkField;
    
        private TMP_Text animalSpeechText;
    
        [SerializeField] private AudioClip soundEffect;
    
        private AudioSource audioSource;

        private bool walkingAnimationRunning;
        private bool talkingAnimationRunning;

        private void Start()
        {
            GetUIElements();
            SetUpButtons();
        }

        // ABSTRACTION
        
        // UI elements
        private void GetUIElements()
        {
            canvas = GameObject.Find("Canvas");
        
            playSoundButton = canvas.transform.Find("PlaySoundButton").GetComponent<Button>();
            walkButton = canvas.transform.Find("WalkButton").GetComponent<Button>();
            jumpButton = canvas.transform.Find("JumpButton").GetComponent<Button>();
            talkButton = canvas.transform.Find("TalkButton").GetComponent<Button>();
        
            talkField = canvas.transform.Find("TalkField").GetComponent<TMP_InputField>();
        
            animalSpeechText = canvas.transform.Find("AnimalSpeech").GetComponent<TMP_Text>();
        }

        private void SetUpButtons()
        {
            playSoundButton.onClick.AddListener(PlaySoundEffect);
            walkButton.onClick.AddListener(Walk);
            jumpButton.onClick.AddListener(Jump);
            talkButton.onClick.AddListener(TalkFromUserInput);
        }

        // Functions of the animal
        protected virtual void PlaySoundEffect()
        {
            audioSource = GameObject.Find("PersistentObject").GetComponent<AudioSource>();
            audioSource.PlayOneShot(soundEffect, 0.5f);
        }

        private void TalkFromUserInput()
        {
            Talk(talkField.text, 1);
        }
    
        private void Walk()
        {
            // Start coroutine WalkingAnimation()
            StartCoroutine(WalkingAnimation());
        }

        private void Jump()
        {
            Talk("JUMP!", 1);
            // Make GameObject with Rigidbody jump
            GetComponent<Rigidbody>().AddForce(Vector3.up * 5, ForceMode.Impulse);
        }
    
        protected void Talk(string speech, float time)
        {
            StartCoroutine(TalkingAnimation(speech, time));
        }
    
        // Coroutines
        private IEnumerator TalkingAnimation(string speech, float time)
        {
            if (!talkingAnimationRunning)
            {
                talkingAnimationRunning = true;
                animalSpeechText.text = speech;
                yield return new WaitForSeconds(time);
                animalSpeechText.text = "";
                talkingAnimationRunning = false;
            }
        }
    
        private IEnumerator WalkingAnimation()
        {
            if (!walkingAnimationRunning)
            {
                walkingAnimationRunning = true;
                // set speed of animator
                GetComponent<Animator>().SetFloat("Speed_f", 0.5f);
                Talk("I'm now walking!", 1);
                yield return new WaitForSeconds(2);
                GetComponent<Animator>().SetFloat("Speed_f", 0);
                walkingAnimationRunning = false;
            }
        }
    }
}
