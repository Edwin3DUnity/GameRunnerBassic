using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody _rigidbody;
    private const string SPEED_F =  "Speed_f";
    private const string SPEEDMULTIPLIER =  "SpeedMultiplier";
    private const string JUMP_TRIG = "Jump_trig";
    private const string DEATH_B = "Death_b";
    private const string DEATH_TYPE = "DeathTYpe_int";

    private bool isDeath;
    private int deathType;

    private bool gameOver;

    public bool GameOver
    {
        get => gameOver;
    }

    [SerializeField, Range(0, 30), Tooltip("fuerza de salto")]
    private float forceJump = 4;

    private float speed_f = 1;

    [SerializeField, Range(0, 20), Tooltip("multiplicador de gravedad")]
    private float gravityMultiplier = 1.5f;

    [SerializeField] private float speedMultiplier = 0.6f;

    [SerializeField] private bool isGround;


    [SerializeField] private ParticleSystem dirt;
    [SerializeField] private ParticleSystem explotion;

    private AudioSource _audioSource;
    public AudioClip jumpSound;
    public AudioClip crashSound;

    [SerializeField, Range(0, 1), Tooltip("Volument de efectos de sonidos")]
    private float soundVolume = 0.5f;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
        Physics.gravity = new Vector3(0, -9.81f, 0) * gravityMultiplier;
        
        _animator.SetFloat(SPEED_F, speed_f);
        _animator.SetFloat(SPEEDMULTIPLIER, speedMultiplier );

        _audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        Jump();
    }


    private void Jump()
    {
        speedMultiplier = 1 + Time.deltaTime / 20;

        if (speedMultiplier >= 2.2f)
        {
            speedMultiplier = 2.2f;
        }
        
        _animator.SetFloat(SPEEDMULTIPLIER, speedMultiplier);

        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            _rigidbody.AddForce(Vector3.up * forceJump , ForceMode.Impulse);
            isGround = false;
            
            _animator.SetTrigger(JUMP_TRIG);
            
            _audioSource.PlayOneShot(jumpSound, soundVolume);
            dirt.Stop();
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
            gameOver = true;

            deathType = Random.Range(1, 3);
            _animator.SetBool(DEATH_B, isDeath = true);
            _animator.SetInteger(DEATH_TYPE, deathType);
            
            _audioSource.PlayOneShot(crashSound, soundVolume);
            Physics.gravity = Vector3.down * 10;
            dirt.Stop();
            explotion.Play();
            Invoke("RestartGame", 1.0f);

        }
    }

    private void RestartGame()
    {
        SceneManager.LoadSceneAsync("Prototype 3");
    }
}
