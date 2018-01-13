using AutoMapper;
using FM.Data.Access.Impl.LinqSql.GeneratedDAL;
using FM.Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM.Data.Access.Impl.LinqSql.Mappers
{
    public static class EntityMapper
    {
        static private MapperConfiguration configMapToModel;
        static private MapperConfiguration configMapToDatabase;

        static EntityMapper()
        {
            // Initialize once a mapper like FM_Feedback to Feedback
            configMapToModel = new MapperConfiguration(cfg =>
            {
                cfg.SourceMemberNamingConvention = new LowerUnderscoreNamingConvention();
                cfg.DestinationMemberNamingConvention = new PascalCaseNamingConvention();
                cfg.CreateMap<FM_Feedback, Feedback>();
                cfg.CreateMap<FM_User, User>();
                cfg.CreateMap<FM_Game, Game>();
                cfg.CreateMap<FM_Game_Session, GameSession>();
            });

            // Initialize once a mapper like Feedback to FM_Feedback
            configMapToDatabase = new MapperConfiguration(cfg =>
            {
                cfg.DestinationMemberNamingConvention = new LowerUnderscoreNamingConvention();
                cfg.SourceMemberNamingConvention = new PascalCaseNamingConvention();
                cfg.CreateMap<Feedback, FM_Feedback> ();
                cfg.CreateMap<User, FM_User>();
                cfg.CreateMap<Game, FM_Game>();
                cfg.CreateMap<GameSession, FM_Game_Session>();
            });
        }

        public static M MapToModel<M,D>(D databaseEntity)
        {
            var mapper = configMapToModel.CreateMapper();
            return mapper.Map<M>(databaseEntity);
        }

        public static D MapToDatabase<M,D>(M modelEntity)
        {
            var mapper = configMapToDatabase.CreateMapper();
            return mapper.Map<D>(modelEntity);
        }
    }
}
