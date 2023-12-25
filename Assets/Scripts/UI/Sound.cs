using UnityEngine;
using UnityEngine.UI;

public class Sound : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(Play);

    }

    public void Play()
    {
        SoundManager.Instance.Play();

    }


}
