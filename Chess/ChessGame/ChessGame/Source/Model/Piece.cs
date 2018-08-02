using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Source.Model {

     abstract class Piece {

        /// <summary>
        /// The Board on which the Piece exists.
        /// </summary>
        private Board board;

        protected Board Board {
            get { return board; }
        }

        /// <summary>
        /// The type of Piece : rook, queen, king, etc.
        /// </summary>
        protected string type;
        
        /// <summary>
        /// Access to type variable. Get only.
        /// </summary>
        public string Type {
            get { return type; }
        }

        /// <summary>
        /// The character user to represent the Piece.
        /// </summary>
        protected char icon;

        /// <summary>
        /// Access to icon variable. Get Only.
        /// </summary>
        public char Icon {
            get { return icon;  }
        }

        /// <summary>
        /// The state of the piece.
        /// true --> on board
        /// false --> off board
        /// </summary>
        private bool alive;

        /// <summary>
        /// Access to alive variable.
        /// </summary>
        public bool Alive {
            get { return alive; }
            set { alive = value;  }
        }

        /// <summary>
        /// The color of the Piece
        /// 0 --> white
        /// 1 --> black
        /// </summary>
        private int color;

        /// <summary>
        /// Access to color variable. Get only.
        /// </summary>
        public int Color {
            get { return color; }
        }

        /// <summary>
        /// Boolean showing if the Piece was played once.
        /// </summary>
        private bool played;

        /// <summary>
        /// Access method for played variable.
        /// Read only.
        /// </summary>
        public bool Played {
            get { return this.played; }
        }

        /// <summary>
        /// Constructor for a Piece.
        /// </summary>
        /// <param name="board"> The Board on which the Piece exists. </param>
        /// <param name="color"> The color of the Piece. 0 --> white and 1 --> black </param>
        public Piece(Board board, int color ) {

            this.board = board;
            this.color = color;
            this.alive = true; //By default, a Piece is alive when created.
            this.played = false; ///By default, a Piece has not been played once.

        }

        /// <summary>
        /// Changes played variable to true.
        /// </summary>
        public void PlayedOnce() {
            this.played = true;
        }

        /// <summary>
        /// Modifies the Board (BoardSpace isPossibleDestination variable) 
        /// depeding on the position given in argument.
        /// </summary>
        /// <param name="posX"> Position on X axis.</param>
        /// <param name="posY"> Position on Y axis.</param>
        public abstract void SetDestinations(int posX, int posY);

     }

}
