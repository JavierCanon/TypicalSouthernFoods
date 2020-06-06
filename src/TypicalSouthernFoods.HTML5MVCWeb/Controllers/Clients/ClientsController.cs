using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using TypicalSouthernFoods.HTML5MVCWeb.Persistence;

namespace TypicalSouthernFoods.HTML5MVCWeb.Controllers
{
    [Route("api/Clients/{action}", Name = "ClientsApi")]
    public class ClientsController : ApiController
    {
        private EntitiesDataModel _context = new EntitiesDataModel();

        [HttpGet]
        public async Task<HttpResponseMessage> Get(DataSourceLoadOptions loadOptions)
        {
            var clients = _context.CLIENTS.Select(i => new
            {
                i.ID,
                i.NAMES,
                i.SURNAMES,
                i.ADDRESS,
                i.PHONE
            });

            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            loadOptions.PrimaryKey = new[] { "ID" };
            loadOptions.PaginateViaPrimaryKey = true;

            return Request.CreateResponse(await DataSourceLoader.LoadAsync(clients, loadOptions));
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Post(FormDataCollection form)
        {
            var model = new CLIENT();
            var values = JsonConvert.DeserializeObject<IDictionary>(form.Get("values"));
            PopulateModel(model, values);

            Validate(model);
            if (!ModelState.IsValid)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, GetFullErrorMessage(ModelState));

            var result = _context.CLIENTS.Add(model);
            await _context.SaveChangesAsync();

            return Request.CreateResponse(HttpStatusCode.Created, result.ID);
        }

        [HttpPut]
        public async Task<HttpResponseMessage> Put(FormDataCollection form)
        {
            var key = Convert.ToDecimal(form.Get("key"), CultureInfo.InvariantCulture);
            var model = await _context.CLIENTS.FirstOrDefaultAsync(item => item.ID == key);
            if (model == null)
                return Request.CreateResponse(HttpStatusCode.Conflict, "Object not found");

            var values = JsonConvert.DeserializeObject<IDictionary>(form.Get("values"));
            PopulateModel(model, values);

            Validate(model);
            if (!ModelState.IsValid)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, GetFullErrorMessage(ModelState));

            await _context.SaveChangesAsync();

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        public async Task Delete(FormDataCollection form)
        {
            var key = Convert.ToDecimal(form.Get("key"), CultureInfo.InvariantCulture);
            var model = await _context.CLIENTS.FirstOrDefaultAsync(item => item.ID == key);

            _context.CLIENTS.Remove(model);
            await _context.SaveChangesAsync();
        }


        private void PopulateModel(CLIENT model, IDictionary values)
        {
            string ID = nameof(CLIENT.ID);
            string NAMES = nameof(CLIENT.NAMES);
            string SURNAMES = nameof(CLIENT.SURNAMES);
            string ADDRESS = nameof(CLIENT.ADDRESS);
            string PHONE = nameof(CLIENT.PHONE);

            if (values.Contains(ID))
            {
                model.ID = Convert.ToDecimal(values[ID], CultureInfo.InvariantCulture);
            }

            if (values.Contains(NAMES))
            {
                model.NAMES = Convert.ToString(values[NAMES]);
            }

            if (values.Contains(SURNAMES))
            {
                model.SURNAMES = Convert.ToString(values[SURNAMES]);
            }

            if (values.Contains(ADDRESS))
            {
                model.ADDRESS = Convert.ToString(values[ADDRESS]);
            }

            if (values.Contains(PHONE))
            {
                model.PHONE = Convert.ToString(values[PHONE]);
            }
        }

        private string GetFullErrorMessage(ModelStateDictionary modelState)
        {
            var messages = new List<string>();

            foreach (var entry in modelState)
            {
                foreach (var error in entry.Value.Errors)
                    messages.Add(error.ErrorMessage);
            }

            return String.Join(" ", messages);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}