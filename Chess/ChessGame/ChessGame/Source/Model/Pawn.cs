using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Source.Model {

    class Pawn : Piece {

        public Pawn(Board board, int color) : base(board, color) {

            base.type = "pawn";

            if (color == 0) {
                base.icon = '\u2659';
            } else {
                base.icon = '\u265f'; //might be u265F
            }

        }

        public override void SetDestinations(int posX, int posY) {
            //throw new NotImplementedException();

            int tmpX;
            int tmpY;
            BoardSpace tmpSpace;

            //Advance by two
            tmpX = posX;
            int otherY;
            if (this.Color == 0) { //advance is different for white or black
                tmpY = posY + 2;
                otherY = posY + 1;
            } else {
                tmpY = posY - 2;
                otherY = posY - 1;
            }

            if (!this.Played 
                && tmpY < Board.GameSize 
                && tmpY >= 0
                && !this.Board.GetBoardSpace(tmpX, tmpY).Occupied
                && !this.Board.GetBoardSpace(tmpX, otherY).Occupied) {

                tmpSpace = this.Board.GetBoardSpace(tmpX, tmpY);
                tmpSpace.IsPossibleDestination = true;

            }

            //Advance by one
            tmpX = posX;
            if (this.Color == 0) { //advance is different for white or black
                tmpY = posY + 1;
            } else {
                tmpY = posY - 1;
            }

            if (tmpY < Board.GameSize
                && tmpY >= 0
                && !this.Board.GetBoardSpace(tmpX, tmpY).Occupied) {

                tmpSpace = this.Board.GetBoardSpace(tmpX, tmpY);
                tmpSpace.IsPossibleDestination = true;

            }

            //Capture diagonal right
            if (this.Color == 0) { //advance is different for white or black
                tmpX = posX + 1;
                tmpY = posY + 1;
            } else {
                tmpX = posX + 1;
                tmpY = posY - 1;
            }

            if (tmpX < Board.GameSize && tmpX >= 0
                && tmpY < Board.GameSize && tmpY >= 0
                && this.Board.GetBoardSpace(tmpX, tmpY).Occupied
                && this.Board.GetBoardSpace(tmpX, tmpY).Piece.Color != this.Color) {

                tmpSpace = this.Board.GetBoardSpace(tmpX, tmpY);
                tmpSpace.IsPossibleDestination = true;

            }

            //Capture diagonal left
            if (this.Color == 0) { //advance is different for white or black
                tmpX = posX - 1;
                tmpY = posY + 1;
            } else {
                tmpX = posX - 1;
                tmpY = posY - 1;
            }

            if (tmpX < Board.GameSize && tmpX >= 0
                && tmpY < Board.GameSize && tmpY >= 0
                && this.Board.GetBoardSpace(tmpX, tmpY).Occupied
                && this.Board.GetBoardSpace(tmpX, tmpY).Piece.Color != this.Color) {

                tmpSpace = this.Board.GetBoardSpace(tmpX, tmpY);
                tmpSpace.IsPossibleDestination = true;

            }

        }
    }

}
