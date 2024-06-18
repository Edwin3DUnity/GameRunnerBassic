using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;


public class PlayerControllerr : MonoBehaviour
{
    private const string SPEED_F =  "Speed_f";
    private const string SPEEDMULTIPLIER = "SpeedMultiplier";
    private const string JUMP_TRIG = "Jump_trig";
    private const string DEATH_B = "Death_b";
    private const string DEATHtYPE = "DeathType_int";

    private bool death_b;
    private int DeathTypeInt;
    

    private float speed_F = 1;
    private float speedMultipler = 0.5f;

    private Animator _animator;
    private Rigidbody _rigidbody;

    [SerializeField, Range(0, 20), Tooltip("Fuerza de salto")]
    private float forceJump = 8;

    private bool isGround;


    public ParticleSystem dirt;
    public ParticleSystem explosion;


    private AudioSource _audioSource;
   [SerializeField] private AudioClip jumpSound;
 [SerializeField]   private AudioClip crashSound;

    [SerializeField, Range(0, 1), Tooltip("sonido ")]
    private float volumenSonido = 0.6f;


    private bool gameOver;

    public bool GameOver
    {
        get => gameOver;
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.SetFloat(SPEED_F, speed_F);
        _animator.SetFloat(SPEEDMULTIPLIER, speedMultipler);

        _rigidbody = GetComponent<Rigidbody>();

        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        JumpPlayer();
    }

    private void JumpPlayer()
    {
        speedMultipler = 1 + Time.deltaTime / 20;

        if (speedMultipler >= 2.2f)
        {
            speedMultipler = 2.2f;
        }
        _animator.SetFloat(SPEEDMULTIPLIER, speedMultipler);

        if (Input.GetKeyDown(KeyCode.Space) && isGround && !gameOver )
        {
            _rigidbody.AddForce(Vector3.up * forceJump, ForceMode.Impulse);
            _animator.SetTrigger(JUMP_TRIG);
            isGround = false;
            
            dirt.Stop();
            
            _audioSource.PlayOneShot(jumpSound,volumenSonido);
        }
        
        


    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGround = true;
            dirt.Play();
        }else if (other.gameObject.CompareTag("Obstacle"))
        {
            
            explosion.Play();
            dirt.Stop();
            Physics.gravity = Vector3.down * 10; 
            _audioSource.PlayOneShot(crashSound);
            Invoke("RestarGame", 1.5f);
            _animator.SetBool(DEATH_B, death_b = true);
            DeathTypeInt = Random.Range(1, 3);
            _animator.SetInteger(DEATHtYPE, DeathTypeInt);
            
            gameOver = true;
        }
    }


    private void RestarGame()
    {
        SceneManager.LoadSceneAsync("Prototype 3");
    }
}

