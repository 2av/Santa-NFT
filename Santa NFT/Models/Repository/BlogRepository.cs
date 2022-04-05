using Dapper;
using Santa_NFT.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Santa_NFT.Models.Repository
{
    public class BlogRepository : IRepository<Blog>
    {
        public static string sqlconn = ConfigurationManager.ConnectionStrings["CONS"].ToString();

        public string AddOrUpdate(Blog t)
        {
            string objResponse = null;
            using (IDbConnection db = new SqlConnection(sqlconn))
            {
                var reqParam = new
                {
                    Action = (t.BlogId>0)?"UPDATE":"INSERT",
                    BlogId = t.BlogId,
                    BlogTitle=t.BlogTitle,
                    BlogShortDescriptions=t.BlogShortDescriptions,
                    BlogDescriptions =t.BlogDescriptions,
                    BlogCategoryId=t.BlogCategoryId,
                    DisplayOrder=t.DisplayOrder,
                    BlogBanner=t.BlogBanner,
                    MetaTag=t.MetaTag,
                    IsPopularFeed=t.IsPopularFeed,
                    BlogSchedule=t.BlogSchedule,
                    ActionBy =1
                };
                var _dbResponse = db.Query<string>("procBlog", reqParam, commandType: CommandType.StoredProcedure).ToList();
                objResponse = _dbResponse.FirstOrDefault();
            }
            return objResponse;
        }

        public string Delete(Blog t)
        {
            string objResponse = null;
            using (IDbConnection db = new SqlConnection(sqlconn))
            {
                var reqParam = new
                {
                    Action ="DELETE",
                    BlogId = t.BlogId ,
                    ActionBy = 1
                };
                var _dbResponse = db.Query<string>("procBlog", reqParam, commandType: CommandType.StoredProcedure).ToList();
                objResponse = _dbResponse.FirstOrDefault();
            }
            return objResponse;
        }

        public Blog Get(int id)
        {
            List<Blog> objResponse = new List<Blog>();
            using (IDbConnection db = new SqlConnection(sqlconn))
            {
                var reqParam = new
                {
                    Action = "SELECT",
                    BlogId = id
                };
                var _dbResponse = db.Query<Blog>("procBlog", reqParam, commandType: CommandType.StoredProcedure).ToList();
                objResponse = _dbResponse;
            }
            return objResponse.FirstOrDefault();
        }

        public List<Blog> GetAll()
        {
            List<Blog> objResponse = new List<Blog>();
            using (IDbConnection db = new SqlConnection(sqlconn))
            {
                var reqParam = new
                {
                    Action = "SELECT",
                };
                var _dbResponse = db.Query<Blog>("procBlog", reqParam, commandType: CommandType.StoredProcedure).ToList();
                objResponse = _dbResponse;
            }
            return objResponse;
        }
        public List<vmBlogCategoryCount> GetBlogCategoryCount()
        {
            List<vmBlogCategoryCount> objResponse = new List<vmBlogCategoryCount>();
            using (IDbConnection db = new SqlConnection(sqlconn))
            {
                var reqParam = new
                {
                    Action = "BlogCategoryCount",
                };
                var _dbResponse = db.Query<vmBlogCategoryCount>("procBlog", reqParam, commandType: CommandType.StoredProcedure).ToList();
                objResponse = _dbResponse;
            }
            return objResponse;
        }
    }
}