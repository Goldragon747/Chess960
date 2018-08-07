using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChessTest
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void IsNormalChessAfterBoardPassedFalse()
        {
            ChessGame.Source.Model.Board board = new ChessGame.Source.Model.Board(false);
            bool isRook1InSpot = board.GetBoardSpace(0, 0).Piece is ChessGame.Source.Model.Rook;
            bool isKnight1InSpot = board.GetBoardSpace(1, 0).Piece is ChessGame.Source.Model.Knight;
            bool isBishop1InSpot = board.GetBoardSpace(2, 0).Piece is ChessGame.Source.Model.Bishop;
            bool isQueenInSpot = board.GetBoardSpace(3, 0).Piece is ChessGame.Source.Model.Queen;
            bool isKingInSpot = board.GetBoardSpace(4, 0).Piece is ChessGame.Source.Model.King;
            bool isBishop2InSpot = board.GetBoardSpace(5, 0).Piece is ChessGame.Source.Model.Bishop;
            bool isKnight2InSpot = board.GetBoardSpace(6, 0).Piece is ChessGame.Source.Model.Knight;
            bool isRook2InSpot = board.GetBoardSpace(7, 0).Piece is ChessGame.Source.Model.Rook;
            Assert.IsTrue(isRook1InSpot &&
                          isKnight1InSpot &&
                          isBishop1InSpot &&
                          isQueenInSpot &&
                          isKingInSpot &&
                          isBishop2InSpot &&
                          isKnight2InSpot &&
                          isRook2InSpot, "Board is not set up to default chess.", null);
        }
        [TestMethod]
        public void IsChess960AfterBoardPassedTrue()
        {
            ChessGame.Source.Model.Board board = new ChessGame.Source.Model.Board(true);
            bool isRook1InSpot = board.GetBoardSpace(0, 0).Piece is ChessGame.Source.Model.Rook;
            bool isKnight1InSpot = board.GetBoardSpace(1, 0).Piece is ChessGame.Source.Model.Knight;
            bool isBishop1InSpot = board.GetBoardSpace(2, 0).Piece is ChessGame.Source.Model.Bishop;
            bool isQueenInSpot = board.GetBoardSpace(3, 0).Piece is ChessGame.Source.Model.Queen;
            bool isKingInSpot = board.GetBoardSpace(4, 0).Piece is ChessGame.Source.Model.King;
            bool isBishop2InSpot = board.GetBoardSpace(5, 0).Piece is ChessGame.Source.Model.Bishop;
            bool isKnight2InSpot = board.GetBoardSpace(6, 0).Piece is ChessGame.Source.Model.Knight;
            bool isRook2InSpot = board.GetBoardSpace(7, 0).Piece is ChessGame.Source.Model.Rook;
            Assert.IsTrue(!isRook1InSpot ||
                          !isKnight1InSpot ||
                          !isBishop1InSpot ||
                          !isQueenInSpot ||
                          !isKingInSpot ||
                          !isBishop2InSpot ||
                          !isKnight2InSpot ||
                          !isRook2InSpot, "Board is not set up to default chess.", null);
        }
        [TestMethod]
        public void Chess960Position1AreSame()
        {
            ChessGame.Source.Model.Board board = new ChessGame.Source.Model.Board(true);
            bool isPos1Same = board.GetBoardSpace(0, 0).Piece.GetType() == board.GetBoardSpace(0, 7).Piece.GetType();
            Assert.IsTrue(isPos1Same, "Positions are not the same.", null);
        }
        [TestMethod]
        public void Chess960Position2AreSame()
        {
            ChessGame.Source.Model.Board board = new ChessGame.Source.Model.Board(true);
            bool isPos2Same = board.GetBoardSpace(1, 0).Piece.GetType() == board.GetBoardSpace(1, 7).Piece.GetType();
            Assert.IsTrue(isPos2Same, "Positions are not the same.", null);
        }
        [TestMethod]
        public void Chess960Position3AreSame()
        {
            ChessGame.Source.Model.Board board = new ChessGame.Source.Model.Board(true);
            bool isPos3Same = board.GetBoardSpace(2, 0).Piece.GetType() == board.GetBoardSpace(2, 7).Piece.GetType();
            Assert.IsTrue(isPos3Same, "Positions are not the same.", null);
        }
        [TestMethod]
        public void Chess960Position4AreSame()
        {
            ChessGame.Source.Model.Board board = new ChessGame.Source.Model.Board(true);
            bool isPos4Same = board.GetBoardSpace(3, 0).Piece.GetType() == board.GetBoardSpace(3, 7).Piece.GetType();
            Assert.IsTrue(isPos4Same, "Positions are not the same.", null);
        }
        [TestMethod]
        public void Chess960Position5AreSame()
        {
            ChessGame.Source.Model.Board board = new ChessGame.Source.Model.Board(true);
            bool isPos5Same = board.GetBoardSpace(4, 0).Piece.GetType() == board.GetBoardSpace(4, 7).Piece.GetType();
            Assert.IsTrue(isPos5Same, "Positions are not the same.", null);
        }
        [TestMethod]
        public void Chess960Position6AreSame()
        {
            ChessGame.Source.Model.Board board = new ChessGame.Source.Model.Board(true);
            bool isPos6Same = board.GetBoardSpace(5, 0).Piece.GetType() == board.GetBoardSpace(5, 7).Piece.GetType();
            Assert.IsTrue(isPos6Same, "Positions are not the same.", null);
        }
        [TestMethod]
        public void Chess960Position7AreSame()
        {
            ChessGame.Source.Model.Board board = new ChessGame.Source.Model.Board(true);
            bool isPos7Same = board.GetBoardSpace(6, 0).Piece.GetType() == board.GetBoardSpace(6, 7).Piece.GetType();
            Assert.IsTrue(isPos7Same, "Positions are not the same.", null);
        }
        [TestMethod]
        public void Chess960Position8AreSame()
        {
            ChessGame.Source.Model.Board board = new ChessGame.Source.Model.Board(true);
            bool isPos8Same = board.GetBoardSpace(7, 0).Piece.GetType() == board.GetBoardSpace(7, 7).Piece.GetType();
            Assert.IsTrue(isPos8Same, "Positions are not the same.", null);
        }
    }
}
