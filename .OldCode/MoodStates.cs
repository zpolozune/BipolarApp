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

namespace MoodStates
{
    class Program
    {
        public void Main(string[] args)
        {

        }
    }



    public class MoodStateObject
    {
        public DateTime StartOfLoggedTime
        {
            get;
            set
            {
                StartOfLoggedTime = value;
            }
        }

        public DateTime EndOfLoggedPeriod
        {
            get;
            init
            {
                this.EndOfLoggedPeriod = value;
            }
        }

        public UInt32 AmountOfSleep
        {
            get;
            set
            {
                if (value <= 24)
                {
                    this.AmountOfSleep = value;
                }
            }
        }

        public UInt32 Mania
        {
            get;
            set
            {
                if ((value >= 0) && (value <= 10))
                {
                    this.Mania = value;
                }
            }
        }

        public UInt32 Depression
        {
            get;
            set
            {
                if ((value >= 0) && (value <= 10))
                {
                    this.Depression = value;
                }
            }
        }

        public UInt32 EnergyLevel
        {
            get;
            set
            {
                if (value <= 10)
                {
                    this.EnergyLevel = value;
                }
            }
        }

        public UInt32 Anxiety
        {
            get;
            set
            {
                if ((value >= 0) && (value <= 10))
                {
                    this.Anxiety = value;
                }
            }
        }

        public UInt32 Impulsivity
        {
            get;
            set
            {
                if ((value >= 0) && (value <= 10))
                {
                    this.Impulsivity = value;
                }
            }
        }

        public Suicidality LevelOfSuicidality
        {
            get;
            set;
        }

        public DateTime RecordedDateTime
        {
            get;
            init
            {
                this.RecordedDateTime = DateTime.Now;
            }
        }



        MoodStateObject(string _start, string _end, uint _sleep, uint _mania, uint _depression, uint _energy, uint _anxiety, uint _impuslivity, Suicidality _suicidality)
        {
            this.StartOfLoggedTime = DateTime.Parse(_start);
            this.EndOfLoggedPeriod = DateTime.Parse(_end);
            this.AmountOfSleep = _sleep;
            this.Mania = _mania;
            this.Depression = _depression;
            this.EnergyLevel = _energy;
            this.Anxiety = _anxiety;
            this.Impulsivity = _impuslivity;
            this.LevelOfSuicidality = _suicidality;
        }

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