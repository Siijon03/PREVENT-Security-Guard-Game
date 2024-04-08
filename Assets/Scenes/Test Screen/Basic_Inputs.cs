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
    public int points_Score = -1;
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

    public static Basic_Inputs instance;

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

        scoreText.text = points_Score.ToString();
        // Check if score exceeds threshold and reset if necessary
        if (points_Score > 5)
        {
            ResetScore();
        }
    }

    private void Awake()
    {
        _mainCamera = Camera.main;

        if (instance == null)
        {
            Debug.Log("Object was not Destroyed");
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Debug.Log("Object was Destroyed...");
            Destroy(gameObject);
        }

        LoadScore();
    }

    //Do Stuff On CLick.
    public void OnClick(InputAction.CallbackContext Context)
    {
        //Return the Context of the Thing Clicked.
        if (!Context.started) return;

        //Use an Invisible Ray that Fires to the Screen.
        Ray ray = _mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
        //Establish a Variable based on the Ray Hitting an Object.
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray);

        //If the Ray hits a Collider then Return a Value based on the Tag.
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
                //Trigger Different Functions within the Script.
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

    //This is to Play a Certain Animation when a certain condition is met.
    void PlayAnimation()
    {
        Debug.Log("Playing Caught Animation");

        //Show the Objects when the Animation is Playing.
        //Since these need to be on screen, having it already there would ruin gameplay massively.
        PoliceActive.SetActive(true);
        DogCaughtActive.SetActive(true);

        //If the Reference and Animation Components are valid/not null.
        if (ref_animation != null && animator != null)
        {
            // Create a new animation clip with the provided animation clip.
            ref_animation.wrapMode = WrapMode.Once;

            // Play the animation clip.
            animator.Play(ref_animation.name);
            //Set a Boolean to True.
            isAnimating = true;
            //Start a Coroutine to allow for the next level to begin.
            StartCoroutine(loadNextLevelOnDelay());
        }
        else
        {
            Debug.LogError("Animation clip or animator not assigned!");
        }

    }

    //This is to Destroy any Object with a Certain Tag.
    void DestroyObjectsWithTag(string tagToDestroy)
    {
        Debug.Log("Destroying Object");
        GameObject[] destroyTag = GameObject.FindGameObjectsWithTag(tagToDestroy);

        foreach (GameObject obj in destroyTag)
        {
            Destroy(obj);
        }
    }

    //Using a Coroutine to Load the Next Level after a Delay.
    IEnumerator loadNextLevelOnDelay()
    {
        Debug.Log("Waiting to Load next Level...");

        yield return new WaitForSeconds(6);

        //Start a Function.
        LoadNextLevel();
    }

    void PlayCaughtAnimationAtDestroyedObjectPosition(GameObject destroyedObject)
    {
        // No need to create new GameObject or Animation component
        // Play animation directly on the existing Animation component
    }

    //Basic Function to Decrease Player Score.
    public void DecreaseScore()
    {
        scoreText.text = "Your Score: ";
        points_Score--;
        Debug.Log("Your Score: " + points_Score);
        SaveScore();
    }

    //Basic Function to Increment Player Score.
    public void IncrementScore()
    {
        scoreText.text = "Your Score: " + points_Score;
        points_Score++;
        Debug.Log("Your Score: " + points_Score);
        SaveScore();
    }

    //This is to save current Player Score and Set it in between Levels/Scenes.
    private void SaveScore()
    {

        PlayerPrefs.SetInt("Player Score", points_Score);
        PlayerPrefs.Save();
        Debug.Log("Set Score of: " + points_Score);
    }

    public void ResetScore()
    {
        points_Score = 1;
        GetPlayerScore();
    }

    //Retrieve the Player Score.
    public int GetPlayerScore()
    {
        SaveScore();
        return points_Score;
    }

    //This Loads the Points by getting the int. 
    public void LoadScore()
    {
        //0 is used in case a Player Prefs Integer Count is not found.
        points_Score = PlayerPrefs.GetInt("Player Score", 0);
        Debug.Log("Loaded Score of: " + points_Score + "(This is Done within the Load Score Function.)");
    }

    public void OnApplicationQuit()
    {
        
    }

    //This is to Carry Over the Score Accumlated by the Player and also to make the levels flow together by using Unity's Build Order.
    public void LoadNextLevel()
    {
        //Loading Next Level.
        //This can Let us Iterate the Next Scene in our Build Order.
        int nextSceneInBuild = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneInBuild < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneInBuild);
            LoadScore();
        }
    }
}
