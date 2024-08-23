using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using infeubackend.Models;


namespace infeubackend.Interfaces
{
    public interface IFireService
    {
        Task<byte[]> GetAllFires();
    }
}