﻿using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;

public class JsonActionResult : IActionResult
{
    public virtual HttpStatusCode GetStatusCode()
    {
        return HttpStatusCode.OK;
    }
    public JsonActionResult(HttpRequest rq, object m)
    {
        model = m;
        Request = rq;
        ResponseHeaders = new List<KeyValuePair<string, string>>();
    }
    public HttpRequest Request { get; private set; }

    public List<KeyValuePair<string, string>> ResponseHeaders { get; private set; }

    public string GetContent()
    {
        return JsonConvert.SerializeObject(model);
    }
    public readonly object model;

    public HttpResponse GetResponse()
    {
        var response = new HttpResponse(Request.ProtocolVersion, GetStatusCode(), GetContent(), HighQualityCodeExamPointsProvider.GetContentType());
        foreach (var responseHeader in ResponseHeaders)
        {
            response.AddHeader(responseHeader.Key, responseHeader.Value);
        }
        return response;
    }
}
public class JsonActionResultWithoutCaching : JsonActionResult
{
    public JsonActionResultWithoutCaching(HttpRequest r, object model)
        : base(r, model)
    {
        this.ResponseHeaders.Add(new KeyValuePair<string, string>("Cache-Control", "private, max-age=0, no-cache"));
        throw new Exception();
    }
}
