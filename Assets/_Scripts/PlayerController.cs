using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour
{

    [SerializeField, Range(0, 25), Tooltip("Fuerza de salto")]
    private float jumpForce = 8;


    private Rigidbody _rigidbody;


    [SerializeField, Tooltip("Está en el suelo ")]
    private bool isGround;

    private Animator _animator;


    private const string SPEED_F = "Speed_f";
    private const string SPEED_MULTIPLIER="SpeedMultiplier";
    private const string JUMP_TRIG = "Jump_trig";

    private const string DEATH = "Death_b";
    private bool isDeath ;
    
    private const string DEATH_TYPE = "DeathType_int" ;
    private int deathTypeInt;
    
    
    private bool gameOver;

    public bool GameOver
    {
        get => gameOver;
    }


    public ParticleSystem explosion;
    public ParticleSystem dirt;



    public AudioClip jumpSound, crashSound;

    private AudioSource _audioSource;

    [Range(0, 1)] public float audioVolume = 1;

    private float speedMultiplier = 1;

    public float gravityMultiplier ; 
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _animator.SetFloat(SPEED_F, 1);
        _animator.SetFloat(SPEED_MULTIPLIER, 0.6f);

        _audioSource = GetComponent<AudioSource>();

        Physics.gravity = gravityMultiplier * new Vector3(0, -9.81f, 0);

    }

    // Update is called once per frame
    void Update()
    {
      Jump();  
      
    }

    private void Jump()
    {
        speedMultiplier += Time.deltaTime /10;
        
        _animator.SetFloat(SPEED_MULTIPLIER, 1 + speedMultiplier / 10);
        
        if (Input.GetKeyDown(KeyCode.Space) && isGround && !gameOver)
        {
            
            
            _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            
           
            
            isGround = false;
            
            _animator.SetTrigger(JUMP_TRIG);
            dirt.Stop();
            
            _audioSource.PlayOneShot(jumpSound, audioVolume);
            
        }
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground") && !gameOver)
        {
            isGround = true;
            dirt.Play();
        }

        {
            if (other.gameObject.CompareTag("Obstacle"))
            {
                gameOver = true;
                dirt.Stop();
                _animator.SetFloat(SPEED_F, 0);
                
                
                explosion.Play();
                
                _animator.SetBool(DEATH, isDeath = true );
                deathTypeInt = Random.Range(1,3);
                _animator.SetInteger(DEATH_TYPE, deathTypeInt);
                
                _audioSource.PlayOneShot(crashSound,audioVolume);
                
                Invoke( "RestartGame", 1.8f);

                Physics.gravity = Vector3.down * 10;
            }
        }
    }


    void RestartGame()
    {
        speedMultiplier = 1;
        
        SceneManager.LoadSceneAsync("Prototype 3", LoadSceneMode.Single);
    }
}
