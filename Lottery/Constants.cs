using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SolverFoundation.Common;

namespace Lottery
{
	public static class Constants
	{
		public static readonly int ChanceToMeetSixFromFourtyNine = 13983816;
		public static readonly int GameNumbersFallsOut = 6;
		public static readonly int GameTotalNumbers = 49;
		public static readonly int CoinsidencesToWin = 3;
		public static readonly Rational probabilityToTakeOneDesiredBall = 1 / (Rational)49;
		public static readonly string TableValuesFilePath= @"..\Debug\Tables\GaussTableValues.dat";
	}
}
