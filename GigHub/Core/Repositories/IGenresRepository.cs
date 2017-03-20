﻿using System.Collections.Generic;
using GigHub.Core.Models;

namespace GigHub.Core.Repositories
{
    public interface IGenresRepository
    {
        List<Genre> GetGenres();
    }
}