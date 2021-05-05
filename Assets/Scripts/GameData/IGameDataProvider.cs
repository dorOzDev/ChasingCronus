﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.GameData
{

    public interface IGameDataProvider <T>
    {
        int GetGameCardsCount();

        List<T> GetAllCardsList();
    }
}
