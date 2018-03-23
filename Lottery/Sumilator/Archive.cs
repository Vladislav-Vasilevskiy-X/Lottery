﻿using Lottery.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SolverFoundation.Common;

namespace Lottery.Sumilator
{
	[Serializable]
	public class Archive
	{

		public List<ArchiveNumber> archive = new List<ArchiveNumber>();

		public void Initialize()
		{
			for (var i = 1; i <= Constants.GameTotalNumbers; i++)
			{
				archive.Add(new ArchiveNumber
				{
					FacedTimes = 0,
					Value = i,
					Edition = 0
				});
			}
		}

		public Archive()
		{
			Initialize();
		}

		public int[] PredictSequence()
		{
			var value = archive.OrderBy(e => e.FacedTimes).ThenBy(e => e.Edition).Select(e => e.Value).Take(Constants.GameNumbersFallsOut).ToArray();
			return value;
		}

		public int[][] PredictSequences(int number)
		{
			var value = archive.OrderBy(e => e.FacedTimes).ThenBy(e => e.Edition).Select(e => e.Value).ToArray();
			var values = new int[number][];
			for (int i = 0; i < number; i++)
			{
				values[i] = new int[Constants.GameNumbersFallsOut];
				for (int j = 0; j < Constants.GameNumbersFallsOut; j++)
				{
					values[i][j] = value[i + j];
				}
			}

			//var values = new int[number][];
			//for (int i = 0; i < number; i++)
			//{
			//	values[i] = new int[Constants.GameSix];
			//	for (int j = 0; j < Constants.GameSix; j++)
			//	{
			//		values[i][j] = value[i * Constants.GameSix + j];
			//	}
			//}

			return values;
		}
		public int[] PredictSequenceWithBernoulli(int editions)
		{
			foreach (var number in archive)
			{
				number.BernuolliCoefToFaceNext = Calculator.Bernoulli(Calculator.HyperGeometricProbability(Constants.GameTotalNumbers, 1, Constants.GameNumbersFallsOut, 1), editions + 1, number.FacedTimes + 1);
				number.BernuolliCoefToNotFaceNext = Calculator.Bernoulli(Calculator.HyperGeometricProbability(Constants.GameTotalNumbers, 1, Constants.GameNumbersFallsOut, 1), editions + 1, number.FacedTimes);
				number.BernuolliCoefDifference = number.BernuolliCoefToFaceNext - number.BernuolliCoefToNotFaceNext;
				//if (Double.IsNaN(number.BernuolliCoefToFaceNext) || Double.IsNaN(number.BernuolliCoefToNotFaceNext))
				//	throw new Exception("Bernoulli is NAN");
			}

			var value = archive.OrderByDescending(e => e.BernuolliCoefDifference).Select(e => e.Value).Take(Constants.GameNumbersFallsOut).ToArray();

			return value;
		}

		public int[][] PredictSequencesWithBernoulli(int numberOfBets, int editions)
		{
			CalculateBernouli(editions);

			var value = archive.OrderByDescending(e => e.BernuolliCoefDifference).Select(e => e.Value).ToArray();
			var values = new int[numberOfBets][];
			for (int i = 0; i < numberOfBets; i++)
			{
				values[i] = new int[Constants.GameNumbersFallsOut];
				for (int j = 0; j < Constants.GameNumbersFallsOut; j++)
				{
					values[i][j] = value[i + j];
				}
			}

			return values;
		}

		public void CalculateBernouli(int editions)
		{
			foreach (var number in archive)
			{
				number.BernuolliCoefToFaceNext = Calculator.Bernoulli(Constants.probabilityToTakeOneDesiredBall, editions + 1, number.FacedTimes + 1);
				//number.BernuolliCoefToNotFaceNext = Calculator.Bernoulli(Calculator.HyperGeometricProbability(Constants.GameFourtyNine, 1, Constants.GameSix, 1), editions + 1, number.FacedTimes);
				//number.BernuolliCoefDifference = number.BernuolliCoefToFaceNext - number.BernuolliCoefToNotFaceNext;
				////if (Double.IsNaN(number.BernuolliCoefToFaceNext) || Double.IsNaN(number.BernuolliCoefToNotFaceNext))
				//	throw new Exception("Bernoulli is NAN");
			}
		}

		public void AddSequence(int[] sequence, int edition)
		{
			foreach (var element in sequence)
			{
				archive.First(e => e.Value == element).FacedTimes++;
				archive.First(e => e.Value == element).Edition = edition;
			}
		}

		public void CalculateStatistics(int totalNumbersPlayed)
		{
			foreach (var number in archive)
			{

				number.FacedTimesFromTotalNumberOfFacings = (double)number.FacedTimes / (double)totalNumbersPlayed;
			}
		}

		public void Print()
		{
			foreach (var element in archive)
			{
				var message = $"{element.Value} - from total numbers: {Math.Round(element.FacedTimesFromTotalNumberOfFacings, 4) * 100}% -  Faced times:{element.FacedTimes}";
				Console.WriteLine(message);
			}
		}

		public void PrintStatistics()
		{
			var message = $"Total sum of faced prob-s: {Math.Round(archive.Sum(e => e.FacedTimesFromTotalNumberOfFacings), 4) * 100}% -  Faced times:{archive.Sum(e => e.FacedTimes)}";
			Console.WriteLine(message);
		}

		public int[][] BestCombinations(int editions, int desiredCombinations)
		{
			CalculateBernouli(editions);
			var que = new Queue<Combination>();
			Rational lastQ = 0;
			var combintaions = Calculator.Combinations(Constants.GameTotalNumbers, Constants.GameNumbersFallsOut);
			for (int c = 0; c < combintaions.Count(); c++)
			{

				if (c % 10 == 0) Console.Clear();
				Rational _q = 1;
				for (int i = 0; i < Constants.GameNumbersFallsOut; i++)
				{
					_q *= archive.Find(a => a.Value == combintaions.ElementAt(c)[i]).BernuolliCoefToFaceNext * (1 / (Rational)(Constants.GameTotalNumbers - i));
				}

				if (_q >= lastQ)
				{
					lastQ = _q;
					que.Enqueue(new Combination(combintaions.ElementAt(c), _q));
				}

				if (que.Count == desiredCombinations)
				{
					break;
				}

				if (que.Count == desiredCombinations)
				{
					que.Dequeue();
				}

				Console.WriteLine($"combination {c + 1} from {combintaions.Count()}. {1 / combintaions.Count() * 100}% completed. Que has {que.Count} numbers.");
			}

			return que.Select(a => a.Value).ToArray();
		}
	}
}
