
using UnityEngine;
using UnityEngine.UI;

public class Sound : MonoBehaviour
{
    [SerializeField]
    AudioSource music;

    [SerializeField]
    AudioSource[] SoundFXGroup;

    private void Start()
    {
        music.volume = StatesGame.music;
        foreach (var item in SoundFXGroup)
            item.volume = StatesGame.sfx;
    }

    public void ChangeMusic(Slider Slidervalue)
    {
        StatesGame.music = Slidervalue.value;
        music.volume = StatesGame.music;
    }
    public void ChangeSFX(Slider Slidervalue)
    {
        StatesGame.sfx = Slidervalue.value;
        foreach (var item in SoundFXGroup)
            item.volume = StatesGame.sfx;
    }
}
