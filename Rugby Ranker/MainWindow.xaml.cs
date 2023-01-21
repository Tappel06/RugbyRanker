using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Rugby_Ranker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ProgramMethods.CreateTeams();
            RetreiveData.Retreive();
            RatingSystem.CalculateRecords();
            ShowMainMenuOptions();
            HideManageTeamsOptions();
            HideUpdateMatchUpdateOptions();
            HideTeamsOptions();
            HideAddTeamOptions();
            HideRemoveTeamOptions();
            HideAddMatchGrid();
            HideHistoryGrid();
            HideTeamProfileGrid();
            HideTeamListGrid();
        }

        private void UpdateListBoxes() 
        {
            RemoveTeamsListBox.Items.Clear();
            Home_Team_Combobox_addMatch.Items.Clear();
            Away_Team_Combobox_addMatch.Items.Clear();

            for (int i = 0; i < ProgramMethods.RugbyTeams.Length; i++) 
            {
                if (ProgramMethods.RugbyTeams[i].GetIsTeamAccountActivated() == true) 
                {
                    RemoveTeamsListBox.Items.Add(ProgramMethods.RugbyTeams[i].GetTeamName());
                    Home_Team_Combobox_addMatch.Items.Add(ProgramMethods.RugbyTeams[i].GetTeamName());
                    Away_Team_Combobox_addMatch.Items.Add(ProgramMethods.RugbyTeams[i].GetTeamName());
                }
            }

            if (MatchDatabase.CountTotalRecords() > 0)
            {
                HistoryListBox.Items.Clear();
                for (int i = 0; i < MatchDatabase.CountTotalRecords(); i++)
                {
                    HistoryListBox.Items.Add(MatchDatabase.GetFullRecord(i));
                }
            }
            else 
            {
                HistoryListBox.Items.Clear();
            }
        }

        private void ShowMainMenuOptions()
        {
            MainMenuSelectedGrid.Visibility = Visibility.Visible;
            ProgramMethods.BuildMainMenuTeamsDisplay();
            setupmainMenuDisplay();
        }

        private void setupmainMenuDisplay() 
        {
           
            mainMenuListbox.Items.Clear();

            for (int i = 0; i < ProgramMethods.TeamDescendingOrderString.Count; i++)
            {
                mainMenuListbox.Items.Add(ProgramMethods.TeamDescendingOrderString[i].ToString());
            }
        }

        private void HideMainMenuOptions()
        {
            MainMenuSelectedGrid.Visibility = Visibility.Collapsed;
        }

        private void ShowManageTeamsOptions()
        {
            ManageTeamsGrid.Visibility = Visibility.Visible;
        }

        private void HideManageTeamsOptions()
        {
            ManageTeamsGrid.Visibility = Visibility.Collapsed;
        }

        //Match updates
        private void ShowUpdateMatchUpdateOptions()
        {
            MatchUpdateGrid.Visibility = Visibility.Visible;
        }

        private void HideUpdateMatchUpdateOptions()
        {
            MatchUpdateGrid.Visibility = Visibility.Collapsed;
        }

        //Show TeamListGrid
        private void ShowTeamListGrid() 
        {
            TeamListGrid.Visibility = Visibility.Visible;
        }

        private void HideTeamListGrid() 
        {
            TeamListGrid.Visibility = Visibility.Collapsed;
        }

        //Show Team Team Profile
        private void ShowTeamProfileGrid() 
        {
            TeamProfileGrid.Visibility = Visibility.Visible;
        }

        private void HideTeamProfileGrid() 
        {
            TeamProfileGrid.Visibility = Visibility.Collapsed;
        }

        //Show Add Matches
        private void ShowAddMatchGrid() 
        {
            AddMatchGrid.Visibility= Visibility.Visible;
        }

        private void HideAddMatchGrid() 
        {
            AddMatchGrid.Visibility = Visibility.Collapsed;
        }

        //Show History
        private void ShowHistoryGrid() 
        {
            History_Grid.Visibility= Visibility.Visible;
        }

        private void HideHistoryGrid() 
        {
            History_Grid.Visibility = Visibility.Collapsed;
        }

        //Teams options
        private void ShowTeamsOptions()
        {
            TeamsGrid.Visibility = Visibility.Visible;
        }

        //Add Teams
        private void HideTeamsOptions()
        {
            TeamsGrid.Visibility = Visibility.Collapsed;
        }

        private void ShowAddTeamOptions()
        {
            AddTeamGrid.Visibility = Visibility.Visible;
        }

        private void HideAddTeamOptions()
        {
            AddTeamGrid.Visibility = Visibility.Collapsed;
        }

        private void AddTeamFromManageTeams() 
        { 
            ProgramMethods.AddNewTeam(TeamNameTextBox.Text, Convert.ToDouble(DefaultRatingTextBox.Text));
            RemoveTeamsListBox.Items.Add(TeamNameTextBox.Text);
        }

        //Remove Teams
        private void ShowRemoveTeamOptions() 
        {
            ManageTeamsRemoveTeamGrid.Visibility = Visibility.Visible;
            UpdateListBoxes();
        }

        private void HideRemoveTeamOptions() 
        {
            ManageTeamsRemoveTeamGrid.Visibility = Visibility.Collapsed;
        }

        private void RemoveTeamFromManagedTeams() 
        {
            for(int i = 0; i < ProgramMethods.RugbyTeams.Length; i++) 
            {
                if (ProgramMethods.RugbyTeams[i].GetTeamName() != null)
                {
                    if (ProgramMethods.RugbyTeams[i].GetTeamName() == RemoveTeamsListBox.SelectedValue.ToString())
                    {
                        ProgramMethods.RemoveTeam(RemoveTeamsListBox.SelectedValue.ToString());
                        RemoveTeamsListBox.Items.Remove(RemoveTeamsListBox.SelectedItem);
                        break;
                    }
                    else 
                    {
                        Console.WriteLine("Failed to match strings");
                    }
                }
            }
        }

        private void RemoveAllTeamsFromManagedTeams() 
        {
            for(int i = 0; i < ProgramMethods.RugbyTeams.Length; i++) 
            {
                ProgramMethods.RugbyTeams[i].SetTeamName(null);
                ProgramMethods.RugbyTeams[i].SetRating(0);
                ProgramMethods.RugbyTeams[i].DeactivateTeamAccount();
            }
            RemoveTeamsListBox.Items.Clear();
        }

        private void AddNewRecord() 
        {
            
            string homeTeam = Home_Team_Combobox_addMatch.SelectedItem.ToString();
            int homeScore =  Convert.ToInt32(home_score_textbox_addMatch.Text);
            int awayScoreScore = Convert.ToInt32(away_score_textbox_addMatch.Text);
            string awayTeam = Away_Team_Combobox_addMatch.SelectedItem.ToString();
            int year = Convert.ToInt32(YearTextBoxAddRecord.Text);
            int month = Convert.ToInt32(MonthTextBoxAddRecord.Text);
            int day = Convert.ToInt32(DayTextBoxAddRecord.Text);
            MatchDatabase.AddRecord(homeTeam, homeScore, awayTeam, awayScoreScore, year, month, day);
        }

        //Highlighted buttons
        private void MainMenuButtonHighlighted()
        {
            MainMenuButton.Height = 50;
            EditTeamButton.Margin = new Thickness (10,115,0,0);
            MatchUpdatesButton.Margin = new Thickness(10,140,0,0);
            TeamsButton.Margin = new Thickness(10, 165, 0, 0);
        }

        private void MainMenuButtonNotHighlighted() 
        {
            MainMenuButton.Height = 20;
            EditTeamButton.Margin = new Thickness(10, 85, 0, 0);
            MatchUpdatesButton.Margin = new Thickness(10, 110, 0, 0);
            TeamsButton.Margin = new Thickness(10, 135, 0, 0);
        }

        private void EditTeamButton_MouseEnter(object sender, MouseEventArgs e)
        {
            EditTeamButton.Height = 50;
            MatchUpdatesButton.Margin = new Thickness(10, 140, 0, 0);
            TeamsButton.Margin = new Thickness(10, 165, 0, 0);
        }

        private void EditTeamButton_MouseLeave(object sender, MouseEventArgs e)
        {
            EditTeamButton.Height = 20;
            MatchUpdatesButton.Margin = new Thickness(10, 110, 0, 0);
            TeamsButton.Margin = new Thickness(10, 135, 0, 0);
        }

        private void MatchUpdatesButton_MouseEnter(object sender, MouseEventArgs e)
        {
            MatchUpdatesButton.Height = 50;
            TeamsButton.Margin = new Thickness(10, 165, 0, 0);
        }

        private void MatchUpdatesButton_MouseLeave(object sender, MouseEventArgs e)
        {
            MatchUpdatesButton.Height = 20;
            TeamsButton.Margin = new Thickness(10, 135, 0, 0);
        }

        private void TeamsButton_MouseEnter(object sender, MouseEventArgs e)
        {
            TeamsButton.Height = 50;
        }

        private void TeamsButton_MouseLeave(object sender, MouseEventArgs e)
        {
            TeamsButton.Height = 20;
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Main_Window_Closed(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }

        private void EditTeamButton_Click(object sender, RoutedEventArgs e)
        {
            MainMenuHeader.Content = "Team Management";
            MainMenuButton.IsEnabled = true;
            EditTeamButton.IsEnabled = false;
            MatchUpdatesButton.IsEnabled = true;
            TeamsButton.IsEnabled = true;

            HideMainMenuOptions();
            ShowManageTeamsOptions();
            HideUpdateMatchUpdateOptions();
            HideTeamsOptions();
        }

        private void MatchUpdatesButton_Click(object sender, RoutedEventArgs e)
        {
            MainMenuHeader.Content = "Update Matches";
            MainMenuButton.IsEnabled = true;
            EditTeamButton.IsEnabled = true;
            MatchUpdatesButton.IsEnabled = false;
            TeamsButton.IsEnabled = true;

            HideMainMenuOptions();
            HideManageTeamsOptions();
            ShowUpdateMatchUpdateOptions();
            HideTeamsOptions();

            UpdateListBoxes();
        }

        private void TeamsButton_Click(object sender, RoutedEventArgs e)
        {
            MainMenuHeader.Content = "Teams";
            MainMenuButton.IsEnabled = true;
            EditTeamButton.IsEnabled = true;
            MatchUpdatesButton.IsEnabled = true;
            TeamsButton.IsEnabled = false;

            HideMainMenuOptions();
            HideManageTeamsOptions();
            HideUpdateMatchUpdateOptions();
            ShowTeamsOptions();
        }

        private void MainMenuButton_Click(object sender, RoutedEventArgs e)
        {
            MainMenuHeader.Content = "Main Menu";
            MainMenuButton.IsEnabled = false;
            EditTeamButton.IsEnabled = true;
            MatchUpdatesButton.IsEnabled = true;
            TeamsButton.IsEnabled = true;

            ShowMainMenuOptions();
            HideManageTeamsOptions();
            HideUpdateMatchUpdateOptions();
            HideTeamsOptions();
            TeamsListButton.IsEnabled = true;
        }

        private void MainMenuButton_MouseEnter(object sender, MouseEventArgs e)
        {
            MainMenuButtonHighlighted();
        }

        private void MainMenuButton_MouseLeave(object sender, MouseEventArgs e)
        {
            MainMenuButtonNotHighlighted();
        }

        private void ManageTeamsAddTeam_Click(object sender, RoutedEventArgs e)
        {
            ManageTeamsAddTeam.IsEnabled = false;
            ManageTeamsRemoveTeam.IsEnabled = true;

            ShowAddTeamOptions();
            HideRemoveTeamOptions();
        }

        private void ManageTeamsRemoveTeam_Click(object sender, RoutedEventArgs e)
        {
            ManageTeamsAddTeam.IsEnabled = true;
            ManageTeamsRemoveTeam.IsEnabled = false;

            HideAddTeamOptions();
            ShowRemoveTeamOptions();
        }

        private void AddTeamGridAddButton_Click(object sender, RoutedEventArgs e)
        {
            AddTeamFromManageTeams();
            StoreData.StoreProgramData();
        }

        private void ManageTeamsRemoveTeamsRemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (RemoveTeamsListBox.SelectedItem != null) 
            {
                RemoveTeamFromManagedTeams();
            }
            StoreData.StoreProgramData();
        }

        private void ManageTeamsRemoveAllTeamsButton_Click(object sender, RoutedEventArgs e)
        {
            RemoveAllTeamsFromManagedTeams();
            StoreData.StoreProgramData();
        }

        private void AddMatchButton_Click(object sender, RoutedEventArgs e)
        {
            ShowAddMatchGrid();
            HideHistoryGrid();

            AddMatchButton.IsEnabled = false;
            HistoryButton.IsEnabled = true;
        }

        private void HistoryButton_Click(object sender, RoutedEventArgs e)
        {
            HideAddMatchGrid();
            ShowHistoryGrid();

            AddMatchButton.IsEnabled = true;
            HistoryButton.IsEnabled = false;

            UpdateListBoxes();
        }

        private void HistoryEditMatchButton_Click(object sender, RoutedEventArgs e)
        {
            StoreData.StoreProgramData();
        }

        private void AddMatchSaveButton_Click(object sender, RoutedEventArgs e)
        {
            AddNewRecord();
            RatingSystem.CalculateRecords();
            StoreData.StoreProgramData();
        }

        private void HistoryDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            MatchDatabase.RemoveRecord(Convert.ToInt32(HistoryListBox.SelectedIndex));
            UpdateListBoxes();
            RatingSystem.CalculateRecords();
            StoreData.StoreProgramData();
        }

        private void TeamsListButton_Click(object sender, RoutedEventArgs e)
        {
            ShowTeamListGrid();
            HideTeamProfileGrid();
            TeamsListButton.IsEnabled = false;
        }

        private void ViewTeamProfileButton_Click(object sender, RoutedEventArgs e)
        {
            ShowTeamProfileGrid();
            HideTeamListGrid();
            TeamsListButton.IsEnabled = true;
        }
    }
}
