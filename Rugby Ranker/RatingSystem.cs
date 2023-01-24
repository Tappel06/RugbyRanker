using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

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

            //finds the index and get calculated rating of homeTeam
            for (int i = 0; i < ProgramMethods.RugbyTeams.Length; i++)
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

            //finds the index and get calculated rating of awayTeam
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

            //Calculate Rating Margin
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

            //adding point difference to team calculated rating and checkking conditions
            // if HS > AS; HR == AR
            if (homeTeamScore > awayTeamScore && homeTeamCalculatedRating == awayTeamCalculatedRating)
            {
                if ((awayTeamCalculatedRating - (pointDiffernece / 2)) < 0)
                {
                    homeTeamCalculatedRating = pointDiffernece;
                    awayTeamCalculatedRating = 0;
                }
                else
                {
                    homeTeamCalculatedRating += (pointDiffernece / 2);
                    awayTeamCalculatedRating -= (pointDiffernece / 2);
                }
            }
            // if HS < AS; HR == AR
            else
            if (homeTeamScore < awayTeamScore && homeTeamCalculatedRating == awayTeamCalculatedRating)
            {
                if ((homeTeamCalculatedRating - (pointDiffernece / 2)) < 0)
                {
                    awayTeamCalculatedRating = pointDiffernece;
                    homeTeamCalculatedRating = 0;
                }
                else
                {
                    awayTeamCalculatedRating += (pointDiffernece / 2);
                    homeTeamCalculatedRating -= (pointDiffernece / 2);
                }
            }
            // if HS > AS; HR > AR; PD >= RD
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
                    homeTeamCalculatedRating += ((pointDiffernece - ratingMargin) / 2);
                    awayTeamCalculatedRating -= ((pointDiffernece - ratingMargin) / 2);
                }
            }
            // if HS > AS; HR > AR; PD < RD
            else
            if (homeTeamScore > awayTeamScore && homeTeamCalculatedRating > awayTeamCalculatedRating && pointDiffernece < ratingMargin)
            {
                if ((ratingMargin - pointDiffernece) < pointDiffernece)
                {
                    homeTeamCalculatedRating -= ((ratingMargin - pointDiffernece) / 2);
                    awayTeamCalculatedRating += ((ratingMargin - pointDiffernece) / 2);
                }
                else
                {
                    homeTeamCalculatedRating -= pointDiffernece / 2;
                    awayTeamCalculatedRating += pointDiffernece / 2;
                }
            }
            // if HS > AS; HR < AR; PD >= RD
            else
            if (homeTeamScore > awayTeamScore && homeTeamCalculatedRating < awayTeamCalculatedRating && pointDiffernece >= ratingMargin)
            {
                if ((awayTeamCalculatedRating - (pointDiffernece / 2)) < 0)
                {
                    awayTeamCalculatedRating = 0;
                    homeTeamCalculatedRating = pointDiffernece;
                }
                else
                {
                    awayTeamCalculatedRating -= pointDiffernece / 2;
                    homeTeamCalculatedRating += pointDiffernece / 2;
                }
            }
            // if HS > AS; HR < AR; PD < RD
            else
            if (homeTeamScore > awayTeamScore && homeTeamCalculatedRating < awayTeamCalculatedRating && pointDiffernece < ratingMargin)
            {
                homeTeamCalculatedRating += pointDiffernece / 2;
                awayTeamCalculatedRating -= pointDiffernece / 2;
            }
            // if HS < AS; HR > AR; PD >= RD
            else
            if (homeTeamScore < awayTeamScore && homeTeamCalculatedRating > awayTeamCalculatedRating && pointDiffernece >= ratingMargin)
            {
                if ((homeTeamCalculatedRating - (pointDiffernece / 2)) < 0)
                {
                    homeTeamCalculatedRating = 0;
                    awayTeamCalculatedRating = pointDiffernece;
                }
                else
                {
                    homeTeamCalculatedRating -= pointDiffernece / 2;
                    awayTeamCalculatedRating += pointDiffernece / 2;
                }
            }
            // if HS < AS; HR > AR; PD < RD
            else
            if (homeTeamScore < awayTeamScore && homeTeamCalculatedRating > awayTeamCalculatedRating && pointDiffernece < ratingMargin)
            {
                homeTeamCalculatedRating -= pointDiffernece / 2;
                awayTeamCalculatedRating += pointDiffernece / 2;
            }
            // if HS < AS; HR < AR; PD >= RD
            else
            if (homeTeamScore < awayTeamScore && homeTeamCalculatedRating < awayTeamCalculatedRating && pointDiffernece >= ratingMargin)
            {
                if ((homeTeamCalculatedRating - ((pointDiffernece - ratingMargin) / 2)) < 0)
                {
                    homeTeamCalculatedRating = 0;
                    awayTeamCalculatedRating = pointDiffernece;
                }
                else
                {
                    homeTeamCalculatedRating -= (pointDiffernece - ratingMargin) / 2;
                    awayTeamCalculatedRating += (pointDiffernece - ratingMargin) / 2;
                }
            }
            // if HS < AS; HR < AR; PD < RD
            else
            if (homeTeamScore < awayTeamScore && homeTeamCalculatedRating < awayTeamCalculatedRating && pointDiffernece < ratingMargin) 
            {
                if ((ratingMargin - pointDiffernece) > pointDiffernece)
                {
                    homeTeamCalculatedRating += pointDiffernece / 2;
                    awayTeamCalculatedRating -= pointDiffernece / 2;
                }
                else 
                {
                    homeTeamCalculatedRating += (ratingMargin - pointDiffernece) / 2;
                    awayTeamCalculatedRating -= (ratingMargin - pointDiffernece) / 2;
                }
            }

            //Add new calculation to teams
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
