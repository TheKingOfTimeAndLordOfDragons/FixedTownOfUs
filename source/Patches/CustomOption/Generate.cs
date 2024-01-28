using System;
using TownOfUs.Extensions;
using TownOfUs.Patches;
using Gamemode = TownOfUs.GameMode;
using Types = TownOfUs.CustomOption.CustomOption.CustomOptionType;

namespace TownOfUs.CustomOption
{
    public class Generate
    {
        public static string[] presets = new string[]{ "option.generate.preset.one", "option.generate.preset.two", "option.generate.preset.three" };

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
        public static CustomOption VigilanteBlockGameEnd;
        public static CustomOption ProsecutorBlockGameEnd;
        public static CustomOption VampireHunterBlockGameEnd;
        public static CustomOption TiebreakerBlockGameEnd;
        
        public static CustomOption DrunkOn;
        
        public static CustomOption BlindOn;
        
        public static CustomOption LighterOn;
        public static CustomOption LighterCooldown;
        public static CustomOption LighterDuration;
        public static CustomOption LighterLightsOn;
        public static CustomOption LighterLightsOff;

        public static Func<float, string> PercentFormat { get; } = (float value) => $"{value:0}%";
        public static Func<float, string> CooldownFormat { get; } = (float value) => $"{value:0.0#}{Language.GetString("option.generate.format.seconds")}";
        public static Func<float, string> MultiplierFormat { get; } = (float value) => $"{value:0.0#}x";
        public static GameMode CurrentGameMode
            => GameMode.Get() == 0 ? Gamemode.Classic : (GameMode.Get() == 1 ? Gamemode.AllAny : (GameMode.Get() == 2 ? Gamemode.KillingOnly : (GameMode.Get() == 3 ? Gamemode.Cultist : Gamemode.All)));

