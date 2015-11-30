﻿using BatchGuy.App.Eac3to.Models;
using BatchGuy.App.Eac3To.Interfaces;
using BatchGuy.App.Enums;
using BatchGuy.App.Helpers;
using BatchGuy.App.Parser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatchGuy.App.Eac3To.Services
{
    public class EAC3ToOutputNamingService : IEAC3ToOutputNamingService
    {
        public string GetChapterName(EAC3ToConfiguration eac3toConfiguration, string filesOutputPath, string paddedEpisodeNumber, string episodeName)
        {
            StringBuilder sb = new StringBuilder();
            if (eac3toConfiguration.IsExtractForRemux != true)
            {
                sb.Append(string.Format("\"{0}\\chapters{1}.txt\"", filesOutputPath, paddedEpisodeNumber));
            }
            else
            {
                sb.Append(string.Format("\"{0}\\{1}{2}S{3}E{4}{5}{6} Remux AVC {7}{8} chapters.txt\"", filesOutputPath, eac3toConfiguration.RemuxFileNameTemplate.SeriesName, this.GetYear(eac3toConfiguration),
                    this.PadNumberWithZeros(eac3toConfiguration.NumberOfEpisodes, eac3toConfiguration.RemuxFileNameTemplate.SeasonNumber),
                    paddedEpisodeNumber,this.GetFormattedEpisodeName(episodeName), eac3toConfiguration.RemuxFileNameTemplate.VideoResolution, eac3toConfiguration.RemuxFileNameTemplate.AudioType, this.GetTag(eac3toConfiguration)));
            }
            return sb.ToString();
        }

        public string GetVideoName(EAC3ToConfiguration eac3toConfiguration, string filesOutputPath, string paddedEpisodeNumber, string episodeName)
        {
            StringBuilder sb = new StringBuilder();
            if (eac3toConfiguration.IsExtractForRemux != true)
            {
                sb.Append(string.Format("\"{0}\\video{1}.mkv\"", filesOutputPath, paddedEpisodeNumber));                
            }
            else
            {
                sb.Append(string.Format("\"{0}\\{1}{2}S{3}E{4}{5}{6} Remux AVC {7}{8}.mkv\"", filesOutputPath, eac3toConfiguration.RemuxFileNameTemplate.SeriesName,this.GetYear(eac3toConfiguration),
                    this.PadNumberWithZeros(eac3toConfiguration.NumberOfEpisodes, eac3toConfiguration.RemuxFileNameTemplate.SeasonNumber),
                    paddedEpisodeNumber, this.GetFormattedEpisodeName(episodeName), eac3toConfiguration.RemuxFileNameTemplate.VideoResolution, eac3toConfiguration.RemuxFileNameTemplate.AudioType, this.GetTag(eac3toConfiguration)));
            }
            return sb.ToString();

        }

        public string GetAudioName(EAC3ToConfiguration eac3toConfiguration, Parser.Models.BluRayTitleAudio audio, string filesOutputPath, string paddedEpisodeNumber, string episodeName, int itemNumber)
        {
            StringBuilder sb = new StringBuilder();
            if (eac3toConfiguration.IsExtractForRemux != true)
            {
                sb.Append(string.Format("\"{0}\\{1}{2}-{3}.{4}\"", filesOutputPath, audio.Language, paddedEpisodeNumber, itemNumber.ToString(), this.GetAudioExtension(audio.AudioType)));
            }
            else
            {
                sb.Append(string.Format("\"{0}\\{1}{2}S{3}E{4}{5}{6} Remux AVC {7}{8} {9}{10}-{11}.{12}\"", filesOutputPath, eac3toConfiguration.RemuxFileNameTemplate.SeriesName,this.GetYear(eac3toConfiguration),
                    this.PadNumberWithZeros(eac3toConfiguration.NumberOfEpisodes, eac3toConfiguration.RemuxFileNameTemplate.SeasonNumber),
                    paddedEpisodeNumber, this.GetFormattedEpisodeName(episodeName), eac3toConfiguration.RemuxFileNameTemplate.VideoResolution, eac3toConfiguration.RemuxFileNameTemplate.AudioType, this.GetTag(eac3toConfiguration), audio.Language, paddedEpisodeNumber, itemNumber.ToString(),
                    this.GetAudioExtension(audio.AudioType)));
            }
            return sb.ToString();
        }

        public string GetSubtitleName(EAC3ToConfiguration eac3toConfiguration, BluRayTitleSubtitle subtitle, string filesOutputPath, string paddedEpisodeNumber, string episodeName, int itemNumber)
        {
            StringBuilder sb = new StringBuilder();
            if (eac3toConfiguration.IsExtractForRemux != true)
            {
                sb.Append(string.Format("\"{0}\\{1}{2}-{3}.sup\"", filesOutputPath, subtitle.Language, paddedEpisodeNumber, itemNumber.ToString()));
            }
            else
            {
                sb.Append(string.Format("\"{0}\\{1}{2}S{3}E{4}{5}{6} Remux AVC {7}{8} {9}{10}-{11}.sup\"", filesOutputPath, eac3toConfiguration.RemuxFileNameTemplate.SeriesName,this.GetYear(eac3toConfiguration),
                    this.PadNumberWithZeros(eac3toConfiguration.NumberOfEpisodes, eac3toConfiguration.RemuxFileNameTemplate.SeasonNumber),
                    paddedEpisodeNumber, this.GetFormattedEpisodeName(episodeName), eac3toConfiguration.RemuxFileNameTemplate.VideoResolution, eac3toConfiguration.RemuxFileNameTemplate.AudioType, this.GetTag(eac3toConfiguration), subtitle.Language, paddedEpisodeNumber, itemNumber.ToString()));
            }
            return sb.ToString();
        }
        public string GetLogName(EAC3ToConfiguration eac3toConfiguration, string filesOutputPath, string paddedEpisodeNumber, string episodeName)
        {
            StringBuilder sb = new StringBuilder();
            if (eac3toConfiguration.IsExtractForRemux != true)
            {
                sb.Append(string.Format(" -log=\"{0}\\log{1}.txt\"", filesOutputPath, paddedEpisodeNumber));
            }
            else
            {
                sb.Append(string.Format(" -log=\"{0}\\{1}{2}S{3}E{4}{5}{6} Remux AVC {7}{8} log.txt\"", filesOutputPath, eac3toConfiguration.RemuxFileNameTemplate.SeriesName, this.GetYear(eac3toConfiguration),
                    this.PadNumberWithZeros(eac3toConfiguration.NumberOfEpisodes, eac3toConfiguration.RemuxFileNameTemplate.SeasonNumber),
                    paddedEpisodeNumber, this.GetFormattedEpisodeName(episodeName), eac3toConfiguration.RemuxFileNameTemplate.VideoResolution, eac3toConfiguration.RemuxFileNameTemplate.AudioType, this.GetTag(eac3toConfiguration)));
            }
            return sb.ToString();
        }

        private string PadNumberWithZeros(int batchCount, int number)
        {
            return HelperFunctions.PadNumberWithZeros(batchCount, number);
        }

        private string GetTag(EAC3ToConfiguration eac3toConfiguration)
        {
            string tag = string.Empty;
            if (eac3toConfiguration.RemuxFileNameTemplate.Tag != null && eac3toConfiguration.RemuxFileNameTemplate.Tag != string.Empty)
                tag = string.Format("-{0}", eac3toConfiguration.RemuxFileNameTemplate.Tag);
            return tag;
        }

        private string GetYear(EAC3ToConfiguration eac3toConfiguration)
        {
            string year = " ";
            if (eac3toConfiguration.RemuxFileNameTemplate.SeasonYear != null)
                year = string.Format(" {0} ", eac3toConfiguration.RemuxFileNameTemplate.SeasonYear);
            return year;
        }

        private string GetAudioExtension(EnumAudioType audioType)
        {
            string audioExtension = string.Empty;

            switch (audioType)
            {
                case EnumAudioType.DTS:
                    audioExtension = "dts";
                    break;
                case EnumAudioType.AC3:
                    audioExtension = "ac3";
                    break;
                case EnumAudioType.FLAC:
                    audioExtension = "flac";
                    break;
                case EnumAudioType.TrueHD:
                    audioExtension = "thd";
                    break;
                case EnumAudioType.MPA:
                    audioExtension = "mpa";
                    break;
                case EnumAudioType.DTSMA:
                    audioExtension = "dtsma";
                    break;
                case EnumAudioType.WAVE:
                    audioExtension = "wav";
                    break;
                default:
                    throw new Exception("Invalid Audio Type");
            }
            return audioExtension;
        }

        private string GetFormattedEpisodeName(string episodeName)
        {
            string formmattedEpisodeName = " ";
            if (!string.IsNullOrEmpty(episodeName))
            {
                formmattedEpisodeName = string.Format(" {0} ",episodeName.Trim());
            }

            return formmattedEpisodeName;
        }
    }
}
