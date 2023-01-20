using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rugby_Ranker
{
    internal class MatchDatabase
    {
        private static ArrayList HomeTeamName = new ArrayList();
        private static ArrayList HomeTeamScore = new ArrayList();
        private static ArrayList AwayTeamName = new ArrayList();
        private static ArrayList AwayTeamScore = new ArrayList();
        private static ArrayList MatchDate = new ArrayList();
        private static ArrayList HashID = new ArrayList();

        //Home Team Name Properties
        public static string GetHomeTeamName(int index)
        {
                return HomeTeamName[index].ToString();
        }

        public static void AddHomeTeamName(string name)
        {
            HomeTeamName.Add(name);
        }

        private static void RemoveHomeTeamName(int index)
        {
            HomeTeamName.RemoveAt(index);
        }

        //Home team score properties
        public static int GetHomeTeamScore(int index)
        {
            return (int)HomeTeamScore[index];
        }

        public static void AddHomeTeamScore(int score)
        {
            HomeTeamScore.Add(score);
        }

        private static void RemoveHomeTeamScore(int index)
        {
            HomeTeamScore.RemoveAt(index);
        }


        //Away Team Name Properties
        public static string GetAwayTeamName(int index)
        {
            return AwayTeamName[index].ToString();
        }

        public static void AddAwayTeamName(string name)
        {
            AwayTeamName.Add(name);
        }

        private static void RemoveAwayTeamName(int index)
        {
            AwayTeamName.RemoveAt(index);
        }

        //Away Team Score Properties
        public static int GetAwayTeamScore(int index)
        {
            return (int)AwayTeamScore[index];
        }

        public static void AddAwayTeamScore(int score)
        {
            AwayTeamScore.Add(score);
        }

        private static void RemoveAwayTeamScore(int index)
        {
            AwayTeamScore.RemoveAt(index);
        }

        //MatchDate Properties
        public static DateTime GetMatchDate(int index)
        {
            return Convert.ToDateTime(MatchDate[index]);
        }

        public static void AddMatchDayByString(string a) 
        {
            DateTime date = DateTime.ParseExact(a, "yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture);
            MatchDate.Add(date);
        }

        private static void AddMatchDate(int year, int month, int day)
        {
            DateTime date = new DateTime(year, month, day);
            MatchDate.Add(date);
        }

        private static void RemoveMatchDate(int index)
        {
            MatchDate.RemoveAt(index);
        }


        //HashID Properties
        public static string GetHashID(int index)
        {
            return HashID[index].ToString();
        }

        public static void AddHashIDByString(string a) 
        {
            HashID.Add(a);
        }

        private static void AddHashID()
        {
            HashID.Add(GenerateHashID());
        }

        private static void RemoveHashID(int index)
        {
            HashID.RemoveAt(index);
        }

        //Generate a unique ID by  using HashCode
        private static string GenerateHashID()
        {
            string buildString;
            string hashID;
            int index = HomeTeamName.Count - 1;
            buildString = HomeTeamName[index].ToString() + AwayTeamName[index].ToString();
            hashID = buildString.GetHashCode().ToString();
            return hashID;
        }

        //Add a record
        public static void AddRecord(string homeName, int homeScore, string awayName, int awayScore, int year, int month, int day)
        {
            AddHomeTeamName(homeName);
            AddHomeTeamScore(homeScore);
            AddAwayTeamName(awayName);
            AddAwayTeamScore(awayScore);
            AddMatchDate(year, month, day);
            AddHashID();
        }

        public static void RemoveRecord(int index)
        {
            RemoveHomeTeamName(index);
            RemoveHomeTeamScore(index);
            RemoveAwayTeamName(index);
            RemoveAwayTeamScore(index);
            RemoveMatchDate(index);
            RemoveHashID(index);
        }

        public static void RemoveAllRecords()
        {
            HomeTeamName.Clear();
            HomeTeamScore.Clear();
            AwayTeamName.Clear();
            AwayTeamScore.Clear();
            MatchDate.Clear();
            HashID.Clear();
        }

        public static string GetFullRecord(int index)
        {
            if(HomeTeamName.Count > 0) 
            {
                string date = GetMatchDate(index).ToShortDateString();
                string home = GetHomeTeamName(index);
                string hS = GetHomeTeamScore(index).ToString();
                string away = GetAwayTeamName(index);
                string aS = GetAwayTeamScore(index).ToString();
                string ID = GetHashID(index);

                string fullRecord = (index + ". " + date + ". " + home + ": " + hS + " VS " + away + ": " + aS + ". ID: " + ID);

                return fullRecord;
            }
            else 
            {
                return null;
            }
        }

        public static int CountTotalRecords() 
        {
            int total;

            if (HomeTeamName.Count > 0) 
            {
                total = HomeTeamName.Count;
            }
            else 
            {
                total = 0;
            }
            return total;
        }
    }
}
