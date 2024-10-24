using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZabbixClient.Entities;
using ZabbixClient.Helper;
using ZabbixClient;

namespace ZabbixClient.Services
{
	public interface ITrendService
	{
		//IEnumerable<Trend> Get(/*object filter = null,*/ IEnumerable<TrendInclude> include = null, Dictionary<string, object> @params = null);
		IEnumerable<Trend> GetByItem(string itemid, /*IEnumerable<TrendInclude> include = null,*/ Dictionary<string, object> @params = null);
		IEnumerable<Trend> GetByItems(IEnumerable<string> itemids, /*IEnumerable<TrendInclude> include = null,*/ Dictionary<string, object> @params = null);
		IEnumerable<Trend> GetByItemFrom(string itemid, DateTime from, /*IEnumerable<TrendInclude> include = null,*/ Dictionary<string, object> @params = null);
		IEnumerable<Trend> GetByItemsFrom(IEnumerable<string> itemids, DateTime from, /*IEnumerable<TrendInclude> include = null,*/ Dictionary<string, object> @params = null);
	}

	public class TrendService : ServiceBase<Trend, TrendInclude>, ITrendService
	{
		public TrendService(IContext context) : base(context, "trend") { }

		protected override Dictionary<string, object> BuildParams(object filter = null, IEnumerable<TrendInclude> include = null, Dictionary<string, object> @params = null)
		{
			var includeHelper = new IncludeHelper(include == null ? 1 : include.Sum(x => (int)x));
			if (@params == null)
				@params = new Dictionary<string, object>();

			@params.AddIfNotExist("output", "extend");

			//Filter is not part of the parameters (yet, in 6.0 and 7.0)
			//@params.AddOrReplace("filter", filter);

			return @params;
		}

		public IEnumerable<Trend> GetByItem(string itemid, Dictionary<string, object> @params = null)
		{
			return GetByItems(new[] { itemid }, @params);
		}
		public IEnumerable<Trend> GetByItems(IEnumerable<string> itemids, Dictionary<string, object> @params = null)
		{
			@params = @params ?? new Dictionary<string, object>();
			@params.AddOrReplace("itemids", itemids);

			return Get(filter: null, include: null, @params: @params);
		}

		public IEnumerable<Trend> GetByItemFrom(string itemid, DateTime from, Dictionary<string, object> @params = null)
		{
			return GetByItemsFrom(new[] { itemid }, from, @params);
		}
		public IEnumerable<Trend> GetByItemsFrom(IEnumerable<string> itemids, DateTime from, Dictionary<string, object> @params = null)
		{
			@params = @params ?? new Dictionary<string, object>();
			@params.AddOrReplace("itemids", itemids);
			@params.AddOrReplace("time_from", from.ToTimestamp());

			return Get(filter: null, include: null, @params: @params);
		}


	}

	public enum TrendInclude
	{
		All = 1,
		None = 2
	}
}
