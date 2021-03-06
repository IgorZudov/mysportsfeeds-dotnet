﻿using System.Threading.Tasks;
using MySportsFeeds.NetCore.Enums;
using MySportsFeeds.NetCore.Helpers;
using MySportsFeeds.NetCore.Models.Mlb;
using MySportsFeeds.NetCore.Workers;

namespace MySportsFeeds.NetCore.Mlb
{
    public class CurrentSeason
    {
        /// <summary>
        /// The URL
        /// </summary>
        private const string Url = "/pull/mlb/{0}/current_season.json";

        /// <summary>
        /// The HTTP worker
        /// </summary>
        private HttpCommunicationWorker _httpWorker;

        /// <summary>
        /// Initializes a new instance of the <see cref="Scoreboard"/> class.
        /// </summary>
        /// <param name="httpWorker">The HTTP worker.</param>
        internal CurrentSeason(HttpCommunicationWorker httpWorker)
        {
            _httpWorker = httpWorker;
        }

        /// <summary>
        /// Gets the specified current season.
        /// </summary>
        /// <param name="league">The league.</param>
        /// <param name="year">The year.</param>
        /// <param name="seasonType">Type of the season.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <returns></returns>
        public async Task<CurrentSeasonResponse> Get(int year, SeasonType seasonType, RequestOptions requestOptions = null)
        {
            var url = string.Concat(_httpWorker.Version, Url);
            string requestUrl = UrlBuilder.FormatRestApiUrl(url, year, seasonType, requestOptions);

            return await _httpWorker.GetAsync<CurrentSeasonResponse>(requestUrl).ConfigureAwait(false);
        }
    }
}