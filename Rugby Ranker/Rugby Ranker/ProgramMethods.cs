using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rugby_Ranker
{
    internal class ProgramMethods
    {
        public static RugbyTeam[] RugbyTeams = new RugbyTeam[100];
        public static ArrayList TeamDescendingOrderString = new ArrayList();
        private static ArrayList teamIndex = new ArrayList();
        

        //PRIVATE METHODS
        private static void DeleteTeam(string teamName) 
        {
            for (int i = 0; i < RugbyTeams.Length; i++) 
            {
                if (teamName.ToString() == RugbyTeams[i].GetTeamName())
                {
                    RugbyTeams[i].SetTeamName(null);
                    RugbyTeams[i].SetRating(0);
                    RugbyTeams[i].setCalculatedRating(0);
                    RugbyTeams[i].DeactivateTeamAccount();
                    break;
                }
            }
        }

        private static void CreateNewTeam(string name, double rating) 
        {
            for (int i = 0; i < RugbyTeams.Length; i++) 
            {
                if (RugbyTeams[i].GetIsTeamAccountActivated() == false) 
                {
                    RugbyTeams[i].SetTeamName(name);
                    RugbyTeams[i].SetRating(rating);
                    RugbyTeams[i].setCalculatedRating(rating);
                    RugbyTeams[i].ActivateTeamAccount();
                    RugbyTeams[i].setCalculatedRating(RugbyTeams[i].GetRating());
                    break;
                }
            }
        }

        private static int NumberOfActivatedTeams() 
        {
            int a = 0;
            for(int i = 0; i < RugbyTeams.Length; i++) 
            {
                if (RugbyTeams[i].GetIsTeamAccountActivated() == true) 
                {
                    a++;
                }
            }
            return a;
        }

        private static void AssignIndex() 
        {
            teamIndex.Clear();
            for(int i = 0; i < RugbyTeams.Length; i++) 
            {
                int a = NumberOfActivatedTeams();
                if (RugbyTeams[i].GetIsTeamAccountActivated() == true) 
                {
                    for (int j = 0; j < RugbyTeams.Length; j++) 
                    {
                        if (RugbyTeams[j].GetIsTeamAccountActivated() == true) 
                        {
                            if ((double)RugbyTeams[i].GetCalculatedRating() > (double)RugbyTeams[j].GetCalculatedRating())
                            {
                                a--;
                            }
                            else if ((double)RugbyTeams[j].GetCalculatedRating() == (double)RugbyTeams[i].GetCalculatedRating() && j <= i)
                            {
                                a--;
                            }
                            else if ((double)RugbyTeams[j].GetCalculatedRating() == (double)RugbyTeams[i].GetCalculatedRating() && j > i)
                            {
                                continue;
                            }
                        }
                    }
                    teamIndex.Add(a);
                }
            }
        }

        //PUBLIC METHODS
        public static void BuildMainMenuTeamsDisplay() 
        {
            TeamDescendingOrderString.Clear();

            AssignIndex();
            
            //number to search for
            for(int i = 0; i < teamIndex.Count; i++) 
            {
                //search wether the current index of a is equal to the number of i
                for(int j = 0; j < teamIndex.Count; j++) 
                {
                    //if current a index matches with i
                    if ((int)teamIndex[j] == i) 
                    {
                        int k = 0;

                        //search for the current matched numbers among the activated accounts, then add them to teamdescend
                        for (int l = 0; l < RugbyTeams.Length; l++) 
                        {
                            if (RugbyTeams[l].GetIsTeamAccountActivated() != false) 
                            {
                                
                                if (k == j)
                                {
                                    string teamName = RugbyTeams[l].GetTeamName();
                                    string teamRank = RugbyTeams[l].GetCalculatedRating().ToString();
                                    TeamDescendingOrderString.Add(teamName + " " + teamRank);
                                    k = 0;
                                    break;
                                }
                                else 
                                {
                                    k++;
                                }
                            }
                        }
                    }
                }
            }
        }

        public static void CreateTeams()
        {
            for (int i = 0; i < RugbyTeams.Length; i++)
            {
                RugbyTeams[i] = new RugbyTeam();
            }
        }

        public static void AddNewTeam(string NewTeamName, double NewTeamRating) 
        {
            CreateNewTeam(NewTeamName, NewTeamRating);
        }

        public static void RemoveTeam(string teamName) 
        {
            DeleteTeam(teamName);
        }

        
    }
}
