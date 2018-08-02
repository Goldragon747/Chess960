using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using ChessGame;
using System.Windows;
using ChessGame.Source.Model;

namespace ChessGame.Source {

    class TextView {

        Board board;

        MainWindow mainWindow;

        public TextView(Board board, MainWindow mainWindow) {

            this.board = board;
            this.mainWindow = mainWindow;

            //this.mainWindow.mainTextBlock.Text = this.board.toString();
        }

        /*
        public void promptPieceSelect() {
            this.mainWindow.instructionsTextBlock.Text = "Please choose a piece (ex. : c6)." +
                " Input below and click submit.";
        }

        public void promptDestinationSelect() {
            this.mainWindow.instructionsTextBlock.Text = "Please choose a destination (ex. : c6)." +
                " Input below and click submit.";
        }

        public void update() {

            this.mainWindow.mainTextBlock.Text = this.board.toString();

        }*/

    }

}
