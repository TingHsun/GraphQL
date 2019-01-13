using System;
using GraphQL.Types;

namespace aspnetcoregraphql.Models
{
    public class EasyStoreSchema : Schema
    {
        public EasyStoreSchema(Func<Type, GraphType> resolveType)
            :base(resolveType)
        {
            Query = (EasyStoreQuery)resolveType(typeof(EasyStoreQuery)); //¬d¸ß
            //Mutation = (EasyStoreQuery)resolveType(typeof(EasyStoreQuery)); //ÅÜ§ó
        }
    }
}