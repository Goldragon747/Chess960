using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Shapes;

namespace ChessGame.Source {
    /// <summary>
    /// Interaction logic for PromotionDialogue.xaml
    /// </summary>
    public partial class PromotionDialogue : Window {

        /// <summary>
        /// The choice of the player regarding how to promote Pawn.
        /// </summary>
        private string choice;

        public string Choice {
            get { return this.choice; }
        }

        public PromotionDialogue() {
            InitializeComponent();

            this.choice = "queen";//default is queen, in case user closes without choice.
        }

        private void Button_Click(object sender, RoutedEventArgs e) {

            Button clickedButton = (sender as Button);

            this.choice = clickedButton.Name;

            this.Close();
        }

    }
}
