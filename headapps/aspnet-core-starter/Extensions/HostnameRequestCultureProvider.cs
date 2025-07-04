﻿using Microsoft.AspNetCore.Localization;

namespace Sitecore.AspNetCore.Starter.Extensions
{
  public class HostnameRequestCultureProvider : RequestCultureProvider
  {
    public override Task<ProviderCultureResult?> DetermineProviderCultureResult(HttpContext httpContext)
    {
      ArgumentNullException.ThrowIfNull(httpContext);

      // Depeneding on the hostname used, set the culture accordingly so that
      // there is no need to use language prefix or query string parameter to switch language
      var culture = httpContext.Request.Host.Host switch
      {
        "testsite.nl" => "nl-NL",
        "testsite.de" => "de-DE",
        _ => "en", // Default to English if no match found
      };

      return Task.FromResult<ProviderCultureResult?>(new ProviderCultureResult(culture, culture));

    }
  }
}
