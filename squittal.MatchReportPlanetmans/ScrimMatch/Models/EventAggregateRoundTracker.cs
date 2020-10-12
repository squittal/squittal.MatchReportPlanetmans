﻿using System.Collections.Generic;
using System.Linq;

namespace squittal.ScrimPlanetmans.ScrimMatch.Models
{
    public class ScrimEventAggregateRoundTracker
    {
        public ScrimEventAggregate TotalStats { get; set; } = new ScrimEventAggregate();
        public ScrimEventAggregate RoundStats { get; set; } = new ScrimEventAggregate();

        // Each aggregate is only the points scored during the round number of the enytry's key
        public Dictionary<int, ScrimEventAggregate> RoundHistory = new Dictionary<int, ScrimEventAggregate>();

        public int HighestRound { get => GetHighestHistoryRound(); }

        public void AddToCurrent(ScrimEventAggregate update)
        {
            TotalStats.Add(update);
            RoundStats.Add(update);
        }

        public void SubtractFromCurrent(ScrimEventAggregate update)
        {
            TotalStats.Subtract(update);
            RoundStats.Subtract(update);
        }

        public void AddToHistory(ScrimEventAggregateRoundTracker addend)
        {
            TotalStats.Add(addend.TotalStats);
            RoundStats.Add(addend.RoundStats);

            var maxBaseRound = GetHighestHistoryRound();
            var maxAddendRound = addend.GetHighestHistoryRound();

            var maxRound = maxBaseRound >= maxAddendRound
                                ? maxBaseRound
                                : maxAddendRound;

            for (var round = 1; round == maxRound; round++)
            {
                var result = new ScrimEventAggregate();

                if (addend.RoundHistory.TryGetValue(round, out var addendRound))
                {
                    result.Add(addendRound);
                }

                if (RoundHistory.TryGetValue(round, out var baseRound))
                {
                    result.Add(baseRound);
                    RoundHistory[round] = result;
                }
                else
                {
                    RoundHistory.Add(round, result);
                }
            }
        }

        public void SubtractFromHistory(ScrimEventAggregateRoundTracker subtrahend)
        {
            TotalStats.Subtract(subtrahend.TotalStats);

            var maxBaseRound = HighestRound;
            var maxSubtrahendRound = subtrahend.HighestRound;

            RoundStats.Subtract(subtrahend.RoundStats);
            //if (maxBaseRound == maxSubtrahendRound)
            //{
            //    RoundStats.Subtract(subtrahend.RoundStats);
            //}

            //var maxBaseRound = GetHighestHistoryRound();
            //var maxAddendRound = subtrahend.GetHighestHistoryRound();

            var maxRound = maxBaseRound >= maxSubtrahendRound
                                ? maxBaseRound
                                : maxSubtrahendRound;

            for (var round = 1; round <= maxRound; round++)
            {
                //var roundSubtrahend = new ScrimEventAggregate();

                var roundSubtrahend = new ScrimEventAggregate();

                if (subtrahend.RoundHistory.ContainsKey(round))
                {
                    roundSubtrahend.Add(subtrahend.RoundHistory[round]);
                }

                if (RoundHistory.ContainsKey(round))
                {
                    RoundHistory[round].Subtract(roundSubtrahend);
                }
                else
                {
                    RoundHistory.Add(round, roundSubtrahend);
                }

                //if (!subtrahend.RoundHistory.TryGetValue(round, out var roundSubtrahend))
                //{
                //    continue;
                //}

                //if (RoundHistory.TryGetValue(round, out var baseRound))
                //{
                //    baseRound.Subtract(roundSubtrahend);
                //    RoundHistory[round] = baseRound;
                //}
            }
        }

        public bool TryGetTargetRoundStats(int targetRound, out ScrimEventAggregate targetRoundStats)
        {
            targetRoundStats = new ScrimEventAggregate();
            
            if (targetRound < 0)
            {
                return false;
            }

            if (RoundHistory.ContainsKey(targetRound))
            {
                targetRoundStats.Add(RoundHistory[targetRound]);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ResetRoundStats()
        {
            RoundStats = new ScrimEventAggregate();
        }

        public void RollBackRound(int currentRound)
        {
            var maxRound = GetHighestHistoryRound();

            // Only allow rolling back from the last saved rounds
            if (currentRound != maxRound)
            {
                // TODO: throw error
                return;
            }

            if (RoundHistory.TryGetValue(currentRound, out var update))
            {
                TotalStats.Subtract(update);

                RoundHistory.Remove(currentRound);

                ResetRoundStats();
            }
            else
            {
                // TODO: throw error
            }
        }

        public void SaveRoundToHistory(int currentRound)
        {
            if (currentRound < 1)
            {
                // TODO: throw error
                return;
            }

            var roundStats = new ScrimEventAggregate();

            roundStats.Add(RoundStats);

            if (RoundHistory.ContainsKey(currentRound))
            {
                RoundHistory[currentRound].Add(roundStats);
            }
            else
            {
                RoundHistory.Add(currentRound, roundStats);
            }
            
            // TODO: take this into account elsewhere
            RoundStats = new ScrimEventAggregate();
        }


        private int GetHighestHistoryRound()
        {
            var rounds = RoundHistory.Keys.ToArray();

            if (!rounds.Any())
            {
                return 0;
            }

            return rounds.Max();
        }
    }
}
