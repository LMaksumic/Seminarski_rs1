﻿using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pozoriste_Seminarski_.Helper
{
    public static class MyCookieExtension
    {
        public static T GetCookieJson<T>(this HttpRequest request, string key) where T : class
        {
            string strValue = request.Cookies[key];
            return strValue == null
                ? null
                : JsonConvert.DeserializeObject<T>(strValue);
        }

        public static void SetCookieJson(this HttpResponse response, string key, object value, int? expireTime = null)
        {
            if (value == null)
            {
                response.Cookies.Delete(key);
                return;
            }

            CookieOptions option = new CookieOptions();
            if (expireTime.HasValue)
                option.Expires = DateTime.Now.AddMinutes(expireTime.Value);
            else
                option.Expires = DateTime.Now.AddDays(7);


            string strValue = JsonConvert.SerializeObject(value);

            response.Cookies.Append(key, strValue, option);
        }

        public static void RemoveCookie(this HttpResponse response, string key)
        {
            response.Cookies.Delete(key);
        }
    }
}
