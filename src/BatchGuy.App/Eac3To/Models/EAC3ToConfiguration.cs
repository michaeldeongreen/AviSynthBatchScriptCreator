﻿using BatchGuy.App.Eac3To.Models;
using BatchGuy.App.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatchGuy.App.Eac3to.Models
{
    public class EAC3ToConfiguration
    {
        public string EAC3ToPath { get; set; }
        public string BatchFilePath { get; set; }
        public string EAC3ToOutputPath { get; set; }
        public EnumDirectoryType OutputDirectoryType { get; set; }
        public bool IsExtractForRemux { get; set; }
        public EAC3ToRemuxFileNameTemplate RemuxFileNameTemplate { get; set; }
        public int NumberOfEpisodes { get; set; }
        public string MKVMergeOutputPath { get; set; }
        public string MKVMergePath { get; set; }
    }
}
