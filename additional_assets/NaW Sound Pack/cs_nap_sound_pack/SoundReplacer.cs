////////////////////////////////////////////////////////////////
//Audio Replacement Program By Davwado
//Big thanks to Wrexial for helping me figure this out
////////////////////////////////////////////////////////////////

using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundReplacer : MonoBehaviour
{
    [Serializable]
    private class CoreInfo
    {
        public enum varCoreclip { MusketFire, MusketReload, PistolFire, PistolReload, CannonFire, CannonReload, SwivelFire, BarrelExplosion, MeleeBlockNormal, MeleeBlockHeavy, SwordSwing, AxeSwing, MusketSwing, DamageBlade, DamageFist, DamageAxe, Pain, MeleeGrunt, MetalHit, DirtHit, WoodHit, StoneHit }
        public varCoreclip Sound;
        public AudioClip NewCoreClip;
    }
    [Header("Audio Replacer")]
    [TextArea]
    public string Explanation = "This is a sound replacement script by Davwado, any questions feel free to ask. Simply select the sound to change and drag in a new one.";
    [Space(10)]
    [Header("Change Core Sounds")]
    [SerializeField] 
    private CoreInfo[] CoreInfoArray;


    [Serializable]
    private class VoicelinesInfo
    {
        public enum varFaction { British, French, Prussian, Russian, Italian }
        public varFaction Faction;
        public enum varVoiceline { Cheer, Compliment, ChallengeToDuel, TakeCover, GoodShot, Help, Insult, Surgeon, ProclaimMutiny, No, PatrioticCheer, Retreat, Salute, StandGround, StayCalm, Surrender, Taunt, Thanks, WarCry, Yes, MakeReady, FireAtWill, CeaseFire, Charge, Fire }
        public varVoiceline Voiceline;
        public AudioClip NewVoiceClip;
    }
    [Header("Change Voicelines")]
    [SerializeField] 
    private VoicelinesInfo[] voicelinesInfoArray;




    [Serializable]
    public class AdvancedInfo
    {
        public string OriginalAudioName;
        public AudioClip NewAudioClip;
    }
    [Header("Advanced Options")]
    [SerializeField] 
    public AdvancedInfo[] advancedInfoArray;

    [Serializable]
    public class AdvancedVoices
    {
        public enum varFaction { British, French, Prussian, Russian, Italian }
        public varFaction Faction;
        public string OriginalAudioName;
        public AudioClip NewAudioClip;
    }
    [Header("Advanced Voices")]
    [SerializeField]
    public AdvancedVoices[] advancedVoicesArray;

    //Arrays 
    private List<AudioClip> sourceAudioClips = new List<AudioClip>();
    private List<AudioSource> sourceAudioSource = new List<AudioSource>();

    //To play on awake
    void Awake()
    {
        

        //Creates variable set to all of the audio sources
        var audioSources = FindObjectsOfType<AudioSource>();

        //Set int as 0 then for all audio sources it runs the loop
        for (int i = 0; i < audioSources.Length; i++)
        {
            //Creates variable for the audiosource in the current iteration of the loop
            var audioSource = audioSources[i];
            
            //Something Wrex added to fix something 
            if (audioSource.clip == null)
            {
                continue;
            }

            //Creates variable for the name of the audio clip
            var sourceName = audioSource.clip.name;

            //Creates variabled for the parent name of the audio clip
            var parentName = audioSource.transform.parent.name;
            
            
            //Array of Holdfast audio names
            string[] audioNames = new string[] { "flintlock_", "musket_reload_14seconds", "pistol_", "musket_reload_6seconds", "cannon_fire_", "ram_shot_", "swivel_fire", "0022_explosion", "blade_hit_blade_normalhit", "blade_hit_blade_heavyhit", "sword_swing", "axe_swing", "musket_swing", "blade_hit_flesh", "blunt_hit_flesh", "axe_hit_flesh", "pain_", "grunt_", "blade_hit_metal", "blade_hit_earth", "blade_hit_wood", "axe_hit_wood", "blade_hit_stone", "axe_hit_stone" };
            
            //loop for core sounds
            for (int y = 0; y < CoreInfoArray.Length; y++)
            {
                //Pulls variable from dropdown menu
                int intSelectedCore = (int) CoreInfoArray[y].Sound;
                                

                //Loop to run through enum
                for (int k = 0; k <= 19; k++)
                {
                    //If statement for what is selected in the dropdown menu
                    if (intSelectedCore == k)
                    {
                        //Checks if the audio name contains the text for the dropdown (change this for what audio clip is changed)
                        if (sourceName.Contains(audioNames[k]))
                        {
                            sourceAudioClips.Add(audioSources[i].clip);
                            sourceAudioSource.Add(audioSources[i]);

                            //sets new audio clip
                            audioSources[i].clip = CoreInfoArray[y].NewCoreClip;

                           
                        }
                    }
                }

                //Special if states because they require multiple changes to be made
                //If statement for what is selected in the dropdown menu
                if (intSelectedCore == 20)
                {
                    //Checks if the audio name contains the text for the dropdown (change this for what audio clip is changed)
                    if (sourceName.Contains(audioNames[20]))
                    {
                        sourceAudioClips.Add(audioSources[i].clip);
                        sourceAudioSource.Add(audioSources[i]);
                        //sets new audio clip
                        audioSources[i].clip = CoreInfoArray[y].NewCoreClip;
                        
                    }
                    //Checks if the audio name contains the text for the dropdown (change this for what audio clip is changed)
                    if (sourceName.Contains(audioNames[21]))
                    {
                        sourceAudioClips.Add(audioSources[i].clip);
                        sourceAudioSource.Add(audioSources[i]);
                        //sets new audio clip
                        audioSources[i].clip = CoreInfoArray[y].NewCoreClip;
                        
                    }
                }
                //If statement for what is selected in the dropdown menu
                else if (intSelectedCore == 21)
                {
                    //Checks if the audio name contains the text for the dropdown (change this for what audio clip is changed)
                    if (sourceName.Contains(audioNames[22]))
                    {
                        sourceAudioClips.Add(audioSources[i].clip);
                        sourceAudioSource.Add(audioSources[i]);
                        //sets new audio clip
                        audioSources[i].clip = CoreInfoArray[y].NewCoreClip;
                        
                    }
                    //Checks if the audio name contains the text for the dropdown (change this for what audio clip is changed)
                    if (sourceName.Contains(audioNames[23]))
                    {
                        sourceAudioClips.Add(audioSources[i].clip);
                        sourceAudioSource.Add(audioSources[i]);
                        //sets new audio clip
                        audioSources[i].clip = CoreInfoArray[y].NewCoreClip;
                        
                    }
                }              
            }


            //Section for changing cheers
            //Array of Holdfast faction names
            string[] factionNames = new string[] { "British", "French", "Prussian", "Russian", "Italian" };
            //Array of voiceline names
            string[] voicelineNames = new string[] { "cheer_", "compliment_", "duel_", "get_down_", "good_shot_", "help_", "insult_", "medic_", "mutiny_", "no_sir_", "cheer_", "retreat_", "salute_", "stand_ground_", "stay_calm_", "surrender_", "taunt_", "thanks_", "warcry_", "yes_sir_", "make_ready_", "fire_at_will_", "cease_fire_", "charge_", "fire_" };


            //loop for voice sounds
            for (int o = 0; o < voicelinesInfoArray.Length; o++)
            {
                //Pulls variable from dropdown menu
                int intSelectedFaction = (int) voicelinesInfoArray[o].Faction;

                int intSelectedVoiceline = (int) voicelinesInfoArray[o].Voiceline;

               
                //loop for faction selection
                for (int f = 0; f <= 4; f++)
                {
                    //checks selected faction name
                    if (intSelectedFaction == f)
                    {
                        //variable for faction name
                        var selectedFaction = factionNames[f];
                                              
                        //Loop to run through enum 
                        for (int p = 0; p <= 22; p++)
                        {
                            //If statement for what is selected in the dropdown menu
                            if (intSelectedVoiceline == p)
                            {
                                //Checks if the audio name contains the text for the dropdown (change this for what audio clip is changed)
                                if (sourceName.Contains(voicelineNames[p]))
                                {
                                                                       
                                    //checks parent text for faction name
                                    if (parentName.Contains(selectedFaction))
                                    {
                                        Debug.LogError("parent found " + parentName);
                                        //sets new audio clip
                                        audioSources[i].clip = voicelinesInfoArray[o].NewVoiceClip;
                                        Debug.LogError("Sound CHANGE WORKED!!!");
                                    }
                                }
                            }                         
                        }

                        //Special cases
                        //If statement for what is selected in the dropdown menu
                        if (intSelectedVoiceline == 23)
                        {
                            //Checks if the audio name contains the text for the dropdown (change this for what audio clip is changed)
                            if (sourceName.Contains(voicelineNames[23]))
                            {
                                //checks if it contains horse
                                if (sourceName.Contains("horse"))
                                    {
                                    //left blank because I can't be bothered setting this up better
                                }
                                else //if it doesn't contain horse
                                {
                                    if (parentName.Contains(selectedFaction))
                                    {
                                        //checks parent text for faction name
                                        //sets new audio clip
                                        audioSources[i].clip = voicelinesInfoArray[o].NewVoiceClip;
                                    }
                                }
                                
                            }
                        }
                        else if (intSelectedVoiceline == 24)
                        {
                            //Checks if the audio name contains the text for the dropdown (change this for what audio clip is changed)
                            if (sourceName.Contains(voicelineNames[24]))
                            {
                                //checks if it contains possible conflictions with other audio clips
                                if ((sourceName.Contains(voicelineNames[21])) || (sourceName.Contains(voicelineNames[22])))
                                    {
                                    //left blank because I can't be bothered setting this up better
                                }
                                else //if it doesn't contain horse
                                {
                                    if (parentName.Contains(selectedFaction))
                                    {
                                        //checks parent text for faction name
                                        //sets new audio clip
                                        audioSources[i].clip = voicelinesInfoArray[o].NewVoiceClip;
                                    }
                                }
                            }
                        }
                    }
                }          
            }

  
            //Loop for checking any advanced entries
            for (int x = 0; x < advancedInfoArray.Length; x++)
            {
                var originalAudioName = advancedInfoArray[x].OriginalAudioName;
                if (sourceName == originalAudioName)
                {
                    sourceAudioClips.Add(audioSources[i].clip);
                    sourceAudioSource.Add(audioSources[i]);

                    audioSources[i].clip = advancedInfoArray[x].NewAudioClip;
                                    
                    Debug.LogWarning("We changed this! " + audioSource);
                }
            }



            //Loop for checking any advanced voices entries
            for (int g = 0; g < advancedVoicesArray.Length; g++)
            {
                //Pulls variable from dropdown menu
                int intSelectedFaction = (int)advancedVoicesArray[g].Faction;

                //loop for faction selection
                for (int f = 0; f <= 4; f++)
                {
                    //checks selected faction name
                    if (intSelectedFaction == f)
                    {
                        //variable for faction name
                        var selectedFactionVoice = factionNames[f];

                        var originalAudioName = advancedVoicesArray[g].OriginalAudioName;

                        if (sourceName == originalAudioName)
                        {
                            //checks parent text for faction name
                            if (parentName.Contains(selectedFactionVoice))
                            {
                                sourceAudioClips.Add(audioSources[i].clip);
                                sourceAudioSource.Add(audioSources[i]);

                                audioSources[i].clip = advancedVoicesArray[g].NewAudioClip;

                                Debug.LogWarning("We changed this! " + audioSource);
                            }

                        }
                    }
                }
                              
            }
        }
    }

    //Runs on destroy to set things back to where they were
    void OnDestroy()
    {
        Debug.LogError("On Destory");
    
        for (int d = 0; d < sourceAudioClips.Count; d++)
        {
            sourceAudioSource[d].clip = sourceAudioClips[d];
            Debug.LogError("Sound swapped" + sourceAudioSource[d].clip);
        }
    }

}