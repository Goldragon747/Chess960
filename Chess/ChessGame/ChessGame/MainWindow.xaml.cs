using ChessGame.Source;
using ChessGame.Source.Model;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ChessGame {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        /// <summary>
        /// Game model - Board class
        /// </summary>
        private Board boardModel;

        /// <summary>
        /// The player at the moment
        /// 0 --> white
        /// 1 --> black
        /// </summary>
        private int turn;

        /// <summary>
        /// Jagged array for all the buttons on the board.
        /// </summary>
        private BoardButton[][] buttonArray;

        /// <summary>
        /// 0 --> choose a piece
        /// 1 --> choose a destination
        /// </summary>
        private int mode;

        /// <summary>
        /// Last pressed button
        /// </summary>
        private BoardButton lastPressed;

        public MainWindow() {

            InitializeComponent();
            MessageBoxResult choice = MessageBox.Show(
                "Want to play with Chess960 rules?",
                "Chess960",
                MessageBoxButton.YesNo, //button options
                MessageBoxImage.Question);
            this.boardModel = new Board(choice == MessageBoxResult.Yes);
            Debug.WriteLine(this.boardModel.ToString()); //REMOVE WHEN DONE

            this.mode = 0;//default start by chosing a piece

            this.turn = 0; //white starts
            this.ShowTurn();

            this.UpdateDeadPiecesViews();

            //initializing the buttonArray
            this.buttonArray = new BoardButton[Board.GameSize][]; //Change Game size
            for (int i = 0; i < this.buttonArray.Length; i++) {
                this.buttonArray[i] = new BoardButton[Board.GameSize];
            }

            //creating the buttons for the board.
            for (int i = 0; i < this.buttonArray.Length; i++) {
                for (int j = 0; j < this.buttonArray.Length; j++) {

                    string name = "space" + i + j;

                    BoardSpace correspondingSpace = this.boardModel.GetBoardSpace(i, j);

                    BoardButton presentButton = new BoardButton(i, j, name, correspondingSpace);
                    this.buttonArray[i][j] = presentButton;
                    
                    if (!correspondingSpace.Occupied
                        || correspondingSpace.Piece.Color != this.turn) {

                        presentButton.IsEnabled = false;

                    }

                    int realJ = (j - this.buttonArray.Length + 1) * -1; //to fix grid y axis problem

                    Grid.SetColumn(presentButton, i);
                    Grid.SetRow(presentButton, realJ);
                    this.boardGrid.Children.Add(presentButton);

                    presentButton.AddHandler(BoardButton.ClickEvent, new RoutedEventHandler(boardButton_Click)); //Adding eventHandler

                }

            }

        }

        /// <summary>
        /// Updated the view to show who's turn it is.
        /// </summary>
        private void ShowTurn() {

            if (this.turn == 0) {
                this.turnDisplay.Text = "White Turn";
            } else {
                this.turnDisplay.Text = "Black Turn";
            }

        }

        private void boardButton_Click(object sender, RoutedEventArgs e) {
            //throw new NotImplementedException();            

            BoardButton clickedButton = sender as BoardButton;
            Debug.WriteLine(clickedButton.Name);//REMOVE

            int x = clickedButton.PosX;
            int y = clickedButton.PosY;

            BoardSpace clickedSpace = this.boardModel.GetBoardSpace(x, y);

            if (this.mode == 0) { //mode 0 --> chose piece

                clickedSpace.Piece.SetDestinations(x, y);
                this.mode = (this.mode + 1) % 2;
                this.lastPressed = clickedButton;

            } else { // other mode is chose destinations

                if (!clickedButton.Equals(this.lastPressed)) { //if button clicked is not the same as before

                    this.MovePiece(clickedSpace);
                    this.lastPressed = null;

                    //we promote pawns getting to the end fo board
                    if ( (y == 0 || y == 7 ) 
                        && clickedSpace.Piece.Type == "pawn") {

                        this.Promote(clickedSpace);

                    }

                    clickedSpace.Piece.PlayedOnce(); //techically redundant, but no harm to efficiency.

                    this.turn = (this.turn + 1) % 2;//. only change turn after destination chosen.

                }

                this.mode = (this.mode + 1) % 2; //always change mode.

            }

            this.UpdateView();
            Debug.WriteLine(this.boardModel.ToString());//REMOVE

            int winner = this.GameWon();

            this.AskForNewGame(winner);

        }

        private void MovePiece(BoardSpace destination) {

            if (destination.Occupied) {
                this.boardModel.KillPiece(destination);
            }

            int sourceX = this.lastPressed.PosX;
            int sourceY = this.lastPressed.PosY;
            BoardSpace sourceSpace = this.boardModel.GetBoardSpace(sourceX, sourceY);

            destination.Piece = sourceSpace.Piece; //move Piece, auto set Occupied to true

            sourceSpace.Piece = null;//auto set Occupied to false

        }

        private void Promote(BoardSpace space) {

            string choice;

            PromotionDialogue dialogue = new PromotionDialogue();
            dialogue.ShowDialog();
            choice = dialogue.Choice;

            int presentColor = space.Piece.Color;

            switch (choice) {
                case "queen":
                    space.Piece = new Queen(this.boardModel, presentColor);
                    break;
                case "knight":
                    space.Piece = new Knight(this.boardModel, presentColor);
                    break;
                case "rook":
                    space.Piece = new Rook(this.boardModel, presentColor);
                    break;
                case "bishop":
                    space.Piece = new Bishop(this.boardModel, presentColor);
                    break;
                case "pawn":
                    space.Piece = new Pawn(this.boardModel, presentColor);
                    break;
            }

        }

        /// <summary>
        /// Checks if someone won the game
        /// -1 --> no one
        ///  0 --> white
        ///  1 --> black
        /// </summary>
        /// <returns>An int representing the winner (or no winner). </returns>
        private int GameWon() {

            //foreach is not necessary as king should be first, but does not hurt to use foreach
            foreach (Piece piece in this.boardModel.DeadWhites) {
                if (piece.Type == "king") { //Maybe change "==" to Equals
                    return 1; //black --> 1
                }
            }

            foreach (Piece piece in this.boardModel.DeadBlacks) {
                if (piece.Type == "king") { //Maybe change "==" to Equals
                    return 0; //white --> 0
                }
            }

            return -1;

        }

        private void AskForNewGame(int winner) {

            string message;

            if ( winner == 0) {
                message = "White wins! Do you want to play a new game?";
            } else if (winner == 1) {
                message = "Black wins! Do you want to play a new game?";
            } else {
                return; //if no winner, we just exit method
            }

            string title = "Game Won! New game?";
            MessageBoxResult choice = MessageBox.Show(
                message,
                title,
                MessageBoxButton.YesNo, //button options
                MessageBoxImage.Question);

            if (choice == MessageBoxResult.Yes) {
                this.boardModel.Reset();
                this.turn = 0;//REMOVE if change turn from MainWindow to Board.
                this.UpdateView();
                Debug.WriteLine(this.boardModel.ToString());//REMOVE
            } else {
                Application.Current.Shutdown();
            }
        }

        private void UpdateView() {

            this.ShowTurn();

            this.UpdateDeadPiecesViews();

            //updating board.
            for (int i = 0; i < this.buttonArray.Length; i++) {
                for (int j = 0; j < this.buttonArray.Length; j++) {

                    BoardButton presentButton = this.buttonArray[i][j];
                    BoardSpace presentSpace = this.boardModel.GetBoardSpace(i, j); //MAYBE REPLACE BY GETTER

                    if (mode == 0) { //if mode is now chose piece, we clear the possible destinations.
                        presentButton.ClearValue(BoardButton.BackgroundProperty); //clears background color
                        presentSpace.IsPossibleDestination = false;
                    }

                    if (presentSpace.IsPossibleDestination) {
                        presentButton.Background = Brushes.Red;
                    }

                    if (!presentSpace.IsPossibleDestination 
                        && ( !presentSpace.Occupied 
                             || presentSpace.Piece.Color != this.turn) ) {

                        presentButton.IsEnabled = false;

                    } else {
                        presentButton.IsEnabled = true;
                    }

                    //Condition in case we're in chose destination mode
                    //only destinations and the pressed button are enabled
                    if(this.mode == 1 
                        && !presentSpace.IsPossibleDestination 
                        && !presentButton.Equals(this.lastPressed)) {
                        presentButton.IsEnabled = false;
                    }

                    presentButton.Content = presentSpace.GetBoardSpaceChar();

                    Debug.WriteLine(presentSpace.ToString());//REMOVE
                    
                }

            }

        }
        
        /// <summary>
        /// Updated the TextBlocks that shows the dead Pieces.
        /// </summary>
        private void UpdateDeadPiecesViews() {


            StringBuilder deadWhitesString = new StringBuilder();

            foreach (Piece piece in this.boardModel.DeadWhites) {
                deadWhitesString.Append(" " + piece.Icon + " ");
            }

            this.deadWhitesView.Text = deadWhitesString.ToString();

            StringBuilder deadBlacksString = new StringBuilder();

            foreach (Piece piece in this.boardModel.DeadBlacks) {
                deadBlacksString.Append(" " + piece.Icon + " ");
            }

            this.deadBlacksView.Text = deadBlacksString.ToString();
        }

    }

}
