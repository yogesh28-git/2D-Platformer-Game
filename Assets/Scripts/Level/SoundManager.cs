using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static SoundManager instance;
    public static SoundManager Instance { get { return instance; } }

    public SoundType[] soundTypes;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


}

public class SoundType
{
    public Sounds soundName;
    public AudioClip audioclip;
}

public enum Sounds
{
    buttonClick,
    playerJump,
    playerDeath,
    enemyDeath
}