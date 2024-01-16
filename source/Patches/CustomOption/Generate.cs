using System;
using Gamemode = TownOfUs.GameMode;
using Types = TownOfUs.CustomOption.CustomOption.CustomOptionType;

namespace TownOfUs.CustomOption
{
    public class Generate
    {
        public static string[] presets = new string[]{"Preset 1", "Preset 2", "Preset 3"};

        public static CustomOption presetSelection;

        public static CustomOption CrewInvestigativeRoles;
        public static CustomOption AurialOn;
        public static CustomOption DetectiveOn;
        public static CustomOption HaunterOn;
        public static CustomOption InvestigatorOn;
        public static CustomOption MysticOn;
        public static CustomOption OracleOn;
        public static CustomOption SeerOn;
        public static CustomOption SnitchOn;
        public static CustomOption SpyOn;
        public static CustomOption TrackerOn;
        public static CustomOption TrapperOn;

        public static CustomOption CrewProtectiveRoles;
        public static CustomOption AltruistOn;
        public static CustomOption MedicOn;

        public static CustomOption CrewKillingRoles;
        public static CustomOption SheriffOn;
        public static CustomOption VampireHunterOn;
        public static CustomOption VeteranOn;
        public static CustomOption VigilanteOn;

        public static CustomOption CrewSupportRoles;
        public static CustomOption EngineerOn;
        public static CustomOption ImitatorOn;
        public static CustomOption MayorOn;
        public static CustomOption MediumOn;
        public static CustomOption ProsecutorOn;
        public static CustomOption SwapperOn;
        public static CustomOption TransporterOn;

        public static CustomOption NeutralBenignRoles;
        public static CustomOption AmnesiacOn;
        public static CustomOption GuardianAngelOn;
        public static CustomOption SurvivorOn;

        public static CustomOption NeutralEvilRoles;
        public static CustomOption DoomsayerOn;
        public static CustomOption ExecutionerOn;
        public static CustomOption JesterOn;
        public static CustomOption PhantomOn;

        public static CustomOption NeutralKillingRoles;
        public static CustomOption ArsonistOn;
        public static CustomOption PlaguebearerOn;
        public static CustomOption GlitchOn;
        public static CustomOption VampireOn;
        public static CustomOption WerewolfOn;

        public static CustomOption ImpostorConcealingRoles;
        public static CustomOption EscapistOn;
        public static CustomOption MorphlingOn;
        public static CustomOption SwooperOn;
        public static CustomOption GrenadierOn;
        public static CustomOption VenererOn;

        public static CustomOption ImpostorKillingRoles;
        public static CustomOption BomberOn;
        public static CustomOption TraitorOn;
        public static CustomOption WarlockOn;

        public static CustomOption ImpostorSupportRoles;
        public static CustomOption BlackmailerOn;
        public static CustomOption JanitorOn;
        public static CustomOption MinerOn;
        public static CustomOption UndertakerOn;

        public static CustomOption CrewmateModifiers;
        public static CustomOption AftermathOn;
        public static CustomOption BaitOn;
        public static CustomOption DiseasedOn;
        public static CustomOption FrostyOn;
        public static CustomOption MultitaskerOn;
        public static CustomOption TorchOn;

        public static CustomOption GlobalModifiers;
        public static CustomOption ButtonBarryOn;
        public static CustomOption FlashOn;
        public static CustomOption GiantOn;
        public static CustomOption LoversOn;
        public static CustomOption RadarOn;
        public static CustomOption SleuthOn;
        public static CustomOption TiebreakerOn;

        public static CustomOption ImpostorModifiers;
        public static CustomOption DisperserOn;
        public static CustomOption DoubleShotOn;
        public static CustomOption UnderdogOn;

        public static CustomOption MapSettings;
        public static CustomOption RandomMapEnabled;
        public static CustomOption RandomMapSkeld;
        public static CustomOption RandomMapMira;
        public static CustomOption RandomMapPolus;
        public static CustomOption RandomMapAirship;
        public static CustomOption RandomMapFungle;
        public static CustomOption RandomMapSubmerged;
        public static CustomOption AutoAdjustSettings;
        public static CustomOption SmallMapHalfVision;
        public static CustomOption SmallMapDecreasedCooldown;
        public static CustomOption LargeMapIncreasedCooldown;
        public static CustomOption SmallMapIncreasedShortTasks;
        public static CustomOption SmallMapIncreasedLongTasks;
        public static CustomOption LargeMapDecreasedShortTasks;
        public static CustomOption LargeMapDecreasedLongTasks;

        public static CustomOption CustomGameSettings;
        public static CustomOption ColourblindComms;
        public static CustomOption ImpostorSeeRoles;
        public static CustomOption DeadSeeRoles;
        public static CustomOption InitialCooldowns;
        public static CustomOption ParallelMedScans;
        public static CustomOption SkipButtonDisable;
        public static CustomOption HiddenRoles;
        public static CustomOption FirstDeathShield;
        public static CustomOption NeutralEvilWinEndsGame;
        public static CustomOption PhantomSpook;
        public static CustomOption JesterHaunt;
        public static CustomOption ExecutionerTorment;

        public static CustomOption BetterPolusSettings;
        public static CustomOption VentImprovements;
        public static CustomOption VitalsLab;
        public static CustomOption ColdTempDeathValley;
        public static CustomOption WifiChartCourseSwap;

        public static CustomOption GameModeSettings;
        public static CustomOption GameMode;

        public static CustomOption ClassicSettings;
        public static CustomOption MinNeutralBenignRoles;
        public static CustomOption MaxNeutralBenignRoles;
        public static CustomOption MinNeutralEvilRoles;
        public static CustomOption MaxNeutralEvilRoles;
        public static CustomOption MinNeutralKillingRoles;
        public static CustomOption MaxNeutralKillingRoles;

        public static CustomOption AllAnySettings;
        public static CustomOption RandomNumberImps;

        public static CustomOption KillingOnlySettings;
        public static CustomOption NeutralRoles;
        public static CustomOption VeteranCount;
        public static CustomOption VigilanteCount;
        public static CustomOption AddArsonist;
        public static CustomOption AddPlaguebearer;

        public static CustomOption CultistSettings;
        public static CustomOption MayorCultistOn;
        public static CustomOption SeerCultistOn;
        public static CustomOption SheriffCultistOn;
        public static CustomOption SurvivorCultistOn;
        public static CustomOption NumberOfSpecialRoles;
        public static CustomOption MaxChameleons;
        public static CustomOption MaxEngineers;
        public static CustomOption MaxInvestigators;
        public static CustomOption MaxMystics;
        public static CustomOption MaxSnitches;
        public static CustomOption MaxSpies;
        public static CustomOption MaxTransporters;
        public static CustomOption MaxVigilantes;
        public static CustomOption WhisperCooldown;
        public static CustomOption IncreasedCooldownPerWhisper;
        public static CustomOption WhisperRadius;
        public static CustomOption ConversionPercentage;
        public static CustomOption DecreasedPercentagePerConversion;
        public static CustomOption ReviveCooldown;
        public static CustomOption IncreasedCooldownPerRevive;
        public static CustomOption MaxReveals;

        public static CustomOption TaskTrackingSettings;
        public static CustomOption SeeTasksDuringRound;
        public static CustomOption SeeTasksDuringMeeting;
        public static CustomOption SeeTasksWhenDead;

        public static CustomOption Sheriff;
        public static CustomOption SheriffKillOther;
        public static CustomOption SheriffKillsDoomsayer;
        public static CustomOption SheriffKillsExecutioner;
        public static CustomOption SheriffKillsJester;
        public static CustomOption SheriffKillsArsonist;
        public static CustomOption SheriffKillsJuggernaut;
        public static CustomOption SheriffKillsPlaguebearer;
        public static CustomOption SheriffKillsGlitch;
        public static CustomOption SheriffKillsVampire;
        public static CustomOption SheriffKillsWerewolf;
        public static CustomOption SheriffKillCd;
        public static CustomOption SheriffBodyReport;

        public static CustomOption Engineer;
        public static CustomOption MaxFixes;

        public static CustomOption Investigator;
        public static CustomOption FootprintSize;
        public static CustomOption FootprintInterval;
        public static CustomOption FootprintDuration;
        public static CustomOption AnonymousFootPrint;
        public static CustomOption VentFootprintVisible;

        public static CustomOption Medic;
        public static CustomOption ShowShielded;
        public static CustomOption WhoGetsNotification;
        public static CustomOption ShieldBreaks;
        public static CustomOption MedicReportSwitch;
        public static CustomOption MedicReportNameDuration;
        public static CustomOption MedicReportColorDuration;

        public static CustomOption Seer;
        public static CustomOption SeerCooldown;
        public static CustomOption CrewKillingRed;
        public static CustomOption NeutBenignRed;
        public static CustomOption NeutEvilRed;
        public static CustomOption NeutKillingRed;
        public static CustomOption TraitorColourSwap;

        public static CustomOption Spy;
        public static CustomOption WhoSeesDead;

        public static CustomOption Swapper;
        public static CustomOption SwapperButton;

        public static CustomOption Transporter;
        public static CustomOption TransportCooldown;
        public static CustomOption TransportMaxUses;
        public static CustomOption TransporterVitals;

        public static CustomOption Jester;
        public static CustomOption JesterButton;
        public static CustomOption JesterVent;
        public static CustomOption JesterImpVision;

        public static CustomOption TheGlitch;
        public static CustomOption MimicCooldownOption;
        public static CustomOption MimicDurationOption;
        public static CustomOption HackCooldownOption;
        public static CustomOption HackDurationOption;
        public static CustomOption GlitchKillCooldownOption;
        public static CustomOption GlitchHackDistanceOption;
        public static CustomOption GlitchVent;

        public static CustomOption Juggernaut;
        public static CustomOption JuggKillCooldown;
        public static CustomOption ReducedKCdPerKill;
        public static CustomOption JuggVent;

        public static CustomOption Morphling;
        public static CustomOption MorphlingCooldown;
        public static CustomOption MorphlingDuration;
        public static CustomOption MorphlingVent;

        public static CustomOption Executioner;
        public static CustomOption OnTargetDead;
        public static CustomOption ExecutionerButton;

        public static CustomOption Phantom;
        public static CustomOption PhantomTasksRemaining;

        public static CustomOption Snitch;
        public static CustomOption SnitchSeesNeutrals;
        public static CustomOption SnitchTasksRemaining;
        public static CustomOption SnitchSeesImpInMeeting;
        public static CustomOption SnitchSeesTraitor;

        public static CustomOption Altruist;
        public static CustomOption ReviveDuration;
        public static CustomOption AltruistTargetBody;

        public static CustomOption Miner;
        public static CustomOption MineCooldown;

        public static CustomOption Swooper;
        public static CustomOption SwoopCooldown;
        public static CustomOption SwoopDuration;
        public static CustomOption SwooperVent;

