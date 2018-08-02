using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessGame;
using ChessGame.Source.Model;

namespace ChessGame.Source {

    class GameController {

        /// <summary>
        /// Game model - Board class
        /// </summary>
        private Board board;

        /// <summary>
        /// Texy View
        /// </summary>
        private TextView textView;

        /// <summary>
        /// The MainWindow of the app.
        /// </summary>
        private MainWindow mainWindow;

        /// <summary>
        /// The player at the moment
        /// 0 --> white
        /// 1 --> black
        /// </summary>
        private int turn;

        /*
        public GameController(MainWindow mainWindow) {

            this.mainWindow = mainWindow;
            this.board = new Board();
            this.textView = new TextView(this.board, this, this.mainWindow);

            this.turn = 0; //white starts

        }*/

    }

}
