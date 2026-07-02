using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private float transitiontime;
    public static SceneLoader instance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        animator = GetComponent<Animator>();
    }
    public void LoadScene(string sceneName)
    {
        animator.SetTrigger("EndScene");
        SceneManager.LoadScene(sceneName);
    }
}