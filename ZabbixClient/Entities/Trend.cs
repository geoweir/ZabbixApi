using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZabbixClient.Helper;

namespace ZabbixClient.Entities
{
    public partial class Trend : EntityBase
    {
        #region Properties
        /// <summary>
        /// Time when that value was received.
        /// </summary>
        [JsonConverter(typeof(TimestampToDateTimeConverter))]
        public DateTime clock { get; set; }

        /// <summary>
        /// ID of the related item.
        /// </summary>
        [JsonProperty("itemid")]
        public override string Id { get; set; }

		/// <summary>
		/// Number of values that were available for the hour.
		/// </summary>
		public int num { get; set; }

		/// <summary>
		/// Hourly minimum value.
		/// </summary>
		public float value_min { get; set; }

		/// <summary>
		/// Hourly average value.
		/// </summary>
		public float value_avg { get; set; }

		/// <summary>
		/// Hourly maximum value.
		/// </summary>
		public float value_max { get; set; }

		#endregion

	}
}
