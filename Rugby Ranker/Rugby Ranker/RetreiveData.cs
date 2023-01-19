using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rugby_Ranker
{
    internal class RetreiveData
    {
        private static string fileName = "teamData.txt";
        private static string teamTriger = "#TeamNames#";
        private static string scoreTrigger = "#TeamScores#";
        private static char endDocumentChar = '@';
        private static string awayTeam = "#AwayTeam#";
        private static string awayTeamScore = "#AwayTeamScore#";
        private static string homeTeam = "#homeTeam#";
        private static string homeTeamScore = "#homeTeamScore#";
        private static string date = "#Date#";
        private static string hashCode = "#hash#";

        //Reads the content from a file and then adds it to the program
        public static void Retreive() 
        {
            string keyWord = "";
            string wordBuilder = "";
            
            ArrayList teamNames = new ArrayList();
            ArrayList teamScores = new ArrayList();

            ArrayList awayTeamNames = new ArrayList();
            ArrayList awayTeamScores = new ArrayList();
            ArrayList homeTeamNames = new ArrayList();
            ArrayList homeTeamScores = new ArrayList();
            ArrayList dates = new ArrayList();
            ArrayList hashCodes = new ArrayList();

            StreamReader readFile = new StreamReader(fileName);
            char Data = (char)readFile.Read();

            while (Data != endDocumentChar) 
            {

                if (Data != ',') 
                {
                    wordBuilder = wordBuilder + Data.ToString();
                }

                if(wordBuilder == teamTriger) 
                {
                    keyWord = teamTriger;
                    wordBuilder = "";
                }

                if (wordBuilder == scoreTrigger) 
                {
                    keyWord = scoreTrigger;
                    wordBuilder = "";
                }

                if (wordBuilder == homeTeam) 
                {
                    keyWord = homeTeam;
                    wordBuilder = "";
                }

                if(wordBuilder == homeTeamScore) 
                {
                    keyWord = homeTeamScore;
                    wordBuilder = "";
                }

                if(wordBuilder == awayTeam) 
                {
                    keyWord = awayTeam;
                    wordBuilder = "";
                }

                if (wordBuilder == awayTeamScore) 
                {
                    keyWord = awayTeamScore;
                    wordBuilder = "";
                }

                if (wordBuilder == date) 
                {
                    keyWord = date;
                    wordBuilder = "";
                }

                if (wordBuilder == hashCode) 
                {
                    keyWord = hashCode;
                    wordBuilder = "";
                }

                if (keyWord == teamTriger) 
                {
                    if (Data == ',')
                    {
                        teamNames.Add(wordBuilder);
                        wordBuilder = "";
                    }
                }

                if (keyWord == scoreTrigger) 
                {
                    if (Data == ',')
                    {
                        teamScores.Add(wordBuilder);
                        wordBuilder = "";
                    }
                }

                if (keyWord == homeTeam) 
                {
                    if (Data == ',') 
                    {
                        homeTeamNames.Add(wordBuilder);
                        wordBuilder = "";
                    }
                }

                if (keyWord == homeTeamScore) 
                {
                    if(Data == ',') 
                    {
                        homeTeamScores.Add(wordBuilder);
                        wordBuilder = "";
                    }
                }

                if (keyWord == awayTeam) 
                {
                    if (Data == ',') 
                    {
                        awayTeamNames.Add(wordBuilder);
                        wordBuilder = "";
                    }
                }

                if (keyWord == awayTeamScore) 
                {
                    if (Data == ',') 
                    {
                        awayTeamScores.Add(wordBuilder);
                        wordBuilder = "";
                    }
                }

                if (keyWord == date) 
                {
                    if (Data == ',') 
                    {
                        dates.Add(wordBuilder);
                        wordBuilder = "";
                    }
                }

                if (keyWord == hashCode) 
                {
                    if (Data == ',') 
                    {
                        hashCodes.Add(wordBuilder);
                        wordBuilder = "";
                    }
                }

                Data = (char)readFile.Read();
            }

            if(teamNames.Count > 0) 
            {
                for (int i = 0; i < teamNames.Count; i++)
                {
                    ProgramMethods.RugbyTeams[i].ActivateTeamAccount();
                    ProgramMethods.RugbyTeams[i].SetTeamName(teamNames[i].ToString());
                    ProgramMethods.RugbyTeams[i].SetRating(Convert.ToDouble(teamScores[i]));
                    ProgramMethods.RugbyTeams[i].setCalculatedRating(ProgramMethods.RugbyTeams[i].GetRating());
                }
            }

            if(homeTeamNames.Count > 0) 
            {
                for(int i = 0; i < homeTeamNames.Count; i++) 
                {
                    MatchDatabase.AddHomeTeamName(homeTeamNames[i].ToString());
                    MatchDatabase.AddHomeTeamScore(Convert.ToInt32(homeTeamScores[i]));
                    MatchDatabase.AddAwayTeamName(awayTeamNames[i].ToString());
                    MatchDatabase.AddAwayTeamScore(Convert.ToInt32(awayTeamScores[i]));
                    MatchDatabase.AddMatchDayByString(dates[i].ToString());
                    MatchDatabase.AddHashIDByString(hashCodes[i].ToString());
                }
            }
        }
    }
}
