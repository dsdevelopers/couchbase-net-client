﻿using Newtonsoft.Json.Linq;

namespace Couchbase.Search.Queries.Simple
{
    /// <summary>
    /// A wildcard query is a query in which term the character * will match 0..n occurrences of any characters and ? will match 1 occurrence of any character.
    /// </summary>
    /// <seealso cref="Couchbase.Search.Queries.FtsQueryBase" />
    public class WildcardQuery : FtsQueryBase
    {
        private string _wildCard;
        private string _field;

        public WildcardQuery(string wildcard)
        {
            _wildCard = wildcard;
        }

        /// <summary>
        /// The field for the match.
        /// </summary>
        /// <param name="field">The field.</param>
        /// <returns></returns>
        public WildcardQuery Field(string field)
        {
            _field = field;
            return this;
        }

        public override JObject Export(ISearchParams searchParams)
        {
            var queryJson = base.Export(searchParams);
            queryJson.Add(new JProperty("query", new JObject(
                new JProperty("boost", _boost),
                new JProperty("field", _field),
                new JProperty("wildcard", _wildCard))));

            return queryJson;
        }

        public override JObject Export()
        {
            var queryJson = base.Export();
            queryJson.Add(new JProperty("query", new JObject(
                new JProperty("boost", _boost),
                new JProperty("field", _field),
                new JProperty("wildcard", _wildCard))));

            return queryJson;
        }
    }
}

#region [ License information          ]

/* ************************************************************
 *
 *    @author Couchbase <info@couchbase.com>
 *    @copyright 2015 Couchbase, Inc.
 *
 *    Licensed under the Apache License, Version 2.0 (the "License");
 *    you may not use this file except in compliance with the License.
 *    You may obtain a copy of the License at
 *
 *        http://www.apache.org/licenses/LICENSE-2.0
 *
 *    Unless required by applicable law or agreed to in writing, software
 *    distributed under the License is distributed on an "AS IS" BASIS,
 *    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *    See the License for the specific language governing permissions and
 *    limitations under the License.
 *
 * ************************************************************/

#endregion