        public static CustomOption Arsonist;
        public static CustomOption DouseCooldown;
        public static CustomOption MaxDoused;
        public static CustomOption ArsoImpVision;
        public static CustomOption IgniteCdRemoved;

        public static CustomOption Undertaker;
        public static CustomOption DragCooldown;
        public static CustomOption UndertakerDragSpeed;
        public static CustomOption UndertakerVent;
        public static CustomOption UndertakerVentWithBody;

        public static CustomOption Assassin;
        public static CustomOption NumberOfImpostorAssassins;
        public static CustomOption NumberOfNeutralAssassins;
        public static CustomOption AmneTurnImpAssassin;
        public static CustomOption AmneTurnNeutAssassin;
        public static CustomOption TraitorCanAssassin;
        public static CustomOption AssassinKills;
        public static CustomOption AssassinMultiKill;
        public static CustomOption AssassinCrewmateGuess;
        public static CustomOption AssassinGuessNeutralBenign;
        public static CustomOption AssassinGuessNeutralEvil;
        public static CustomOption AssassinGuessNeutralKilling;
        public static CustomOption AssassinGuessImpostors;
        public static CustomOption AssassinGuessModifiers;
        public static CustomOption AssassinGuessLovers;

        public static CustomOption Underdog;
        public static CustomOption UnderdogKillBonus;
        public static CustomOption UnderdogIncreasedKC;

        public static CustomOption Vigilante;
        public static CustomOption VigilanteKills;
        public static CustomOption VigilanteMultiKill;
        public static CustomOption VigilanteGuessNeutralBenign;
        public static CustomOption VigilanteGuessNeutralEvil;
        public static CustomOption VigilanteGuessNeutralKilling;
        public static CustomOption VigilanteGuessLovers;

        public static CustomOption Haunter;
        public static CustomOption HaunterTasksRemainingClicked;
        public static CustomOption HaunterTasksRemainingAlert;
        public static CustomOption HaunterRevealsNeutrals;
        public static CustomOption HaunterCanBeClickedBy;

        public static CustomOption Grenadier;
        public static CustomOption GrenadeCooldown;
        public static CustomOption GrenadeDuration;
        public static CustomOption GrenadierIndicators;
        public static CustomOption GrenadierVent;
        public static CustomOption FlashRadius;

        public static CustomOption Veteran;
        public static CustomOption KilledOnAlert;
        public static CustomOption AlertCooldown;
        public static CustomOption AlertDuration;
        public static CustomOption MaxAlerts;

        public static CustomOption Tracker;
        public static CustomOption UpdateInterval;
        public static CustomOption TrackCooldown;
        public static CustomOption ResetOnNewRound;
        public static CustomOption MaxTracks;

        public static CustomOption Trapper;
        public static CustomOption TrapCooldown;
        public static CustomOption TrapsRemoveOnNewRound;
        public static CustomOption MaxTraps;
        public static CustomOption MinAmountOfTimeInTrap;
        public static CustomOption TrapSize;
        public static CustomOption MinAmountOfPlayersInTrap;

        public static CustomOption Traitor;
        public static CustomOption LatestSpawn;
        public static CustomOption NeutralKillingStopsTraitor;

        public static CustomOption Amnesiac;
        public static CustomOption RememberArrows;
        public static CustomOption RememberArrowDelay;

        public static CustomOption Medium;
        public static CustomOption MediateCooldown;
        public static CustomOption ShowMediatePlayer;
        public static CustomOption ShowMediumToDead;
        public static CustomOption DeadRevealed;

        public static CustomOption Survivor;
        public static CustomOption VestCd;
        public static CustomOption VestDuration;
        public static CustomOption VestKCReset;
        public static CustomOption MaxVests;

        public static CustomOption GuardianAngel;
        public static CustomOption ProtectCd;
        public static CustomOption ProtectDuration;
        public static CustomOption ProtectKCReset;
        public static CustomOption MaxProtects;
        public static CustomOption ShowProtect;
        public static CustomOption GaOnTargetDeath;
        public static CustomOption GATargetKnows;
        public static CustomOption GAKnowsTargetRole;
        public static CustomOption EvilTargetPercent;

        public static CustomOption Mystic;
        public static CustomOption MysticArrowDuration;

        public static CustomOption Blackmailer;
        public static CustomOption BlackmailCooldown;

        public static CustomOption Plaguebearer;
        public static CustomOption InfectCooldown;
        public static CustomOption PestKillCooldown;
        public static CustomOption PestVent;

        public static CustomOption Werewolf;
        public static CustomOption RampageCooldown;
        public static CustomOption RampageDuration;
        public static CustomOption RampageKillCooldown;
        public static CustomOption WerewolfVent;

        public static CustomOption Detective;
        public static CustomOption ExamineCooldown;
        public static CustomOption DetectiveReportOn;
        public static CustomOption DetectiveRoleDuration;
        public static CustomOption DetectiveFactionDuration;
        public static CustomOption CanDetectLastKiller;

        public static CustomOption Escapist;
        public static CustomOption EscapeCooldown;
        public static CustomOption EscapistVent;

        public static CustomOption Bomber;
        public static CustomOption MaxKillsInDetonation;
        public static CustomOption DetonateDelay;
        public static CustomOption DetonateRadius;
        public static CustomOption BomberVent;

        public static CustomOption Doomsayer;
        public static CustomOption ObserveCooldown;
        public static CustomOption DoomsayerGuessNeutralBenign;
        public static CustomOption DoomsayerGuessNeutralEvil;
        public static CustomOption DoomsayerGuessNeutralKilling;
        public static CustomOption DoomsayerGuessImpostors;
        public static CustomOption DoomsayerGuessesToWin;

        public static CustomOption Vampire;
        public static CustomOption BiteCooldown;
        public static CustomOption VampImpVision;
        public static CustomOption VampVent;
        public static CustomOption NewVampCanAssassin;
        public static CustomOption MaxVampiresPerGame;
        public static CustomOption CanBiteNeutralBenign;
        public static CustomOption CanBiteNeutralEvil;

        public static CustomOption VampireHunter;
        public static CustomOption StakeCooldown;
        public static CustomOption MaxFailedStakesPerGame;
        public static CustomOption CanStakeRoundOne;
        public static CustomOption SelfKillAfterFinalStake;
        public static CustomOption BecomeOnVampDeaths;

        public static CustomOption Prosecutor;
        public static CustomOption ProsDiesOnIncorrectPros;

        public static CustomOption Warlock;
        public static CustomOption ChargeUpDuration;
        public static CustomOption ChargeUseDuration;

        public static CustomOption Oracle;
        public static CustomOption ConfessCooldown;
        public static CustomOption RevealAccuracy;
        public static CustomOption NeutralBenignShowsEvil;
        public static CustomOption NeutralEvilShowsEvil;
        public static CustomOption NeutralKillingShowsEvil;

        public static CustomOption Venerer;
        public static CustomOption AbilityCooldown;
        public static CustomOption AbilityDuration;
        public static CustomOption SprintSpeed;
        public static CustomOption FreezeSpeed;

        public static CustomOption Aurial;
        public static CustomOption RadiateRange;
        public static CustomOption RadiateCooldown;
        public static CustomOption RadiateSucceedChance;
        public static CustomOption RadiateCount;
        public static CustomOption RadiateInvis;

        public static CustomOption Giant;
        public static CustomOption GiantSlow;

        public static CustomOption Flash;
        public static CustomOption FlashSpeed;

        public static CustomOption Diseased;
        public static CustomOption DiseasedKillMultiplier;

        public static CustomOption Bait;
        public static CustomOption BaitMinDelay;
        public static CustomOption BaitMaxDelay;

        public static CustomOption Lovers;
        public static CustomOption BothLoversDie;
        public static CustomOption LovingImpPercent;
        public static CustomOption NeutralLovers;

        public static CustomOption Frosty;
        public static CustomOption ChillDuration;
        public static CustomOption ChillStartSpeed;

        public static CustomOption BlockGameEndHeader;
        public static CustomOption BlockGameEnd;
        public static CustomOption SheriffBlockGameEnd;
        public static CustomOption VeteranBlockGameEnd;
        public static CustomOption MayorBlockGameEnd;
        public static CustomOption SwapperBlockGameEnd;
        public static CustomOption TiebreakerBlockGameEnd;

        public static Func<float, string> PercentFormat { get; } = (float value) => $"{value:0}%";
        public static Func<float, string> CooldownFormat { get; } = (float value) => $"{value:0.0#}s";
        public static Func<float, string> MultiplierFormat { get; } = (float value) => $"{value:0.0#}x";
        public static GameMode CurrentGameMode
            => GameMode.Get() == 0 ? Gamemode.Classic : (GameMode.Get() == 1 ? Gamemode.AllAny : (GameMode.Get() == 2 ? Gamemode.KillingOnly : (GameMode.Get() == 3 ? Gamemode.Cultist : Gamemode.All)));

