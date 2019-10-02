using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using ModelObjet;
using Windows.UI.Popups;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Devoir2_TraderActions
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        // Déclaration des variables globales
        Dictionary<string, List<ActionAchetee>> dico;
        List<ActionReelle> lesActionsReelles;

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            dico = new Dictionary<string, List<ActionAchetee>>();
            lesActionsReelles = new List<ActionReelle>();

            #region jeu d'essais pour la liste de toutes les actions réelles

            lesActionsReelles.Add
            (
                new ActionReelle()
                {
                    CodeAction = "AAPL",
                    NomAction = "Apple",
                    ValeurAction = 200
                }
            );
            lesActionsReelles.Add
            (
                new ActionReelle()
                {
                    CodeAction = "MSFT",
                    NomAction = "Microsoft",
                    ValeurAction = 14
                }
            );
            lesActionsReelles.Add
            (
                new ActionReelle()
                {
                    CodeAction = "TWTR",
                    NomAction = "Twitter",
                    ValeurAction = 40
                }
            );
            lesActionsReelles.Add
            (
                new ActionReelle()
                {
                    CodeAction = "IBM",
                    NomAction = "International Business Machines",
                    ValeurAction = 140
                }
            );
            lesActionsReelles.Add
            (
                new ActionReelle()
                {
                    CodeAction = "FB",
                    NomAction = "Facebook",
                    ValeurAction = 180
                }
            );
            lesActionsReelles.Add
            (
                new ActionReelle()
                {
                    CodeAction = "AXA",
                    NomAction = "Axa assurances",
                    ValeurAction = 25
                }
            );
            lesActionsReelles.Add
            (
                new ActionReelle()
                {
                    CodeAction = "SAP",
                    NomAction = "SAP SE",
                    ValeurAction = 120
                }
            );
            lesActionsReelles.Add
            (
                new ActionReelle()
                {
                    CodeAction = "INTC",
                    NomAction = "Intel Corporation",
                    ValeurAction = 50
                }
            );
            lesActionsReelles.Add
            (
                new ActionReelle()
                {
                    CodeAction = "VMW",
                    NomAction = "VMware",
                    ValeurAction = 145
                }
            );
            lesActionsReelles.Add
            (
                new ActionReelle()
                {
                    CodeAction = "TXN",
                    NomAction = "Texas Instrument Incorporated",
                    ValeurAction = 130
                }
            );
            #endregion

            #region jeu d'essais pour le dico

            dico.Add
            ("Enzo", new List<ActionAchetee>()
            {
                new ActionAchetee()
                {
                    CodeAction = "AAPL",
                    NomAction = "Apple",
                    ValeurAction = 200,
                    PrixAchat = 210,
                    Quantite = 10
                },
                new ActionAchetee()
                {
                    CodeAction = "MSFT",
                    NomAction = "Microsoft",
                    ValeurAction = 140,
                    PrixAchat = 100,
                    Quantite = 50
                },
                new ActionAchetee()
                {
                    CodeAction = "TWTR",
                    NomAction = "Twitter",
                    ValeurAction = 40,
                    PrixAchat = 35,
                    Quantite = 20
                },
                new ActionAchetee()
                {
                    CodeAction = "IBM",
                    NomAction = "International Business Machines",
                    ValeurAction = 140,
                    PrixAchat = 110,
                    Quantite = 40
                }
            }
            );
            dico.Add
            ("Noa", new List<ActionAchetee>()
                {
                new ActionAchetee()
                {
                    CodeAction = "FB",
                    NomAction = "Facebook",
                    ValeurAction = 180,
                    PrixAchat = 210,
                    Quantite = 10
                },
                new ActionAchetee()
                {
                    CodeAction = "AXA",
                    NomAction = "Axa assurances",
                    ValeurAction = 25,
                    PrixAchat = 15,
                    Quantite = 20
                },
                new ActionAchetee()
                {
                    CodeAction = "SAP",
                    NomAction = "SAP SE",
                    ValeurAction = 120,
                    PrixAchat = 100,
                    Quantite = 30
                }
            }
            );
            dico.Add
            ("Lilou", new List<ActionAchetee>()
                {
                new ActionAchetee()
                {
                    CodeAction = "TWTR",
                    NomAction = "Twitter",
                    ValeurAction = 40,
                    PrixAchat = 25,
                    Quantite = 50
                },
                new ActionAchetee()
                {
                    CodeAction = "INTC",
                    NomAction = "Intel Corporation",
                    ValeurAction = 50,
                    PrixAchat = 35,
                    Quantite = 15
                },
                new ActionAchetee()
                {
                    CodeAction = "VMW",
                    NomAction = "VMware",
                    ValeurAction = 145,
                    PrixAchat = 150,
                    Quantite = 30
                },
                new ActionAchetee()
                {
                    CodeAction = "TXN",
                    NomAction = "Texas Instrument Incorporated",
                    ValeurAction = 130,
                    PrixAchat = 140,
                    Quantite = 25
                }
            }
            );
            #endregion

            // Remplissage des traders
            lvTraders.ItemsSource = dico.Keys;

            // Remplissage des actions réelles
            lvActionsReelles.ItemsSource = lesActionsReelles;



        }

        private void lvTraders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvTraders.SelectedItem != null)
            {
                if(dico.ContainsKey(lvTraders.SelectedItem.ToString()))
                {
                    lvActionsAchetees.ItemsSource = null;
                    lvActionsAchetees.ItemsSource = dico[lvTraders.SelectedItem.ToString()];

                    double montantPorteFeuille = 0;
                    foreach(ActionAchetee a in dico[lvTraders.SelectedItem.ToString()])
                    {
                        montantPorteFeuille += Convert.ToInt32(a.Quantite) * a.PrixAchat;
                    }
                    txtMontantPorteFeuille.Text = montantPorteFeuille.ToString();
                }
            }
        }

        private void lvActionsAchetees_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(lvActionsAchetees.SelectedItem != null && lvTraders.SelectedItem != null)
            {
                txtNomAction.Text = (lvActionsAchetees.SelectedItem as ActionAchetee).NomAction;

                txtValeurAction.Text = (lvActionsAchetees.SelectedItem as ActionAchetee).ValeurAction.ToString();

                txtPrixAchatAction.Text = (lvActionsAchetees.SelectedItem as ActionAchetee).PrixAchat.ToString();

                txtQteAcheteeAction.Text = (lvActionsAchetees.SelectedItem as ActionAchetee).Quantite.ToString();
            }
            else
            {
                txtNomAction.Text = "";

                txtValeurAction.Text = "";

                txtPrixAchatAction.Text = "";

                txtQteAcheteeAction.Text = "";
            }
        }

        private async void btnAcheterAction_Click(object sender, RoutedEventArgs e)
        {
            if(lvActionsReelles.SelectedItem == null)
            {
                var messageSelectionnerAction = new MessageDialog("Sélectionner une action");
                await messageSelectionnerAction.ShowAsync();
            }
            else if(txtPrixAchatAchat.Text == "")
            {
                var messageSaisirPrix = new MessageDialog("Saisir le prix d'achat");
                await messageSaisirPrix.ShowAsync();
            }
            else if (txtQteAchat.Text == "")
            {
                var messageSaisirQte = new MessageDialog("Saisir la quantité");
                await messageSaisirQte.ShowAsync();
            }
            else
            {
                if(lvTraders.SelectedItem != null)
                {
                    if (lvActionsReelles.SelectedItem != null)
                    {
                        ActionAchetee actionAchetee = new ActionAchetee()
                        {
                            CodeAction = (lvActionsReelles.SelectedItem as ActionReelle).CodeAction,
                            NomAction = (lvActionsReelles.SelectedItem as ActionReelle).NomAction,
                            ValeurAction = (lvActionsReelles.SelectedItem as ActionReelle).ValeurAction,
                            PrixAchat = Convert.ToInt32(txtPrixAchatAchat.Text),
                            Quantite = Convert.ToInt32(txtQteAchat.Text)
                        };
                        dico[lvTraders.SelectedItem.ToString()].Add(actionAchetee);

                        // maintenant il faut rafraichir la liste d'actions achetées et le montant du portefeuille
                        lvActionsAchetees.ItemsSource = null;
                        lvActionsAchetees.ItemsSource = dico[lvTraders.SelectedItem.ToString()];

                        double montantPorteFeuille = 0;
                        foreach (ActionAchetee a in dico[lvTraders.SelectedItem.ToString()])
                        {
                            montantPorteFeuille += Convert.ToInt32(a.Quantite) * a.PrixAchat;
                        }
                        txtMontantPorteFeuille.Text = montantPorteFeuille.ToString();

                        txtPrixAchatAchat.Text = "";
                        txtQteAchat.Text = "";

                    }
                }
            }
        }

        private async void btnVendreAction_Click(object sender, RoutedEventArgs e)
        {
            if(lvTraders.SelectedItem != null)
            {
                if (lvActionsAchetees.SelectedItem == null)
                {
                    var messageSelectAction = new MessageDialog("Sélectionner une action");
                    await messageSelectAction.ShowAsync();
                }
                else if(txtQteVendueAction.Text == "")
                {
                    var messageSaisirQuantite = new MessageDialog("Saisir la quantité vendue");
                    await messageSaisirQuantite.ShowAsync();
                }
                else if (Convert.ToInt32(txtQteAcheteeAction.Text) < Convert.ToInt32(txtQteVendueAction.Text))
                {
                    var messageAuDela = new MessageDialog("Vous ne pouvez pas vendre au délà de ce que vous possédez");
                    await messageAuDela.ShowAsync();
                }
                else // ici la quantité est saisie, l'action est choisie, et qte vendue =< qte possédée
                {
                    // si la quantité vendue est = à celle possédée, supprimer l'action
                    if (txtQteAcheteeAction.Text == txtQteVendueAction.Text)
                    {
                        dico[lvTraders.SelectedItem.ToString()].Remove((lvActionsAchetees.SelectedItem as ActionAchetee));
                    }
                    // si la quantité vendue est < à celle possédée
                    else if (Convert.ToInt32(txtQteAcheteeAction.Text) > Convert.ToInt32(txtQteVendueAction.Text))
                    {
                        (lvActionsAchetees.SelectedItem as ActionAchetee).Quantite = ((lvActionsAchetees.SelectedItem as ActionAchetee).Quantite) - Convert.ToInt32(txtQteVendueAction.Text);
                    }


                    // rafraichir la liste des actions achetées et le portefeuille
                    lvActionsAchetees.ItemsSource = null;
                    lvActionsAchetees.ItemsSource = dico[lvTraders.SelectedItem.ToString()];

                    double montantPorteFeuille = 0;
                    foreach (ActionAchetee a in dico[lvTraders.SelectedItem.ToString()])
                    {
                        montantPorteFeuille += Convert.ToInt32(a.Quantite) * a.PrixAchat;
                    }
                    txtMontantPorteFeuille.Text = montantPorteFeuille.ToString();

                    txtQteVendueAction.Text = "";
                }
            }
        }
    }
}
