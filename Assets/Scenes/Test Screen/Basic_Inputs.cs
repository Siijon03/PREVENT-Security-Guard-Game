using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using TMPro;

public class Basic_Inputs : MonoBehaviour
{

    [SerializeField] private Camera _mainCamera;

    // Score System Establishment
    public int points_Score;
    public TextMeshPro scoreText;

    // Assigning Animation Values.
    public AnimationClip ref_animation;
    public Animator animator;

    // Creating Variables.
    private Transform trackedObjectTransform;
    private bool isAnimating = false;

    // Needed For 'ObjectTracking.' 
    public GameObject police_Ref;
    public Vector3 spawnedObjectOffset;
    public Transform trackObjectTransform;

    public GameObject PoliceActive;
    public GameObject DogCaughtActive;

    void Start()
    {
        PoliceActive.SetActive(false);
        DogCaughtActive.SetActive(false);
        scoreText.gameObject.SetActive(false);

        scoreText.text = "Your Score: ";

        if (police_Ref != null)
        {
            trackedObjectTransform = transform;
        }
        else
        {
            Debug.Log("No Object was Assigned");
        }
    }

    void LateUpdate()
    {
        Debug.Log("Playing Animation");
        if (isAnimating)
        {
            // Check if animation is finished.
            Animator animator = GetComponent<Animator>();
            if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
            {
                isAnimating = false;
            }
        }
        else if (trackedObjectTransform != null)
        {
            transform.position = trackedObjectTransform.position + spawnedObjectOffset;
            transform.rotation = trackedObjectTransform.rotation;
        }
    }

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("Starting Screen");
            Debug.Log("Loading");
        }

        scoreText.text = points_Score.ToString();
    }

    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    //Do Stuff On CLick.
    public void OnClick(InputAction.CallbackContext Context)
    {
        if (!Context.started) return;

        Ray ray = _mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray);

        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("Student"))
            {
                DecreaseScore();
                Debug.Log("Clicked Object Name: " + hit.collider.gameObject.name);
                Debug.Log("Clicked Object Tag: " + hit.collider.gameObject.tag);
            }

            if (hit.collider.CompareTag("Radicaliser"))
            {
                IncrementScore();
                Debug.Log("Clicked Object Name: " + hit.collider.gameObject.name);
                Debug.Log("Clicked Object Tag: " + hit.collider.gameObject.tag);

                Debug.Log("Playing Caught Animation");

                PlayCaughtAnimationAtDestroyedObjectPosition(hit.collider.gameObject);
                PlayAnimation();

                DestroyObjectsWithTag("Radicaliser");
            }

            if (hit.collider.CompareTag("Police"))
            {
                Debug.Log("Clicked Object Name: " + hit.collider.gameObject.name);
                Debug.Log("Clicked Object Tag: " + hit.collider.gameObject.tag);
            }
        }
    }

    void PlayAnimation()
    {
        Debug.Log("Playing Caught Animation");

        PoliceActive.SetActive(true);
        DogCaughtActive.SetActive(true);

        if (ref_animation != null && animator != null)
        {
            // Create a new animation clip with the provided animation clip.
            ref_animation.wrapMode = WrapMode.Once;

            // Play the animation clip.
            animator.Play(ref_animation.name);
            isAnimating = true;
        }
        else
        {
            Debug.LogError("Animation clip or animator not assigned!");
        }

    }

    void DestroyObjectsWithTag(string tagToDestroy)
    {
        Debug.Log("Destroying Object");
        GameObject[] destroyTag = GameObject.FindGameObjectsWithTag(tagToDestroy);

        foreach (GameObject obj in destroyTag)
        {
            Destroy(obj);
        }
    }

    void PlayCaughtAnimationAtDestroyedObjectPosition(GameObject destroyedObject)
    {
        // No need to create new GameObject or Animation component
        // Play animation directly on the existing Animation component
    }

    private void DecreaseScore()
    {
        scoreText.text = "Your Score: ";
        points_Score--;
        Debug.Log("Your Score: " + points_Score);
    }

    private void IncrementScore()
    {
        scoreText.text = "Your Score: ";
        points_Score++;
        Debug.Log("Your Score: " + points_Score);
    }
}
