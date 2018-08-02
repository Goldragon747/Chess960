using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Source.Model {

    class Queen : Piece {

        public Queen(Board board, int color) : base(board, color) {

            base.type = "queen";

            if (color == 0) {
                base.icon = '\u2655';
            } else {
                base.icon = '\u265b'; //might be u265B
            }

        }

        public override void SetDestinations(int posX, int posY) {
            //throw new NotImplementedException();

            int tmpX;
            int tmpY;
            BoardSpace tmpSpace;

            //Up, down, left and right searches are copies of the Rook method

            //up seach
            tmpX = posX;
            tmpY = posY + 1;

            while (tmpY < Board.GameSize
                && !this.Board.GetBoardSpace(tmpX, tmpY).Occupied) {

                tmpSpace = this.Board.GetBoardSpace(tmpX, tmpY);
                tmpSpace.IsPossibleDestination = true;

                tmpY++;

            }
            //Check in case the loop stoped because we found occupied space
            if (tmpY < Board.GameSize
                && this.Board.GetBoardSpace(tmpX, tmpY).Occupied
                && this.Board.GetBoardSpace(tmpX, tmpY).Piece.Color != this.Color) {

                tmpSpace = this.Board.GetBoardSpace(tmpX, tmpY);
                tmpSpace.IsPossibleDestination = true;

            }

            //down seach
            tmpX = posX;
            tmpY = posY - 1;

            while (tmpY >= 0
                && !this.Board.GetBoardSpace(tmpX, tmpY).Occupied) {

                tmpSpace = this.Board.GetBoardSpace(tmpX, tmpY);
                tmpSpace.IsPossibleDestination = true;

                tmpY--;

            }
            //Check in case the loop stoped because we found occupied space
            if (tmpY >= 0
                && this.Board.GetBoardSpace(tmpX, tmpY).Occupied
                && this.Board.GetBoardSpace(tmpX, tmpY).Piece.Color != this.Color) {

                tmpSpace = this.Board.GetBoardSpace(tmpX, tmpY);
                tmpSpace.IsPossibleDestination = true;

            }

            //right seach
            tmpX = posX + 1;
            tmpY = posY;

            while (tmpX < Board.GameSize
                && !this.Board.GetBoardSpace(tmpX, tmpY).Occupied) {

                tmpSpace = this.Board.GetBoardSpace(tmpX, tmpY);
                tmpSpace.IsPossibleDestination = true;

                tmpX++;

            }
            //Check in case the loop stoped because we found occupied space
            if (tmpX < Board.GameSize
                && this.Board.GetBoardSpace(tmpX, tmpY).Occupied
                && this.Board.GetBoardSpace(tmpX, tmpY).Piece.Color != this.Color) {

                tmpSpace = this.Board.GetBoardSpace(tmpX, tmpY);
                tmpSpace.IsPossibleDestination = true;

            }

            //left seach
            tmpX = posX - 1;
            tmpY = posY;

            while (tmpX >= 0
                && !this.Board.GetBoardSpace(tmpX, tmpY).Occupied) {

                tmpSpace = this.Board.GetBoardSpace(tmpX, tmpY);
                tmpSpace.IsPossibleDestination = true;

                tmpX--;

            }
            //Check in case the loop stoped because we found occupied space
            if (tmpX >= 0
                && this.Board.GetBoardSpace(tmpX, tmpY).Occupied
                && this.Board.GetBoardSpace(tmpX, tmpY).Piece.Color != this.Color) {

                tmpSpace = this.Board.GetBoardSpace(tmpX, tmpY);
                tmpSpace.IsPossibleDestination = true;

            }

            //Diagonal searches are copies of Bishop method

            //up right diagonal
            tmpX = posX + 1;
            tmpY = posY + 1;

            while (tmpX < Board.GameSize
                && tmpY < Board.GameSize
                && !this.Board.GetBoardSpace(tmpX, tmpY).Occupied) {

                tmpSpace = this.Board.GetBoardSpace(tmpX, tmpY);
                tmpSpace.IsPossibleDestination = true;

                tmpX++;
                tmpY++;

            }
            //Check in case the loop stoped because we found occupied space
            if (tmpX < Board.GameSize
                && tmpY < Board.GameSize
                && this.Board.GetBoardSpace(tmpX, tmpY).Occupied
                && this.Board.GetBoardSpace(tmpX, tmpY).Piece.Color != this.Color) {

                tmpSpace = this.Board.GetBoardSpace(tmpX, tmpY);
                tmpSpace.IsPossibleDestination = true;

            }

            //up left diagonal
            tmpX = posX - 1;
            tmpY = posY + 1;

            while (tmpX >= 0
                && tmpY < Board.GameSize
                && !this.Board.GetBoardSpace(tmpX, tmpY).Occupied) {

                tmpSpace = this.Board.GetBoardSpace(tmpX, tmpY);
                tmpSpace.IsPossibleDestination = true;

                tmpX--;
                tmpY++;

            }
            //Check in case the loop stoped because we found occupied space
            if (tmpX >= 0
                && tmpY < Board.GameSize
                && this.Board.GetBoardSpace(tmpX, tmpY).Occupied
                && this.Board.GetBoardSpace(tmpX, tmpY).Piece.Color != this.Color) {

                tmpSpace = this.Board.GetBoardSpace(tmpX, tmpY);
                tmpSpace.IsPossibleDestination = true;

            }

            //down right diagonal
            tmpX = posX + 1;
            tmpY = posY - 1;

            while (tmpX < Board.GameSize
                && tmpY >= 0
                && !this.Board.GetBoardSpace(tmpX, tmpY).Occupied) {

                tmpSpace = this.Board.GetBoardSpace(tmpX, tmpY);
                tmpSpace.IsPossibleDestination = true;

                tmpX++;
                tmpY--;

            }
            //Check in case the loop stoped because we found occupied space
            if (tmpX < Board.GameSize
                && tmpY >= 0
                && this.Board.GetBoardSpace(tmpX, tmpY).Occupied
                && this.Board.GetBoardSpace(tmpX, tmpY).Piece.Color != this.Color) {

                tmpSpace = this.Board.GetBoardSpace(tmpX, tmpY);
                tmpSpace.IsPossibleDestination = true;

            }

            //down left diagonal
            tmpX = posX - 1;
            tmpY = posY - 1;

            while (tmpX >= 0
                && tmpY >= 0
                && !this.Board.GetBoardSpace(tmpX, tmpY).Occupied) {

                tmpSpace = this.Board.GetBoardSpace(tmpX, tmpY);
                tmpSpace.IsPossibleDestination = true;

                tmpX--;
                tmpY--;

            }
            //Check in case the loop stoped because we found occupied space
            if (tmpX >= 0
                && tmpY >= 0
                && this.Board.GetBoardSpace(tmpX, tmpY).Occupied
                && this.Board.GetBoardSpace(tmpX, tmpY).Piece.Color != this.Color) {

                tmpSpace = this.Board.GetBoardSpace(tmpX, tmpY);
                tmpSpace.IsPossibleDestination = true;

            }

        }
    }

}
