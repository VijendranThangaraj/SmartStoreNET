﻿using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.OData;
using SmartStore.Core.Domain.Tax;
using SmartStore.Core.Security;
using SmartStore.Services.Tax;
using SmartStore.Web.Framework.WebApi;
using SmartStore.Web.Framework.WebApi.OData;
using SmartStore.Web.Framework.WebApi.Security;

namespace SmartStore.WebApi.Controllers.OData
{
    public class TaxCategoriesController : WebApiEntityController<TaxCategory, ITaxCategoryService>
	{
		[WebApiQueryable]
		[WebApiAuthenticate(Permission = Permissions.Configuration.Tax.Read)]
		public IQueryable<TaxCategory> Get()
		{
			return GetEntitySet();
		}

		[WebApiQueryable]
        [WebApiAuthenticate(Permission = Permissions.Configuration.Tax.Read)]
        public SingleResult<TaxCategory> Get(int key)
		{
			return GetSingleResult(key);
		}

		[WebApiAuthenticate(Permission = Permissions.Configuration.Tax.Create)]
		public IHttpActionResult Post(TaxCategory entity)
		{
			var result = Insert(entity, () => Service.InsertTaxCategory(entity));
			return result;
		}

		[WebApiAuthenticate(Permission = Permissions.Configuration.Tax.Update)]
		public async Task<IHttpActionResult> Put(int key, TaxCategory entity)
		{
			var result = await UpdateAsync(entity, key, () => Service.UpdateTaxCategory(entity));
			return result;
		}

		[WebApiAuthenticate(Permission = Permissions.Configuration.Tax.Update)]
		public async Task<IHttpActionResult> Patch(int key, Delta<TaxCategory> model)
		{
			var result = await PartiallyUpdateAsync(key, model, entity => Service.UpdateTaxCategory(entity));
			return result;
		}

		[WebApiAuthenticate(Permission = Permissions.Configuration.Tax.Delete)]
		public async Task<IHttpActionResult> Delete(int key)
		{
			var result = await DeleteAsync(key, entity => Service.DeleteTaxCategory(entity));
			return result;
		}
	}
}
