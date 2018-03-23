using Lottery.Sumilator;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SolverFoundation.Common;
using Microsoft.SolverFoundation.Services;

namespace Lottery
{
	class Program
	{
		static void Main(string[] args)
		{
			var simulator = new Simulator();
			//int Editions = 20000;
			//var archive = new Archive();
			//var archiveGames = 800;
			//var attemptsToCompare = 100;
			//var gamesToBeComparedIn = 10;

			//var threeCons = 0;
			//var fourCons = 0;
			//var fiveCons = 0;
			//var sixCons = 0;
			//var bernWon = 0;
			//var randWon = 0;
			//var predWon = 0;

			//for (int a = 1; a <= attemptsToCompare; a++)
			//{

			//	archive.archive.Clear();
			//	archive.Initialize();
			//	for (int i = 1; i < archiveGames; i++)
			//	{
			//		var sequence = simulator.GenerateGameResult();
			//		archive.AddSequence(sequence, i);
			//	}

			//	var betPrediction = archive.PredictSequence();
			//	var betRandom = simulator.GenerateGameResult();
			//	var betBernoulli = archive.PredictSequenceWithBernoulli(archiveGames);

			//	for (int i = 1; i <= gamesToBeComparedIn; i++)
			//	{

			//		bool won = false;
			//		var sequence = simulator.GenerateGameResult();

			//		var resultPred = Bettor.CheckResult(betPrediction, sequence);
			//		var resultRand = Bettor.CheckResult(betRandom, sequence);
			//		var resultBern = Bettor.CheckResult(betBernoulli, sequence);

			//		if (resultPred > 3)
			//		{
			//			predWon++;
			//			won = true;
			//		}

			//		if (resultRand > 3)
			//		{
			//			randWon++;
			//			won = true;
			//		}

			//		if (resultBern > 3)
			//		{
			//			bernWon++;
			//			won = true;
			//		}

			//		if (won)
			//			break;
			//	}
			//}

			//Console.WriteLine($"predicted wons {predWon}");
			//Console.WriteLine($"radnom wons {randWon}");
			//Console.WriteLine($"bern wons {bernWon}");

			//Console.WriteLine($"win times: { Calculator.Bernoulli(0.01, 1000, 10) * 100}% ");
			//Console.WriteLine($"win times: { Calculator.Bernoulli(0.01, 1000, 1) * 100}% ");

			//var archive = new Archive();
			//var betsToPlayOnce = 42;
			//var threeCons = 0;
			//var fourCons = 0;
			//var fiveCons = 0;
			//var sixCons = 0;
			//int[][] bets = new int[betsToPlayOnce][];

			//for (int i = 1; i <= Editions; i++)
			//{
			//	var sequence = simulator.GenerateGameResult();

			//	if (i >= 1000)
			//	{
			//		if (i % 10 == 0) {
			//			Console.WriteLine($"Predicting for {i}, {Editions - i} remaining.");
			//			//bets = archive.PredictSequences(betsToPlayOnce); 
			//			bets = archive.PredictSequencesWithBernoulli(betsToPlayOnce, i);
			//		}
			//	}


			//	archive.AddSequence(sequence, i);
			//	if (i >= 1000)
			//	{
			//		for (int b = 0; b < betsToPlayOnce; b++)
			//		{
			//			var res = Bettor.CheckResult(bets[b], sequence);
			//			switch (res)
			//			{
			//				case 3:
			//					threeCons++;
			//					break;
			//				case 4:
			//					fourCons++;
			//					break;
			//				case 5:
			//					fiveCons++;
			//					break;
			//				case 6:
			//					sixCons++;
			//					break;
			//				default:
			//					break;
			//			}
			//		}
			//	}
			//}

			//var winsCount = threeCons + fourCons + fiveCons + sixCons;
			//Console.WriteLine($"Total plays: {Editions}, total wins: {winsCount}, total loses: {Editions - winsCount}, win times: {Math.Round((double)winsCount / (double)Editions, 8) * 100}%");
			//Console.WriteLine($"3 wons {threeCons}, times from total wins: {Math.Round((double)threeCons / (double)winsCount, 8) * 100}%, chance to win: {Math.Round((double)threeCons / (double)Editions, 8) * 100}%");
			//Console.WriteLine($"4 wons {fourCons}, times from total wins: {Math.Round((double)fourCons / (double)winsCount, 8) * 100}%, chance to win: {Math.Round((double)fourCons / (double)Editions, 8) * 100}%");
			//Console.WriteLine($"5 wons {fiveCons}, times from total wins: {Math.Round((double)fiveCons / (double)winsCount, 8) * 100}%, chance to win: {Math.Round((double)fiveCons / (double)Editions, 8) * 100}%");
			//Console.WriteLine($"6 wons {sixCons}, times from total wins: {Math.Round((double)sixCons / (double)winsCount, 8) * 100}%, chance to win: { Math.Round((double)sixCons / (double)Editions, 8) * 100}% ");


			//var casinoBlackOneFrom5 = Calculator.Bernoulli(0.5, 1, 1);
			/*var totalNumbers = 10;
			var po4 = 4;
			var comb = Calculator.Combination(10, 4);
			var value = (double)(1 / comb);
			//var probSeq = ;
			var casinoBlackOneFrom5 = Calculator.Bernoulli(Calculator.HyperGeometricProbability(49, 6, 6, 6), 100, 1);
			Console.WriteLine((double)casinoBlackOneFrom5 * 100 + "%");
			Calculator.PrintProbabilityToOdds(casinoBlackOneFrom5);
			*/

			// Probabilities to win in 6 from 49
			//var seq = Calculator.Combinations(49, 6);
			var comb = Calculator.Combination(49, 6);
			var expectedWonTimes = Calculator.HyperGeometricProbability(49, 3, 6, 3);
			var chanceToWin4 = Calculator.HyperGeometricProbability(49, 4, 6, 4);
			var chanceToWin5 = Calculator.HyperGeometricProbability(49, 5, 6, 5);
			var chanceToWin6 = 1 / comb;

			Console.WriteLine((double)expectedWonTimes);
			Console.WriteLine((decimal)(double)chanceToWin4);
			Console.WriteLine((decimal)(double)chanceToWin5);
			Console.WriteLine((decimal)(double)chanceToWin6);
			Calculator.PrintProbabilityToOdds(expectedWonTimes);
			Calculator.PrintProbabilityToOdds(chanceToWin4);
			Calculator.PrintProbabilityToOdds(chanceToWin5);
			Calculator.PrintProbabilityToOdds(chanceToWin6);

			/*// Probabilities to win in 6 from 45
			comb = Calculator.Combination(45, 6);
			expectedWonTimes = Calculator.HyperGeometricProbability(45, 3, 6, 3);
			chanceToWin4 = Calculator.HyperGeometricProbability(45, 4, 6, 4);
			chanceToWin5 = Calculator.HyperGeometricProbability(45, 5, 6, 5);
			chanceToWin6 = 1 / comb;

			Console.WriteLine((double)expectedWonTimes);
			Console.WriteLine((decimal)(double)chanceToWin4);
			Console.WriteLine((decimal)(double)chanceToWin5);
			Console.WriteLine((decimal)(double)chanceToWin6);
			Calculator.PrintProbabilityToOdds(expectedWonTimes);
			Calculator.PrintProbabilityToOdds(chanceToWin4);
			Calculator.PrintProbabilityToOdds(chanceToWin5);
			Calculator.PrintProbabilityToOdds(chanceToWin6);

			// Probabilities to win in KENO
			var seq2 = Calculator.Combination(60, 20);
			var chanceToWin10f10 = Calculator.HyperGeometricProbability(60, 10, 20, 10);
			var chanceToWin9f10 = Calculator.HyperGeometricProbability(60, 10, 20, 9);
			var chanceToWin8f10 = Calculator.HyperGeometricProbability(60, 10, 20, 8);
			var chanceToWin9f9 = Calculator.HyperGeometricProbability(60, 9, 20, 9);
			var chanceToWin8f9 = Calculator.HyperGeometricProbability(60, 9, 20, 8);
			var chanceToWin7f9 = Calculator.HyperGeometricProbability(60, 9, 20, 7);
			var chanceToWin8f8 = Calculator.HyperGeometricProbability(60, 8, 20, 8);
			var chanceToWin7f8 = Calculator.HyperGeometricProbability(60, 8, 20, 7);
			var chanceToWin7f7 = Calculator.HyperGeometricProbability(60, 7, 20, 7);

			Console.WriteLine(((double)seq2).ToString("N1", CultureInfo.InvariantCulture));

			Console.WriteLine((decimal)(double)chanceToWin10f10);
			Console.WriteLine((decimal)(double)chanceToWin9f10);
			Console.WriteLine((decimal)(double)chanceToWin8f10);
			Console.WriteLine((decimal)(double)chanceToWin9f9);
			Console.WriteLine((decimal)(double)chanceToWin8f9);
			Console.WriteLine((decimal)(double)chanceToWin7f9);
			Console.WriteLine((decimal)(double)chanceToWin8f8);
			Console.WriteLine((decimal)(double)chanceToWin7f8);
			Console.WriteLine((decimal)(double)chanceToWin7f7);
			Calculator.PrintProbabilityToOdds(chanceToWin10f10);
			Calculator.PrintProbabilityToOdds(chanceToWin9f10);
			Calculator.PrintProbabilityToOdds(chanceToWin8f10);
			Calculator.PrintProbabilityToOdds(chanceToWin9f9);
			Calculator.PrintProbabilityToOdds(chanceToWin8f9);
			Calculator.PrintProbabilityToOdds(chanceToWin7f9);
			Calculator.PrintProbabilityToOdds(chanceToWin8f8);
			Calculator.PrintProbabilityToOdds(chanceToWin7f8);
			Calculator.PrintProbabilityToOdds(chanceToWin7f7);
			*/

			/*var archive = new Archive();
			var archiveGames = 500;
			for (int i = 1; i <= archiveGames; i++)
			{
				var sequence = simulator.GenerateGameResult();
				archive.AddSequence(sequence, i);
			}

			var combos = archive.BestCombinations(archiveGames, 10);

			foreach (var c in combos)
			{
				Console.Write($"{10 - Array.IndexOf(combos, c)}: ");
				foreach (var number in c)
				{
					var postfix = (Array.IndexOf(c, number) == c.Length - 1) ? ".\n" : ", ";
					Console.Write(number + postfix);
				}
			}
			*/

			var archive = new Archive();
			var threeCons = 0;
			var fourCons = 0;
			var fiveCons = 0;
			var sixCons = 0;
			//var games = 511;

			//for (var i = 1; i <= games; i++)
			//{
			//	var resultArray = simulator.GenerateGameResult();
			//	archive.AddSequence(resultArray, i);
			//}

			var combinationsToCheck = Constants.ChanceToMeetSixFromFourtyNine;

			var bet = simulator.GenerateGameResult();
			for (int i = 1; i <= combinationsToCheck; i++)
			{
				var sequence = simulator.GenerateGameResult();
				var result = Bettor.CheckResult(bet, sequence);
				//archive.AddSequence(sequence, i);
				switch (result)
				{
					case 3:
						threeCons++;
						break;
					case 4:
						fourCons++;
						break;
					case 5:
						fiveCons++;
						break;
					case 6:
						sixCons++;
						break;
					default:
						break;
				}
			}

			Console.WriteLine("Checked");

			var expectedWonTimes3 = Calculator.NumberOfWinningsForSubset(49, 6, 3);
			var expectedWonTimes4 = Calculator.NumberOfWinningsForSubset(49, 6, 4);
			var expectedWonTimes5 = Calculator.NumberOfWinningsForSubset(49, 6, 5);

			var expectedWonTimes6 = 1;

			var actual3diffInPerc = (double)(threeCons / expectedWonTimes3 * 100) - 100;
			var actual4diffInPerc = (double)(fourCons / expectedWonTimes4 * 100) - 100;
			var actual5diffInPerc = (double)(fiveCons / expectedWonTimes5 * 100) - 100;
			var actual6diffInPerc = (double)(sixCons / expectedWonTimes6 * 100) - 100;

			var winsCount = threeCons + fourCons + fiveCons + sixCons;
			Console.WriteLine($"Total plays: {combinationsToCheck}, total wins: {winsCount}, total loses: {Constants.ChanceToMeetSixFromFourtyNine - winsCount}, win times: {Math.Round((double)winsCount / (double)combinationsToCheck, 8) * 100}%");

			Console.WriteLine($"3 wons {threeCons} won times vs expected {(decimal)(double)expectedWonTimes3}. Difference (actual more than expected) is : {actual3diffInPerc}%");
			Console.WriteLine($"4 wons {fourCons} won times vs expected {(decimal)(double)expectedWonTimes4}. Difference (actual more than expected) is : {actual4diffInPerc}%");
			Console.WriteLine($"5 wons {fiveCons} won times vs expected {(decimal)(double)expectedWonTimes5}. Difference (actual more than expected) is : {actual5diffInPerc}%");
			Console.WriteLine($"6 wons {sixCons} won times vs expected {(decimal)(double)expectedWonTimes6}. Difference (actual more than expected) is : {actual6diffInPerc}%");
		}
	}
}
