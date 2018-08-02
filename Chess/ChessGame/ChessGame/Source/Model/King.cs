using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Source.Model {

    class King : Piece {

        public King(Board board, int color) : base(board, color) {

            base.type = "king";

            if (color == 0) {
                base.icon = '\u2654';
            } else {
                base.icon = '\u265a'; //might be u265A
            }

        }

        public override void SetDestinations(int posX, int posY) {
            //throw new NotImplementedException();

            //jagged array of all 8 possible destinations
            int[][] possibleDestinations = new int[][] { 
                new int [] {posX, posY + 1 },
                new int [] {posX, posY - 1 },
                new int [] {posX + 1, posY },
                new int [] {posX - 1, posY },
                new int [] {posX + 1, posY + 1 },
                new int [] {posX + 1, posY - 1 },
                new int [] {posX - 1, posY + 1 },
                new int [] {posX -1, posY - 1 }
            };

            int tmpX;
            int tmpY;
            BoardSpace tmpSpace;

            foreach (int[] pos in possibleDestinations) {

                tmpX = pos[0];
                tmpY = pos[1];

                if (tmpX >= 0 && tmpX < Board.GameSize 
                    && tmpY >= 0 && tmpY < Board.GameSize) {

                    tmpSpace = this.Board.GetBoardSpace(tmpX, tmpY);
                    tmpSpace.IsPossibleDestination = true;

                    if (tmpSpace.Occupied 
                        && tmpSpace.Piece.Color == this.Color) {

                        tmpSpace.IsPossibleDestination = false;

                    }

                }

            }

        }
    }

}
