using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rugby_Ranker
{
    internal class RugbyTeam
    {
        private Boolean isTeamAccountActivated = false;
        private string teamName = null;
        private double rating; // the rating given to the team that works as the root of future calculated ratings
        private double calculatedRating = 0; // the new calculated rating that is applied when all the match records is calculated
        private int id;

        //Acount Activated
        public Boolean GetIsTeamAccountActivated() 
        {
            return isTeamAccountActivated;
        }

        public void DeactivateTeamAccount() 
        {
            isTeamAccountActivated = false;
        }

        public void ActivateTeamAccount() 
        {
            isTeamAccountActivated = true;
        }

        //team name
        public string GetTeamName() 
        {
            return teamName;
        }

        public void SetTeamName(string name) 
        {
            teamName = name;
        }

        //Team Rating
        public double GetRating() 
        {
            return Math.Round(rating, 2);
        }

        public void SetRating(double rate) 
        {
            rating = Math.Round(rate, 2);
        }

        //Team calculate rating

        public double GetCalculatedRating() 
        {
            return Math.Round(calculatedRating, 2);
        }

        public void setCalculatedRating(double value) 
        {
            calculatedRating = Math.Round(value, 2);
        }

        //Team id
        public int GetID() 
        {
            return id; 
        }

        public void SetID() 
        {

        }
    }
}
