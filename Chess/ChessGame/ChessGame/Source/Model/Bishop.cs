using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Source.Model {

    class Bishop : Piece {

        public Bishop(Board board, int color) : base(board, color) {

            base.type = "bishop";

            if (color == 0) {
                base.icon = '\u2657';
            } else {
                base.icon = '\u265d'; //might be u265D
            }

        }

        public override void SetDestinations(int posX, int posY) {
            //throw new NotImplementedException();

            int tmpX;
            int tmpY;
            BoardSpace tmpSpace;

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
