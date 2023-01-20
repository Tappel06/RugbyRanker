using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rugby_Ranker
{
    internal class RatingSystem
    {
        private static double pointDiffernece;
        private static int homeTeamIndex;
        private static int awayTeamIndex;
        private static double homeTeamCalculatedRating;
        private static double awayTeamCalculatedRating;
        private static double ratingMargin;

        //Calculates point difference, and then add it to the specific teams as a rating
        public static void CalculateMatch(string homeTeam, double homeTeamScore, string awayTeam, double awayTeamScore) 
        {
            Console.WriteLine(homeTeam + " " + awayTeam);

            //deducts the lowest score from the highest score to get a point difference
            if (homeTeamScore > awayTeamScore) 
            {
                pointDiffernece = homeTeamScore - awayTeamScore;
            }
            else 
            if (homeTeamScore < awayTeamScore) 
            {
                pointDiffernece = awayTeamScore - homeTeamScore;
            }
            else 
            if (homeTeamScore == awayTeamScore) 
            {
                pointDiffernece = 0;
            }

            //finds the index and calculated rating of homeTeam
            for(int i = 0; i < ProgramMethods.RugbyTeams.Length; i++) 
            {
                if (ProgramMethods.RugbyTeams[i].GetIsTeamAccountActivated() == true) 
                {
                    if (ProgramMethods.RugbyTeams[i].GetTeamName() == homeTeam) 
                    {
                        homeTeamIndex = i;
                        homeTeamCalculatedRating = ProgramMethods.RugbyTeams[i].GetCalculatedRating();
                        break;
                    }
                }
            }

            //finds the index and calculated rating of awayTeam
            for (int i = 0; i < ProgramMethods.RugbyTeams.Length; i++)
            {
                if (ProgramMethods.RugbyTeams[i].GetIsTeamAccountActivated() == true)
                {
                    if (ProgramMethods.RugbyTeams[i].GetTeamName() == awayTeam)
                    {
                        awayTeamIndex = i;
                        awayTeamCalculatedRating = ProgramMethods.RugbyTeams[i].GetCalculatedRating();
                        break;
                    }
                }
            }

            //adding point difference to team calculated rating and checkking conditions
            // if calculated ratings are equal
            if (awayTeamCalculatedRating == homeTeamCalculatedRating)
            {
                //if hometeam score is bigger than away team
                if (homeTeamScore > awayTeamScore)
                {

                    if ((awayTeamCalculatedRating - (pointDiffernece / 2)) < 0)
                    {
                        awayTeamCalculatedRating = 0;
                        homeTeamCalculatedRating = pointDiffernece;
                    }
                    else
                    {
                        homeTeamCalculatedRating = homeTeamCalculatedRating + (pointDiffernece / 2);
                        awayTeamCalculatedRating = awayTeamCalculatedRating - (pointDiffernece / 2);
                    }
                }
                //if away team score is bigger than home team
                else
                if (homeTeamScore < awayTeamScore)
                {
                    if ((homeTeamCalculatedRating - (pointDiffernece / 2)) < 0)
                    {
                        homeTeamCalculatedRating = 0;
                        awayTeamCalculatedRating = pointDiffernece;
                    }
                    else
                    {
                        homeTeamCalculatedRating = homeTeamCalculatedRating - (pointDiffernece / 2);
                        awayTeamCalculatedRating = awayTeamCalculatedRating + (pointDiffernece / 2);
                    }
                }
                //calculate rating margin
                if (homeTeamCalculatedRating == awayTeamCalculatedRating)
                {
                    ratingMargin = 0;
                }
                else
                if (homeTeamCalculatedRating > awayTeamCalculatedRating)
                {
                    ratingMargin = homeTeamCalculatedRating - awayTeamCalculatedRating;
                }
                else
                if (homeTeamCalculatedRating < awayTeamCalculatedRating)
                {
                    ratingMargin = awayTeamCalculatedRating - homeTeamCalculatedRating;
                }

            }
            //home score >, rating >, point difference > rating margin.
            else
            if (homeTeamScore > awayTeamScore && homeTeamCalculatedRating > awayTeamCalculatedRating && pointDiffernece > ratingMargin)
            {
                if ((awayTeamCalculatedRating - ((pointDiffernece - ratingMargin) / 2)) < 0)
                {
                    awayTeamCalculatedRating = 0;
                    homeTeamCalculatedRating = pointDiffernece;
                }
                else
                {
                    awayTeamCalculatedRating = awayTeamCalculatedRating - ((pointDiffernece - ratingMargin) / 2);
                    homeTeamCalculatedRating = homeTeamCalculatedRating + ((pointDiffernece - ratingMargin) / 2);
                }
            }
            //home score >, rating >,  point difference < rating margin.
            else
            if (homeTeamScore > awayTeamScore && homeTeamCalculatedRating > awayTeamCalculatedRating && pointDiffernece < ratingMargin)
            {
                //if (rating margin - point difference) < point difference
                if ((ratingMargin - pointDiffernece) < pointDiffernece)
                {
                    homeTeamCalculatedRating = homeTeamCalculatedRating - ((ratingMargin - pointDiffernece) / 2);
                    awayTeamCalculatedRating = awayTeamCalculatedRating + ((ratingMargin - pointDiffernece) / 2);
                }
                //if (rating margin - point difference) > point difference
                else
                if ((ratingMargin - pointDiffernece) > pointDiffernece)
                {
                    homeTeamCalculatedRating = homeTeamCalculatedRating - (pointDiffernece / 2);
                    awayTeamCalculatedRating = awayTeamCalculatedRating + (pointDiffernece / 2);
                }
            }
            //home score >, rating <.
            else
            if (homeTeamScore > awayTeamScore && homeTeamCalculatedRating < awayTeamCalculatedRating)
            {
                if ((awayTeamCalculatedRating - (pointDiffernece / 2)) < 0)
                {
                    awayTeamCalculatedRating = 0;
                    homeTeamCalculatedRating = pointDiffernece;
                }
                else 
                {
                    awayTeamCalculatedRating = awayTeamCalculatedRating - (pointDiffernece / 2);
                    homeTeamCalculatedRating = homeTeamCalculatedRating + (pointDiffernece / 2);
                }
            }
            //away score >, rating >,  point difference > rating margin.
            else
            if (awayTeamScore > homeTeamScore && awayTeamCalculatedRating > homeTeamCalculatedRating && pointDiffernece > ratingMargin)
            {
                //if awayteam score is bigger than home team
                if (awayTeamScore > homeTeamScore)
                {

                    if ((homeTeamCalculatedRating - (pointDiffernece / 2)) < 0)
                    {
                        homeTeamCalculatedRating = 0;
                        awayTeamCalculatedRating = pointDiffernece;
                    }
                    else
                    {
                        awayTeamCalculatedRating = awayTeamCalculatedRating + (pointDiffernece / 2);
                        homeTeamCalculatedRating = homeTeamCalculatedRating - (pointDiffernece / 2);
                    }
                }
                //if home team score is bigger than away team
                else
                if (awayTeamScore < homeTeamScore)
                {
                    if ((awayTeamCalculatedRating - (pointDiffernece / 2)) < 0)
                    {
                        awayTeamCalculatedRating = 0;
                        homeTeamCalculatedRating = pointDiffernece;
                    }
                    else
                    {
                        awayTeamCalculatedRating = awayTeamCalculatedRating - (pointDiffernece / 2);
                        homeTeamCalculatedRating = homeTeamCalculatedRating + (pointDiffernece / 2);
                    }
                }
                //calculate rating margin
                if (awayTeamCalculatedRating == homeTeamCalculatedRating)
                {
                    ratingMargin = 0;
                }
                else
                if (awayTeamCalculatedRating > homeTeamCalculatedRating)
                {
                    ratingMargin = awayTeamCalculatedRating - homeTeamCalculatedRating;
                }
                else
                if (awayTeamCalculatedRating < homeTeamCalculatedRating)
                {
                    ratingMargin = homeTeamCalculatedRating - awayTeamCalculatedRating;
                }
            }
            //away score >, rating >,  point difference < rating margin.
            else
            if (awayTeamScore > homeTeamScore && awayTeamCalculatedRating > homeTeamCalculatedRating && pointDiffernece < ratingMargin)
            {
                if ((homeTeamCalculatedRating - ((pointDiffernece - ratingMargin) / 2)) < 0)
                {
                    homeTeamCalculatedRating = 0;
                    awayTeamCalculatedRating = pointDiffernece;
                }
                else
                {
                    homeTeamCalculatedRating = homeTeamCalculatedRating - ((pointDiffernece - ratingMargin) / 2);
                    awayTeamCalculatedRating = awayTeamCalculatedRating + ((pointDiffernece - ratingMargin) / 2);
                }
            }
            //away score >, rating <.
            else
            if (awayTeamScore > homeTeamScore && awayTeamCalculatedRating < homeTeamCalculatedRating) 
            {
                if ((homeTeamCalculatedRating - (pointDiffernece / 2)) < 0)
                {
                    homeTeamCalculatedRating = 0;
                    awayTeamCalculatedRating = pointDiffernece;
                }
                else
                {
                    homeTeamCalculatedRating = homeTeamCalculatedRating - (pointDiffernece / 2);
                    awayTeamCalculatedRating = awayTeamCalculatedRating + (pointDiffernece / 2);
                }
            }

            //update original team calculated ratings
            //home team
            ProgramMethods.RugbyTeams[homeTeamIndex].setCalculatedRating(homeTeamCalculatedRating);
            ProgramMethods.RugbyTeams[awayTeamIndex].setCalculatedRating(awayTeamCalculatedRating);
        }

        //calculate new calculated ranks from stored records
        public static void CalculateRecords() 
        {
            if (MatchDatabase.CountTotalRecords() != null || MatchDatabase.CountTotalRecords() != 0) 
            {
                for (int i = 0; i < ProgramMethods.RugbyTeams.Length; i++)
                {
                    if (ProgramMethods.RugbyTeams[i].GetIsTeamAccountActivated() == true)
                    {
                        ProgramMethods.RugbyTeams[i].setCalculatedRating(ProgramMethods.RugbyTeams[i].GetRating());
                    }
                }
                for (int i = 0; i < MatchDatabase.CountTotalRecords(); i++)
                {
                    CalculateMatch(MatchDatabase.GetHomeTeamName(i), MatchDatabase.GetHomeTeamScore(i), MatchDatabase.GetAwayTeamName(i), MatchDatabase.GetAwayTeamScore(i));
                }
            }
        }
    }
}
