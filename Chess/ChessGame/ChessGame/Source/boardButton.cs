using ChessGame.Source.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ChessGame.Source {

    class BoardButton : Button {

        /// <summary>
        /// The position on the X and Y axis of the button.
        /// </summary>
        private int posX;
        private int posY;

        /// <summary>
        /// Access methods for position on the X and Y axis of the button.
        /// Read only.
        /// </summary>
        public int PosX {
            get { return this.posX; }
        }

        public int PosY {
            get { return this.posY; }
        }

        /// <summary>
        /// The board Space associated to the button.
        /// </summary>
        private BoardSpace boardSpace;

        //Maybe add access methods to boardSpace

        public BoardButton(int posX, int posY, string name, BoardSpace boardSpace) {

            this.posX = posX;
            this.posY = posY;

            this.Name = name;
            this.boardSpace = boardSpace;

            this.Content = this.boardSpace.GetBoardSpaceChar();

            this.FontSize = 25;

        }

        /// <summary>
        /// Checks is BoardButtons are the same, based on X and Y coordinates.
        /// </summary>
        /// <param name="other">The BoarButton being compared.</param>
        /// <returns></returns>
        public bool Equals(BoardButton other) {

            return (this.posX == other.PosX && this.posY == other.posY);

        }

    }

}
