using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain;
using AutoMapper;

namespace API.Repository
{
    public class EntityMapper<TSource, TDestination> where TSource : class where TDestination : class
    {
        public EntityMapper()
        {
            Mapper.CreateMap<Models.StudentModel, Student>();
            Mapper.CreateMap<Student, Models.StudentModel>();
        }

        public TDestination Translate(TSource obj)
        {
            return Mapper.Map<TDestination>(obj);
        }
    }
}