        public static void GenerateAll()
        {
            CustomOption.baseSettings = TownOfUs.Instance.Config.Bind("Preset0", "VanillaOptions", "");
            presetSelection = CustomOption.CreateString(0, Types.General, Language.GetString("option.generate.preset"), presets, null, true);

            CrewInvestigativeRoles = CustomOption.CreateHeader(100, Types.Crewmate, Language.GetString("option.generate.crewmate.investigative.header"));

            AurialOn = CustomOption.CreateNumber(1, Types.Crewmate, Utils.cs(Colors.Aurial, Language.GetString("option.generate.crewmate.aurial")), 0f, 0f, 100f, 10f, PercentFormat, CrewInvestigativeRoles, true);
            RadiateRange = CustomOption.CreateNumber(2, Types.Crewmate, Language.GetString("option.generate.crewmate.aurial.range"), 1f, 0.25f, 5f, 0.25f, MultiplierFormat, AurialOn);
            RadiateCooldown = CustomOption.CreateNumber(3, Types.Crewmate, Language.GetString("option.generate.crewmate.aurial.cooldown"), 30f, 10f, 60f, 2.5f, CooldownFormat, AurialOn);
            RadiateInvis = CustomOption.CreateNumber(4, Types.Crewmate, Language.GetString("option.generate.crewmate.aurial.delay"), 10f, 0f, 15f, 1f, CooldownFormat, AurialOn);
            RadiateCount = CustomOption.CreateNumber(5, Types.Crewmate, Language.GetString("option.generate.crewmate.aurial.uses"), 3, 1, 5, 1, null, AurialOn);
            RadiateSucceedChance = CustomOption.CreateNumber(6, Types.Crewmate, Language.GetString("option.generate.crewmate.aurial.chance"), 100f, 0f, 100f, 10f, PercentFormat, AurialOn);

            DetectiveOn = CustomOption.CreateNumber(7, Types.Crewmate, Utils.cs(Colors.Detective, Language.GetString("option.generate.crewmate.detective")), 0f, 0f, 100f, 10f, PercentFormat, CrewInvestigativeRoles, true);
            ExamineCooldown = CustomOption.CreateNumber(8, Types.Crewmate, Language.GetString("option.generate.crewmate.detective.cooldown"), 30f, 10f, 60f, 2.5f, CooldownFormat, DetectiveOn);
            DetectiveReportOn = CustomOption.CreateToggle(9, Types.Crewmate, Language.GetString("option.generate.crewmate.detective.report"), true, DetectiveOn);
            DetectiveRoleDuration = CustomOption.CreateNumber(10, Types.Crewmate, Language.GetString("option.generate.crewmate.detective.report.role"), 15f, 0f, 60f, 0.5f, CooldownFormat, DetectiveReportOn);
            DetectiveFactionDuration = CustomOption.CreateNumber(11, Types.Crewmate, Language.GetString("option.generate.crewmate.detective.report.faction"), 30f, 0f, 60f, 0.5f, CooldownFormat, DetectiveReportOn);
            CanDetectLastKiller = CustomOption.CreateToggle(12, Types.Crewmate, Language.GetString("option.generate.crewmate.detective.detect"), false, DetectiveOn);

            HaunterOn = CustomOption.CreateNumber(13, Types.Crewmate, Utils.cs(Colors.Haunter, Language.GetString("option.generate.crewmate.haunter")), 0f, 0f, 100f, 10f, PercentFormat, CrewInvestigativeRoles, true);
            HaunterTasksRemainingClicked = CustomOption.CreateNumber(14, Types.Crewmate, Language.GetString("option.generate.crewmate.haunter.tasks.click"), 5f, 1f, 15f, 1f, null, HaunterOn);
            HaunterTasksRemainingAlert = CustomOption.CreateNumber(15, Types.Crewmate, Language.GetString("option.generate.crewmate.haunter.tasks.alert"), 1, 1, 5, 1, null, HaunterOn);
            HaunterRevealsNeutrals = CustomOption.CreateToggle(16, Types.Crewmate, Language.GetString("option.generate.crewmate.haunter.neutral"), false, HaunterOn);
            HaunterCanBeClickedBy = CustomOption.CreateString(17, Types.Crewmate, Language.GetString("option.generate.crewmate.haunter.click"), new[] { "option.generate.crewmate.haunter.click.all", "option.generate.crewmate.haunter.click.noncrew", "option.generate.crewmate.haunter.click.impsonly" }, HaunterOn);

            InvestigatorOn = CustomOption.CreateNumber(18, Types.Crewmate, Utils.cs(Colors.Investigator, Language.GetString("option.generate.crewmate.investigator")), 0f, 0f, 100f, 10f, PercentFormat, CrewInvestigativeRoles, true);
            FootprintSize = CustomOption.CreateNumber(19, Types.Crewmate, Language.GetString("option.generate.crewmate.investigator.size"), 4f, 1f, 10f, 1f, null, InvestigatorOn);
            FootprintInterval = CustomOption.CreateNumber(20, Types.Crewmate, Language.GetString("option.generate.crewmate.investigator.interval"), 0.1f, 0.05f, 1f, 0.05f, CooldownFormat, InvestigatorOn);
            FootprintDuration = CustomOption.CreateNumber(21, Types.Crewmate, Language.GetString("option.generate.crewmate.investigator.duration"), 10f, 1f, 15f, 0.5f, CooldownFormat, InvestigatorOn);
            AnonymousFootPrint = CustomOption.CreateToggle(22, Types.Crewmate, Language.GetString("option.generate.crewmate.investigator.anonymous"), false, InvestigatorOn);
            VentFootprintVisible = CustomOption.CreateToggle(23, Types.Crewmate, Language.GetString("option.generate.crewmate.investigator.vent"), false, InvestigatorOn);

            MysticOn = CustomOption.CreateNumber(24, Types.Crewmate, Utils.cs(Colors.Mystic, Language.GetString("option.generate.crewmate.mystic")), 0f, 0f, 100f, 10f, PercentFormat, CrewInvestigativeRoles, true);
            MysticArrowDuration = CustomOption.CreateNumber(25, Types.Crewmate, Language.GetString("option.generate.crewmate.mystic.duration"), 0.1f, 0f, 1f, 0.05f, CooldownFormat, MysticOn);

            OracleOn = CustomOption.CreateNumber(26, Types.Crewmate, Utils.cs(Colors.Oracle, Language.GetString("option.generate.crewmate.oracle")), 0f, 0f, 100f, 10f, PercentFormat, CrewInvestigativeRoles, true);
            ConfessCooldown = CustomOption.CreateNumber(27, Types.Crewmate, Language.GetString("option.generate.crewmate.oracle.cooldown"), 30f, 10f, 60f, 2.5f, CooldownFormat, OracleOn);
            RevealAccuracy = CustomOption.CreateNumber(28, Types.Crewmate, Language.GetString("option.generate.crewmate.oracle.accuracy"), 80f, 0f, 100f, 10f, PercentFormat, OracleOn);
            NeutralBenignShowsEvil = CustomOption.CreateToggle(29, Types.Crewmate, Language.GetString("option.generate.crewmate.oracle.benign.evil"), false, OracleOn);
            NeutralEvilShowsEvil = CustomOption.CreateToggle(30, Types.Crewmate, Language.GetString("option.generate.crewmate.oracle.evil.evil"), false, OracleOn);
            NeutralKillingShowsEvil = CustomOption.CreateToggle(31, Types.Crewmate, Language.GetString("option.generate.crewmate.oracle.killing.evil"), true, OracleOn);

            SeerOn = CustomOption.CreateNumber(32, Types.Crewmate, Utils.cs(Colors.Seer, Language.GetString("option.generate.crewmate.seer")), 0f, 0f, 100f, 10f, PercentFormat, CrewInvestigativeRoles, true);
            SeerCooldown = CustomOption.CreateNumber(33, Types.Crewmate, Language.GetString("option.generate.crewmate.seer.cooldown"), 30f, 10f, 60f, 2.5f, CooldownFormat, SeerOn);
            CrewKillingRed = CustomOption.CreateToggle(34, Types.Crewmate, Language.GetString("option.generate.crewmate.seer.crewmate.killing.red"), false, SeerOn);
            NeutBenignRed = CustomOption.CreateToggle(35, Types.Crewmate, Language.GetString("option.generate.crewmate.seer.neutral.benign.red"), false, SeerOn);
            NeutEvilRed = CustomOption.CreateToggle(36, Types.Crewmate, Language.GetString("option.generate.crewmate.seer.neutral.evil.red"), false, SeerOn);
            NeutKillingRed = CustomOption.CreateToggle(37, Types.Crewmate, Language.GetString("option.generate.crewmate.seer.neutral.killing.red"), true, SeerOn);
            TraitorColourSwap = CustomOption.CreateToggle(38, Types.Crewmate, Language.GetString("option.generate.crewmate.seer.traitor"), false, SeerOn);

            SnitchOn = CustomOption.CreateNumber(39, Types.Crewmate, Utils.cs(Colors.Snitch, Language.GetString("option.generate.crewmate.snitch")), 0f, 0f, 100f, 10f, PercentFormat, CrewInvestigativeRoles, true);
            SnitchSeesNeutrals = CustomOption.CreateToggle(40, Types.Crewmate, Language.GetString("option.generate.crewmate.snitch.neutral"), false, SnitchOn);
            SnitchTasksRemaining = CustomOption.CreateNumber(41, Types.Crewmate, Language.GetString("option.generate.crewmate.snitch.tasks"), 1, 1, 5, 1, null, SnitchOn);
            SnitchSeesImpInMeeting = CustomOption.CreateToggle(42, Types.Crewmate, Language.GetString("option.generate.crewmate.snitch.meetings"), true, SnitchOn);
            SnitchSeesTraitor = CustomOption.CreateToggle(43, Types.Crewmate, Language.GetString("option.generate.crewmate.snitch.traitor"), true, SnitchOn);

            SpyOn = CustomOption.CreateNumber(44, Types.Crewmate, Utils.cs(Colors.Spy, Language.GetString("option.generate.crewmate.spy")), 0f, 0f, 100f, 10f, PercentFormat, CrewInvestigativeRoles, true);
            WhoSeesDead = CustomOption.CreateString(45, Types.Crewmate, Language.GetString("option.generate.crewmate.spy.dead"), new[] { "option.generate.crewmate.spy.dead.nobody", "option.generate.crewmate.spy.dead.spy", "option.generate.crewmate.spy.dead.everyone.spy", "option.generate.crewmate.spy.dead.everyone" }, SpyOn);

            TrackerOn = CustomOption.CreateNumber(46, Types.Crewmate, Utils.cs(Colors.Tracker, Language.GetString("option.generate.crewmate.tracker")), 0f, 0f, 100f, 10f, PercentFormat, CrewInvestigativeRoles, true);
            UpdateInterval = CustomOption.CreateNumber(47, Types.Crewmate, Language.GetString("option.generate.crewmate.tracker.interval"), 5f, 0f, 15f, 0.25f, CooldownFormat, TrackerOn);
            TrackCooldown = CustomOption.CreateNumber(48, Types.Crewmate, Language.GetString("option.generate.crewmate.tracker.cooldown"), 30f, 10f, 60f, 2.5f, CooldownFormat, TrackerOn);
            ResetOnNewRound = CustomOption.CreateToggle(49, Types.Crewmate, Language.GetString("option.generate.crewmate.tracker.reset"), false, TrackerOn);
            MaxTracks = CustomOption.CreateNumber(50, Types.Crewmate, Language.GetString("option.generate.crewmate.tracker.maximum"), 5f, 1f, 15f, 1f, null, TrackerOn);

            TrapperOn = CustomOption.CreateNumber(51, Types.Crewmate, Utils.cs(Colors.Trapper, Language.GetString("option.generate.crewmate.trapper")), 0f, 0f, 100f, 10f, PercentFormat, CrewInvestigativeRoles, true);
            MinAmountOfTimeInTrap = CustomOption.CreateNumber(52, Types.Crewmate, Language.GetString("option.generate.crewmate.trapper.mintime"), 1f, 0f, 15f, 0.25f, CooldownFormat, TrapperOn);
            TrapCooldown = CustomOption.CreateNumber(53, Types.Crewmate, Language.GetString("option.generate.crewmate.trapper.cooldown"), 30f, 10f, 60f, 2.5f, CooldownFormat, TrapperOn);
            TrapsRemoveOnNewRound = CustomOption.CreateToggle(54, Types.Crewmate, Language.GetString("option.generate.crewmate.trapper.reset"), true, TrapperOn);
            MaxTraps = CustomOption.CreateNumber(55, Types.Crewmate, Language.GetString("option.generate.crewmate.trapper.maximum"), 5f, 1f, 15f, 1f, null, TrapperOn);
            TrapSize = CustomOption.CreateNumber(56, Types.Crewmate, Language.GetString("option.generate.crewmate.trapper.size"), 0.25f, 0.05f, 1f, 0.05f, MultiplierFormat, TrapperOn);
            MinAmountOfPlayersInTrap = CustomOption.CreateNumber(57, Types.Crewmate, Language.GetString("option.generate.crewmate.trapper.minroles"), 3, 1, 5, 1, null, TrapperOn);


            CrewKillingRoles = CustomOption.CreateHeader(58, Types.Crewmate, Language.GetString("option.generate.crewmate.killing.header"));

            SheriffOn = CustomOption.CreateNumber(59, Types.Crewmate, Utils.cs(Colors.Sheriff, Language.GetString("option.generate.crewmate.sheriff")), 0f, 0f, 100f, 10f, PercentFormat, CrewKillingRoles, true);
            SheriffKillOther = CustomOption.CreateToggle(60, Types.Crewmate, Language.GetString("option.generate.crewmate.sheriff.misskill"), false, SheriffOn);
            SheriffKillsDoomsayer = CustomOption.CreateToggle(61, Types.Crewmate, Language.GetString("option.generate.crewmate.sheriff.doom"), false, SheriffOn);
            SheriffKillsExecutioner = CustomOption.CreateToggle(62, Types.Crewmate, Language.GetString("option.generate.crewmate.sheriff.exe"), false, SheriffOn);
            SheriffKillsJester = CustomOption.CreateToggle(63, Types.Crewmate, Language.GetString("option.generate.crewmate.sheriff.jest"), false, SheriffOn);
            SheriffKillsArsonist = CustomOption.CreateToggle(64, Types.Crewmate, Language.GetString("option.generate.crewmate.sheriff.ars"), false, SheriffOn);
            SheriffKillsGlitch = CustomOption.CreateToggle(65, Types.Crewmate, Language.GetString("option.generate.crewmate.sheriff.glitch"), false, SheriffOn);
            SheriffKillsJuggernaut = CustomOption.CreateToggle(66, Types.Crewmate, Language.GetString("option.generate.crewmate.sheriff.jugg"), false, SheriffOn);
            SheriffKillsPlaguebearer = CustomOption.CreateToggle(67, Types.Crewmate, Language.GetString("option.generate.crewmate.sheriff.plag"), false, SheriffOn);
            SheriffKillsVampire = CustomOption.CreateToggle(68, Types.Crewmate, Language.GetString("option.generate.crewmate.sheriff.vamp"), false, SheriffOn);
            SheriffKillsWerewolf = CustomOption.CreateToggle(69, Types.Crewmate, Language.GetString("option.generate.crewmate.sheriff.were"), false, SheriffOn);
            SheriffKillCd = CustomOption.CreateNumber(70, Types.Crewmate, Language.GetString("option.generate.crewmate.sheriff.cooldown"), 30f, 10f, 60f, 2.5f, CooldownFormat, SheriffOn);
            SheriffBodyReport = CustomOption.CreateToggle(71, Types.Crewmate, Language.GetString("option.generate.crewmate.sheriff.report"), true, SheriffOn);

            VampireHunterOn = CustomOption.CreateNumber(72, Types.Crewmate, Utils.cs(Colors.VampireHunter, Language.GetString("option.generate.crewmate.vh")), 0f, 0f, 100f, 10f, PercentFormat, CrewKillingRoles, true);
            StakeCooldown = CustomOption.CreateNumber(73, Types.Crewmate, Language.GetString("option.generate.crewmate.vh.cooldown"), 30f, 10f, 60f, 2.5f, CooldownFormat, VampireHunterOn);
            MaxFailedStakesPerGame = CustomOption.CreateNumber(74, Types.Crewmate, Language.GetString("option.generate.crewmate.vh.maximum"), 5f, 1f, 15f, 1f, null, VampireHunterOn);
            CanStakeRoundOne = CustomOption.CreateToggle(75, Types.Crewmate, Language.GetString("option.generate.crewmate.vh.canstake"), false, VampireHunterOn);
            SelfKillAfterFinalStake = CustomOption.CreateToggle(76, Types.Crewmate, Language.GetString("option.generate.crewmate.vh.selfkill"), false, VampireHunterOn);
            BecomeOnVampDeaths = CustomOption.CreateString(77, Types.Crewmate, Language.GetString("option.generate.crewmate.vh.become"), new[] { "option.generate.crewmate.crewmate", "option.generate.crewmate.sheriff", "option.generate.crewmate.veteran", "option.generate.crewmate.vigilante" }, VampireHunterOn);

            VeteranOn = CustomOption.CreateNumber(78, Types.Crewmate, Utils.cs(Colors.Veteran, Language.GetString("option.generate.crewmate.veteran")), 0f, 0f, 100f, 10f, PercentFormat, CrewKillingRoles, true);
            KilledOnAlert = CustomOption.CreateToggle(79, Types.Crewmate, Language.GetString("option.generate.crewmate.veteran.canbekilled"), false, VeteranOn);
            AlertCooldown = CustomOption.CreateNumber(80, Types.Crewmate, Language.GetString("option.generate.crewmate.veteran.cooldown"), 30f, 10f, 60f, 2.5f, CooldownFormat, VeteranOn);
            AlertDuration = CustomOption.CreateNumber(81, Types.Crewmate, Language.GetString("option.generate.crewmate.veteran.duration"), 10f, 5f, 15f, 0.5f, CooldownFormat, VeteranOn);
            MaxAlerts = CustomOption.CreateNumber(82, Types.Crewmate, Language.GetString("option.generate.crewmate.veteran.maximum"), 5f, 1f, 15f, 1f, null, VeteranOn);

            VigilanteOn = CustomOption.CreateNumber(83, Types.Crewmate, Utils.cs(Colors.Vigilante, Language.GetString("option.generate.crewmate.vigilante")), 0f, 0f, 100f, 10f, PercentFormat, CrewKillingRoles, true);
            VigilanteKills = CustomOption.CreateNumber(84, Types.Crewmate, Language.GetString("option.generate.crewmate.vigilante.kills"), 1, 1, 15, 1, null, VigilanteOn);
            VigilanteMultiKill = CustomOption.CreateToggle(85, Types.Crewmate, Language.GetString("option.generate.crewmate.vigilante.multi"), false, VigilanteOn);
            VigilanteGuessNeutralBenign = CustomOption.CreateToggle(86, Types.Crewmate, Language.GetString("option.generate.crewmate.vigilante.guess.benign"), false, VigilanteOn);
            VigilanteGuessNeutralEvil = CustomOption.CreateToggle(87, Types.Crewmate, Language.GetString("option.generate.crewmate.vigilante.guess.evil"), false, VigilanteOn);
            VigilanteGuessNeutralKilling = CustomOption.CreateToggle(88, Types.Crewmate, Language.GetString("option.generate.crewmate.vigilante.guess.killing"), false, VigilanteOn);
            VigilanteGuessLovers = CustomOption.CreateToggle(89, Types.Crewmate, Language.GetString("option.generate.crewmate.vigilante.guess.lovers"), false, VigilanteOn);


            CrewProtectiveRoles = CustomOption.CreateHeader(91, Types.Crewmate, Language.GetString("option.generate.crewmate.protective.header"));

            AltruistOn = CustomOption.CreateNumber(92, Types.Crewmate, Utils.cs(Colors.Altruist, Language.GetString("option.generate.crewmate.altruist")), 0f, 0f, 100f, 10f, PercentFormat, CrewProtectiveRoles, true);
            ReviveDuration = CustomOption.CreateNumber(93, Types.Crewmate, Language.GetString("option.generate.crewmate.altruist.duration"), 10f, 1f, 15f, 0.5f, CooldownFormat, AltruistOn);
            AltruistTargetBody = CustomOption.CreateToggle(94, Types.Crewmate, Language.GetString("option.generate.crewmate.altruist.disappear"), false, AltruistOn);

            MedicOn = CustomOption.CreateNumber(95, Types.Crewmate, Utils.cs(Colors.Medic, Language.GetString("option.generate.crewmate.medic")), 0f, 0f, 100f, 10f, PercentFormat, CrewProtectiveRoles, true);
            ShowShielded = CustomOption.CreateString(96, Types.Crewmate, Language.GetString("option.generate.crewmate.medic.show"), new[] { "option.generate.crewmate.medic.show.self", "option.generate.crewmate.medic.show.medic", "option.generate.crewmate.medic.show.sm", "option.generate.crewmate.medic.show.everyone" }, MedicOn);
            WhoGetsNotification = CustomOption.CreateString(97, Types.Crewmate, Language.GetString("option.generate.crewmate.medic.gets"), new[] { "option.generate.crewmate.medic.gets.medic", "option.generate.crewmate.medic.gets.shield", "option.generate.crewmate.medic.gets.everyone", "option.generate.crewmate.medic.gets.nobody" }, MedicOn);
            ShieldBreaks = CustomOption.CreateToggle(98, Types.Crewmate, Language.GetString("option.generate.crewmate.medic.break"), false, MedicOn);
            MedicReportSwitch = CustomOption.CreateToggle(99, Types.Crewmate, Language.GetString("option.generate.crewmate.medic.report"), true, MedicOn);
            MedicReportNameDuration = CustomOption.CreateNumber(101, Types.Crewmate, Language.GetString("option.generate.crewmate.medic.name"), 0f, 0f, 60f, 2.5f, CooldownFormat, MedicReportSwitch);
            MedicReportColorDuration = CustomOption.CreateNumber(102, Types.Crewmate, Language.GetString("option.generate.crewmate.medic.color"), 15f, 0f, 60f, 2.5f, CooldownFormat, MedicReportSwitch);


            CrewSupportRoles = CustomOption.CreateHeader(103, Types.Crewmate, Language.GetString("option.generate.crewmate.support.header"));

            EngineerOn = CustomOption.CreateNumber(104, Types.Crewmate, Utils.cs(Colors.Engineer, Language.GetString("option.generate.crewmate.engineer")), 0f, 0f, 100f, 10f, PercentFormat, CrewSupportRoles, true);
            MaxFixes = CustomOption.CreateNumber(105, Types.Crewmate, Language.GetString("option.generate.crewmate.engineer.fixes"), 5f, 1f, 15f, 1f, null, EngineerOn);

            ImitatorOn = CustomOption.CreateNumber(106, Types.Crewmate, Utils.cs(Colors.Imitator, Language.GetString("option.generate.crewmate.imitator")), 0f, 0f, 100f, 10f, PercentFormat, CrewSupportRoles, true);

            LighterOn = CustomOption.CreateNumber(455, Types.Crewmate, Utils.cs(Colors.Lighter, Language.GetString("option.generate.crewmate.lighter")), 0f, 0f, 100f, 10f, PercentFormat, CrewSupportRoles, true);
            LighterLightsOn = CustomOption.CreateNumber(456, Types.Crewmate, Language.GetString("option.generate.crewmate.lighter.ability.on"), 1.25f, 0.25f, 5f, 0.25f, MultiplierFormat, LighterOn);
            LighterLightsOff = CustomOption.CreateNumber(457, Types.Crewmate, Language.GetString("option.generate.crewmate.lighter.ability.off"), 0.75f, 0.25f, 5f, 0.25f, MultiplierFormat, LighterOn);
            LighterCooldown = CustomOption.CreateNumber(458, Types.Crewmate, Language.GetString("option.generate.crewmate.lighter.cooldown"), 30f, 10f, 60f, 2.5f, CooldownFormat, LighterOn);
            LighterDuration = CustomOption.CreateNumber(459, Types.Crewmate, Language.GetString("option.generate.crewmate.lighter.duration"), 10f, 5f, 15f, 0.5f, CooldownFormat, LighterOn);

            MayorOn = CustomOption.CreateNumber(107, Types.Crewmate, Language.GetString("option.generate.crewmate.mayor"), 0f, 0f, 100f, 10f, PercentFormat, CrewSupportRoles, true);

            MediumOn = CustomOption.CreateNumber(108, Types.Crewmate, Utils.cs(Colors.Medium, Language.GetString("option.generate.crewmate.medium")), 0f, 0f, 100f, 10f, PercentFormat, CrewSupportRoles, true);
            MediateCooldown = CustomOption.CreateNumber(109, Types.Crewmate, Language.GetString("option.generate.crewmate.medium.cooldown"), 10f, 1f, 15f, 0.5f, CooldownFormat, MediumOn);
            ShowMediatePlayer = CustomOption.CreateToggle(110, Types.Crewmate, Language.GetString("option.generate.crewmate.medium.reveal.appearance"), true, MediumOn);
            ShowMediumToDead = CustomOption.CreateToggle(111, Types.Crewmate, Language.GetString("option.generate.crewmate.medium.reveal.medium"), true, MediumOn);
            DeadRevealed = CustomOption.CreateString(112, Types.Crewmate, Language.GetString("option.generate.crewmate.medium.who"), new[] { "option.generate.crewmate.medium.who.old", "option.generate.crewmate.medium.who.new", "option.generate.crewmate.medium.who.all" }, MediumOn);

            ProsecutorOn = CustomOption.CreateNumber(113, Types.Crewmate, Utils.cs(Colors.Prosecutor, Language.GetString("option.generate.crewmate.prosecutor")), 0f, 0f, 100f, 10f, PercentFormat, CrewSupportRoles, true);
            ProsDiesOnIncorrectPros = CustomOption.CreateToggle(114, Types.Crewmate, Language.GetString("option.generate.crewmate.prosecutor.penalty"), false, ProsecutorOn);

            SwapperOn = CustomOption.CreateNumber(115, Types.Crewmate, Utils.cs(Colors.Swapper, Language.GetString("option.generate.crewmate.swapper")), 0f, 0f, 100f, 10f, PercentFormat, CrewSupportRoles, true);
            SwapperButton = CustomOption.CreateToggle(116, Types.Crewmate, Language.GetString("option.generate.crewmate.swapper.button"), true, SwapperOn);

            TransporterOn = CustomOption.CreateNumber(117, Types.Crewmate, Utils.cs(Colors.Transporter, Language.GetString("option.generate.crewmate.transporter")), 0f, 0f, 100f, 10f, PercentFormat, CrewSupportRoles, true);
            TransportCooldown = CustomOption.CreateNumber(118, Types.Crewmate, Language.GetString("option.generate.crewmate.transporter.cooldown"), 30f, 10f, 60f, 2.5f, CooldownFormat, TransporterOn);
            TransportMaxUses = CustomOption.CreateNumber(119, Types.Crewmate, Language.GetString("option.generate.crewmate.transporter.maximum"), 5f, 1f, 15f, 1f, null, TransporterOn);
            TransporterVitals = CustomOption.CreateToggle(120, Types.Crewmate, Language.GetString("option.generate.crewmate.transporter.vitals"), false, TransporterOn);


            NeutralBenignRoles = CustomOption.CreateHeader(121, Types.Neutral, Language.GetString("option.generate.neutral.benign.header"));

            AmnesiacOn = CustomOption.CreateNumber(122, Types.Neutral, Utils.cs(Colors.Amnesiac, Language.GetString("option.generate.neutral.amnesiac")), 0f, 0f, 100f, 10f, PercentFormat, NeutralBenignRoles, true);
            RememberArrows = CustomOption.CreateToggle(123, Types.Neutral, Language.GetString("option.generate.neutral.amnesiac.arrow"), false, AmnesiacOn);
            RememberArrowDelay = CustomOption.CreateNumber(124, Types.Neutral, Language.GetString("option.generate.neutral.amnesiac.delay"), 5f, 0f, 15f, 0.5f, CooldownFormat, RememberArrows);

            GuardianAngelOn = CustomOption.CreateNumber(125, Types.Neutral, Utils.cs(Colors.GuardianAngel, Language.GetString("option.generate.neutral.ga")), 0f, 0f, 100f, 10f, PercentFormat, NeutralBenignRoles, true);
            ProtectCd = CustomOption.CreateNumber(126, Types.Neutral, Language.GetString("option.generate.neutral.ga.cooldown"), 30f, 10f, 60f, 2.5f, CooldownFormat, GuardianAngelOn);
            ProtectDuration = CustomOption.CreateNumber(127, Types.Neutral, Language.GetString("option.generate.neutral.ga.duration"), 10f, 5f, 15f, 0.5f, CooldownFormat, GuardianAngelOn);
            ProtectKCReset = CustomOption.CreateNumber(128, Types.Neutral, Language.GetString("option.generate.neutral.ga.reset"), 30f, 0f, 60f, 2.5f, CooldownFormat, GuardianAngelOn);
            MaxProtects = CustomOption.CreateNumber(129, Types.Neutral, Language.GetString("option.generate.neutral.ga.maximum"), 5f, 1f, 15f, 1f, null, GuardianAngelOn);
            ShowProtect = CustomOption.CreateString(130, Types.Neutral, Language.GetString("option.generate.neutral.ga.show"), new[] { "option.generate.neutral.ga.show.self", "option.generate.neutral.ga", "option.generate.neutral.ga.show.selfga", "option.generate.neutral.ga.show.everyone" }, GuardianAngelOn);
            GaOnTargetDeath = CustomOption.CreateString(131, Types.Neutral, Language.GetString("option.generate.neutral.ga.become"), new[] { "option.generate.crewmate.crewmate", "option.generate.neutral.amnesiac", "option.generate.neutral.survivor", "option.generate.neutral.jester" }, GuardianAngelOn);
            GATargetKnows = CustomOption.CreateToggle(132, Types.Neutral, Language.GetString("option.generate.neutral.ga.exists"), false, GuardianAngelOn);
            GAKnowsTargetRole = CustomOption.CreateToggle(133, Types.Neutral, Language.GetString("option.generate.neutral.ga.role"), false, GuardianAngelOn);
            EvilTargetPercent = CustomOption.CreateNumber(134, Types.Neutral, Language.GetString("option.generate.neutral.ga.evil"), 0f, 0f, 100f, 10f, PercentFormat, GuardianAngelOn);

            SurvivorOn = CustomOption.CreateNumber(135, Types.Neutral, Utils.cs(Colors.Survivor, Language.GetString("option.generate.neutral.survivor")), 0f, 0f, 100f, 10f, PercentFormat, NeutralBenignRoles, true);
            VestCd = CustomOption.CreateNumber(136, Types.Neutral, Language.GetString("option.generate.neutral.survivor.cooldown"), 30f, 10f, 60f, 2.5f, CooldownFormat, SurvivorOn);
            VestDuration = CustomOption.CreateNumber(137, Types.Neutral, Language.GetString("option.generate.neutral.survivor.duration"), 10f, 5f, 15f, 0.5f, CooldownFormat, SurvivorOn);
            VestKCReset = CustomOption.CreateNumber(138, Types.Neutral, Language.GetString("option.generate.neutral.survivor.reset"), 30f, 0f, 60f, 2.5f, CooldownFormat, SurvivorOn);
            MaxVests = CustomOption.CreateNumber(139, Types.Neutral, Language.GetString("option.generate.neutral.survivor.maximum"), 5f, 1f, 15f, 1f, null, SurvivorOn);


            NeutralEvilRoles = CustomOption.CreateHeader(140, Types.Neutral, Language.GetString("option.generate.neutral.evil.header"));

            DoomsayerOn = CustomOption.CreateNumber(141, Types.Neutral, Utils.cs(Colors.Doomsayer, Language.GetString("option.generate.neutral.doomsayer")), 0f, 0f, 100f, 10f, PercentFormat, NeutralEvilRoles, true);
            ObserveCooldown = CustomOption.CreateNumber(142, Types.Neutral, Language.GetString("option.generate.neutral.doomsayer.cooldown"), 30f, 10f, 60f, 2.5f, CooldownFormat, DoomsayerOn);
            DoomsayerGuessNeutralBenign = CustomOption.CreateToggle(143, Types.Neutral, Language.GetString("option.generate.neutral.doomsayer.guess.benign.neutral"), false, DoomsayerOn);
            DoomsayerGuessNeutralEvil = CustomOption.CreateToggle(144, Types.Neutral, Language.GetString("option.generate.neutral.doomsayer.guess.evil.neutral"), false, DoomsayerOn);
            DoomsayerGuessNeutralKilling = CustomOption.CreateToggle(145, Types.Neutral, Language.GetString("option.generate.neutral.doomsayer.guess.killing.neutral"), false, DoomsayerOn);
            DoomsayerGuessImpostors = CustomOption.CreateToggle(146, Types.Neutral, Language.GetString("option.generate.neutral.doomsayer.guess.impostor"), false, DoomsayerOn);
            DoomsayerGuessesToWin = CustomOption.CreateNumber(148, Types.Neutral, Language.GetString("option.generate.neutral.doomsayer.win"), 3f, 1f, 5f, 1f, null, DoomsayerOn);

            ExecutionerOn = CustomOption.CreateNumber(149, Types.Neutral, Utils.cs(Colors.Executioner, Language.GetString("option.generate.neutral.executioner")), 0f, 0f, 100f, 10f, PercentFormat, NeutralEvilRoles, true);
            OnTargetDead = CustomOption.CreateString(150, Types.Neutral, Language.GetString("option.generate.neutral.executioner.become"), new[] { "option.generate.crewmate.crewmate", "option.generate.neutral.amnesiac", "option.generate.neutral.survivor", "option.generate.neutral.jester" }, ExecutionerOn);
            ExecutionerButton = CustomOption.CreateToggle(151, Types.Neutral, Language.GetString("option.generate.neutral.executioner.button"), true, ExecutionerOn);
            ExecutionerTorment = CustomOption.CreateToggle(417, Types.Neutral, Language.GetString("option.generate.neutral.executioner.torment"), false, ExecutionerOn);

            JesterOn = CustomOption.CreateNumber(153, Types.Neutral, Utils.cs(Colors.Jester, Language.GetString("option.generate.neutral.jester")), 0f, 0f, 100f, 10f, PercentFormat, NeutralEvilRoles, true);
            JesterButton = CustomOption.CreateToggle(154, Types.Neutral, Language.GetString("option.generate.neutral.jester.button"), true, JesterOn);
            JesterVent = CustomOption.CreateToggle(155, Types.Neutral, Language.GetString("option.generate.neutral.jester.vent"), false, JesterOn);
            JesterImpVision = CustomOption.CreateToggle(156, Types.Neutral, Language.GetString("option.generate.neutral.jester.vision"), false, JesterOn);
            JesterHaunt = CustomOption.CreateToggle(416, Types.Neutral, Language.GetString("option.generate.neutral.jester.haunt"), false, JesterOn);

            PhantomOn = CustomOption.CreateNumber(158, Types.Neutral, Utils.cs(Colors.Phantom, Language.GetString("option.generate.neutral.phantom")), 0f, 0f, 100f, 10f, PercentFormat, NeutralEvilRoles, true);
            PhantomTasksRemaining = CustomOption.CreateNumber(159, Types.Neutral, Language.GetString("option.generate.neutral.phantom.tasks"), 5f, 1f, 15f, 1f, null, PhantomOn);
            PhantomSpook = CustomOption.CreateToggle(415, Types.Neutral, Language.GetString("option.generate.neutral.phantom.spook"), false, PhantomOn);


            NeutralKillingRoles = CustomOption.CreateHeader(161, Types.Neutral, Language.GetString("option.generate.neutral.killing.header"));
            
            ArsonistOn = CustomOption.CreateNumber(162, Types.Neutral, Utils.cs(Colors.Arsonist, Language.GetString("option.generate.neutral.arsonist")), 0f, 0f, 100f, 10f, PercentFormat, NeutralKillingRoles, true);
            DouseCooldown = CustomOption.CreateNumber(163, Types.Neutral, Language.GetString("option.generate.neutral.arsonist.cooldown"), 30f, 10f, 60f, 2.5f, CooldownFormat, ArsonistOn);
            MaxDoused = CustomOption.CreateNumber(164, Types.Neutral, Language.GetString("option.generate.neutral.arsonist.maximum"), 5f, 1f, 15f, 1f, null, ArsonistOn);
            ArsoImpVision = CustomOption.CreateToggle(165, Types.Neutral, Language.GetString("option.generate.neutral.arsonist.vision"), false, ArsonistOn);
            IgniteCdRemoved = CustomOption.CreateToggle(166, Types.Neutral, Language.GetString("option.generate.neutral.arsonist.remove"), false, ArsonistOn);

            Juggernaut = CustomOption.CreateString(167, Types.Neutral, Utils.cs(Colors.Juggernaut, Language.GetString("option.generate.neutral.juggernaut")), new string[] { "option.generate.neutral.juggernaut.hide", "option.generate.neutral.juggernaut.show" }, NeutralKillingRoles, true);
            JuggKillCooldown = CustomOption.CreateNumber(168, Types.Neutral, Language.GetString("option.generate.neutral.juggernaut.initial"), 30f, 10f, 60f, 2.5f, CooldownFormat, Juggernaut);
            ReducedKCdPerKill = CustomOption.CreateNumber(169, Types.Neutral, Language.GetString("option.generate.neutral.juggernaut.reduce"), 5f, 2.5f, 10f, 2.5f, CooldownFormat, Juggernaut);
            JuggVent = CustomOption.CreateToggle(170, Types.Neutral, Language.GetString("option.generate.neutral.juggernaut.vent"), false, Juggernaut);

            PlaguebearerOn = CustomOption.CreateNumber(171, Types.Neutral, Utils.cs(Colors.Plaguebearer, Language.GetString("option.generate.neutral.plaguebearer")), 0f, 0f, 100f, 10f, PercentFormat, NeutralKillingRoles, true);
            InfectCooldown = CustomOption.CreateNumber(172, Types.Neutral, Language.GetString("option.generate.neutral.plaguebearer.cooldown"), 30f, 10f, 60f, 2.5f, CooldownFormat, PlaguebearerOn);
            PestKillCooldown = CustomOption.CreateNumber(173, Types.Neutral, Language.GetString("option.generate.neutral.plaguebearer.kill.cooldown"), 30f, 0f, 60f, 2.5f, CooldownFormat, PlaguebearerOn);
            PestVent = CustomOption.CreateToggle(174, Types.Neutral, Language.GetString("option.generate.neutral.plaguebearer.vent"), false, PlaguebearerOn);

            GlitchOn = CustomOption.CreateNumber(175, Types.Neutral, Utils.cs(Colors.Glitch, Language.GetString("option.generate.neutral.glitch")), 0f, 0f, 100f, 10f, PercentFormat, NeutralKillingRoles, true);
            MimicCooldownOption = CustomOption.CreateNumber(176, Types.Neutral, Language.GetString("option.generate.neutral.glitch.mimic.cooldown"), 30f, 10f, 60f, 2.5f, CooldownFormat, GlitchOn);
            MimicDurationOption = CustomOption.CreateNumber(177, Types.Neutral, Language.GetString("option.generate.neutral.glitch.mimic.duration"), 10f, 1f, 15f, 0.5f, CooldownFormat, GlitchOn);
            HackCooldownOption = CustomOption.CreateNumber(178, Types.Neutral, Language.GetString("option.generate.neutral.glitch.hack.cooldown"), 30f, 10f, 60f, 2.5f, CooldownFormat, GlitchOn);
            HackDurationOption = CustomOption.CreateNumber(179, Types.Neutral, Language.GetString("option.generate.neutral.glitch.hack.duration"), 10f, 1f, 15f, 0.5f, CooldownFormat, GlitchOn);
            GlitchKillCooldownOption = CustomOption.CreateNumber(180, Types.Neutral, Language.GetString("option.generate.neutral.glitch.kill.cooldown"), 30f, 10f, 60f, 2.5f, CooldownFormat, GlitchOn);
            GlitchHackDistanceOption = CustomOption.CreateString(181, Types.Neutral, Language.GetString("option.generate.neutral.glitch.hack.distance"), new[] { "option.generate.neutral.glitch.hack.distance.short", "option.generate.neutral.glitch.hack.distance.normal", "option.generate.neutral.glitch.hack.distance.long" }, GlitchOn);
            GlitchVent = CustomOption.CreateToggle(182, Types.Neutral, Language.GetString("option.generate.neutral.glitch.vent"), false, GlitchOn);

            VampireOn = CustomOption.CreateNumber(183, Types.Neutral, Utils.cs(Colors.Vampire, Language.GetString("option.generate.neutral.vampire")), 0f, 0f, 100f, 10f, PercentFormat, NeutralKillingRoles, true);
            BiteCooldown = CustomOption.CreateNumber(184, Types.Neutral, Language.GetString("option.generate.neutral.vampire.cooldown"), 30f, 10f, 60f, 2.5f, CooldownFormat, VampireOn);
            VampImpVision = CustomOption.CreateToggle(185, Types.Neutral, Language.GetString("option.generate.neutral.vampire.vision"), false, VampireOn);
            VampVent = CustomOption.CreateToggle(186, Types.Neutral, Language.GetString("option.generate.neutral.vampire.vent"), false, VampireOn);
            NewVampCanAssassin = CustomOption.CreateToggle(187, Types.Neutral, Language.GetString("option.generate.neutral.vampire.assassin"), false, VampireOn);
            MaxVampiresPerGame = CustomOption.CreateNumber(188, Types.Neutral, Language.GetString("option.generate.neutral.vampire.maximum"), 2f, 2f, 5f, 1f, null, VampireOn);
            CanBiteNeutralBenign = CustomOption.CreateToggle(189, Types.Neutral, Language.GetString("option.generate.neutral.vampire.convert.benign"), false, VampireOn);
            CanBiteNeutralEvil = CustomOption.CreateToggle(190, Types.Neutral, Language.GetString("option.generate.neutral.vampire.convert.evil"), false, VampireOn);

            WerewolfOn = CustomOption.CreateNumber(191, Types.Neutral, Utils.cs(Colors.Werewolf, Language.GetString("option.generate.neutral.werewolf")), 0f, 0f, 100f, 10f, PercentFormat, NeutralKillingRoles, true);
            RampageCooldown = CustomOption.CreateNumber(192, Types.Neutral, Language.GetString("option.generate.neutral.werewolf.cooldown"), 30f, 10f, 60f, 2.5f, CooldownFormat, WerewolfOn);
            RampageDuration = CustomOption.CreateNumber(193, Types.Neutral, Language.GetString("option.generate.neutral.werewolf.duration"), 30f, 10f, 60f, 2.5f, CooldownFormat, WerewolfOn);
            RampageKillCooldown = CustomOption.CreateNumber(194, Types.Neutral, Language.GetString("option.generate.neutral.werewolf.kill.cooldown"), 10f, 0.5f, 15f, 0.25f, CooldownFormat, WerewolfOn);
            WerewolfVent = CustomOption.CreateToggle(195, Types.Neutral, Language.GetString("option.generate.neutral.werewolf.vent"), false, WerewolfOn);
            
            Assassin = CustomOption.CreateString(242, Types.Impostor, Utils.cs(Colors.Impostor, Language.GetString("option.generate.impostor.assassin")), new string[] { "option.generate.impostor.assassin.hide", "option.generate.impostor.assassin.show" }, null, true);
            NumberOfImpostorAssassins = CustomOption.CreateNumber(243, Types.Impostor, Language.GetString("option.generate.impostor.assassin.imps"), 1f, 0f, 4f, 1f, null, Assassin);
            NumberOfNeutralAssassins = CustomOption.CreateNumber(244, Types.Impostor, Language.GetString("option.generate.impostor.assassin.neut"), 1f, 0f, 5f, 1f, null, Assassin);
            AmneTurnImpAssassin = CustomOption.CreateToggle(245, Types.Impostor, Language.GetString("option.generate.impostor.assassin.amnesiac.imp"), false, Assassin);
            AmneTurnNeutAssassin = CustomOption.CreateToggle(246, Types.Impostor, Language.GetString("option.generate.impostor.assassin.amnesiac.neut"), false, Assassin);
            TraitorCanAssassin = CustomOption.CreateToggle(247, Types.Impostor, Language.GetString("option.generate.impostor.assassin.traitor"), false, Assassin);
            AssassinKills = CustomOption.CreateNumber(248, Types.Impostor, Language.GetString("option.generate.impostor.assassin.kills"), 1f, 1f, 15f, 1f, null, Assassin);
            AssassinMultiKill = CustomOption.CreateToggle(249, Types.Impostor, Language.GetString("option.generate.impostor.assassin.multi"), false, Assassin);
            AssassinCrewmateGuess = CustomOption.CreateToggle(250, Types.Impostor, Language.GetString("option.generate.impostor.assassin.guess.crew"), false, Assassin);
            AssassinGuessNeutralBenign = CustomOption.CreateToggle(251, Types.Impostor, Language.GetString("option.generate.impostor.assassin.guess.benign.neutral"), false, Assassin);
            AssassinGuessNeutralEvil = CustomOption.CreateToggle(252, Types.Impostor, Language.GetString("option.generate.impostor.assassin.guess.evil.neutral"), false, Assassin);
            AssassinGuessNeutralKilling = CustomOption.CreateToggle(253, Types.Impostor, Language.GetString("option.generate.impostor.assassin.guess.killing.neutral"), false, Assassin);
            AssassinGuessImpostors = CustomOption.CreateToggle(254, Types.Impostor, Language.GetString("option.generate.impostor.assassin.guess.imp"), false, Assassin);
            AssassinGuessModifiers = CustomOption.CreateToggle(255, Types.Impostor, Language.GetString("option.generate.impostor.assassin.guess.crew.modifier"), false, Assassin);
            AssassinGuessLovers = CustomOption.CreateToggle(256, Types.Impostor, Language.GetString("option.generate.impostor.assassin.guess.lovers"), false, Assassin);

            ImpostorConcealingRoles = CustomOption.CreateHeader(196, Types.Impostor, Language.GetString("option.generate.impostor.concealing.header"));

            EscapistOn = CustomOption.CreateNumber(197, Types.Impostor, Utils.cs(Colors.Impostor, Language.GetString("option.generate.impostor.escapist")), 0f, 0f, 100f, 10f, PercentFormat, ImpostorConcealingRoles, true);
            EscapeCooldown = CustomOption.CreateNumber(198, Types.Impostor, Language.GetString("option.generate.impostor.escapist.cooldown"), 30f, 10f, 60f, 2.5f, CooldownFormat, EscapistOn);
            EscapistVent = CustomOption.CreateToggle(199, Types.Impostor, Language.GetString("option.generate.impostor.escapist.vent"), false, EscapistOn);

            GrenadierOn = CustomOption.CreateNumber(200, Types.Impostor, Utils.cs(Colors.Impostor, Language.GetString("option.generate.impostor.grenadier")), 0f, 0f, 100f, 10f, PercentFormat, ImpostorConcealingRoles, true);
            GrenadeCooldown = CustomOption.CreateNumber(201, Types.Impostor, Language.GetString("option.generate.impostor.grenadier.cooldown"), 30f, 10f, 60f, 2.5f, CooldownFormat, GrenadierOn);
            GrenadeDuration = CustomOption.CreateNumber(202, Types.Impostor, Language.GetString("option.generate.impostor.grenadier.duration"), 10f, 5f, 15f, 0.5f, CooldownFormat, GrenadierOn);
            FlashRadius = CustomOption.CreateNumber(203, Types.Impostor, Language.GetString("option.generate.impostor.grenadier.radius"), 1f, 0.25f, 5f, 0.25f, MultiplierFormat, GrenadierOn);
            GrenadierIndicators = CustomOption.CreateToggle(204, Types.Impostor, Language.GetString("option.generate.impostor.grenadier.indicate"), false, GrenadierOn);
            GrenadierVent = CustomOption.CreateToggle(205, Types.Impostor, Language.GetString("option.generate.impostor.grenadier.vent"), false, GrenadierOn);

            MorphlingOn = CustomOption.CreateNumber(206, Types.Impostor, Utils.cs(Colors.Impostor, Language.GetString("option.generate.impostor.morphling")), 0f, 0f, 100f, 10f, PercentFormat, ImpostorConcealingRoles, true);
            MorphlingCooldown = CustomOption.CreateNumber(207, Types.Impostor, Language.GetString("option.generate.impostor.morphling.cooldown"), 30f, 10f, 60f, 2.5f, CooldownFormat, MorphlingOn);
            MorphlingDuration = CustomOption.CreateNumber(208, Types.Impostor, Language.GetString("option.generate.impostor.morphling.duration"), 10f, 5f, 15f, 0.5f, CooldownFormat, MorphlingOn);
            MorphlingVent = CustomOption.CreateToggle(209, Types.Impostor, Language.GetString("option.generate.impostor.morphling.vent"), false, MorphlingOn);

            SwooperOn = CustomOption.CreateNumber(210, Types.Impostor, Utils.cs(Colors.Impostor, Language.GetString("option.generate.impostor.swooper")), 0f, 0f, 100f, 10f, PercentFormat, ImpostorConcealingRoles, true);
            SwoopCooldown = CustomOption.CreateNumber(211, Types.Impostor, Language.GetString("option.generate.impostor.swooper.cooldown"), 30f, 10f, 60f, 2.5f, CooldownFormat, SwooperOn);
            SwoopDuration = CustomOption.CreateNumber(212, Types.Impostor, Language.GetString("option.generate.impostor.swooper.duration"), 10f, 5f, 15f, 0.5f, CooldownFormat, SwooperOn);
            SwooperVent = CustomOption.CreateToggle(213, Types.Impostor, Language.GetString("option.generate.impostor.swooper.vent"), false, SwooperOn);

            VenererOn = CustomOption.CreateNumber(214, Types.Impostor, Utils.cs(Colors.Impostor, Language.GetString("option.generate.impostor.venerer")), 0f, 0f, 100f, 10f, PercentFormat, ImpostorConcealingRoles, true);
            AbilityCooldown = CustomOption.CreateNumber(215, Types.Impostor, Language.GetString("option.generate.impostor.venerer.cooldown"), 30f, 10f, 60f, 2.5f, CooldownFormat, VenererOn);
            AbilityDuration = CustomOption.CreateNumber(216, Types.Impostor, Language.GetString("option.generate.impostor.venerer.duration"), 10f, 5f, 15f, 0.5f, CooldownFormat, VenererOn);
            SprintSpeed = CustomOption.CreateNumber(217, Types.Impostor, Language.GetString("option.generate.impostor.venerer.sprint"), 1.25f, 1.05f, 2.5f, 0.05f, MultiplierFormat, VenererOn);
            FreezeSpeed = CustomOption.CreateNumber(218, Types.Impostor, Language.GetString("option.generate.impostor.venerer.freeze"), 0.75f, 0.05f, 0.95f, 0.05f, MultiplierFormat, VenererOn);


            ImpostorKillingRoles = CustomOption.CreateHeader(219, Types.Impostor, Language.GetString("option.generate.impostor.killing.header"));

            BomberOn = CustomOption.CreateNumber(220, Types.Impostor, Utils.cs(Colors.Impostor, Language.GetString("option.generate.impostor.bomber")), 0f, 0f, 100f, 10f, PercentFormat, ImpostorKillingRoles, true);
            DetonateDelay = CustomOption.CreateNumber(221, Types.Impostor, Language.GetString("option.generate.impostor.bomber.delay"), 5f, 1f, 15f, 0.5f, CooldownFormat, BomberOn);
            MaxKillsInDetonation = CustomOption.CreateNumber(222, Types.Impostor, Language.GetString("option.generate.impostor.bomber.maximum"), 5f, 1f, 15f, 1f, null, BomberOn);
            DetonateRadius = CustomOption.CreateNumber(223, Types.Impostor, Language.GetString("option.generate.impostor.bomber.radius"), 0.25f, 0.05f, 1f, 0.05f, MultiplierFormat, BomberOn);
            BomberVent = CustomOption.CreateToggle(224, Types.Impostor, Language.GetString("option.generate.impostor.bomber.vent"), false, BomberOn);

            TraitorOn = CustomOption.CreateNumber(225, Types.Impostor, Utils.cs(Colors.Impostor, Language.GetString("option.generate.impostor.traitor")), 0f, 0f, 100f, 10f, PercentFormat, ImpostorKillingRoles, true);
            LatestSpawn = CustomOption.CreateNumber(226, Types.Impostor, Language.GetString("option.generate.impostor.traitor.min"), 5, 3, 15, 1, null, TraitorOn);
            NeutralKillingStopsTraitor = CustomOption.CreateToggle(227, Types.Impostor, Language.GetString("option.generate.impostor.traitor.neutral"), false, TraitorOn);

            WarlockOn = CustomOption.CreateNumber(228, Types.Impostor, Utils.cs(Colors.Impostor, Language.GetString("option.generate.impostor.warlock")), 0f, 0f, 100f, 10f, PercentFormat, ImpostorKillingRoles, true);
            ChargeUpDuration = CustomOption.CreateNumber(229, Types.Impostor, Language.GetString("option.generate.impostor.warlock.charge"), 30f, 10f, 60f, 2.5f, CooldownFormat, WarlockOn);
            ChargeUseDuration = CustomOption.CreateNumber(230, Types.Impostor, Language.GetString("option.generate.impostor.warlock.use"), 1f, 0.05f, 5f, 0.05f, CooldownFormat, WarlockOn);


            ImpostorSupportRoles = CustomOption.CreateHeader(231, Types.Impostor, Language.GetString("option.generate.impostor.support.header"));

            BlackmailerOn = CustomOption.CreateNumber(232, Types.Impostor, Utils.cs(Colors.Impostor, Language.GetString("option.generate.impostor.blackmailer")), 0f, 0f, 100f, 10f, PercentFormat, ImpostorSupportRoles, true);
            BlackmailCooldown = CustomOption.CreateNumber(233, Types.Impostor, Language.GetString("option.generate.impostor.blackmailer.cooldown"), 10f, 1f, 15f, 0.5f, CooldownFormat, BlackmailerOn);

            JanitorOn = CustomOption.CreateNumber(234, Types.Impostor, Utils.cs(Colors.Impostor, Language.GetString("option.generate.impostor.janitor")), 0f, 0f, 100f, 10f, PercentFormat, ImpostorSupportRoles, true);

            MinerOn = CustomOption.CreateNumber(235, Types.Impostor, Utils.cs(Colors.Impostor, Language.GetString("option.generate.impostor.miner")), 0f, 0f, 100f, 10f, PercentFormat, ImpostorSupportRoles, true);
            MineCooldown = CustomOption.CreateNumber(236, Types.Impostor, Language.GetString("option.generate.impostor.miner.cooldown"), 30f, 10f, 60f, 2.5f, CooldownFormat, MinerOn);

            UndertakerOn = CustomOption.CreateNumber(237, Types.Impostor, Utils.cs(Colors.Impostor, Language.GetString("option.generate.impostor.undertaker")), 0f, 0f, 100f, 10f, PercentFormat, ImpostorSupportRoles, true);
            DragCooldown = CustomOption.CreateNumber(238, Types.Impostor, Language.GetString("option.generate.impostor.undertaker.cooldown"), 30f, 10f, 60f, 2.5f, CooldownFormat, UndertakerOn);
            UndertakerDragSpeed = CustomOption.CreateNumber(239, Types.Impostor, Language.GetString("option.generate.impostor.undertaker.speed"), 0.75f, 0.25f, 1f, 0.05f, MultiplierFormat, UndertakerOn);
            UndertakerVent = CustomOption.CreateToggle(240, Types.Impostor, Language.GetString("option.generate.impostor.undertaker.vent"), false, UndertakerOn);
            UndertakerVentWithBody = CustomOption.CreateToggle(241, Types.Impostor, Language.GetString("option.generate.impostor.undertaker.vent.body"), false, UndertakerVent);


            CrewmateModifiers = CustomOption.CreateHeader(258, Types.Modifier, Language.GetString("option.generate.modifier.crewmate.header"));

            AftermathOn = CustomOption.CreateNumber(259, Types.Modifier, Utils.cs(Colors.Aftermath, Language.GetString("option.generate.modifier.aftermath")), 0f, 0f, 100f, 10f, PercentFormat, CrewmateModifiers, true);

            BaitOn = CustomOption.CreateNumber(260, Types.Modifier, Utils.cs(Colors.Bait, Language.GetString("option.generate.modifier.bait")), 0f, 0f, 100f, 10f, PercentFormat, CrewmateModifiers, true);
            BaitMinDelay = CustomOption.CreateNumber(261, Types.Modifier, Language.GetString("option.generate.modifier.bait.min"), 0f, 0f, 15f, 0.5f, CooldownFormat, BaitOn);
            BaitMaxDelay = CustomOption.CreateNumber(262, Types.Modifier, Language.GetString("option.generate.modifier.bait.max"), 1f, 0f, 15f, 0.5f, CooldownFormat, BaitOn);
            
            BlindOn = CustomOption.CreateNumber(453, Types.Modifier, Utils.cs(Colors.Blind, Language.GetString("option.generate.modifier.blind")), 0f, 0f, 100f, 10f, PercentFormat, CrewmateModifiers, true);

            DiseasedOn = CustomOption.CreateNumber(263, Types.Modifier, Utils.cs(Colors.Diseased, Language.GetString("option.generate.modifier.diseased")), 0f, 0f, 100f, 10f, PercentFormat, CrewmateModifiers, true);
            DiseasedKillMultiplier = CustomOption.CreateNumber(264, Types.Modifier, Language.GetString("option.generate.modifier.diseased.multi"), 3f, 1.5f, 5f, 0.25f, MultiplierFormat, DiseasedOn);

            FrostyOn = CustomOption.CreateNumber(265, Types.Modifier, Utils.cs(Colors.Frosty, Language.GetString("option.generate.modifier.frosty")), 0f, 0f, 100f, 10f, PercentFormat, CrewmateModifiers, true);
            ChillDuration = CustomOption.CreateNumber(266, Types.Modifier, Language.GetString("option.generate.modifier.frosty.duration"), 10f, 1f, 15f, 0.5f, CooldownFormat, FrostyOn);
            ChillStartSpeed = CustomOption.CreateNumber(267, Types.Modifier, Language.GetString("option.generate.modifier.frosty.speed"), 0.75f, 0.25f, 0.95f, 0.05f, MultiplierFormat, FrostyOn);

            MultitaskerOn = CustomOption.CreateNumber(268, Types.Modifier, Utils.cs(Colors.Multitasker, Language.GetString("option.generate.modifier.multitasker")), 0f, 0f, 100f, 10f, PercentFormat, CrewmateModifiers, true);

            TorchOn = CustomOption.CreateNumber(269, Types.Modifier, Utils.cs(Colors.Torch, Language.GetString("option.generate.modifier.torch")), 0f, 0f, 100f, 10f, PercentFormat, CrewmateModifiers, true);


            GlobalModifiers = CustomOption.CreateHeader(270, Types.Modifier, Language.GetString("option.generate.modifier.general.header"));

            ButtonBarryOn = CustomOption.CreateNumber(271, Types.Modifier, Utils.cs(Colors.ButtonBarry, Language.GetString("option.generate.modifier.button")), 0f, 0f, 100f, 10f, PercentFormat, GlobalModifiers, true);

            DrunkOn = CustomOption.CreateNumber(452, Types.Modifier, Utils.cs(Colors.Drunk, Language.GetString("option.generate.modifier.drunk")), 0f, 0f, 100f, 10f, PercentFormat, GlobalModifiers, true);

            FlashOn = CustomOption.CreateNumber(272, Types.Modifier, Utils.cs(Colors.Flash, Language.GetString("option.generate.modifier.flash")), 0f, 0f, 100f, 10f, PercentFormat, GlobalModifiers, true);
            FlashSpeed = CustomOption.CreateNumber(273, Types.Modifier, Language.GetString("option.generate.modifier.flash.speed"), 1.25f, 1.05f, 2.5f, 0.05f, MultiplierFormat, FlashOn);

            GiantOn = CustomOption.CreateNumber(274, Types.Modifier, Utils.cs(Colors.Giant, Language.GetString("option.generate.modifier.giant")), 0f, 0f, 100f, 10f, PercentFormat, GlobalModifiers, true);
            GiantSlow = CustomOption.CreateNumber(275, Types.Modifier, Language.GetString("option.generate.modifier.giant.speed"), 0.75f, 0.25f, 1f, 0.05f, MultiplierFormat, GiantOn);

            LoversOn = CustomOption.CreateNumber(276, Types.Modifier, Utils.cs(Colors.Lovers, Language.GetString("option.generate.modifier.lovers")), 0f, 0f, 100f, 10f, PercentFormat, GlobalModifiers, true);
            BothLoversDie = CustomOption.CreateToggle(277, Types.Modifier, Language.GetString("option.generate.modifier.lovers.die"), true, LoversOn);
            LovingImpPercent = CustomOption.CreateNumber(278, Types.Modifier, Language.GetString("option.generate.modifier.lovers.imp"), 0f, 0f, 100f, 10f, PercentFormat, LoversOn);
            NeutralLovers = CustomOption.CreateToggle(279, Types.Modifier, Language.GetString("option.generate.modifier.lovers.neut"), false, LoversOn);

            RadarOn = CustomOption.CreateNumber(280, Types.Modifier, Utils.cs(Colors.Radar, Language.GetString("option.generate.modifier.radar")), 0f, 0f, 100f, 10f, PercentFormat, GlobalModifiers, true);

            SleuthOn = CustomOption.CreateNumber(281, Types.Modifier, Utils.cs(Colors.Sleuth, Language.GetString("option.generate.modifier.sleuth")), 0f, 0f, 100f, 10f, PercentFormat, GlobalModifiers, true);

            TiebreakerOn = CustomOption.CreateNumber(282, Types.Modifier, Utils.cs(Colors.Tiebreaker, Language.GetString("option.generate.modifier.tiebreaker")), 0f, 0f, 100f, 10f, PercentFormat, GlobalModifiers, true);


            ImpostorModifiers = CustomOption.CreateHeader(283, Types.Modifier, Language.GetString("option.generate.modifier.impostor.header"));

            DisperserOn = CustomOption.CreateNumber(284, Types.Modifier, Utils.cs(Colors.Impostor, Language.GetString("option.generate.modifier.disperser")), 0f, 0f, 100f, 10f, PercentFormat, ImpostorModifiers, true);

            DoubleShotOn = CustomOption.CreateNumber(285, Types.Modifier, Utils.cs(Colors.Impostor, Language.GetString("option.generate.modifier.double")), 0f, 0f, 100f, 10f, PercentFormat, ImpostorModifiers, true);

            UnderdogOn = CustomOption.CreateNumber(286, Types.Modifier, Utils.cs(Colors.Impostor, Language.GetString("option.generate.modifier.underdog")), 0f, 0f, 100f, 10f, PercentFormat, ImpostorModifiers, true);
            UnderdogKillBonus = CustomOption.CreateNumber(287, Types.Modifier, Language.GetString("option.generate.modifier.underdog.bonus"), 30f, 2.5f, 60f, 2.5f, CooldownFormat, UnderdogOn);
            UnderdogIncreasedKC = CustomOption.CreateToggle(288, Types.Modifier, Language.GetString("option.generate.modifier.underdog.increase"), true, UnderdogOn);

            GameModeSettings = CustomOption.CreateHeader(289, Types.General, Language.GetString("option.generate.general.gamemode.header"));
            GameMode = CustomOption.CreateString(290, Types.General, Language.GetString("option.generate.general.gamemode"), new[] { "option.generate.general.gamemode.classic", "option.generate.general.gamemode.all", "option.generate.general.gamemode.killing", "option.generate.general.gamemode.cultist" }, GameModeSettings);

            ClassicSettings = CustomOption.CreateHeader(359, Types.General, Language.GetString("option.generate.general.classic"), false, Gamemode.Classic);
            MinNeutralBenignRoles = CustomOption.CreateNumber(292, Types.General, Language.GetString("option.generate.general.classic.min.benign.neutral"), 1f, 0f, 15f, 1f, null, ClassicSettings, false, false, Gamemode.Classic);
            MaxNeutralBenignRoles = CustomOption.CreateNumber(293, Types.General, Language.GetString("option.generate.general.classic.max.benign.neutral"), 1f, 0f, 15f, 1f, null, ClassicSettings, false, false, Gamemode.Classic);
            MinNeutralEvilRoles = CustomOption.CreateNumber(294, Types.General, Language.GetString("option.generate.general.classic.min.evil.neutral"), 1f, 0f, 15f, 1f, null, ClassicSettings, false, false, Gamemode.Classic);
            MaxNeutralEvilRoles = CustomOption.CreateNumber(295, Types.General, Language.GetString("option.generate.general.classic.max.evil.neutral"), 1f, 0f, 15f, 1f, null, ClassicSettings, false, false, Gamemode.Classic);
            MinNeutralKillingRoles = CustomOption.CreateNumber(296, Types.General, Language.GetString("option.generate.general.classic.min.killing.neutral"), 1f, 0f, 15f, 1f, null, ClassicSettings, false, false, Gamemode.Classic);
            MaxNeutralKillingRoles = CustomOption.CreateNumber(297, Types.General, Language.GetString("option.generate.general.classic.max.killing.neutral"), 1f, 0f, 15f, 1f, null, ClassicSettings, false, false, Gamemode.Classic);

            AllAnySettings = CustomOption.CreateHeader(360, Types.General, Language.GetString("option.generate.general.all"), false, Gamemode.AllAny);
            RandomNumberImps = CustomOption.CreateToggle(298, Types.General, Language.GetString("option.generate.general.all.random"), true, AllAnySettings, false, false, Gamemode.AllAny);

            KillingOnlySettings = CustomOption.CreateHeader(361, Types.General, Language.GetString("option.generate.general.killing"), false, Gamemode.KillingOnly);
            NeutralRoles = CustomOption.CreateNumber(299, Types.General, Language.GetString("option.generate.general.killing.neutral"), 1, 0, 5, 1, null, KillingOnlySettings, false, false, Gamemode.KillingOnly);
            VeteranCount = CustomOption.CreateNumber(300, Types.General, Language.GetString("option.generate.general.killing.veteran"), 1, 0, 5, 1, null, KillingOnlySettings, false, false, Gamemode.KillingOnly);
            VigilanteCount = CustomOption.CreateNumber(301, Types.General, Language.GetString("option.generate.general.killing.vigilante"), 1, 0, 5, 1, null, KillingOnlySettings, false, false, Gamemode.KillingOnly);
            AddArsonist = CustomOption.CreateToggle(302, Types.General, Language.GetString("option.generate.general.killing.arsonist"), true, KillingOnlySettings, false, false, Gamemode.KillingOnly);
            AddPlaguebearer = CustomOption.CreateToggle(303, Types.General, Language.GetString("option.generate.general.killing.plaguebearer"), true, KillingOnlySettings, false, false, Gamemode.KillingOnly);

            CultistSettings = CustomOption.CreateHeader(362, Types.General, Language.GetString("option.generate.general.cultist"), false, Gamemode.Cultist);
            MayorCultistOn = CustomOption.CreateNumber(304, Types.General, Utils.cs(Colors.Mayor, Language.GetString("option.generate.general.cultist.mayor")), 100f, 0f, 100f, 10f, PercentFormat, CultistSettings, false, false, Gamemode.Cultist);
            SeerCultistOn = CustomOption.CreateNumber(305, Types.General, Utils.cs(Colors.Seer, Language.GetString("option.generate.general.cultist.seer")), 100f, 0f, 100f, 10f, PercentFormat, CultistSettings, false, false, Gamemode.Cultist);
            SheriffCultistOn = CustomOption.CreateNumber(306, Types.General, Utils.cs(Colors.Sheriff, Language.GetString("option.generate.general.cultist.sheriff")), 100f, 0f, 100f, 10f, PercentFormat, CultistSettings, false, false, Gamemode.Cultist);
            SurvivorCultistOn = CustomOption.CreateNumber(307, Types.General, Utils.cs(Colors.Survivor, Language.GetString("option.generate.general.cultist.survivor")), 100f, 0f, 100f, 10f, PercentFormat, CultistSettings, false, false, Gamemode.Cultist);
            NumberOfSpecialRoles = CustomOption.CreateNumber(308, Types.General, Language.GetString("option.generate.general.cultist.special"), 4f, 0f, 4f, 1f, null, CultistSettings, false, false, Gamemode.Cultist);
            MaxChameleons = CustomOption.CreateNumber(309, Types.General, Language.GetString("option.generate.general.cultist.max.cham"), 3f, 0f, 5f, 1f, null, CultistSettings, false, false, Gamemode.Cultist);
            MaxEngineers = CustomOption.CreateNumber(310, Types.General, Language.GetString("option.generate.general.cultist.max.eng"), 3f, 0f, 5f, 1f, null, CultistSettings, false, false, Gamemode.Cultist);
            MaxInvestigators = CustomOption.CreateNumber(311, Types.General, Language.GetString("option.generate.general.cultist.max.inv"), 3f, 0f, 5f, 1f, null, CultistSettings, false, false, Gamemode.Cultist);
            MaxMystics = CustomOption.CreateNumber(312, Types.General, Language.GetString("option.generate.general.cultist.max.myst"), 3f, 0f, 5f, 1f, null, CultistSettings, false, false, Gamemode.Cultist);
            MaxSnitches = CustomOption.CreateNumber(313, Types.General, Language.GetString("option.generate.general.cultist.max.snit"), 3f, 0f, 5f, 1f, null, CultistSettings, false, false, Gamemode.Cultist);
            MaxSpies = CustomOption.CreateNumber(314, Types.General, Language.GetString("option.generate.general.cultist.max.spy"), 3f, 0f, 5f, 1f, null, CultistSettings, false, false, Gamemode.Cultist);
            MaxTransporters = CustomOption.CreateNumber(315, Types.General, Language.GetString("option.generate.general.cultist.max.tran"), 3f, 0f, 5f, 1f, null, CultistSettings, false, false, Gamemode.Cultist);
            MaxVigilantes = CustomOption.CreateNumber(316, Types.General, Language.GetString("option.generate.general.cultist.max.vigi"), 3f, 0f, 5f, 1f, null, CultistSettings, false, false, Gamemode.Cultist);
            WhisperCooldown = CustomOption.CreateNumber(317, Types.General, Language.GetString("option.generate.general.cultist.initial.whisp"), 30f, 10f, 60f, 2.5f, CooldownFormat, CultistSettings, false, false, Gamemode.Cultist);
            IncreasedCooldownPerWhisper = CustomOption.CreateNumber(318, Types.General, Language.GetString("option.generate.general.cultist.increase.whisp"), 5f, 0f, 15f, 0.5f, CooldownFormat, CultistSettings, false, false, Gamemode.Cultist);
            WhisperRadius = CustomOption.CreateNumber(319, Types.General, Language.GetString("option.generate.general.cultist.radius"), 1f, 0.25f, 5f, 0.25f, MultiplierFormat, CultistSettings, false, false, Gamemode.Cultist);
            ConversionPercentage = CustomOption.CreateNumber(320, Types.General, Language.GetString("option.generate.general.cultist.convert"), 25f, 0f, 100f, 5f, PercentFormat, CultistSettings, false, false, Gamemode.Cultist);
            DecreasedPercentagePerConversion = CustomOption.CreateNumber(321, Types.General, Language.GetString("option.generate.general.cultist.convert.decrease"), 5f, 0f, 15f, 1f, PercentFormat, CultistSettings, false, false, Gamemode.Cultist);
            ReviveCooldown = CustomOption.CreateNumber(322, Types.General, Language.GetString("option.generate.general.cultist.initial.revive"), 30f, 10f, 60f, 2.5f, CooldownFormat, CultistSettings, false, false, Gamemode.Cultist);
            IncreasedCooldownPerRevive = CustomOption.CreateNumber(323, Types.General, Language.GetString("option.generate.general.cultist.increase.revive"), 30f, 10f, 60f, 2.5f, CooldownFormat, CultistSettings, false, false, Gamemode.Cultist);
            MaxReveals = CustomOption.CreateNumber(324, Types.General, Language.GetString("option.generate.general.cultist.max.reveal"), 5f, 1f, 15f, 1f, null, CultistSettings, false, false, Gamemode.Cultist);

            BetterPolusSettings = CustomOption.CreateHeader(340, Types.General, Language.GetString("option.generate.general.bp.header"));
            VentImprovements = CustomOption.CreateToggle(341, Types.General, Language.GetString("option.generate.general.bp.vent"), false, BetterPolusSettings);
            VitalsLab = CustomOption.CreateToggle(342, Types.General, Language.GetString("option.generate.general.bp.vitals"), false, BetterPolusSettings);
            ColdTempDeathValley = CustomOption.CreateToggle(343, Types.General, Language.GetString("option.generate.general.bp.cold"), false, BetterPolusSettings);
            WifiChartCourseSwap = CustomOption.CreateToggle(344, Types.General, Language.GetString("option.generate.general.bp.wifi"), false, BetterPolusSettings);

            CustomGameSettings = CustomOption.CreateHeader(345, Types.General, Language.GetString("option.generate.general.cgs.header"));
            ColourblindComms = CustomOption.CreateToggle(346, Types.General, Language.GetString("option.generate.general.cgs.camo"), false, CustomGameSettings);
            ImpostorSeeRoles = CustomOption.CreateToggle(347, Types.General, Language.GetString("option.generate.general.cgs.imp"), false, CustomGameSettings);
            DeadSeeRoles = CustomOption.CreateToggle(348, Types.General, Language.GetString("option.generate.general.cgs.dead"), false, CustomGameSettings);
            InitialCooldowns = CustomOption.CreateNumber(349, Types.General, Language.GetString("option.generate.general.cgs.cooldown"), 10f, 10f, 30f, 2.5f, CooldownFormat, CustomGameSettings);
            ParallelMedScans = CustomOption.CreateToggle(350, Types.General, Language.GetString("option.generate.general.cgs.medbay"), false, CustomGameSettings);
            SkipButtonDisable = CustomOption.CreateString(351, Types.General, Language.GetString("option.generate.general.cgs.skip"), new[] { "option.generate.general.cgs.skip.no", "option.generate.general.cgs.skip.emergency", "option.generate.general.cgs.skip.always" }, CustomGameSettings);
            HiddenRoles = CustomOption.CreateToggle(352, Types.General, Language.GetString("option.generate.general.cgs.roles"), true, CustomGameSettings);
            FirstDeathShield = CustomOption.CreateToggle(353, Types.General, Language.GetString("option.generate.general.cgs.shield"), false, CustomGameSettings);
            NeutralEvilWinEndsGame = CustomOption.CreateToggle(354, Types.General, Language.GetString("option.generate.general.cgs.evil"), false, CustomGameSettings);

            BlockGameEndHeader = CustomOption.CreateHeader(445, Types.General, Language.GetString("option.generate.general.bge.header"));
            BlockGameEnd = CustomOption.CreateToggle(446, Types.General, Language.GetString("option.generate.general.bge.power"), false, BlockGameEndHeader);
            SheriffBlockGameEnd = CustomOption.CreateToggle(447, Types.General, Language.GetString("option.generate.general.bge.sheriff"), false, BlockGameEnd);
            VeteranBlockGameEnd = CustomOption.CreateToggle(448, Types.General, Language.GetString("option.generate.general.bge.veteran"), false, BlockGameEnd);
            MayorBlockGameEnd = CustomOption.CreateToggle(449, Types.General, Language.GetString("option.generate.general.bge.mayor"), false, BlockGameEnd);
            SwapperBlockGameEnd = CustomOption.CreateToggle(450, Types.General, Language.GetString("option.generate.general.bge.swapper"), false, BlockGameEnd);
            VigilanteBlockGameEnd = CustomOption.CreateToggle(461, Types.General, Language.GetString("option.generate.general.bge.vigilante"), false, BlockGameEnd);
            ProsecutorBlockGameEnd = CustomOption.CreateToggle(462, Types.General, Language.GetString("option.generate.general.bge.prosecutor"), false, BlockGameEnd);
            VampireHunterBlockGameEnd = CustomOption.CreateToggle(460, Types.General, Language.GetString("option.generate.general.bge.vh"), false, BlockGameEnd);
            TiebreakerBlockGameEnd = CustomOption.CreateToggle(451, Types.General, Language.GetString("option.generate.general.bge.tiebreaker"), false, BlockGameEnd);

            TaskTrackingSettings = CustomOption.CreateHeader(355, Types.General, Language.GetString("option.generate.general.tts"));
            SeeTasksDuringRound = CustomOption.CreateToggle(356, Types.General, Language.GetString("option.generate.general.tts.round"), false, TaskTrackingSettings);
            SeeTasksDuringMeeting = CustomOption.CreateToggle(357, Types.General, Language.GetString("option.generate.general.tts.meeting"), false, TaskTrackingSettings);
            SeeTasksWhenDead = CustomOption.CreateToggle(358, Types.General, Language.GetString("option.generate.general.tts.dead"), true, TaskTrackingSettings);
            
            MapSettings = CustomOption.CreateHeader(325, Types.General, Language.GetString("option.generate.general.ms.header"));
            RandomMapEnabled = CustomOption.CreateToggle(326, Types.General, Language.GetString("option.generate.general.ms.random"), false, MapSettings);
            RandomMapSkeld = CustomOption.CreateNumber(327, Types.General, Language.GetString("option.generate.general.ms.skeld"), 0f, 0f, 100f, 10f, PercentFormat, RandomMapEnabled);
            RandomMapMira = CustomOption.CreateNumber(328, Types.General, Language.GetString("option.generate.general.ms.mira"), 0f, 0f, 100f, 10f, PercentFormat, RandomMapEnabled);
            RandomMapPolus = CustomOption.CreateNumber(329, Types.General, Language.GetString("option.generate.general.ms.polus"), 0f, 0f, 100f, 10f, PercentFormat, RandomMapEnabled);
            RandomMapAirship = CustomOption.CreateNumber(330, Types.General, Language.GetString("option.generate.general.ms.airship"), 0f, 0f, 100f, 10f, PercentFormat, RandomMapEnabled);
            RandomMapSubmerged = CustomOption.CreateNumber(331, Types.General, Language.GetString("option.generate.general.ms.submerged"), 0f, 0f, 100f, 10f, PercentFormat, RandomMapEnabled);
            AutoAdjustSettings = CustomOption.CreateToggle(332, Types.General, Language.GetString("option.generate.general.ms.adjust"), false, RandomMapEnabled);
            SmallMapHalfVision = CustomOption.CreateToggle(333, Types.General, Language.GetString("option.generate.general.ms.half"), false, RandomMapEnabled);
            SmallMapDecreasedCooldown = CustomOption.CreateNumber(334, Types.General, Language.GetString("option.generate.general.ms.decrease"), 0f, 0f, 15f, 2.5f, CooldownFormat, RandomMapEnabled);
            LargeMapIncreasedCooldown = CustomOption.CreateNumber(335, Types.General, Language.GetString("option.generate.general.ms.increase"), 0f, 0f, 15f, 2.5f, CooldownFormat, RandomMapEnabled);
            SmallMapIncreasedShortTasks = CustomOption.CreateNumber(336, Types.General, Language.GetString("option.generate.general.ms.skeld.increase.short"), 0f, 0f, 5f, 1f, null, RandomMapEnabled);
            SmallMapIncreasedLongTasks = CustomOption.CreateNumber(337, Types.General, Language.GetString("option.generate.general.ms.skeld.increase.long"), 0f, 0f, 3f, 1f, null, RandomMapEnabled);
            LargeMapDecreasedShortTasks = CustomOption.CreateNumber(338, Types.General, Language.GetString("option.generate.general.ms.airship.decrease.short"), 0f, 0f, 5f, 1f, null, RandomMapEnabled);
            LargeMapDecreasedLongTasks = CustomOption.CreateNumber(339, Types.General, Language.GetString("option.generate.general.ms.airship.decrease.long"), 0f, 0f, 3f, 1f, null, RandomMapEnabled);
        }
    }
}