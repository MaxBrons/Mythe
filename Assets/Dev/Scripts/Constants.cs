using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Constants
{
    public const string _navMeshComponents = "NavMeshComponents";
    public const string _player = "Player";
    public const string _mainPlayer = "Main Player";
    public const string _managersTag = "Managers";
    public const string _caveSectionFunctionName = "Save";
    public const string _playerSpawnpoint = "PlayerSpawnpoint";
    public const string _postProcessingTag = "PostProcessing";
    public const string _doors = "Door";

    #region Save & Load System
    public const string _caveSaveLocation = "/GameSaveData";
    public const string _caveSeedName = "/mapseed";
    public const string _caveName = "/cave";
    public const string _saveLocationFileDataType = ".mythe";
    #endregion

    #region Cave Sections
    public const string _caveGenerator = "CaveGenerator";
    public const string _spawnpointTag = "Spawnpoint";
    public const string _spawnFunctionName = "Spawn";
    public const string _caveSectionTag = "CaveSections";
    public const string _intersectionCaveSection = "IntersectionCaveSection";
    public const string _objectiveRoom = "ObjectiveRoom";
    public const float _caveSpawnTime = .1f;
    #endregion

    #region Sound
    public const string _soundHeader = "Sounds";
    #endregion

    #region Animation State Names
    public const string _Move_Bool = "Move";
    public const string _Run_Bool = "Run";
    public const string _Attack_Bool = "Attack";
    #endregion

}
