﻿// Copyright (c) Damir Dobric. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.
using NeoCortexApi.Entities;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace NeoCortexApi.Classifiers
{
    public class HtmUnionClassifier<TIN, TOUT> : IClassifier<TIN, TOUT>, IClassifierKnn<TIN, TOUT>
    {
        private Dictionary<TIN, int[]> m_ActiveMap = new Dictionary<TIN, int[]>();

        public TIN GetPredictedInputValue(Cell[] predictiveCells)
        {
            int result = 0, predictedNextValueResult = 0;
            dynamic charOutput = null;
            int[] arr = new int[predictiveCells.Length];
            for (int i = 0; i < predictiveCells.Length; i++)
            {
                arr[i] = predictiveCells[i].Index;
            }

            Stopwatch sw = Stopwatch.StartNew();

            foreach (var key in m_ActiveMap.Keys)
            {
                predictedNextValueResult = PredictNextValue(arr, m_ActiveMap[key]);
                if (result < predictedNextValueResult)
                {
                    result = predictedNextValueResult;
                    charOutput = key as string;
                }
            }
            sw.Stop();
            Debug.WriteLine("Time elapsed: {0}", sw.Elapsed.ToString());

            return (TIN)charOutput;
        }

        public List<ClassifierResult<TIN>> GetPredictedInputValues(int[] cellIndicies, short howMany = 1)
        {
            throw new System.NotImplementedException();
        }

        public List<ClassifierResult<TIN>> GetPredictedInputValues(Cell[] predictiveCells, short howMany = 1)
        {
            throw new System.NotImplementedException();
        }

       
        public void Learn(TIN input, Cell[] activeCells, bool learn)
        {
            if (learn == true)
            {
                int[] unionArray;
                int[] cellAsInt = new int[activeCells.Length];
                for (int i = 0; i < activeCells.Length; i++)
                {
                    cellAsInt[i] = activeCells[i].Index;
                }
                if (!m_ActiveMap.TryGetValue(input, out unionArray))
                {
                    m_ActiveMap.Add(input, cellAsInt);
                    return; // or whatever you want to do
                }
                else
                {
                    m_ActiveMap[input] = GetUnionArr(cellAsInt, m_ActiveMap[input]);
                }
            }
        }

        public void Learn(TIN input, Cell[] output)
        {
            throw new System.NotImplementedException();
        }

        private int[] GetUnionArr(int[] prevCells, int[] currCells)
        {
            return prevCells.Union(currCells).ToArray();
        }

        private int PredictNextValue(int[] activeArr, int[] predictedArr)
        {
            var same = predictedArr.Intersect(activeArr);

            return same.Count();
        }
    }
}
