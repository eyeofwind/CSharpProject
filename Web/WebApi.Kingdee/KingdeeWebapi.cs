using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WebApi.Kingdee
    {
    internal sealed class HttpClient
        {
      
        /// <summary>
        /// url
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// cookie
        /// </summary>
        static CookieContainer Cookie = new CookieContainer();
        /// <summary>
        /// 异步请求
        /// </summary>
        /// <returns></returns>
        public string AsyncRequest()
            {
            HttpWebRequest httpRequest = HttpWebRequest.Create(Url) as HttpWebRequest;
            httpRequest.Method = "POST";
            httpRequest.ContentType = "application/json";
            httpRequest.CookieContainer = Cookie;
            httpRequest.Timeout = 1000 * 60 * 10;//10min

            using(Stream reqStream = httpRequest.GetRequestStream())
                {
                JObject jObj = new JObject();
                jObj.Add("format" , 1);
                jObj.Add("useragent" , "ApiClient");
                jObj.Add("rid" , Guid.NewGuid().ToString().GetHashCode().ToString());
                jObj.Add("parameters" , Content);
                jObj.Add("timestamp" , DateTime.Now);
                jObj.Add("v" , "1.0");
                string sContent = jObj.ToString();
                var bytes = UnicodeEncoding.UTF8.GetBytes(sContent);
                reqStream.Write(bytes , 0 , bytes.Length);
                reqStream.Flush();
                }
            using(Stream repStream = httpRequest.GetResponse().GetResponseStream())
                {
                using(var reader = new StreamReader(repStream))
                    {
                    return ValidateResult(reader.ReadToEnd());
                    }
                }
            }

        private static string ValidateResult(string responseText)
            {
            if(responseText.StartsWith("response_error:"))
                {
                return responseText.TrimStart("response_error:".ToCharArray());
                }
            return responseText;
            }
        }

    public sealed class KingdeeWebapi
        {
         HttpClient httpClient = new HttpClient();

        /// <summary>
        /// 接口类型枚举
        /// </summary>
        public enum InterfaceType
            {   
                   
            BatchSave,                                       
            Submit,
            Audit,
            UnAudit,
            Delete

            }

        /// <summary>
        /// 验证用户信息,返回"1"即验证成功
        /// </summary>
        /// <param name="url">url地址</param>
        /// <param name="accountId">帐套id</param>
        /// <param name="userCode">用户帐号</param>
        /// <param name="userPassword">用户密码</param>
        /// <returns>登录结果,1位成功</returns>
        public string ConnResult(string url , string accountId , string userCode , string userPassword)
            {
            try
                {

                if(url.EndsWith("/")) url = url.Remove(url.Length - 1 , 1);
                httpClient.Url = url + "/Kingdee.BOS.WebApi.ServicesStub.AuthService.ValidateUser.common.kdsvc";

                List<object> validateUserParameters = new List<object>();
                validateUserParameters.Add(accountId);
                validateUserParameters.Add(userCode);
                validateUserParameters.Add(userPassword);
                validateUserParameters.Add(2052);
                httpClient.Content = JsonConvert.SerializeObject(validateUserParameters);
                return JObject.Parse(httpClient.AsyncRequest())["LoginResultType"].Value<int>().ToString();

                } catch(Exception)
                {

                }
            return "";
            }

        /// <summary>
        /// 金蝶单据查询webapi
        /// </summary>
        /// <param name="Url">URL地址</param>
        /// <param name="formId">表单id</param>
        /// <param name="keyList">查询的字段</param>
        /// <param name="filter">过滤条件</param>
        /// <returns>查询结果</returns>
        public string WebApiGetData(string Url , string formId , string keyList , string filter)
            {
            try
                {
                httpClient.Url = Url + "/Kingdee.BOS.WebApi.ServicesStub.DynamicFormService.ExecuteBillQuery.common.kdsvc";
                string Json = "{\"FormId\":\"" + formId + "\",\"FieldKeys\":\"" + keyList + "\",\"FilterString\":\"" + filter + "\",\"OrderString\":\"\",\"TopRowCount\":0,\"StartRow\":0,\"Limit\":0}";
                List<string> Parameters = new List<string>();
                Parameters.Add(Json);
                httpClient.Content = JsonConvert.SerializeObject(Parameters);
                return httpClient.AsyncRequest();

                } catch(Exception) { }
            return "";
            }

        /// <summary>
        /// 金蝶webapi动作
        /// </summary>
        /// <param name="Url">URL地址</param>
        /// <param name="formId">表单id</param>
        /// <param name="jsonModel">json体</param>
        /// <param name="type">接口类型</param>
        /// <returns>接口动作结果</returns>
        public string WebApiAction(string Url , string formId , string jsonModel , InterfaceType type) 
            {
            try
                {
                switch(type)
                    {
                    case InterfaceType.BatchSave://批量保存
                        httpClient.Url = Url + "/Kingdee.BOS.WebApi.ServicesStub.DynamicFormService.BatchSave.common.kdsvc";
                        break;                                 
                    case InterfaceType.Submit://提交
                        httpClient.Url = Url + "/Kingdee.BOS.WebApi.ServicesStub.DynamicFormService.Submit.common.kdsvc";
                        break;
                    case InterfaceType.Audit://审核
                        httpClient.Url = Url + "/Kingdee.BOS.WebApi.ServicesStub.DynamicFormService.Audit.common.kdsvc";
                        break;
                    case InterfaceType.UnAudit://反审核
                        httpClient.Url = Url + "/Kingdee.BOS.WebApi.ServicesStub.DynamicFormService.UnAudit.common.kdsvc";
                        break;
                    case InterfaceType.Delete://删除
                        httpClient.Url = Url + "/Kingdee.BOS.WebApi.ServicesStub.DynamicFormService.Delete.common.kdsvc";
                        break;
                    default:
                        throw new Exception("Wrong Interface!");
                    }
                List<string> Parameters = new List<string>();
                Parameters.Add(formId);
                Parameters.Add(jsonModel);
                httpClient.Content = JsonConvert.SerializeObject(Parameters);
                return httpClient.AsyncRequest();

                } catch(Exception)
                {
                return "";
                }       
            }


        /// <summary>
        /// 金蝶二次开发接口
        /// </summary>
        /// <param name="url">url地址</param>
        /// <param name="listParameters">内容参数</param>
        /// <returns>接口返回内容</returns>
        public string SecondaryInterface(string url,List<string> listParameters)
            {
            try
                {
                httpClient.Url = url;   
                httpClient.Content = JsonConvert.SerializeObject(listParameters);
                return httpClient.AsyncRequest();
                } catch(Exception)
                {
                return "";
                }
            }

        /// <summary>
        /// 金蝶二次开发接口
        /// </summary>
        /// <param name="url">url地址</param>
        /// <returns>接口返回内容</returns>
        public string SecondaryInterface(string url)
            {
            try
                {
                httpClient.Url = url;
                return httpClient.AsyncRequest();
                } catch(Exception)
                {
                return "";
                }
            }

        }  
    }


