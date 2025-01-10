using Microsoft.Extensions.Options;
using Scalar.AspNetCore;

namespace Store.Api.OptionsSetup;

public class ScalarOptionsSetup : IConfigureOptions<ScalarOptions>
{
    public void Configure(ScalarOptions options)
    {
        options.Title = "Store API";
        options.Theme = ScalarTheme.BluePlanet;
        options.DefaultHttpClient = new (ScalarTarget.CSharp, ScalarClient.HttpClient);
    }
}
