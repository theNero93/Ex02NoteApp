﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp.Services
{
    public interface IStorageService
    {
        void Write<T>(string key, T value);

        T Read<T>(string key);
        T Read<T>(string key, T defaultValue);
    }
}
