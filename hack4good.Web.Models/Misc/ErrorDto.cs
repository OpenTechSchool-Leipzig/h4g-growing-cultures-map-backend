﻿namespace hack4good.Web.Models.Misc;

public class ErrorDto : IDTO
{
    public string Error { get; set; }

    public ErrorDto(string error)
    {
        Error = error;
    }
}