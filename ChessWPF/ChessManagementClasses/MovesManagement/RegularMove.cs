﻿namespace ChessManagementClasses
{
    public class RegularMove : MoveBase
	{
		public RegularMove(Position start, Position end) : base(start, end) { }

		public override void MakeMove(Board board)
		{
			PieceBase piece = board.GetPiece(StartPosition);
			CapturedPiece = board.GetPiece(EndPosition);

			board.SetPiece(EndPosition, piece);
			board.SetPiece(StartPosition, null);

			piece.HasMoved = true;
		}

		public override void ReverseMove(Board board)
		{
			PieceBase piece = board.GetPiece(EndPosition);

			board.SetPiece(StartPosition, piece);
			board.SetPiece(EndPosition, CapturedPiece);

			piece.HasMoved = piece.PreviousHasMoved;
		}
	}
}
