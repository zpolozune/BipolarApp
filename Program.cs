using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Collections.Immutable;
using System.Collections.Specialized;
using System.Data;
using System.Data.Common;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.IO.Pipes;
using System.IO.Pipelines;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Metadata;
using System.Reflection.Emit;
using System.Reflection.PortableExecutable;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Net.NetworkInformation;
using System.Net.Quic;
using System.Net.Security;
using System.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Schema;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using System.Threading.Tasks.Sources;
using System.Threading.Channels;
using System.Timers;
using System.Windows;
using System.Windows.Input;
using System.Windows.Markup;
using Microsoft.Win32;
using Microsoft.Win32.SafeHandles;
using Microsoft.CSharp;

namespace BipolarApp
{
    class MoodState
    {
        DateTime StartOfLoggedTime
        {
            get => StartOfLoggedTime;
            set
            {
                StartOfLoggedTime = value;
            }
        }

        DateTime EndOfLoggedTime
        {
            get => EndOfLoggedTime;
            set
            {
                EndOfLoggedTime = value;
            }
        }

        UInt32 Mania
        {
            get => Mania;
            set
            {
                if ((value >= 0) && (value <= 10))
                {
                    Mania = value;
                }
            }
        }

        UInt32 Depression
        {
            get => Depression;
            set
            {
                if ((value >= 0) && (value <= 10)) {
                    Depression = value;
                }
            }
        }

        UInt32 EnergyLevel
        {
            get => EnergyLevel;
            set
            {
                if ((value >= 0) && (value <= 10))
                {
                    EnergyLevel = value;
                }
            }
        }

        UInt32 Anxiety
        {
            get => Anxiety;
            set
            {
                if ((value >= 0) && (value <= 10))
                {
                    Anxiety = value;
                }
            }
        }

        UInt32 Impuslivity
        {
            get => Impuslivity;
            set
            {
                if ((value >= 0) && (value <= 10))
                {
                    Impuslivity = value;
                }
            }
        }

        Suicidality LevelOfSuicidality
        {
            get => LevelOfSuicidality;
            set => LevelOfSuicidality = value;
        }

        private Int32 _levelOfSuicidality
        {
            get => _levelOfSuicidality;
            set
            {
                _levelOfSuicidality = (Int32)this.LevelOfSuicidality;
            }
        }

        private DateTime RecordedDateTime
        {
            get => RecordedDateTime;
            init => RecordedDateTime = DateTime.Now;
        }
    }


    class ManicSymptoms
    {
        SeverityLevels Grandiosity
        {
            get => Grandiosity;
            set => Grandiosity = value;
        }

        private int _grandiosity
        {
            get => _grandiosity;
            set => _grandiosity = (int)this.Grandiosity;
        }

        SeverityLevels DecreasedNeedForSleep
        {
            get => DecreasedNeedForSleep;
            set => DecreasedNeedForSleep = value;
        }

        private int _decreasedNeedForSleep
        {
            get => _decreasedNeedForSleep;
            set => _decreasedNeedForSleep = (int)this.DecreasedNeedForSleep;
        }

        SeverityLevels PressuredSpeech
        {
            get => PressuredSpeech;
            set => PressuredSpeech = value;
        }

        private int _pressuredSpeech
        {
            get => _pressuredSpeech;
            set => _pressuredSpeech = (int)this.PressuredSpeech;
        }

        SeverityLevels FlightOfIdeas
        {
            get => FlightOfIdeas;
            set => FlightOfIdeas = value;
        }

        private int _flightOfIdeas
        {
            get => _flightOfIdeas;
            set => _flightOfIdeas = (int)this.FlightOfIdeas;
        }

        SeverityLevels Distractibility
        {
            get => Distractibility;
            set => Distractibility = value;
        }
        private int _distractibility
        {
            get => _distractibility;
            set => _distractibility = (int)this.Distractibility;
        }

        SeverityLevels GoalDirectedActivity
        {
            get => GoalDirectedActivity;
            set => GoalDirectedActivity = value;
        }

        private int _goalDirectedActivity
        {
            get => _goalDirectedActivity;
            set => _goalDirectedActivity = (int)this.GoalDirectedActivity;
        }

        SeverityLevels PsychomotorAgitation
        {
            get => PsychomotorAgitation;
            set => PsychomotorAgitation = value;
        }

        private int _psychomotorAgitation
        {
            get => _psychomotorAgitation;
            set => _psychomotorAgitation = (int)this.PsychomotorAgitation;
        }

        SeverityLevels RiskyImpulsivity
        {
            get => RiskyImpulsivity;
            set => RiskyImpulsivity = value;
        }

        private int _riskyImpuslivity
        {
            get => _riskyImpuslivity;
            set => _riskyImpuslivity = (int)this.RiskyImpulsivity;
        }

        SeverityLevels DisruptionOfDailyLife
        {
            get => DisruptionOfDailyLife;
            set => DisruptionOfDailyLife = value;
        }

        bool PsychosisPresent
        {
            get => PsychosisPresent;
            set => PsychosisPresent = value;
        }

        bool HospitalizationRequired
        {
            get => HospitalizationRequired;
            set => HospitalizationRequired = value;
        }

        TimeSpan LengthOfDisturbance
        {
            get => LengthOfDisturbance;
            set
            {
                if (value >= TimeSpan.FromDays(1))
                {
                    LengthOfDisturbance = value;
                }
            }
        }

        // Need constructor and methods

    }


    class DepressiveSymptoms
    {
        SeverityLevels DepressedMood
        {
            get => DepressedMood;
            set => DepressedMood = value;
        }

        SeverityLevels Anhedonia
        {
            get => Anhedonia;
            set => Anhedonia = value;
        }

        SeverityLevels AppetiteChanges
        {
            get => AppetiteChanges;
            set => AppetiteChanges = value;
        }

        SeverityLevels SleepChanges
        {
            get => SleepChanges;
            set => SleepChanges = value;
        }

        Int32 PsychomotorRetardationOrAgitation
        {
            get => PsychomotorRetardationOrAgitation;
            set
            {
                if ((value >= -10) && (value <= 10))
                {
                    PsychomotorRetardationOrAgitation = value;
                }
            }
        }

        SeverityLevels Fatigue
        {
            get => Fatigue;
            set => Fatigue = value;
        }

        SeverityLevels WorthlessnessOrGuilt
        {
            get => WorthlessnessOrGuilt;
            set => WorthlessnessOrGuilt = value;
        }

        SeverityLevels BrainFog
        {
            get => BrainFog;
            set => BrainFog = value;
        }

        Suicidality LevelOfSuicidality
        {
            get => LevelOfSuicidality;
            set => LevelOfSuicidality = value;
        }

        SeverityLevels DisruptionOfDailyLife
        {
            get => DisruptionOfDailyLife;
            set => DisruptionOfDailyLife = value;
        }

        // Need constructors and methods
    }




    enum SeverityLevels
    {
        None = 0,
        Mild = 1,
        Moderate = 2,
        Severe = 4,
        Extreme = 8
    }


    enum Suicidality
    {
        None = 0,
        Mild = 1,
        Moderate = 2,
        Severe = 4,
        Imminent = 8
    }


}
















    class Program
    {
        static void Main(string[] args)
        {

        }
    }
}