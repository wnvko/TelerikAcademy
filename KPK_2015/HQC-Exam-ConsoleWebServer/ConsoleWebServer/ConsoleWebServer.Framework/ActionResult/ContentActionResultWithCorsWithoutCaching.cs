﻿using System.Collections.Generic;

public class ContentActionResultWithCorsWithoutCaching : ContentActionResult
{
    public ContentActionResultWithCorsWithoutCaching(HttpRequest request, object model, string corsSettings) : base(request, model)
    {
        this.ResponseHeaders.Add(new KeyValuePair<string, string>("Access-Control-Allow-Origin", corsSettings));
        this.ResponseHeaders.Add(new KeyValuePair<string, string>("Cache-Control", "private, max-age=0, no-cache"));
    }
}
