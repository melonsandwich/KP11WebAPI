﻿using KP11.Integration.Models.Auth;

namespace KP11.Integration;

public interface IClient
{
    Task<bool> Authorize(ClientAuthConfiguration config);
}