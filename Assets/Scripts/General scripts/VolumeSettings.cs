using UnityEngine;
using FMODUnity;
using UnityEngine.Rendering;
public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private string vcaPathMaster = "vca:/Master";
    [SerializeField]private string vcaPathMusic="";
    [SerializeField]private string vcaPathSFX="";
    private FMOD.Studio.VCA vca;
    private FMOD.Studio.VCA vca2;
    private FMOD.Studio.VCA vca3;
    [SerializeField]private float masterVolume=1;
    [SerializeField] private float musicVolume=1;
    [SerializeField]private float sfxVolume=1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
         vca = RuntimeManager.GetVCA(vcaPathMaster);
         vca2=RuntimeManager.GetVCA(vcaPathMusic);
         vca3=RuntimeManager.GetVCA(vcaPathSFX);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MuteMaster()
    {
       if(masterVolume==0)
        {
            vca.setVolume(1);
            masterVolume=1; 
        }
        else
        {
            vca.setVolume(0);
            masterVolume=0;
        }

    }
    public void MuteMusic()
    {
        if(musicVolume==0)
        {
            vca2.setVolume(1);
            musicVolume=1; 
        }
        else
        {
            vca2.setVolume(0);
            musicVolume=0;
        }
    } 
    public void MuteSFX()
    {
        if(sfxVolume==0)
        {
            vca3.setVolume(1);
            sfxVolume=1; 
        }
        else
        {
            vca3.setVolume(0);
            sfxVolume=0;
        }
    }       
}
