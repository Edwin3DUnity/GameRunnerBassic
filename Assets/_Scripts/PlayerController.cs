using System;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;
using Vector3 = System.Numerics.Vector3;

public class PlayerController : MonoBehaviour
{

    [SerializeField, Range(0, 20), Tooltip("Fuerza de salto")]
    private float jumpForce = 7;

    private Rigidbody _rigidbody;

    private bool isGround;


   [SerializeField] private float gravityMultiplier = 1.5f;
    
    
    
    private Animator _animator;
    private const string SPEED_F = "Speed_f";
    private const string JUMP_TRIG = "Jump_trig";
    private const string DEATH_B = "Death_b";
    private const string DEATH_TYPE_INT = "DeathType_int";
    private const string SPEED_MULTIPLIER = "SpeedMultiplier";

    private int typeDeath;
    private bool deathB;
    

   [SerializeField] private float speedMultiplierFloat = 0.6f;


   private bool gameOver;

   public bool GameOver
   {
       get => gameOver;
   }




   private AudioSource _audioSource;
   public AudioClip jumpSound;
   public AudioClip crashSound;
   [SerializeField, Range(0, 1)] private float volumeFx = 0.5f;

   
   public ParticleSystem explosion;
   public ParticleSystem dirt;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        Physics.gravity = new UnityEngine.Vector3(0, -9.81f, 0 * gravityMultiplier);
        
        
        _animator = GetComponent<Animator>();
         
        _animator.SetFloat(SPEED_F, 1 );
        _animator.SetFloat(SPEED_MULTIPLIER , speedMultiplierFloat);

        _audioSource = GetComponent<AudioSource>();
   

    }

    // Update is called once per frame
    void Update()
    {
        Jump();
    }

    private void Jump()
    {
        speedMultiplierFloat = 1 + Time.time / 10;

        if (speedMultiplierFloat >= 2)
        {
            speedMultiplierFloat = 2;
        }
        
        _animator.SetFloat(SPEED_MULTIPLIER, speedMultiplierFloat);
        
        if (Input.GetKeyDown(KeyCode.Space) && isGround && !gameOver)
        {
            _rigidbody.AddForce(UnityEngine.Vector3.up * jumpForce , ForceMode.Impulse);
            isGround = false;
            _animator.SetTrigger(JUMP_TRIG);
            
            _audioSource.PlayOneShot(jumpSound, volumeFx);
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
            typeDeath = Random.Range(1, 3);
            _animator.SetBool(DEATH_B, deathB = true);
            _animator.SetInteger(DEATH_TYPE_INT, typeDeath);
            gameOver = true;
            _audioSource.PlayOneShot(crashSound);
            explosion.Play();
            dirt.Stop();
            Physics.gravity = UnityEngine.Vector3.down * 10;
            Invoke("RestarGame", 1.8f);
        }
    }

    private void RestarGame()
    {
        SceneManager.LoadSceneAsync("Prototype 3");
        

    }
    
}
