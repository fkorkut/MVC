﻿using MyblogSite.Data.UnitOfWork;
using MyBlogSite.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogSite.Service
{
    public class DefinitionService : BaseService
    {
        public List<CategoryDTO> GetCategories()
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                var result = uow.Categories.List();

                List<CategoryDTO> list = new List<CategoryDTO>();

                foreach (var item in result)
                {
                    CategoryDTO category = new CategoryDTO
                    {
                        CategoryId = item.CategoryId,
                        CategoryName = item.CategoryName
                    };

                    list.Add(category);
                }

                return list;
            }
        }

        public List<CityDTO> GetCities()
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                var result = uow.Cities.List();

                List<CityDTO> list = new List<CityDTO>();

                foreach (var item in result)
                {
                    CityDTO city = new CityDTO
                    {
                        CityID = item.CityID,
                        CityName = item.CityName
                    };

                    list.Add(city);
                }

                return list;
            }
        }

        public List<RecordStatusDTO> GetRecordStatuses()
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                var result = uow.RecordStatuses.List();

                List<RecordStatusDTO> list = new List<RecordStatusDTO>();

                foreach (var item in result)
                {
                    RecordStatusDTO obj = new RecordStatusDTO
                    {
                        RecordStatusId = item.RecordStatusId,
                        RecordStatusName = item.RecordStatusName
                    };

                    list.Add(obj);
                }

                return list;
            }
        }


        //İle göre ilçe getir
        public List<TownDTO> GetTownsByCity(int cityId)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                var result = uow.Towns.Search(x => x.CityID == cityId);

                if (result.Count == 0)
                {
                    return null;
                }

                // throw new System.Exception("Hata oluştu");

                List<TownDTO> list = new List<TownDTO>();

                foreach (var item in result)
                {
                    TownDTO obj = new TownDTO
                    {
                        TownID = item.TownID,
                        TownName = item.TownName
                    };

                    list.Add(obj);
                }

                return list;
            }
        }
    }
}
