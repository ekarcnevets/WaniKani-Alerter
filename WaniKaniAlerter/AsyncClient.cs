using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaniKaniClientLib;
using WaniKaniClientLib.Models;

namespace WaniKaniAlerter {
    /// <summary>
    /// Asynchronous wrapper around the <seealso cref="WaniKaniClientLib.WaniKaniClient"/>
    /// </summary>
    public class AsyncClient {
        private WaniKaniClient _client;

        public Task<UserInformation> UserInformation(bool noCache = false) {
	        return Task.Factory.StartNew(() => _client.UserInformation(noCache));
        }

        public Task<StudyQueue> StudyQueue(bool noCache = false) {
	        return Task.Factory.StartNew(() => _client.StudyQueue(noCache));
        }

        public Task<LevelProgression> LevelProgression(bool noCache = false) {
	        return Task.Factory.StartNew(() => _client.LevelProgression(noCache));
        }

        public Task<SrsDistribution> SrsDistribution(bool noCache = false) {
	        return Task.Factory.StartNew(() => _client.SrsDistribution(noCache));
        }

        public Task<List<BaseCharacter>> RecentUnlocks(int take = 10) {
	        return Task.Factory.StartNew(() => _client.RecentUnlocks(take));
        }

        public Task<List<BaseCharacter>> CriticalItems(int maxPercentage = 75) {
	        return Task.Factory.StartNew(() => _client.CriticalItems(maxPercentage));
        }

        public Task<List<Radical>> Radicals(int maxLevel = 0) {
	        return Task.Factory.StartNew(() => _client.Radicals(maxLevel));
        }

        public Task<List<Radical>> Radicals(string levels) {
	        return Task.Factory.StartNew(() => _client.Radicals(levels));
        }

        public Task<List<Kanji>> Kanji(int maxLevel = 0) {
	        return Task.Factory.StartNew(() => _client.Kanji(maxLevel));
        }

        public Task<List<Kanji>> Kanji(string levels) {
	        return Task.Factory.StartNew(() => _client.Kanji(levels));
        }

        public Task<List<Vocabulary>> Vocabulary(int maxLevel = 0) {
	        return Task.Factory.StartNew(() => _client.Vocabulary(maxLevel));
        }

        public Task<List<Vocabulary>> Vocabulary(string levels) {
	        return Task.Factory.StartNew(() => _client.Vocabulary(levels));
        }

        public AsyncClient(string apiKey, int cacheInMinutes = 15) {
            this._client = new WaniKaniClient(apiKey, cacheInMinutes);
        }
    }
}
