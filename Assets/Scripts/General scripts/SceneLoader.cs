using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance;
    private Animator animator;
    [SerializeField]private float transitiontime;
    void Awake()
    {
        if(Instance!=null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        animator=GetComponent<Animator>();
    }
    public void LoadScene(string sceneName)
    {
      StartCoroutine(SceneCoroutine(sceneName));
    }
    public IEnumerator SceneCoroutine(string sceneName)
    {
        animator.SetTrigger("FadeOut");
        yield return new WaitForSeconds(transitiontime);
        yield return SceneManager.LoadSceneAsync(sceneName);
        animator.SetTrigger("FadeIn");
    }
}
