using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] playlist;
    public AudioSource audioSource;
    private int musicIndex = 0;

    public static AudioManager Instance;

    public AudioMixerGroup soundEffectMixer;

    /* La fonction Awake est lue avant tout le monde, avant même la fonction start */
    /* on va pouvoir accéder à l'inventory depuis n'importe où */

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de AudioManager dans la scène");
            return;
        }

        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = playlist[0];
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(!audioSource.isPlaying)
        {
            PlayNextSong();
        }
    }

    void PlayNextSong()
    {
        musicIndex = (musicIndex + 1) % playlist.Length;
        audioSource.clip = playlist[musicIndex];
        audioSource.Play();
    }

    /* bidouille de la fonction unity PlayClipAtPoint() */

    public AudioSource PlayClipAt(AudioClip clip, Vector3 pos)
    {
        // creation d'un gameobject vide 
        GameObject tempGO = new GameObject("TempAudio");
        tempGO.transform.position = pos;

        // creation d'une audiosource
        AudioSource audioSource = tempGO.AddComponent<AudioSource>();

        // son à jouer
        audioSource.clip = clip;

        // piste son à utiliser
        audioSource.outputAudioMixerGroup = soundEffectMixer;

        // on joue le son
        audioSource.Play();

        // on supprime l'objet
        Destroy(tempGO, clip.length);

        return audioSource;
    }

}
