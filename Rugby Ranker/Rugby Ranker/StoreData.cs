using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rugby_Ranker
{
    internal class StoreData
    {
        private static string fileName = "teamData.txt";
        private static string saveDataBuilder;
        private static string teamTriger = "#TeamNames#";
        private static string scoreTrigger = "#TeamScores#";
        private static string awayTeam = "#AwayTeam#";
        private static string awayTeamScore = "#AwayTeamScore#";
        private static string homeTeam = "#homeTeam#";
        private static string homeTeamScore = "#homeTeamScore#";
        private static string date = "#Date#";
        private static string hashCode = "#hash#";

        private static void BuildString() 
        {
            saveDataBuilder = "";

            //Store Team names
            saveDataBuilder = teamTriger;
            for(int i = 0; i < ProgramMethods.RugbyTeams.Length; i++) 
            {
                if (ProgramMethods.RugbyTeams[i].GetIsTeamAccountActivated() == true) 
                {
                    saveDataBuilder = saveDataBuilder + ProgramMethods.RugbyTeams[i].GetTeamName().ToString() +"%";

                }
            }
            //Save Team Scores
            saveDataBuilder = saveDataBuilder + scoreTrigger;
            for (int i = 0; i < ProgramMethods.RugbyTeams.Length; i++) 
            {
                if (ProgramMethods.RugbyTeams[i].GetIsTeamAccountActivated() == true)
                {
                    //saveDataBuilder = saveDataBuilder + ProgramMethods.RugbyTeams[i].GetRating().ToString() + "%";
                    saveDataBuilder = saveDataBuilder + Math.Round(ProgramMethods.RugbyTeams[i].GetRating(), 2).ToString() + "%";
                }
            }
            //Save Records Home Team Names
            saveDataBuilder = saveDataBuilder + homeTeam;
            for (int i = 0; i < MatchDatabase.CountTotalRecords(); i++) 
            {
                saveDataBuilder = saveDataBuilder + MatchDatabase.GetHomeTeamName(i).ToString() + "%";
            }

            //Save Records Away Team Names
            saveDataBuilder = saveDataBuilder + awayTeam;
            for (int i = 0; i <  MatchDatabase.CountTotalRecords(); i++) 
            {
                saveDataBuilder = saveDataBuilder + MatchDatabase.GetAwayTeamName(i).ToString() + "%";
            }

            //Save Records Home Team Scores
            saveDataBuilder = saveDataBuilder + homeTeamScore;
            for (int i = 0; i < MatchDatabase.CountTotalRecords(); i++) 
            {
                saveDataBuilder = saveDataBuilder + MatchDatabase.GetHomeTeamScore(i).ToString() + "%";
            }

            //Save Records Away Team Score
            saveDataBuilder = saveDataBuilder + awayTeamScore;
            for (int i = 0; i < MatchDatabase.CountTotalRecords(); i++) 
            {
                saveDataBuilder = saveDataBuilder + MatchDatabase.GetAwayTeamScore(i).ToString() + "%";
            }

            //Save Records Dates
            saveDataBuilder = saveDataBuilder + date;
            for (int i = 0; i < MatchDatabase.CountTotalRecords(); i++) 
            {
                saveDataBuilder = saveDataBuilder + MatchDatabase.GetMatchDate(i).ToShortDateString() + "%";
            }

            //Save Records HashCodes
            saveDataBuilder = saveDataBuilder + hashCode;
            for(int i = 0; i < MatchDatabase.CountTotalRecords(); i++) 
            {
                saveDataBuilder = saveDataBuilder + MatchDatabase.GetHashID(i).ToString() + "%";
            }

            saveDataBuilder = saveDataBuilder + "@";
        }

        public static void StoreProgramData() 
        {
            BuildString();
            StreamWriter writer = new StreamWriter(fileName);
            writer.WriteLine(saveDataBuilder);
            writer.Close();
        }
    }
}
