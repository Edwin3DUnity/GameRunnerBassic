using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour
{

    [SerializeField, Range(0, 20), Tooltip("Fuerza de salto")]
    private float jumpForce = 7;

    private Rigidbody _rigidbody;

    private bool isGround;


    [SerializeField, Range(-17, 17), Tooltip("Multiplicador de gravedad")]
    private float gravityMultiplier = 1.5f;


    private Animator _animator;

    private const string SPEED_F = "Speed_f";
    private const string JUMP_TRIG = "Jump_trig";
    private const string DEATH_B = "Death_b";
    private const string DEATH_TYPE = "DeathType_int";
    private const string SPEED_MULTIPLIER = "SpeedMultiplier";

    private float speedF = 1;

    [SerializeField] private float speedMultiplier = 0.6f;

    private bool isDeath;
    private int deathTYpe;

    private bool gameOver;

    public bool GameOver
    {
        get => gameOver;
    }

    private AudioSource _audioSource;
    public AudioClip jumpSound;
    public AudioClip crashSound;

    [SerializeField, Range(0, 1), Tooltip("Volumen de efectos de sonido")]
    private float soundVolume = 0.5f;

    public ParticleSystem explotion;
    public ParticleSystem dirt;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();

       // Physics.gravity = new Vector3(0, -9.81f, 0) * gravityMultiplier;
        _animator = GetComponent<Animator>();
        _animator.SetFloat(SPEED_F, speedF);
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
        speedMultiplier = 1 + Time.deltaTime / 20;

        if (speedMultiplier >= 2.2f)
        {
            speedMultiplier = 2.2f;
        }
        
        _animator.SetFloat(SPEED_MULTIPLIER, speedMultiplier);

        if (Input.GetKeyDown(KeyCode.Space) && isGround && !gameOver )
        {
            _rigidbody.AddForce(Vector3.up * jumpForce , ForceMode.Impulse);

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


            deathTYpe = Random.Range(1, 3);
            _animator.SetBool(DEATH_B, isDeath = true);
            _animator.SetInteger(DEATH_TYPE, deathTYpe);
            
            _audioSource.PlayOneShot(crashSound, soundVolume);
            Physics.gravity = Vector3.down * 10;
            dirt.Stop();
            explotion.Play();
            Invoke("RestarGame", 1.0f);
        }
    }


    private void RestarGame()
    {
        SceneManager.LoadSceneAsync("Prototype 3");
    }
}