        public static void GenerateAll()
        {
            CustomOption.baseSettings = TownOfUs.Instance.Config.Bind("Preset0", "VanillaOptions", "");
            presetSelection = CustomOption.CreateString(0, Types.General, "Preset", presets, null, true);

            CrewInvestigativeRoles = CustomOption.CreateHeader(100, Types.Crewmate, "Crewmate Investigative Roles");

            AurialOn = CustomOption.CreateNumber(1, Types.Crewmate, $"<color=#B34D99FF>Aurial</color>", 0f, 0f, 100f, 10f, PercentFormat, CrewInvestigativeRoles, true);
            RadiateRange = CustomOption.CreateNumber(2, Types.Crewmate, "Radiate Range", 1f, 0.25f, 5f, 0.25f, MultiplierFormat, AurialOn);
            RadiateCooldown = CustomOption.CreateNumber(3, Types.Crewmate, "Radiate Cooldown", 30f, 10f, 60f, 2.5f, CooldownFormat, AurialOn);
            RadiateInvis = CustomOption.CreateNumber(4, Types.Crewmate, "Radiate See Delay", 10f, 0f, 15f, 1f, CooldownFormat, AurialOn);
            RadiateCount = CustomOption.CreateNumber(5, Types.Crewmate, "Radiate Uses To See", 3, 1, 5, 1, null, AurialOn);
            RadiateSucceedChance = CustomOption.CreateNumber(6, Types.Crewmate, "Radiate Succeed Chance", 100f, 0f, 100f, 10f, PercentFormat, AurialOn);

            DetectiveOn = CustomOption.CreateNumber(7, Types.Crewmate, "<color=#4D4DFFFF>Detective</color>", 0f, 0f, 100f, 10f, PercentFormat, CrewInvestigativeRoles, true);
            ExamineCooldown = CustomOption.CreateNumber(8, Types.Crewmate, "Examine Cooldown", 30f, 10f, 60f, 2.5f, CooldownFormat, DetectiveOn);
            DetectiveReportOn = CustomOption.CreateToggle(9, Types.Crewmate, "Show Detective Reports", true, DetectiveOn);
            DetectiveRoleDuration = CustomOption.CreateNumber(10, Types.Crewmate, "Time Where Detective Will Have Role", 15f, 0f, 60f, 0.5f, CooldownFormat, DetectiveReportOn);
            DetectiveFactionDuration = CustomOption.CreateNumber(11, Types.Crewmate, "Time Where Detective Will Have Faction", 30f, 0f, 60f, 0.5f, CooldownFormat, DetectiveReportOn);
            CanDetectLastKiller = CustomOption.CreateToggle(12, Types.Crewmate, "Can Detect Last Killer", false, DetectiveOn);

            HaunterOn = CustomOption.CreateNumber(13, Types.Crewmate, "<color=#D3D3D3FF>Haunter</color>", 0f, 0f, 100f, 10f, PercentFormat, CrewInvestigativeRoles, true);
            HaunterTasksRemainingClicked = CustomOption.CreateNumber(14, Types.Crewmate, "Tasks Remaining When Haunter Can Be Clicked", 5f, 1f, 15f, 1f, null, HaunterOn);
            HaunterTasksRemainingAlert = CustomOption.CreateNumber(15, Types.Crewmate, "Tasks Remaining When Alert Is Sent", 1, 1, 5, 1, null, HaunterOn);
            HaunterRevealsNeutrals = CustomOption.CreateToggle(16, Types.Crewmate, "Haunter Reveals Neutral Roles", false, HaunterOn);
            HaunterCanBeClickedBy = CustomOption.CreateString(17, Types.Crewmate, "Who Can Click Haunter", new[] { "All", "Non-Crew", "Imps Only" }, HaunterOn);

            InvestigatorOn = CustomOption.CreateNumber(18, Types.Crewmate, "<color=#00B3B3FF>Investigator</color>", 0f, 0f, 100f, 10f, PercentFormat, CrewInvestigativeRoles, true);
            FootprintSize = CustomOption.CreateNumber(19, Types.Crewmate, "Footprint Size", 4f, 1f, 10f, 1f, null, InvestigatorOn);
            FootprintInterval = CustomOption.CreateNumber(20, Types.Crewmate, "Footprint Interval", 0.1f, 0.05f, 1f, 0.05f, CooldownFormat, InvestigatorOn);
            FootprintDuration = CustomOption.CreateNumber(21, Types.Crewmate, "Footprint Duration", 10f, 1f, 15f, 0.5f, CooldownFormat, InvestigatorOn);
            AnonymousFootPrint = CustomOption.CreateToggle(22, Types.Crewmate, "Anonymous Footprint", false, InvestigatorOn);
            VentFootprintVisible = CustomOption.CreateToggle(23, Types.Crewmate, "Footprint Vent Visible", false, InvestigatorOn);

            MysticOn = CustomOption.CreateNumber(24, Types.Crewmate, "<color=#4D99E6FF>Mystic</color>", 0f, 0f, 100f, 10f, PercentFormat, CrewInvestigativeRoles, true);
            MysticArrowDuration = CustomOption.CreateNumber(25, Types.Crewmate, "Dead Body Arrow Duration", 0.1f, 0f, 1f, 0.05f, CooldownFormat, MysticOn);

            OracleOn = CustomOption.CreateNumber(26, Types.Crewmate, "<color=#BF00BFFF>Oracle</color>", 0f, 0f, 100f, 10f, PercentFormat, CrewInvestigativeRoles, true);
            ConfessCooldown = CustomOption.CreateNumber(27, Types.Crewmate, "Confess Cooldown", 30f, 10f, 60f, 2.5f, CooldownFormat, OracleOn);
            RevealAccuracy = CustomOption.CreateNumber(28, Types.Crewmate, "Reveal Accuracy", 80f, 0f, 100f, 10f, PercentFormat, OracleOn);
            NeutralBenignShowsEvil = CustomOption.CreateToggle(29, Types.Crewmate, "Neutral Benign Roles Show Evil", false, OracleOn);
            NeutralEvilShowsEvil = CustomOption.CreateToggle(30, Types.Crewmate, "Neutral Evil Roles Show Evil", false, OracleOn);
            NeutralKillingShowsEvil = CustomOption.CreateToggle(31, Types.Crewmate, "Neutral Killing Roles Show Evil", true, OracleOn);

            SeerOn = CustomOption.CreateNumber(32, Types.Crewmate, "<color=#FFCC80FF>Seer</color>", 0f, 0f, 100f, 10f, PercentFormat, CrewInvestigativeRoles, true);
            SeerCooldown = CustomOption.CreateNumber(33, Types.Crewmate, "Seer Cooldown", 30f, 10f, 60f, 2.5f, CooldownFormat, SeerOn);
            CrewKillingRed = CustomOption.CreateToggle(34, Types.Crewmate, "Crewmate Killing Roles Are Red", false, SeerOn);
            NeutBenignRed = CustomOption.CreateToggle(35, Types.Crewmate, "Neutral Benign Roles Are Red", false, SeerOn);
            NeutEvilRed = CustomOption.CreateToggle(36, Types.Crewmate, "Neutral Evil Roles Are Red", false, SeerOn);
            NeutKillingRed = CustomOption.CreateToggle(37, Types.Crewmate, "Neutral Killing Roles Are Red", true, SeerOn);
            TraitorColourSwap = CustomOption.CreateToggle(38, Types.Crewmate, "Traitor Does Not Swap Colours", false, SeerOn);

            SnitchOn = CustomOption.CreateNumber(39, Types.Crewmate, "<color=#D4AF37FF>Snitch</color>", 0f, 0f, 100f, 10f, PercentFormat, CrewInvestigativeRoles, true);
            SnitchSeesNeutrals = CustomOption.CreateToggle(40, Types.Crewmate, "Snitch Sees Neutral Roles", false, SnitchOn);
            SnitchTasksRemaining = CustomOption.CreateNumber(41, Types.Crewmate, "Tasks Remaining When Revealed", 1, 1, 5, 1, null, SnitchOn);
            SnitchSeesImpInMeeting = CustomOption.CreateToggle(42, Types.Crewmate, "Snitch Sees Impostors In Meetings", true, SnitchOn);
            SnitchSeesTraitor = CustomOption.CreateToggle(43, Types.Crewmate, "Snitch Sees Traitor", true, SnitchOn);

            SpyOn = CustomOption.CreateNumber(44, Types.Crewmate, "<color=#CCA3CCFF>Spy</color>", 0f, 0f, 100f, 10f, PercentFormat, CrewInvestigativeRoles, true);
            WhoSeesDead = CustomOption.CreateString(45, Types.Crewmate, "Who Sees Dead Bodies On Admin", new[] { "Nobody", "Spy", "Everyone But Spy", "Everyone" }, SpyOn);

            TrackerOn = CustomOption.CreateNumber(46, Types.Crewmate, "<color=#009900FF>Tracker</color>", 0f, 0f, 100f, 10f, PercentFormat, CrewInvestigativeRoles, true);
            UpdateInterval = CustomOption.CreateNumber(47, Types.Crewmate, "Arrow Update Interval", 5f, 0f, 15f, 0.25f, CooldownFormat, TrackerOn);
            TrackCooldown = CustomOption.CreateNumber(48, Types.Crewmate, "Track Cooldown", 30f, 10f, 60f, 2.5f, CooldownFormat, TrackerOn);
            ResetOnNewRound = CustomOption.CreateToggle(49, Types.Crewmate, "Tracker Arrows Reset After Each Round", false, TrackerOn);
            MaxTracks = CustomOption.CreateNumber(50, Types.Crewmate, "Maximum Number Of Tracks Per Round", 5f, 1f, 15f, 1f, null, TrackerOn);

            TrapperOn = CustomOption.CreateNumber(51, Types.Crewmate, "<color=#A7D1B3FF>Trapper</color>", 0f, 0f, 100f, 10f, PercentFormat, CrewInvestigativeRoles, true);
            MinAmountOfTimeInTrap = CustomOption.CreateNumber(52, Types.Crewmate, "Min Amount Of Time In Trap To Register", 1f, 0f, 15f, 0.25f, CooldownFormat, TrapperOn);
            TrapCooldown = CustomOption.CreateNumber(53, Types.Crewmate, "Trap Cooldown", 30f, 10f, 60f, 2.5f, CooldownFormat, TrapperOn);
            TrapsRemoveOnNewRound = CustomOption.CreateToggle(54, Types.Crewmate, "Traps Removed After Each Round", true, TrapperOn);
            MaxTraps = CustomOption.CreateNumber(55, Types.Crewmate, "Maximum Number Of Traps Per Game", 5f, 1f, 15f, 1f, null, TrapperOn);
            TrapSize = CustomOption.CreateNumber(56, Types.Crewmate, "Trap Size", 0.25f, 0.05f, 1f, 0.05f, MultiplierFormat, TrapperOn);
            MinAmountOfPlayersInTrap = CustomOption.CreateNumber(57, Types.Crewmate, "Minimum Number Of Roles Required To Trigger Trap", 3, 1, 5, 1, null, TrapperOn);


            CrewKillingRoles = CustomOption.CreateHeader(58, Types.Crewmate, "Crewmate Killing Roles");

            SheriffOn = CustomOption.CreateNumber(59, Types.Crewmate, "<color=#FFFF00FF>Sheriff</color>", 0f, 0f, 100f, 10f, PercentFormat, CrewKillingRoles, true);
            SheriffKillOther = CustomOption.CreateToggle(60, Types.Crewmate, "Sheriff Miskill Kills Crewmate", false, SheriffOn);
            SheriffKillsDoomsayer = CustomOption.CreateToggle(61, Types.Crewmate, "Sheriff Kills Doomsayer", false, SheriffOn);
            SheriffKillsExecutioner = CustomOption.CreateToggle(62, Types.Crewmate, "Sheriff Kills Executioner", false, SheriffOn);
            SheriffKillsJester = CustomOption.CreateToggle(63, Types.Crewmate, "Sheriff Kills Jester", false, SheriffOn);
            SheriffKillsArsonist = CustomOption.CreateToggle(64, Types.Crewmate, "Sheriff Kills Arsonist", false, SheriffOn);
            SheriffKillsGlitch = CustomOption.CreateToggle(65, Types.Crewmate, "Sheriff Kills The Glitch", false, SheriffOn);
            SheriffKillsJuggernaut = CustomOption.CreateToggle(66, Types.Crewmate, "Sheriff Kills Juggernaut", false, SheriffOn);
            SheriffKillsPlaguebearer = CustomOption.CreateToggle(67, Types.Crewmate, "Sheriff Kills Plaguebearer", false, SheriffOn);
            SheriffKillsVampire = CustomOption.CreateToggle(68, Types.Crewmate, "Sheriff Kills Vampire", false, SheriffOn);
            SheriffKillsWerewolf = CustomOption.CreateToggle(69, Types.Crewmate, "Sheriff Kills Werewolf", false, SheriffOn);
            SheriffKillCd = CustomOption.CreateNumber(70, Types.Crewmate, "Sheriff Kill Cooldown", 30f, 10f, 60f, 2.5f, CooldownFormat, SheriffOn);
            SheriffBodyReport = CustomOption.CreateToggle(71, Types.Crewmate, "Sheriff Can Report Who They've Killed", true, SheriffOn);

            VampireHunterOn = CustomOption.CreateNumber(72, Types.Crewmate, "<color=#B3B3E6FF>Vampire Hunter</color>", 0f, 0f, 100f, 10f, PercentFormat, CrewKillingRoles, true);
            StakeCooldown = CustomOption.CreateNumber(73, Types.Crewmate, "Stake Cooldown", 30f, 10f, 60f, 2.5f, CooldownFormat, VampireHunterOn);
            MaxFailedStakesPerGame = CustomOption.CreateNumber(74, Types.Crewmate, "Maximum Failed Stakes Per Game", 5f, 1f, 15f, 1f, null, VampireHunterOn);
            CanStakeRoundOne = CustomOption.CreateToggle(75, Types.Crewmate, "Can Stake Round One", false, VampireHunterOn);
            SelfKillAfterFinalStake = CustomOption.CreateToggle(76, Types.Crewmate, "Self Kill On Failure To Kill A Vamp With All Stakes", false, VampireHunterOn);
            BecomeOnVampDeaths = CustomOption.CreateString(77, Types.Crewmate, "What Vampire Hunter Becomes On All Vampire Deaths", new[] { "Crewmate", "Sheriff", "Veteran", "Vigilante" }, VampireHunterOn);

            VeteranOn = CustomOption.CreateNumber(78, Types.Crewmate, "<color=#998040FF>Veteran</color>", 0f, 0f, 100f, 10f, PercentFormat, CrewKillingRoles, true);
            KilledOnAlert = CustomOption.CreateToggle(79, Types.Crewmate, "Can Be Killed On Alert", false, VeteranOn);
            AlertCooldown = CustomOption.CreateNumber(80, Types.Crewmate, "Alert Cooldown", 30f, 10f, 60f, 2.5f, CooldownFormat, VeteranOn);
            AlertDuration = CustomOption.CreateNumber(81, Types.Crewmate, "Alert Duration", 10f, 5f, 15f, 0.5f, CooldownFormat, VeteranOn);
            MaxAlerts = CustomOption.CreateNumber(82, Types.Crewmate, "Maximum Number Of Alerts", 5f, 1f, 15f, 1f, null, VeteranOn);

            VigilanteOn = CustomOption.CreateNumber(83, Types.Crewmate, "<color=#FFFF99FF>Vigilante</color>", 0f, 0f, 100f, 10f, PercentFormat, CrewKillingRoles, true);
            VigilanteKills = CustomOption.CreateNumber(84, Types.Crewmate, "Number Of Vigilante Kills", 1, 1, 15, 1, null, VigilanteOn);
            VigilanteMultiKill = CustomOption.CreateToggle(85, Types.Crewmate, "Vigilante Can Kill More Than Once Per Meeting", false, VigilanteOn);
            VigilanteGuessNeutralBenign = CustomOption.CreateToggle(86, Types.Crewmate, "Vigilante Can Guess Neutral Benign Roles", false, VigilanteOn);
            VigilanteGuessNeutralEvil = CustomOption.CreateToggle(87, Types.Crewmate, "Vigilante Can Guess Neutral Evil Roles", false, VigilanteOn);
            VigilanteGuessNeutralKilling = CustomOption.CreateToggle(88, Types.Crewmate, "Vigilante Can Guess Neutral Killing Roles", false, VigilanteOn);
            VigilanteGuessLovers = CustomOption.CreateToggle(89, Types.Crewmate, "Vigilante Can Guess Lovers", false, VigilanteOn);


            CrewProtectiveRoles = CustomOption.CreateHeader(91, Types.Crewmate, "Crewmate Protective Roles");

            AltruistOn = CustomOption.CreateNumber(92, Types.Crewmate, "<color=#660000FF>Altruist</color>", 0f, 0f, 100f, 10f, PercentFormat, CrewProtectiveRoles, true);
            ReviveDuration = CustomOption.CreateNumber(93, Types.Crewmate, "Altruist Revive Duration", 10f, 1f, 15f, 0.5f, CooldownFormat, AltruistOn);
            AltruistTargetBody = CustomOption.CreateToggle(94, Types.Crewmate, "Target's Body Disappears On Beginning Of Revive", false, AltruistOn);

            MedicOn = CustomOption.CreateNumber(95, Types.Crewmate, "<color=#006600FF>Medic</color>", 0f, 0f, 100f, 10f, PercentFormat, CrewProtectiveRoles, true);
            ShowShielded = CustomOption.CreateString(96, Types.Crewmate, "Show Shielded Player", new[] { "Self", "Medic", "Self+Medic", "Everyone" }, MedicOn);
            WhoGetsNotification = CustomOption.CreateString(97, Types.Crewmate, "Who Gets Murder Attempt Indicator", new[] { "Medic", "Shielded", "Everyone", "Nobody" }, MedicOn);
            ShieldBreaks = CustomOption.CreateToggle(98, Types.Crewmate, "Shield Breaks On Murder Attempt", false, MedicOn);
            MedicReportSwitch = CustomOption.CreateToggle(99, Types.Crewmate, "Show Medic Reports", true, MedicOn);
            MedicReportNameDuration = CustomOption.CreateNumber(101, Types.Crewmate, "Time Where Medic Will Have Name", 0f, 0f, 60f, 2.5f, CooldownFormat, MedicReportSwitch);
            MedicReportColorDuration = CustomOption.CreateNumber(102, Types.Crewmate, "Time Where Medic Will Have Color Type", 15f, 0f, 60f, 2.5f, CooldownFormat, MedicReportSwitch);


            CrewSupportRoles = CustomOption.CreateHeader(103, Types.Crewmate, "Crewmate Support Roles");

            EngineerOn = CustomOption.CreateNumber(104, Types.Crewmate, "<color=#FFA60AFF>Engineer</color>", 0f, 0f, 100f, 10f, PercentFormat, CrewSupportRoles, true);
            MaxFixes = CustomOption.CreateNumber(105, Types.Crewmate, "Maximum Number Of Fixes", 5f, 1f, 15f, 1f, null, EngineerOn);

            ImitatorOn = CustomOption.CreateNumber(106, Types.Crewmate, "<color=#B3D94DFF>Imitator</color>", 0f, 0f, 100f, 10f, PercentFormat, CrewSupportRoles, true);

            MayorOn = CustomOption.CreateNumber(107, Types.Crewmate, "<color=#704FA8FF>Mayor</color>", 0f, 0f, 100f, 10f, PercentFormat, CrewSupportRoles, true);

            MediumOn = CustomOption.CreateNumber(108, Types.Crewmate, "<color=#A680FFFF>Medium</color>", 0f, 0f, 100f, 10f, PercentFormat, CrewSupportRoles, true);
            MediateCooldown = CustomOption.CreateNumber(109, Types.Crewmate, "Mediate Cooldown", 10f, 1f, 15f, 0.5f, CooldownFormat, MediumOn);
            ShowMediatePlayer = CustomOption.CreateToggle(110, Types.Crewmate, "Reveal Appearance Of Mediate Target", true, MediumOn);
            ShowMediumToDead = CustomOption.CreateToggle(111, Types.Crewmate, "Reveal The Medium To The Mediate Target", true, MediumOn);
            DeadRevealed = CustomOption.CreateString(112, Types.Crewmate, "Who Is Revealed With Mediate", new[] { "Oldest Dead", "Newest Dead", "All Dead" }, MediumOn);

            ProsecutorOn = CustomOption.CreateNumber(113, Types.Crewmate, "<color=#B38000FF>Prosecutor</color>", 0f, 0f, 100f, 10f, PercentFormat, CrewSupportRoles, true);
            ProsDiesOnIncorrectPros = CustomOption.CreateToggle(114, Types.Crewmate, "Prosecutor Dies When They Exile A Crewmate", false, ProsecutorOn);

            SwapperOn = CustomOption.CreateNumber(115, Types.Crewmate, "<color=#66E666FF>Swapper</color>", 0f, 0f, 100f, 10f, PercentFormat, CrewSupportRoles, true);
            SwapperButton = CustomOption.CreateToggle(116, Types.Crewmate, "Swapper Can Button", true, SwapperOn);

            TransporterOn = CustomOption.CreateNumber(117, Types.Crewmate, "<color=#00EEFFFF>Transporter</color>", 0f, 0f, 100f, 10f, PercentFormat, CrewSupportRoles, true);
            TransportCooldown = CustomOption.CreateNumber(118, Types.Crewmate, "Transport Cooldown", 30f, 10f, 60f, 2.5f, CooldownFormat, TransporterOn);
            TransportMaxUses = CustomOption.CreateNumber(119, Types.Crewmate, "Maximum Number Of Transports", 5f, 1f, 15f, 1f, null, TransporterOn);
            TransporterVitals = CustomOption.CreateToggle(120, Types.Crewmate, "Transporter Can Use Vitals", false, TransporterOn);


            NeutralBenignRoles = CustomOption.CreateHeader(121, Types.Neutral, "Neutral Benign Roles");

            AmnesiacOn = CustomOption.CreateNumber(122, Types.Neutral, "<color=#80B2FFFF>Amnesiac</color>", 0f, 0f, 100f, 10f, PercentFormat, NeutralBenignRoles, true);
            RememberArrows = CustomOption.CreateToggle(123, Types.Neutral, "Amnesiac Gets Arrows Pointing To Dead Bodies", false, AmnesiacOn);
            RememberArrowDelay = CustomOption.CreateNumber(124, Types.Neutral, "Time After Death Arrow Appears", 5f, 0f, 15f, 0.5f, CooldownFormat, RememberArrows);

            GuardianAngelOn = CustomOption.CreateNumber(125, Types.Neutral, "<color=#B3FFFFFF>Guardian Angel</color>", 0f, 0f, 100f, 10f, PercentFormat, NeutralBenignRoles, true);
            ProtectCd = CustomOption.CreateNumber(126, Types.Neutral, "Protect Cooldown", 30f, 10f, 60f, 2.5f, CooldownFormat, GuardianAngelOn);
            ProtectDuration = CustomOption.CreateNumber(127, Types.Neutral, "Protect Duration", 10f, 5f, 15f, 0.5f, CooldownFormat, GuardianAngelOn);
            ProtectKCReset = CustomOption.CreateNumber(128, Types.Neutral, "Kill Cooldown Reset When Protected", 30f, 0f, 60f, 2.5f, CooldownFormat, GuardianAngelOn);
            MaxProtects = CustomOption.CreateNumber(129, Types.Neutral, "Maximum Number Of Protects", 5f, 1f, 15f, 1f, null, GuardianAngelOn);
            ShowProtect = CustomOption.CreateString(130, Types.Neutral, "Show Protected Player", new[] { "Self", "Guardian Angel", "Self+GA", "Everyone" }, GuardianAngelOn);
            GaOnTargetDeath = CustomOption.CreateString(131, Types.Neutral, "GA Becomes On Target Dead", new[] { "Crew", "Amnesiac", "Survivor", "Jester" }, GuardianAngelOn);
            GATargetKnows = CustomOption.CreateToggle(132, Types.Neutral, "Target Knows GA Exists", false, GuardianAngelOn);
            GAKnowsTargetRole = CustomOption.CreateToggle(133, Types.Neutral, "GA Knows Targets Role", false, GuardianAngelOn);
            EvilTargetPercent = CustomOption.CreateNumber(134, Types.Neutral, "Odds Of Target Being Evil", 0f, 0f, 100f, 10f, PercentFormat, GuardianAngelOn);

            SurvivorOn = CustomOption.CreateNumber(135, Types.Neutral, "<color=#FFE64DFF>Survivor</color>", 0f, 0f, 100f, 10f, PercentFormat, NeutralBenignRoles, true);
            VestCd = CustomOption.CreateNumber(136, Types.Neutral, "Vest Cooldown", 30f, 10f, 60f, 2.5f, CooldownFormat, SurvivorOn);
            VestDuration = CustomOption.CreateNumber(137, Types.Neutral, "Vest Duration", 10f, 5f, 15f, 0.5f, CooldownFormat, SurvivorOn);
            VestKCReset = CustomOption.CreateNumber(138, Types.Neutral, "Kill Cooldown Reset On Attack", 30f, 0f, 60f, 2.5f, CooldownFormat, SurvivorOn);
            MaxVests = CustomOption.CreateNumber(139, Types.Neutral, "Maximum Number Of Vests", 5f, 1f, 15f, 1f, null, SurvivorOn);


            NeutralEvilRoles = CustomOption.CreateHeader(140, Types.Neutral, "Neutral Evil Roles");

            DoomsayerOn = CustomOption.CreateNumber(141, Types.Neutral, "<color=#00FF80FF>Doomsayer</color>", 0f, 0f, 100f, 10f, PercentFormat, NeutralEvilRoles, true);
            ObserveCooldown = CustomOption.CreateNumber(142, Types.Neutral, "Observe Cooldown", 30f, 10f, 60f, 2.5f, CooldownFormat, DoomsayerOn);
            DoomsayerGuessNeutralBenign = CustomOption.CreateToggle(143, Types.Neutral, "Doomsayer Can Guess Neutral Benign Roles", false, DoomsayerOn);
            DoomsayerGuessNeutralEvil = CustomOption.CreateToggle(144, Types.Neutral, "Doomsayer Can Guess Neutral Evil Roles", false, DoomsayerOn);
            DoomsayerGuessNeutralKilling = CustomOption.CreateToggle(145, Types.Neutral, "Doomsayer Can Guess Neutral Killing Roles", false, DoomsayerOn);
            DoomsayerGuessImpostors = CustomOption.CreateToggle(146, Types.Neutral, "Doomsayer Can Guess Impostor Roles", false, DoomsayerOn);
            DoomsayerGuessesToWin = CustomOption.CreateNumber(148, Types.Neutral, "Number Of Doomsayer Kills To Win", 3f, 1f, 5f, 1f, null, DoomsayerOn);

            ExecutionerOn = CustomOption.CreateNumber(149, Types.Neutral, "<color=#8C4005FF>Executioner</color>", 0f, 0f, 100f, 10f, PercentFormat, NeutralEvilRoles, true);
            OnTargetDead = CustomOption.CreateString(150, Types.Neutral, "Executioner Becomes On Target Dead", new[] { "Crew", "Amnesiac", "Survivor", "Jester" }, ExecutionerOn);
            ExecutionerButton = CustomOption.CreateToggle(151, Types.Neutral, "Executioner Can Button", true, ExecutionerOn);
            ExecutionerTorment = CustomOption.CreateToggle(417, Types.General, "Executioner Torment Player On Victory", false, ExecutionerOn);

            JesterOn = CustomOption.CreateNumber(153, Types.Neutral, "<color=#FFBFCCFF>Jester</color>", 0f, 0f, 100f, 10f, PercentFormat, NeutralEvilRoles, true);
            JesterButton = CustomOption.CreateToggle(154, Types.Neutral, "Jester Can Button", true, JesterOn);
            JesterVent = CustomOption.CreateToggle(155, Types.Neutral, "Jester Can Hide In Vents", false, JesterOn);
            JesterImpVision = CustomOption.CreateToggle(156, Types.Neutral, "Jester Has Impostor Vision", false, JesterOn);
            JesterHaunt = CustomOption.CreateToggle(416, Types.General, "Jester Haunt Player On Victory", false, JesterOn);

            PhantomOn = CustomOption.CreateNumber(158, Types.Neutral, "<color=#662962FF>Phantom</color>", 0f, 0f, 100f, 10f, PercentFormat, NeutralEvilRoles, true);
            PhantomTasksRemaining = CustomOption.CreateNumber(159, Types.Neutral, "Tasks Remaining When Phantom Can Be Clicked", 5f, 1f, 15f, 1f, null, PhantomOn);
            PhantomSpook = CustomOption.CreateToggle(415, Types.General, "Phantom Spook Player On Victory", false, PhantomOn);


            NeutralKillingRoles = CustomOption.CreateHeader(161, Types.Neutral, "Neutral Killing Roles");
            
            ArsonistOn = CustomOption.CreateNumber(162, Types.Neutral, "<color=#FF4D00FF>Arsonist</color>", 0f, 0f, 100f, 10f, PercentFormat, NeutralKillingRoles, true);
            DouseCooldown = CustomOption.CreateNumber(163, Types.Neutral, "Douse Cooldown", 30f, 10f, 60f, 2.5f, CooldownFormat, ArsonistOn);
            MaxDoused = CustomOption.CreateNumber(164, Types.Neutral, "Maximum Alive Players Doused", 5f, 1f, 15f, 1f, null, ArsonistOn);
            ArsoImpVision = CustomOption.CreateToggle(165, Types.Neutral, "Arsonist Has Impostor Vision", false, ArsonistOn);
            IgniteCdRemoved = CustomOption.CreateToggle(166, Types.Neutral, "Ignite Cooldown Removed When Arsonist Is Last Killer", false, ArsonistOn);

            Juggernaut = CustomOption.CreateString(167, Types.Neutral, "<color=#8C004DFF>Juggernaut Settings</color>", new string[] { "Hide", "Show" }, NeutralKillingRoles, true);
            JuggKillCooldown = CustomOption.CreateNumber(168, Types.Neutral, "Juggernaut Initial Kill Cooldown", 30f, 10f, 60f, 2.5f, CooldownFormat, Juggernaut);
            ReducedKCdPerKill = CustomOption.CreateNumber(169, Types.Neutral, "Reduced Kill Cooldown Per Kill", 5f, 2.5f, 10f, 2.5f, CooldownFormat, Juggernaut);
            JuggVent = CustomOption.CreateToggle(170, Types.Neutral, "Juggernaut Can Vent", false, Juggernaut);

            PlaguebearerOn = CustomOption.CreateNumber(171, Types.Neutral, "<color=#E6FFB3FF>Plaguebearer</color>", 0f, 0f, 100f, 10f, PercentFormat, NeutralKillingRoles, true);
            InfectCooldown = CustomOption.CreateNumber(172, Types.Neutral, "Infect Cooldown", 30f, 10f, 60f, 2.5f, CooldownFormat, PlaguebearerOn);
            PestKillCooldown = CustomOption.CreateNumber(173, Types.Neutral, "Pestilence Kill Cooldown", 30f, 0f, 60f, 2.5f, CooldownFormat, PlaguebearerOn);
            PestVent = CustomOption.CreateToggle(174, Types.Neutral, "Pestilence Can Vent", false, PlaguebearerOn);

            GlitchOn = CustomOption.CreateNumber(175, Types.Neutral, "<color=#00FF00FF>The Glitch</color>", 0f, 0f, 100f, 10f, PercentFormat, NeutralKillingRoles, true);
            MimicCooldownOption = CustomOption.CreateNumber(176, Types.Neutral, "Mimic Cooldown", 30f, 10f, 60f, 2.5f, CooldownFormat, GlitchOn);
            MimicDurationOption = CustomOption.CreateNumber(177, Types.Neutral, "Mimic Duration", 10f, 1f, 15f, 0.5f, CooldownFormat, GlitchOn);
            HackCooldownOption = CustomOption.CreateNumber(178, Types.Neutral, "Hack Cooldown", 30f, 10f, 60f, 2.5f, CooldownFormat, GlitchOn);
            HackDurationOption = CustomOption.CreateNumber(179, Types.Neutral, "Hack Duration", 10f, 1f, 15f, 0.5f, CooldownFormat, GlitchOn);
            GlitchKillCooldownOption = CustomOption.CreateNumber(180, Types.Neutral, "Glitch Kill Cooldown", 30f, 10f, 60f, 2.5f, CooldownFormat, GlitchOn);
            GlitchHackDistanceOption = CustomOption.CreateString(181, Types.Neutral, "Glitch Hack Distance", new[] { "Short", "Normal", "Long" }, GlitchOn);
            GlitchVent = CustomOption.CreateToggle(182, Types.Neutral, "Glitch Can Vent", false, GlitchOn);

            VampireOn = CustomOption.CreateNumber(183, Types.Neutral, "<color=#262626FF>Vampire</color>", 0f, 0f, 100f, 10f, PercentFormat, NeutralKillingRoles, true);
            BiteCooldown = CustomOption.CreateNumber(184, Types.Neutral, "Vampire Bite Cooldown", 30f, 10f, 60f, 2.5f, CooldownFormat, VampireOn);
            VampImpVision = CustomOption.CreateToggle(185, Types.Neutral, "Vampires Have Impostor Vision", false, VampireOn);
            VampVent = CustomOption.CreateToggle(186, Types.Neutral, "Vampires Can Vent", false, VampireOn);
            NewVampCanAssassin = CustomOption.CreateToggle(187, Types.Neutral, "New Vampire Can Assassinate", false, VampireOn);
            MaxVampiresPerGame = CustomOption.CreateNumber(188, Types.Neutral, "Maximum Vampires Per Game", 2f, 2f, 5f, 1f, null, VampireOn);
            CanBiteNeutralBenign = CustomOption.CreateToggle(189, Types.Neutral, "Can Convert Neutral Benign Roles", false, VampireOn);
            CanBiteNeutralEvil = CustomOption.CreateToggle(190, Types.Neutral, "Can Convert Neutral Evil Roles", false, VampireOn);

            WerewolfOn = CustomOption.CreateNumber(191, Types.Neutral, "<color=#A86629FF>Werewolf</color>", 0f, 0f, 100f, 10f, PercentFormat, NeutralKillingRoles, true);
            RampageCooldown = CustomOption.CreateNumber(192, Types.Neutral, "Rampage Cooldown", 30f, 10f, 60f, 2.5f, CooldownFormat, WerewolfOn);
            RampageDuration = CustomOption.CreateNumber(193, Types.Neutral, "Rampage Duration", 30f, 10f, 60f, 2.5f, CooldownFormat, WerewolfOn);
            RampageKillCooldown = CustomOption.CreateNumber(194, Types.Neutral, "Rampage Kill Cooldown", 10f, 0.5f, 15f, 0.25f, CooldownFormat, WerewolfOn);
            WerewolfVent = CustomOption.CreateToggle(195, Types.Neutral, "Werewolf Can Vent When Rampaged", false, WerewolfOn);
            
            Assassin = CustomOption.CreateString(242, Types.Impostor, "<color=#FF0000FF>Assassin Ability</color>", new string[] { "Hide", "Show" }, null, true);
            NumberOfImpostorAssassins = CustomOption.CreateNumber(243, Types.Impostor, "Number Of Impostor Assassins", 1f, 0f, 4f, 1f, null, Assassin);
            NumberOfNeutralAssassins = CustomOption.CreateNumber(244, Types.Impostor, "Number Of Neutral Assassins", 1f, 0f, 5f, 1f, null, Assassin);
            AmneTurnImpAssassin = CustomOption.CreateToggle(245, Types.Impostor, "Amnesiac Turned Impostor Gets Ability", false, Assassin);
            AmneTurnNeutAssassin = CustomOption.CreateToggle(246, Types.Impostor, "Amnesiac Turned Neutral Killing Gets Ability", false, Assassin);
            TraitorCanAssassin = CustomOption.CreateToggle(247, Types.Impostor, "Traitor Gets Ability", false, Assassin);
            AssassinKills = CustomOption.CreateNumber(248, Types.Impostor, "Number Of Assassin Kills", 1f, 1f, 15f, 1f, null, Assassin);
            AssassinMultiKill = CustomOption.CreateToggle(249, Types.Impostor, "Assassin Can Kill More Than Once Per Meeting", false, Assassin);
            AssassinCrewmateGuess = CustomOption.CreateToggle(250, Types.Impostor, "Assassin Can Guess \"Crewmate\"", false, Assassin);
            AssassinGuessNeutralBenign = CustomOption.CreateToggle(251, Types.Impostor, "Assassin Can Guess Neutral Benign Roles", false, Assassin);
            AssassinGuessNeutralEvil = CustomOption.CreateToggle(252, Types.Impostor, "Assassin Can Guess Neutral Evil Roles", false, Assassin);
            AssassinGuessNeutralKilling = CustomOption.CreateToggle(253, Types.Impostor, "Assassin Can Guess Neutral Killing Roles", false, Assassin);
            AssassinGuessImpostors = CustomOption.CreateToggle(254, Types.Impostor, "Assassin Can Guess Impostor Roles", false, Assassin);
            AssassinGuessModifiers = CustomOption.CreateToggle(255, Types.Impostor, "Assassin Can Guess Crewmate Modifiers", false, Assassin);
            AssassinGuessLovers = CustomOption.CreateToggle(256, Types.Impostor, "Assassin Can Guess Lovers", false, Assassin);

            ImpostorConcealingRoles = CustomOption.CreateHeader(196, Types.Impostor, "Impostor Concealing Roles");

            EscapistOn = CustomOption.CreateNumber(197, Types.Impostor, "<color=#FF0000FF>Escapist</color>", 0f, 0f, 100f, 10f, PercentFormat, ImpostorConcealingRoles, true);
            EscapeCooldown = CustomOption.CreateNumber(198, Types.Impostor, "Recall Cooldown", 30f, 10f, 60f, 2.5f, CooldownFormat, EscapistOn);
            EscapistVent = CustomOption.CreateToggle(199, Types.Impostor, "Escapist Can Vent", false, EscapistOn);

            GrenadierOn = CustomOption.CreateNumber(200, Types.Impostor, "<color=#FF0000FF>Grenadier</color>", 0f, 0f, 100f, 10f, PercentFormat, ImpostorConcealingRoles, true);
            GrenadeCooldown = CustomOption.CreateNumber(201, Types.Impostor, "Flash Grenade Cooldown", 30f, 10f, 60f, 2.5f, CooldownFormat, GrenadierOn);
            GrenadeDuration = CustomOption.CreateNumber(202, Types.Impostor, "Flash Grenade Duration", 10f, 5f, 15f, 0.5f, CooldownFormat, GrenadierOn);
            FlashRadius = CustomOption.CreateNumber(203, Types.Impostor, "Flash Radius", 1f, 0.25f, 5f, 0.25f, MultiplierFormat, GrenadierOn);
            GrenadierIndicators = CustomOption.CreateToggle(204, Types.Impostor, "Indicate Flashed Crewmates", false, GrenadierOn);
            GrenadierVent = CustomOption.CreateToggle(205, Types.Impostor, "Grenadier Can Vent", false, GrenadierOn);

            MorphlingOn = CustomOption.CreateNumber(206, Types.Impostor, "<color=#FF0000FF>Morphling</color>", 0f, 0f, 100f, 10f, PercentFormat, ImpostorConcealingRoles, true);
            MorphlingCooldown = CustomOption.CreateNumber(207, Types.Impostor, "Morphling Cooldown", 30f, 10f, 60f, 2.5f, CooldownFormat, MorphlingOn);
            MorphlingDuration = CustomOption.CreateNumber(208, Types.Impostor, "Morphling Duration", 10f, 5f, 15f, 0.5f, CooldownFormat, MorphlingOn);
            MorphlingVent = CustomOption.CreateToggle(209, Types.Impostor, "Morphling Can Vent", false, MorphlingOn);

            SwooperOn = CustomOption.CreateNumber(210, Types.Impostor, "<color=#FF0000FF>Swooper</color>", 0f, 0f, 100f, 10f, PercentFormat, ImpostorConcealingRoles, true);
            SwoopCooldown = CustomOption.CreateNumber(211, Types.Impostor, "Swoop Cooldown", 30f, 10f, 60f, 2.5f, CooldownFormat, SwooperOn);
            SwoopDuration = CustomOption.CreateNumber(212, Types.Impostor, "Swoop Duration", 10f, 5f, 15f, 0.5f, CooldownFormat, SwooperOn);
            SwooperVent = CustomOption.CreateToggle(213, Types.Impostor, "Swooper Can Vent", false, SwooperOn);

            VenererOn = CustomOption.CreateNumber(214, Types.Impostor, "<color=#FF0000FF>Venerer</color>", 0f, 0f, 100f, 10f, PercentFormat, ImpostorConcealingRoles, true);
            AbilityCooldown = CustomOption.CreateNumber(215, Types.Impostor, "Ability Cooldown", 30f, 10f, 60f, 2.5f, CooldownFormat, VenererOn);
            AbilityDuration = CustomOption.CreateNumber(216, Types.Impostor, "Ability Duration", 10f, 5f, 15f, 0.5f, CooldownFormat, VenererOn);
            SprintSpeed = CustomOption.CreateNumber(217, Types.Impostor, "Sprint Speed", 1.25f, 1.05f, 2.5f, 0.05f, MultiplierFormat, VenererOn);
            FreezeSpeed = CustomOption.CreateNumber(218, Types.Impostor, "Freeze Speed", 0.75f, 0.05f, 0.95f, 0.05f, MultiplierFormat, VenererOn);


            ImpostorKillingRoles = CustomOption.CreateHeader(219, Types.Impostor, "Impostor Killing Roles");

            BomberOn = CustomOption.CreateNumber(220, Types.Impostor, "<color=#FF0000FF>Bomber</color>", 0f, 0f, 100f, 10f, PercentFormat, ImpostorKillingRoles, true);
            DetonateDelay = CustomOption.CreateNumber(221, Types.Impostor, "Detonate Delay", 5f, 1f, 15f, 0.5f, CooldownFormat, BomberOn);
            MaxKillsInDetonation = CustomOption.CreateNumber(222, Types.Impostor, "Max Kills In Detonation", 5f, 1f, 15f, 1f, null, BomberOn);
            DetonateRadius = CustomOption.CreateNumber(223, Types.Impostor, "Detonate Radius", 0.25f, 0.05f, 1f, 0.05f, MultiplierFormat, BomberOn);
            BomberVent = CustomOption.CreateToggle(224, Types.Impostor, "Bomber Can Vent", false, BomberOn);

            TraitorOn = CustomOption.CreateNumber(225, Types.Impostor, "<color=#FF0000FF>Traitor</color>", 0f, 0f, 100f, 10f, PercentFormat, ImpostorKillingRoles, true);
            LatestSpawn = CustomOption.CreateNumber(226, Types.Impostor, "Minimum People Alive When Traitor Can Spawn", 5, 3, 15, 1, null, TraitorOn);
            NeutralKillingStopsTraitor = CustomOption.CreateToggle(227, Types.Impostor, "Traitor Won't Spawn If Any Neutral Killing Is Alive", false, TraitorOn);

            WarlockOn = CustomOption.CreateNumber(228, Types.Impostor, "<color=#FF0000FF>Warlock</color>", 0f, 0f, 100f, 10f, PercentFormat, ImpostorKillingRoles, true);
            ChargeUpDuration = CustomOption.CreateNumber(229, Types.Impostor, "Time It Takes To Fully Charge", 30f, 10f, 60f, 2.5f, CooldownFormat, WarlockOn);
            ChargeUseDuration = CustomOption.CreateNumber(230, Types.Impostor, "Time It Takes To Use Full Charge", 1f, 0.05f, 5f, 0.05f, CooldownFormat, WarlockOn);


            ImpostorSupportRoles = CustomOption.CreateHeader(231, Types.Impostor, "Impostor Support Roles");

            BlackmailerOn = CustomOption.CreateNumber(232, Types.Impostor, "<color=#FF0000FF>Blackmailer</color>", 0f, 0f, 100f, 10f, PercentFormat, ImpostorSupportRoles, true);
            BlackmailCooldown = CustomOption.CreateNumber(233, Types.Impostor, "Initial Blackmail Cooldown", 10f, 1f, 15f, 0.5f, CooldownFormat, BlackmailerOn);

            JanitorOn = CustomOption.CreateNumber(234, Types.Impostor, "<color=#FF0000FF>Janitor</color>", 0f, 0f, 100f, 10f, PercentFormat, ImpostorSupportRoles, true);

            MinerOn = CustomOption.CreateNumber(235, Types.Impostor, "<color=#FF0000FF>Miner</color>", 0f, 0f, 100f, 10f, PercentFormat, ImpostorSupportRoles, true);
            MineCooldown = CustomOption.CreateNumber(236, Types.Impostor, "Mine Cooldown", 30f, 10f, 60f, 2.5f, CooldownFormat, MinerOn);

            UndertakerOn = CustomOption.CreateNumber(237, Types.Impostor, "<color=#FF0000FF>Undertaker</color>", 0f, 0f, 100f, 10f, PercentFormat, ImpostorSupportRoles, true);
            DragCooldown = CustomOption.CreateNumber(238, Types.Impostor, "Drag Cooldown", 30f, 10f, 60f, 2.5f, CooldownFormat, UndertakerOn);
            UndertakerDragSpeed = CustomOption.CreateNumber(239, Types.Impostor, "Undertaker Drag Speed", 0.75f, 0.25f, 1f, 0.05f, MultiplierFormat, UndertakerOn);
            UndertakerVent = CustomOption.CreateToggle(240, Types.Impostor, "Undertaker Can Vent", false, UndertakerOn);
            UndertakerVentWithBody = CustomOption.CreateToggle(241, Types.Impostor, "Undertaker Can Vent While Dragging", false, UndertakerOn);


            CrewmateModifiers = CustomOption.CreateHeader(258, Types.Modifier, "Crewmate Modifiers");

            AftermathOn = CustomOption.CreateNumber(259, Types.Modifier, "<color=#A6FFA6FF>Aftermath</color>", 0f, 0f, 100f, 10f, PercentFormat, CrewmateModifiers, true);

            BaitOn = CustomOption.CreateNumber(260, Types.Modifier, "<color=#00B3B3FF>Bait</color>", 0f, 0f, 100f, 10f, PercentFormat, CrewmateModifiers, true);
            BaitMinDelay = CustomOption.CreateNumber(261, Types.Modifier, "Minimum Delay for the Bait Report", 0f, 0f, 15f, 0.5f, CooldownFormat, BaitOn);
            BaitMaxDelay = CustomOption.CreateNumber(262, Types.Modifier, "Maximum Delay for the Bait Report", 1f, 0f, 15f, 0.5f, CooldownFormat, BaitOn);

            DiseasedOn = CustomOption.CreateNumber(263, Types.Modifier, "<color=#808080FF>Diseased</color>", 0f, 0f, 100f, 10f, PercentFormat, CrewmateModifiers, true);
            DiseasedKillMultiplier = CustomOption.CreateNumber(264, Types.Modifier, "Diseased Kill Multiplier", 3f, 1.5f, 5f, 0.25f, MultiplierFormat, DiseasedOn);

            FrostyOn = CustomOption.CreateNumber(265, Types.Modifier, "<color=#99FFFFFF>Frosty</color>", 0f, 0f, 100f, 10f, PercentFormat, CrewmateModifiers, true);
            ChillDuration = CustomOption.CreateNumber(266, Types.Modifier, "Chill Duration", 10f, 1f, 15f, 0.5f, CooldownFormat, FrostyOn);
            ChillStartSpeed = CustomOption.CreateNumber(267, Types.Modifier, "Chill Start Speed", 0.75f, 0.25f, 0.95f, 0.05f, MultiplierFormat, FrostyOn);

            MultitaskerOn = CustomOption.CreateNumber(268, Types.Modifier, "<color=#FF804DFF>Multitasker</color>", 0f, 0f, 100f, 10f, PercentFormat, CrewmateModifiers, true);

            TorchOn = CustomOption.CreateNumber(269, Types.Modifier, "<color=#FFFF99FF>Torch</color>", 0f, 0f, 100f, 10f, PercentFormat, CrewmateModifiers, true);


            GlobalModifiers = CustomOption.CreateHeader(270, Types.Modifier, "Global Modifiers");

            ButtonBarryOn = CustomOption.CreateNumber(271, Types.Modifier, "<color=#E600FFFF>Button Barry</color>", 0f, 0f, 100f, 10f, PercentFormat, GlobalModifiers, true);

            FlashOn = CustomOption.CreateNumber(272, Types.Modifier, "<color=#FF8080FF>Flash</color>", 0f, 0f, 100f, 10f, PercentFormat, GlobalModifiers, true);
            FlashSpeed = CustomOption.CreateNumber(273, Types.Modifier, "Flash Speed", 1.25f, 1.05f, 2.5f, 0.05f, MultiplierFormat, FlashOn);

            GiantOn = CustomOption.CreateNumber(274, Types.Modifier, "<color=#FFB34DFF>Giant</color>", 0f, 0f, 100f, 10f, PercentFormat, GlobalModifiers, true);
            GiantSlow = CustomOption.CreateNumber(275, Types.Modifier, "Giant Speed", 0.75f, 0.25f, 1f, 0.05f, MultiplierFormat, GiantOn);

            LoversOn = CustomOption.CreateNumber(276, Types.Modifier, "<color=#FF66CCFF>Lovers</color>", 0f, 0f, 100f, 10f, PercentFormat, GlobalModifiers, true);
            BothLoversDie = CustomOption.CreateToggle(277, Types.Modifier, "Both Lovers Die", true, LoversOn);
            LovingImpPercent = CustomOption.CreateNumber(278, Types.Modifier, "Loving Impostor Probability", 0f, 0f, 100f, 10f, PercentFormat, LoversOn);
            NeutralLovers = CustomOption.CreateToggle(279, Types.Modifier, "Neutral Roles Can Be Lovers", false, LoversOn);

            RadarOn = CustomOption.CreateNumber(280, Types.Modifier, "<color=#FF0080FF>Radar</color>", 0f, 0f, 100f, 10f, PercentFormat, GlobalModifiers, true);

            SleuthOn = CustomOption.CreateNumber(281, Types.Modifier, "<color=#803333FF>Sleuth</color>", 0f, 0f, 100f, 10f, PercentFormat, GlobalModifiers, true);

            TiebreakerOn = CustomOption.CreateNumber(282, Types.Modifier, "<color=#99E699FF>Tiebreaker</color>", 0f, 0f, 100f, 10f, PercentFormat, GlobalModifiers, true);


            ImpostorModifiers = CustomOption.CreateHeader(283, Types.Modifier, "Impostor Modifiers");

            DisperserOn = CustomOption.CreateNumber(284, Types.Modifier, "<color=#FF0000FF>Disperser</color>", 0f, 0f, 100f, 10f, PercentFormat, ImpostorModifiers, true);

            DoubleShotOn = CustomOption.CreateNumber(285, Types.Modifier, "<color=#FF0000FF>Double Shot</color>", 0f, 0f, 100f, 10f, PercentFormat, ImpostorModifiers, true);

            UnderdogOn = CustomOption.CreateNumber(286, Types.Modifier, "<color=#FF0000FF>Underdog</color>", 0f, 0f, 100f, 10f, PercentFormat, ImpostorModifiers, true);
            UnderdogKillBonus = CustomOption.CreateNumber(287, Types.Modifier, "Kill Cooldown Bonus", 30f, 2.5f, 60f, 2.5f, CooldownFormat, UnderdogOn);
            UnderdogIncreasedKC = CustomOption.CreateToggle(288, Types.Modifier, "Increased Kill Cooldown When 2+ Imps", true, UnderdogOn);

            GameModeSettings = CustomOption.CreateHeader(289, Types.General, "Game Mode Settings");
            GameMode = CustomOption.CreateString(290, Types.General, "Game Mode", new[] { "Classic", "All Any", "Killing Only", "Cultist" }, GameModeSettings);

            ClassicSettings = CustomOption.CreateHeader(359, Types.General, "Classic Game Mode Settings", false, Gamemode.Classic);
            MinNeutralBenignRoles = CustomOption.CreateNumber(292, Types.General, "Min Neutral Benign Roles", 1f, 0f, 3f, 1f, null, ClassicSettings, false, false, Gamemode.Classic);
            MaxNeutralBenignRoles = CustomOption.CreateNumber(293, Types.General, "Max Neutral Benign Roles", 1f, 0f, 3f, 1f, null, ClassicSettings, false, false, Gamemode.Classic);
            MinNeutralEvilRoles = CustomOption.CreateNumber(294, Types.General, "Min Neutral Evil Roles", 1f, 0f, 3f, 1f, null, ClassicSettings, false, false, Gamemode.Classic);
            MaxNeutralEvilRoles = CustomOption.CreateNumber(295, Types.General, "Max Neutral Evil Roles", 1f, 0f, 3f, 1f, null, ClassicSettings, false, false, Gamemode.Classic);
            MinNeutralKillingRoles = CustomOption.CreateNumber(296, Types.General, "Min Neutral Killing Roles", 1f, 0f, 5f, 1f, null, ClassicSettings, false, false, Gamemode.Classic);
            MaxNeutralKillingRoles = CustomOption.CreateNumber(297, Types.General, "Max Neutral Killing Roles", 1f, 0f, 5f, 1f, null, ClassicSettings, false, false, Gamemode.Classic);

            AllAnySettings = CustomOption.CreateHeader(360, Types.General, "All Any Game Mode Settings", false, Gamemode.AllAny);
            RandomNumberImps = CustomOption.CreateToggle(298, Types.General, "Random Number Of Impostors", true, AllAnySettings, false, false, Gamemode.AllAny);

            KillingOnlySettings = CustomOption.CreateHeader(361, Types.General, "Killing Only Game Mode Settings", false, Gamemode.KillingOnly);
            NeutralRoles = CustomOption.CreateNumber(299, Types.General, "Neutral Roles", 1, 0, 5, 1, null, KillingOnlySettings, false, false, Gamemode.KillingOnly);
            VeteranCount = CustomOption.CreateNumber(300, Types.General, "Veteran Count", 1, 0, 5, 1, null, KillingOnlySettings, false, false, Gamemode.KillingOnly);
            VigilanteCount = CustomOption.CreateNumber(301, Types.General, "Vigilante Count", 1, 0, 5, 1, null, KillingOnlySettings, false, false, Gamemode.KillingOnly);
            AddArsonist = CustomOption.CreateToggle(302, Types.General, "Add Arsonist", true, KillingOnlySettings, false, false, Gamemode.KillingOnly);
            AddPlaguebearer = CustomOption.CreateToggle(303, Types.General, "Add Plaguebearer", true, KillingOnlySettings, false, false, Gamemode.KillingOnly);

            CultistSettings = CustomOption.CreateHeader(362, Types.General, "Cultist Game Mode Settings", false, Gamemode.Cultist);
            MayorCultistOn = CustomOption.CreateNumber(304, Types.General, "<color=#704FA8FF>Mayor</color> (Cultist Mode)", 100f, 0f, 100f, 10f, PercentFormat, CultistSettings, false, false, Gamemode.Cultist);
            SeerCultistOn = CustomOption.CreateNumber(305, Types.General, "<color=#FFCC80FF>Seer</color> (Cultist Mode)", 100f, 0f, 100f, 10f, PercentFormat, CultistSettings, false, false, Gamemode.Cultist);
            SheriffCultistOn = CustomOption.CreateNumber(306, Types.General, "<color=#FFFF00FF>Sheriff</color> (Cultist Mode)", 100f, 0f, 100f, 10f, PercentFormat, CultistSettings, false, false, Gamemode.Cultist);
            SurvivorCultistOn = CustomOption.CreateNumber(307, Types.General, "<color=#FFE64DFF>Survivor</color> (Cultist Mode)", 100f, 0f, 100f, 10f, PercentFormat, CultistSettings, false, false, Gamemode.Cultist);
            NumberOfSpecialRoles = CustomOption.CreateNumber(308, Types.General, "Number Of Special Roles", 4f, 0f, 4f, 1f, null, CultistSettings, false, false, Gamemode.Cultist);
            MaxChameleons = CustomOption.CreateNumber(309, Types.General, "Max Chameleons", 3f, 0f, 5f, 1f, null, CultistSettings, false, false, Gamemode.Cultist);
            MaxEngineers = CustomOption.CreateNumber(310, Types.General, "Max Engineers", 3f, 0f, 5f, 1f, null, CultistSettings, false, false, Gamemode.Cultist);
            MaxInvestigators = CustomOption.CreateNumber(311, Types.General, "Max Investigators", 3f, 0f, 5f, 1f, null, CultistSettings, false, false, Gamemode.Cultist);
            MaxMystics = CustomOption.CreateNumber(312, Types.General, "Max Mystics", 3f, 0f, 5f, 1f, null, CultistSettings, false, false, Gamemode.Cultist);
            MaxSnitches = CustomOption.CreateNumber(313, Types.General, "Max Snitches", 3f, 0f, 5f, 1f, null, CultistSettings, false, false, Gamemode.Cultist);
            MaxSpies = CustomOption.CreateNumber(314, Types.General, "Max Spies", 3f, 0f, 5f, 1f, null, CultistSettings, false, false, Gamemode.Cultist);
            MaxTransporters = CustomOption.CreateNumber(315, Types.General, "Max Transporters", 3f, 0f, 5f, 1f, null, CultistSettings, false, false, Gamemode.Cultist);
            MaxVigilantes = CustomOption.CreateNumber(316, Types.General, "Max Vigilantes", 3f, 0f, 5f, 1f, null, CultistSettings, false, false, Gamemode.Cultist);
            WhisperCooldown = CustomOption.CreateNumber(317, Types.General, "Initial Whisper Cooldown", 30f, 10f, 60f, 2.5f, CooldownFormat, CultistSettings, false, false, Gamemode.Cultist);
            IncreasedCooldownPerWhisper = CustomOption.CreateNumber(318, Types.General, "Increased Cooldown Per Whisper", 5f, 0f, 15f, 0.5f, CooldownFormat, CultistSettings, false, false, Gamemode.Cultist);
            WhisperRadius = CustomOption.CreateNumber(319, Types.General, "Whisper Radius", 1f, 0.25f, 5f, 0.25f, MultiplierFormat, CultistSettings, false, false, Gamemode.Cultist);
            ConversionPercentage = CustomOption.CreateNumber(320, Types.General, "Conversion Percentage", 25f, 0f, 100f, 5f, PercentFormat, CultistSettings, false, false, Gamemode.Cultist);
            DecreasedPercentagePerConversion = CustomOption.CreateNumber(321, Types.General, "Decreased Conversion Percentage Per Conversion", 5f, 0f, 15f, 1f, PercentFormat, CultistSettings, false, false, Gamemode.Cultist);
            ReviveCooldown = CustomOption.CreateNumber(322, Types.General, "Initial Revive Cooldown", 30f, 10f, 60f, 2.5f, CooldownFormat, CultistSettings, false, false, Gamemode.Cultist);
            IncreasedCooldownPerRevive = CustomOption.CreateNumber(323, Types.General, "Increased Cooldown Per Revive", 30f, 10f, 60f, 2.5f, CooldownFormat, CultistSettings, false, false, Gamemode.Cultist);
            MaxReveals = CustomOption.CreateNumber(324, Types.General, "Maximum Number Of Reveals", 5f, 1f, 15f, 1f, null, CultistSettings, false, false, Gamemode.Cultist);

            BetterPolusSettings = CustomOption.CreateHeader(340, Types.General, "Better Polus Settings");
            VentImprovements = CustomOption.CreateToggle(341, Types.General, "Better Polus Vent Layout", false, BetterPolusSettings);
            VitalsLab = CustomOption.CreateToggle(342, Types.General, "Vitals Moved To Lab", false, BetterPolusSettings);
            ColdTempDeathValley = CustomOption.CreateToggle(343, Types.General, "Cold Temp Moved To Death Valley", false, BetterPolusSettings);
            WifiChartCourseSwap = CustomOption.CreateToggle(344, Types.General, "Reboot Wifi And Chart Course Swapped", false, BetterPolusSettings);

            CustomGameSettings = CustomOption.CreateHeader(345, Types.General, "Custom Game Settings");
            ColourblindComms = CustomOption.CreateToggle(346, Types.General, "Camouflaged Comms", false, CustomGameSettings);
            ImpostorSeeRoles = CustomOption.CreateToggle(347, Types.General, "Impostors Can See The Roles Of Their Team", false, CustomGameSettings);
            DeadSeeRoles = CustomOption.CreateToggle(348, Types.General, "Dead Can See Everyone's Roles/Votes", false, CustomGameSettings);
            InitialCooldowns = CustomOption.CreateNumber(349, Types.General, "Game Start Cooldowns", 10f, 10f, 30f, 2.5f, CooldownFormat, CustomGameSettings);
            ParallelMedScans = CustomOption.CreateToggle(350, Types.General, "Parallel Medbay Scans", false, CustomGameSettings);
            SkipButtonDisable = CustomOption.CreateString(351, Types.General, "Disable Meeting Skip Button", new[] { "No", "Emergency", "Always" }, CustomGameSettings);
            HiddenRoles = CustomOption.CreateToggle(352, Types.General, "Enable Hidden Roles", true, CustomGameSettings);
            FirstDeathShield = CustomOption.CreateToggle(353, Types.General, "First Death Shield Next Game", false, CustomGameSettings);
            NeutralEvilWinEndsGame = CustomOption.CreateToggle(354, Types.General, "Neutral Evil Win Ends Game", false, CustomGameSettings);

            BlockGameEndHeader = CustomOption.CreateHeader(445, Types.General, "Block Game Ending");
            BlockGameEnd = CustomOption.CreateToggle(446, Types.General, "Power Crewmates Block Game End", false, BlockGameEndHeader);
            SheriffBlockGameEnd = CustomOption.CreateToggle(447, Types.General, "Block Game End If Sheriff Is Alive", false, BlockGameEnd);
            VeteranBlockGameEnd = CustomOption.CreateToggle(448, Types.General, "Block Game End If Veteran Is Alive", false, BlockGameEnd);
            MayorBlockGameEnd = CustomOption.CreateToggle(449, Types.General, "Block Game End If Mayor Is Alive", false, BlockGameEnd);
            SwapperBlockGameEnd = CustomOption.CreateToggle(450, Types.General, "Block Game End If Swapper Is Alive", false, BlockGameEnd);
            TiebreakerBlockGameEnd = CustomOption.CreateToggle(451, Types.General, "Block Game End If Crew Tiebreaker Is Alive", false, BlockGameEnd);

            TaskTrackingSettings = CustomOption.CreateHeader(355, Types.General, "Task Tracking Settings");
            SeeTasksDuringRound = CustomOption.CreateToggle(356, Types.General, "See Tasks During Round", false, TaskTrackingSettings);
            SeeTasksDuringMeeting = CustomOption.CreateToggle(357, Types.General, "See Tasks During Meetings", false, TaskTrackingSettings);
            SeeTasksWhenDead = CustomOption.CreateToggle(358, Types.General, "See Tasks When Dead", true, TaskTrackingSettings);
            
            MapSettings = CustomOption.CreateHeader(325, Types.General, "Map Settings");
            RandomMapEnabled = CustomOption.CreateToggle(326, Types.General, "Choose Random Map", false, MapSettings);
            RandomMapSkeld = CustomOption.CreateNumber(327, Types.General, "Skeld Chance", 0f, 0f, 100f, 10f, PercentFormat, RandomMapEnabled);
            RandomMapMira = CustomOption.CreateNumber(328, Types.General, "Mira Chance", 0f, 0f, 100f, 10f, PercentFormat, RandomMapEnabled);
            RandomMapPolus = CustomOption.CreateNumber(329, Types.General, "Polus Chance", 0f, 0f, 100f, 10f, PercentFormat, RandomMapEnabled);
            RandomMapAirship = CustomOption.CreateNumber(330, Types.General, "Airship Chance", 0f, 0f, 100f, 10f, PercentFormat, RandomMapEnabled);
            RandomMapFungle = CustomOption.CreateNumber(363, Types.General, "The Fungle Chance", 0f, 0f, 100f, 10f, PercentFormat, RandomMapEnabled);
            RandomMapSubmerged = CustomOption.CreateNumber(331, Types.General, "Submerged Chance", 0f, 0f, 100f, 10f, PercentFormat, RandomMapEnabled);
            AutoAdjustSettings = CustomOption.CreateToggle(332, Types.General, "Auto Adjust Settings", false, RandomMapEnabled);
            SmallMapHalfVision = CustomOption.CreateToggle(333, Types.General, "Half Vision On Skeld/Mira HQ", false, RandomMapEnabled);
            SmallMapDecreasedCooldown = CustomOption.CreateNumber(334, Types.General, "Mira HQ Decreased Cooldowns", 0f, 0f, 15f, 2.5f, CooldownFormat, RandomMapEnabled);
            LargeMapIncreasedCooldown = CustomOption.CreateNumber(335, Types.General, "Airship/Submerged Increased Cooldowns", 0f, 0f, 15f, 2.5f, CooldownFormat, RandomMapEnabled);
            SmallMapIncreasedShortTasks = CustomOption.CreateNumber(336, Types.General, "Skeld/Mira HQ Increased Short Tasks", 0f, 0f, 5f, 1f, null, RandomMapEnabled);
            SmallMapIncreasedLongTasks = CustomOption.CreateNumber(337, Types.General, "Skeld/Mira HQ Increased Long Tasks", 0f, 0f, 3f, 1f, null, RandomMapEnabled);
            LargeMapDecreasedShortTasks = CustomOption.CreateNumber(338, Types.General, "Airship/Submerged Decreased Short Tasks", 0f, 0f, 5f, 1f, null, RandomMapEnabled);
            LargeMapDecreasedLongTasks = CustomOption.CreateNumber(339, Types.General, "Airship/Submerged Decreased Long Tasks", 0f, 0f, 3f, 1f, null, RandomMapEnabled);
        }
    }
}