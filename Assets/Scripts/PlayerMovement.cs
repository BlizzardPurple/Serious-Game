// This script is used for player movement using keyboard

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    [SerializeField] public LayerMask solidObjectsLayer;
    [SerializeField] public LayerMask interactableLayer;
    [SerializeField] float speedFactor = 7f;
    [SerializeField] bool onMarket = false;
    [SerializeField] public AudioClip Theme;
    [SerializeField] public AudioClip Horn;

    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        animator=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetAxisRaw("Horizontal")>0.1f && !onMarket) {
            animator.SetBool("IsMoving",true);
            animator.SetFloat("MoveX", 1f);
            animator.SetFloat("MoveY", 0f);
            
            Vector2 targetPos =  transform.position+ transform.right * (Time.deltaTime * speedFactor);

            // for checking any obstacle
            if (Physics2D.OverlapCircle(targetPos, 0.1f, solidObjectsLayer) == null && Physics2D.OverlapCircle(targetPos, 0.1f, interactableLayer) == null)
                transform.position = targetPos;
        }
        else if(Input.GetAxisRaw("Horizontal")<-0.1f && !onMarket) {
            animator.SetBool("IsMoving",true);
            animator.SetFloat("MoveX", -1f);
            animator.SetFloat("MoveY", 0f);
            Vector2 targetPos =  transform.position - transform.right * (Time.deltaTime * speedFactor);

            // for checking any obstacle
            if (Physics2D.OverlapCircle(targetPos, 0.1f, solidObjectsLayer) == null && Physics2D.OverlapCircle(targetPos, 0.1f, interactableLayer) == null)
                transform.position = targetPos;
        }
        else if(Input.GetAxisRaw("Vertical")>0.1f && !onMarket) {
            animator.SetBool("IsMoving",true);
            animator.SetFloat("MoveX", 0f);
            animator.SetFloat("MoveY", 1f);
            Vector2 targetPos =  transform.position+ transform.up * (Time.deltaTime * speedFactor);

            // for checking any obstacle
            if (Physics2D.OverlapCircle(targetPos, 0.1f, solidObjectsLayer) == null && Physics2D.OverlapCircle(targetPos, 0.1f, interactableLayer) == null)
                transform.position = targetPos;
        }
        else if(Input.GetAxisRaw("Vertical")<-0.1f && !onMarket) {
            animator.SetBool("IsMoving",true);
            animator.SetFloat("MoveX", 0f);
            animator.SetFloat("MoveY", -1f);
            Vector2 targetPos =  transform.position - transform.up * (Time.deltaTime * speedFactor);

            // for checking any obstacle
            if (Physics2D.OverlapCircle(targetPos, 0.1f, solidObjectsLayer) == null && Physics2D.OverlapCircle(targetPos, 0.1f, interactableLayer) == null)
                transform.position = targetPos;
        }
        else
        {
            animator.SetBool("IsMoving",false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
            if (other.CompareTag("Checkpoint")){
            // Add logic to save the player's progress or perform other actions
                UIManager.Instance.ShowPhonePanel();
                speedFactor = 0f;
                Debug.Log("Player reached the checkpoint!");
                AudioSource audioSource = GetComponent<AudioSource>();
                ChangeMusic(audioSource, Theme, Horn);
            }
    }

    void ChangeMusic(AudioSource audioSource, AudioClip oldClip, AudioClip newClip)
    {
        audioSource.Stop();
        audioSource.clip = newClip;
        audioSource.Play();
    }

}
