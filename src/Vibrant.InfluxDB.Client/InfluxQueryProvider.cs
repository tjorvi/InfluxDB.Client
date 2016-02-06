﻿//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Linq.Expressions;
//using System.Reflection;
//using System.Threading.Tasks;
//using Vibrant.InfluxDB.Client.Dto;
//using Vibrant.InfluxDB.Client.IQToolkit;

//namespace Vibrant.InfluxDB.Client
//{
//   public class InfluxQueryProvider<TInfluxRow> : QueryProvider
//   {
//      private readonly InfluxClient _client;
//      private readonly string _db;
//      private readonly string _seriesId;

//      public InfluxQueryProvider( InfluxClient client, string db, string seriesId )
//      {
//         _client = client;
//         _db = db;
//         _seriesId = seriesId;
//      }

//      private TranslateResult Translate( Expression expression )
//      {
//         expression = PartialEvaluator.Eval( expression );


//         ProjectionExpression proj = (ProjectionExpression)new QueryBinder().Bind( expression );
//         string commandText = new QueryFormatter().Format( proj.Source );
//         LambdaExpression projector = new ProjectionBuilder().Build( proj.Projector );
//         return new TranslateResult { CommandText = commandText, Projector = projector };

//         return null;
//      }

//      public IQueryable CreateQuery( Expression expression )
//      {
//         Type elementType = TypeHelper.GetElementType( expression.Type );
//         try
//         {
//            return (IQueryable)Activator.CreateInstance( typeof( InfluxQuery<> ).MakeGenericType( elementType ), new object[] { this, expression } );
//         }
//         catch ( TargetInvocationException tie )
//         {
//            throw tie.InnerException;
//         }
//      }

//      public IQueryable<TElement> CreateQuery<TElement>( Expression expression )
//      {
//         return new InfluxQuery<TElement>( this, expression ).To;
//      }

//      public TResult Execute<TResult>( Expression expression )
//      {
//         return (TResult)Execute( expression );
//      }

//      public override object Execute( Expression expression )
//      {
//         //var query = Translate( expression );
//         //var projector = query.Projector.Compile();
//         ////var queryResult = _client.QueryAsync( _db, query.CommandText ).Result;
//         //var queryResult = _client.InternalQueryAsync( _db, "SELECT * FROM cpu" ).Result;

//         //SeriesResult seriesResult = null;
//         //foreach ( var result in queryResult.Results )
//         //{
//         //   foreach ( var series in result.Series )
//         //   {
//         //      if ( series.Name == _seriesId )
//         //      {
//         //         seriesResult = series;
//         //         break;
//         //      }
//         //   }
//         //}

//         //if ( seriesResult == null )
//         //{
//         //   throw new InvalidOperationException();
//         //}

//         // TODO: queryResult into queryType

//         // which type to return?

//         // TODO: transform into grouped type using delegate retrieved from expression

//         return null;
//      }

//      public override string GetQueryText( Expression expression )
//      {
//         return Translate( expression ).CommandText;
//      }

//      // TODO: override async versions
//   }
//}
