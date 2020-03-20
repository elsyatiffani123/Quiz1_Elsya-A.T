using Lampu.Entities;
using Quiz1_Elsya_A.T.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quiz1_Elsya_A.T.Services
{
    public class LampuService
    {
        private readonly ManagementDbContext _db;
        public LampuService(ManagementDbContext dbContext)
        {
            this._db = dbContext;
        }

        /// <summary>
        /// untuk insert data
        /// </summary>
        /// <param name="lampuModel"></param>
        /// <returns></returns>
        public async Task<bool> InsertLamp(LampuModel lampuModel)
        {
            this._db.Add(new Lampu.Entities.Lampu {
                IdLampu = lampuModel.IdLampu,
                NamaLampu = lampuModel.NamaLampu,
                StockLampu = lampuModel.StockLampu
            });
           
            await this._db.SaveChangesAsync();
            return true;
        }

        public int GetTotalData()
        {
            var totalLampu = this._db.lampus.Count();

            return totalLampu;
        }

        /// <summary>
        /// untuk ambil semua data
        /// </summary>
        /// <returns></returns>
        public async Task<List<LampuModel>> GetAllLamps()
        {
            var lamps = await this._db.lampus.Select(Q => new LampuModel
            {
                IdLampu = Q.IdLampu,
                NamaLampu = Q.NamaLampu,
                StockLampu = Q.StockLampu
            }).AsNoTracking().ToListAsync();

            return lamps;
        }

        /// <summary>
        /// untuk update data
        /// </summary>
        /// <param name="lampu"></param>
        /// <returns></returns>
        public async Task<bool> UpdateLampAsync(LampuModel lampu)
        {
            var lampModel = await this._db.lampus.Where(Q => Q.IdLampu == lampu.IdLampu).FirstOrDefaultAsync();

            lampModel.NamaLampu = lampu.NamaLampu;
            lampModel.StockLampu = lampu.StockLampu;

            await this._db.SaveChangesAsync();

            return true;
        }

        /// <summary>
        /// untuk delete data
        /// </summary>
        /// <param name="lampId"></param>
        /// <returns></returns>
        public async Task<bool> DeleteLampAsync(Guid lampId)
        { 
            var lampModel = await this._db.lampus.Where(Q => Q.IdLampu == lampId).FirstOrDefaultAsync();

            if (lampModel == null)
            {
                return false;
            }

            this._db.Remove(lampModel);
            await this._db.SaveChangesAsync();

            return true;
        }

       
        public async Task<LampuModel> GetSpesificEmployeeAsync(Guid idLamp)
        {
            var lamp = await this._db
                .lampus
                .Where(Q => Q.IdLampu == idLamp)
                .Select(Q => new LampuModel
                {
                    IdLampu = Q.IdLampu,
                    NamaLampu = Q.NamaLampu,
                    StockLampu = Q.StockLampu
                })
                .FirstOrDefaultAsync();

            return lamp;
        }


        /// <summary>
        /// untuk filter data dan paginate
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="itemPerPage"></param>
        /// <param name="filterByName"></param>
        /// <returns></returns>
        public async Task<List<LampuModel>> GetAsync(int pageIndex, int itemPerPage, string filterByName)
        {
            
            var query = this._db
                .lampus
                .AsQueryable();

            
            if (string.IsNullOrEmpty(filterByName) == false)
            {
                query = query
                    .Where(Q => Q.NamaLampu.StartsWith(filterByName));
            }

           
            var lamps = await query
                .Select(Q => new LampuModel
                {
                    IdLampu = Q.IdLampu,
                    NamaLampu = Q.NamaLampu,
                    StockLampu = Q.StockLampu
                })
                .Skip((pageIndex - 1) * itemPerPage)
                .Take(itemPerPage)
                .AsNoTracking()
                .ToListAsync();

            return lamps;
        }
    }
}
