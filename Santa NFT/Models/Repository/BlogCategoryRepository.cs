using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Santa_NFT.Models.Repository
{
    public class BlogCategoryRepository : IRepository<BlogCategory>
    {
        public static string sqlconn = ConfigurationManager.ConnectionStrings["CONS"].ToString();

        public string AddOrUpdate(BlogCategory t)
        {
            string objResponse = null;
            using (IDbConnection db = new SqlConnection(sqlconn))
            {
                var reqParam = new
                {
                    Action = (t.BlogCategoryId > 0) ? "UPDATE" : "INSERT",
                    BlogCategoryId = t.BlogCategoryId,
                    BlogCategoryName = t.BlogCategoryName,
                   
                };
                var _dbResponse = db.Query<string>("procBlogCategory", reqParam, commandType: CommandType.StoredProcedure).ToList();
                objResponse = _dbResponse.FirstOrDefault();
            }
            return objResponse;
        }

        public string Delete(BlogCategory t)
        {
            string objResponse = null;
            using (IDbConnection db = new SqlConnection(sqlconn))
            {
                var reqParam = new
                {
                    Action = "DELETE",
                    BlogCategoryId = t.BlogCategoryId,
                    ActionBy = 1
                };
                var _dbResponse = db.Query<string>("procBlogCategory", reqParam, commandType: CommandType.StoredProcedure).ToList();
                objResponse = _dbResponse.FirstOrDefault();
            }
            return objResponse;
        }

        public BlogCategory Get(int id)
        {
            List<BlogCategory> objResponse = new List<BlogCategory>();
            using (IDbConnection db = new SqlConnection(sqlconn))
            {
                var reqParam = new
                {
                    Action = "SELECT",
                    BlogCategoryId = id
                };
                var _dbResponse = db.Query<BlogCategory>("procBlogCategory", reqParam, commandType: CommandType.StoredProcedure).ToList();
                objResponse = _dbResponse;
            }
            return objResponse.FirstOrDefault();
        }

        public List<BlogCategory> GetAll()
        {
            List<BlogCategory> objResponse = new List<BlogCategory>();
            using (IDbConnection db = new SqlConnection(sqlconn))
            {
                var reqParam = new
                {
                    Action = "SELECT",
                };
                var _dbResponse = db.Query<BlogCategory>("procBlogCategory", reqParam, commandType: CommandType.StoredProcedure).ToList();
                objResponse = _dbResponse;
            }
            return objResponse;
        }
    }
}