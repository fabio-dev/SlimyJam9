using UnityEngine;

public class SoundEffectsPlayer : Singleton<SoundEffectsPlayer>
{
    [SerializeField] private AudioClip[] _spacecraftDamaged;

    public void PlaySpacecraftDamaged()
    {
        var randomSound = GetRandomSound(_spacecraftDamaged);
        AudioSource.PlayClipAtPoint(randomSound, Camera.main.transform.position);
    }

    private AudioClip GetRandomSound(AudioClip[] sounds)
    {
        var rng = Random.Range(0, sounds.Length);
        return sounds[rng];
    }
}