using AppCoreModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoreApiClient
{

    public partial class ApiClient
    {
        public async Task<List<Acreditacion>> GetAcreditaciones()
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Acreditacion"));
            return await GetAsync<List<Acreditacion>>(requestUrl);
        }

    }

}
