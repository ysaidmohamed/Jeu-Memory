using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using System.Windows.Forms;
using System.Threading;

namespace Jeu_Memory
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Partie partiencours;
        string libCarteA;
        string libCarteB;
        int cartesRetournées = 0;
        private Joueur Joueur1;
        private Joueur Joueur2;
        List<System.Windows.Controls.Button> lesBoutons;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (cartesRetournées < 1)
            {
                System.Windows.Controls.Button boutonclique = (System.Windows.Controls.Button)sender;
                boutonclique.Content = boutonclique.Tag;
                libCarteA = boutonclique.Content.ToString();
                cartesRetournées++;
            }
            else if (cartesRetournées < 2)
            {
                System.Windows.Controls.Button boutonclique = (System.Windows.Controls.Button)sender;
                boutonclique.Content = boutonclique.Tag;
                libCarteB = boutonclique.Content.ToString();
                cartesRetournées++;
                boutonclique.UpdateLayout();
                Thread.Sleep(1000);
                if (libCarteA == libCarteB)
                {
                    if (partiencours.TourjoueurA == true)
                    {
                        System.Windows.MessageBox.Show("Point pour " + J1.Text);
                        Joueur1.PointsJoueur++;
                        ScoreJ1.Text = Joueur1.PointsJoueur.ToString();
                        partiencours.TourjoueurA = false;
                        cartesRetournées = 0;
                        
                        foreach (System.Windows.Controls.Button unBouton in lesBoutons)
                        {

                            if (unBouton.Content != null && unBouton.Content.ToString() != "")
                            {
                                unBouton.IsEnabled = false;
                            }

                        }
                        isWin();
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("Point pour " + J2.Text);
                        Joueur2.PointsJoueur++;
                        ScoreJ2.Text = Joueur2.PointsJoueur.ToString();
                        partiencours.TourjoueurA = true;
                        cartesRetournées = 0;
                        foreach (System.Windows.Controls.Button unBouton in lesBoutons)
                        {
                            int btnsActifs = 0;
                            if (unBouton.Content !=null && unBouton.Content.ToString() != "")
                            {
                                btnsActifs++;
                            }
                            if (unBouton.Content != null && unBouton.Content.ToString() != "")
                            {
                                unBouton.IsEnabled = false;
                            }
                            if (btnsActifs >= lesBoutons.Count)
                            {
                                unBouton.Content = "";
                            }
                        }
                        isWin();
                    }
                }
                else
                {
                    cartesRetournées = 0;
                    foreach (System.Windows.Controls.Button unBouton in lesBoutons)
                    {
                        if (unBouton.IsEnabled == true && unBouton.Content !=null && unBouton.Content.ToString() != "")
                        {
                            unBouton.Content = "";
                        }
                    }
                    if (partiencours.TourjoueurA == true)
                    {
                        partiencours.TourjoueurA = false;
                    }
                    else
                    {
                        partiencours.TourjoueurA = true;
                    }
                }
                
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("Pour gagner la partie,rassemblez le plus de paires de cartes avant votre adversaire.");
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            if(J1.Text == "" || J2.Text == "")
            {
                System.Windows.MessageBox.Show("Il n'y a pas assez de joueurs","Attention",MessageBoxButton.OK,MessageBoxImage.Question);
            }
            else
            {
                System.Windows.MessageBox.Show("Joueur 1 : " + J1.Text + "\nJoueur 2: " + J2.Text, "Memory", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                J1.IsReadOnly = true;
                J2.IsReadOnly = true;
                Joueur joueur1 = new Joueur(J1.Text, 0);
                Joueur joueur2 = new Joueur(J2.Text, 0);
                Joueur1 = joueur1;
                Joueur2 = joueur2;
                Partie partie = new Partie(0, true, true);
                partiencours = partie;
                List<System.Windows.Controls.Button> buttons = new List<System.Windows.Controls.Button>();
                lesBoutons = buttons;
                lesBoutons.Add(Case1); lesBoutons.Add(Case2); lesBoutons.Add(Case3); lesBoutons.Add(Case4); lesBoutons.Add(Case5);
                lesBoutons.Add(Case6); lesBoutons.Add(Case7); lesBoutons.Add(Case8); lesBoutons.Add(Case9); lesBoutons.Add(Case10);
                lesBoutons.Add(Case11); lesBoutons.Add(Case12); lesBoutons.Add(Case13); lesBoutons.Add(Case14); lesBoutons.Add(Case15);
                lesBoutons.Add(Case16);
                foreach(System.Windows.Controls.Button unBouton in lesBoutons)
                {
                    unBouton.Content = "";
                }
                List<string> taglist = new List<String>();
                taglist.Add("Chat"); taglist.Add("Chien"); taglist.Add("Crocodile"); taglist.Add("Ours");
                taglist.Add("Pigeon"); taglist.Add("Calamar"); taglist.Add("Hibou"); taglist.Add("Lézard");
                int p = 0;
                int t = 0;
                for(int i = 0; i < 16; i++)
                {
                    if (i == p + 2)
                    {
                        p = i;
                        t = t + 1;
                    }
                    lesBoutons[i].Tag = taglist[t];
                    
                }
                MelangerBoutons();
                foreach (System.Windows.Controls.Button unBouton in lesBoutons)
                {
                    unBouton.IsEnabled = true;
                }

            }
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            if (J1.IsReadOnly==true)
            {
                ShowMessageBox();
                
            }
            else
            {
                Environment.Exit(0);
            }
            
        }

        private static void ShowMessageBox()
        {
            DialogResult result = System.Windows.Forms.MessageBox.Show("Une partie est en cours,voulez-vous quitter la partie ?", "Attention", MessageBoxButtons.YesNo);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                Environment.Exit(0);
            }
        }

        private void MelangerBoutons()
        {
            Random rand = new Random();

            int n = lesBoutons.Count;
            while (n > 1)
            {
                n--;
                int k = rand.Next(n + 1);
                string value = lesBoutons[k].Tag.ToString();
                lesBoutons[k].Tag = lesBoutons[n].Tag;
                lesBoutons[n].Tag = value;
            }
        }

        private void isWin()
        {
            int cartesRévélées = 0;
            foreach (System.Windows.Controls.Button unBouton in lesBoutons)
            {
                if(unBouton.Content != null && unBouton.Content.ToString() != "" )
                {   
                    cartesRévélées++;
                }
            }
            if (cartesRévélées == lesBoutons.Count)
            {
                int n = 0;
                foreach (System.Windows.Controls.Button unBouton in lesBoutons)
                {   
                
                    unBouton.Content = null;
                    unBouton.Name = "Case"+n.ToString();
                    n++;
                }
                if (Joueur1.PointsJoueur > Joueur2.PointsJoueur)
                {
                    System.Windows.MessageBox.Show("Victoire de " + J1.Text + " ! ");
                    J1.IsReadOnly = false;
                    J2.IsReadOnly = false;
                }
                else if (Joueur2.PointsJoueur > Joueur1.PointsJoueur)
                {
                    System.Windows.MessageBox.Show("Victoire de " + J2.Text + " ! ");
                    J1.IsReadOnly = false;
                    J2.IsReadOnly = false;
                }
                else if (Joueur1.PointsJoueur == Joueur2.PointsJoueur)
                {
                    System.Windows.MessageBox.Show("Egalité");
                    J1.IsReadOnly = false;
                    J2.IsReadOnly = false;
                }
            }

        }


    }
}
