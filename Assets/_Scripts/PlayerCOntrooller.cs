using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class PlayerCOntrooller : MonoBehaviour
{

    private Animator _animator;

    private const string SPEED_F = "Speed_f";
    private const string SPEEDMULTIPLIER = "SpeedMultiplier";
    private const string JUMP_TRIG = "Jump_trig";
    private const string DEATH_B = "Death_b";
    private const string DEATHTYPE_INT = "DeathType_int";
    
    
    [SerializeField, Range(0, 20), Tooltip("velocidad de movimiento")]
    private float speed_F = 1;

    [SerializeField, Range(0, 20), Tooltip("multiplicador de velocidad")]
    private float speedMultiplier = 0.6f;

    [SerializeField, Range(0, 20), Tooltip("Fuerza de salto")]
    private float forceJump = 8;

    private Rigidbody _rigidbody;

    [SerializeField, Range(-17, 17), Tooltip("multiplicador de gravedad")]
    private float gravityMultiplier = 1.5f;

    private bool isGround;
    
    
    
    public ParticleSystem dirt;
    public ParticleSystem explotion;


    public AudioClip jumpSound;
    private AudioSource _audioSource;

    private bool death_b;
    private int deathType_int;
    private bool gameOver;

    public bool GameOver
    {
        get => gameOver;
    }

    public AudioClip crashSound;
    
    [SerializeField] private float soundVolume = 0.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.SetFloat(SPEED_F, speed_F);
        _animator.SetFloat(SPEEDMULTIPLIER, speedMultiplier );

        _rigidbody = GetComponent<Rigidbody>();
        Physics.gravity = new Vector3(0, -9.81F, 0) * gravityMultiplier;

        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        JumpPlayer();
    }

    private void JumpPlayer()
    {
        speedMultiplier = 1 + Time.deltaTime / 20;
        if (speedMultiplier >= 2.2f)
        {
            speedMultiplier = 2.2f;
        }
        _animator.SetFloat(SPEEDMULTIPLIER, speedMultiplier);
        
        if (Input.GetKeyDown(KeyCode.Space) && isGround )
        {
            _rigidbody.AddForce(Vector3.up * forceJump , ForceMode.Impulse);
            dirt.Stop();
            isGround = false;
            
            _animator.SetTrigger(JUMP_TRIG);
            
            _audioSource.PlayOneShot(jumpSound);
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

            deathType_int = Random.Range(1, 3);
            _animator.SetBool(DEATH_B, death_b = true);
            _animator.SetInteger(DEATHTYPE_INT, deathType_int);
            
            _audioSource.PlayOneShot(crashSound, soundVolume);
            Physics.gravity = Vector3.down * 10;
            dirt.Stop();
            explotion.Play();
            
            Invoke("RestarGame", 1 );

        }
    }


    private void RestarGame()
    {
        SceneManager.LoadSceneAsync("Prototype 3");
    }
}
