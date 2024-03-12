using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class PlayerControlador : MonoBehaviour
{

    private Rigidbody _rigidbody;

    [SerializeField, Range(0, 25), Tooltip("Fuerza de salto")]
    private float jumpForce =7;


    private bool isGround;

    [SerializeField] private float gravityMultiplier = 1;



    private Animator _animator;
    
    private const string SPEED_F = "Speed_f";
    private const string JUMP_TRIG = "Jump_trig";
    private const string SPEED_MULTIPLIER  = "SpeedMultiplier";
    private const string DEATH_B = "Death_b";
    private const string DEATH_TYPE_INT = "DeathType_int";


    public float speedMultiplier = 0.5f;


    private bool gameOver;

    public bool GameOver
    {
        get => gameOver;
    }

    private bool death;
    private int deathType;


    public AudioClip jumpSound, crashSound;
    private AudioSource _audioSource;
    [SerializeField, Range(0,1)] public float SFXVolume;


    public ParticleSystem explosion;
    public ParticleSystem dirt;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();

        Physics.gravity = gravityMultiplier * new Vector3(0, -9.81f, 0);

        _animator = GetComponent<Animator>();
        
        _animator.SetFloat(SPEED_F, 1);
        _animator.SetFloat(SPEED_MULTIPLIER, speedMultiplier);
        _audioSource = GetComponent<AudioSource>();

        

    }

    // Update is called once per frame
    void Update()
    {
        Jump();
    }


    private void Jump()
    {
        speedMultiplier += Time.deltaTime / 10;
       
        _animator.SetFloat(SPEED_MULTIPLIER, speedMultiplier );
        if (speedMultiplier >= 2)
        {
            speedMultiplier = 2;
        }
        
        if (Input.GetKeyDown(KeyCode.Space) && isGround && !gameOver) 
        {
            _rigidbody.AddForce(Vector3.up * jumpForce , ForceMode.Impulse);

            isGround = false;
            
            _animator.SetTrigger(JUMP_TRIG);
            
            _audioSource.PlayOneShot(jumpSound, SFXVolume);
            dirt.Stop();
        }
        
        
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground") && ! gameOver)
        {
            
            isGround = true;
            dirt.Play();
            
        }else if (other.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;

            deathType = Random.Range(1, 3);
            _animator.SetBool(DEATH_B, death = true);
            _animator.SetInteger(DEATH_TYPE_INT, deathType);
            
            _audioSource.PlayOneShot(crashSound, SFXVolume);
            explosion.Play();
            dirt.Stop();
            Physics.gravity = Vector3.down * 10;
            
            Invoke("RestartGame", 1.2f);
        }
        
            
        
    }

    private void RestartGame()
    {
        SceneManager.LoadSceneAsync("Prototype 3");
    }
}


