using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryTracker.API.Models.DTOs.ApiResponse
{
    public class GenericResponse<T>
    {
        public string statusCode { get; set; }
        public string description { get; set; }
        public T data { get; set; }

        public GenericResponse(){}
        public GenericResponse(string statusCode, string description, T data = default) {
            this.statusCode = statusCode;
            this.description = description;
            this.data = data;
        }
        public static GenericResponse<T> GetResponse(string statusCode, string description, T data=default)
        {
            return new GenericResponse<T>(statusCode, description, data);
        }

        public static GenericResponse<T> Success(T data)
        {
            return GetResponse("00", "request successfull", data);
        }
        public static GenericResponse<T> Success(string description, T data)
        {
            return GetResponse("00", description, data);
        }

        public static GenericResponse<T> Failed(string description)
        {
            return GetResponse("99", description, default);
        }
    }
}
