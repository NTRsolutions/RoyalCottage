using System.Collections.Generic;

namespace RoyalCottage.Framework.Core.Models
{
    public class BusinessResponse<T> 
        where T : EntityBase
    {
        public T Data { get; set; }
        public List<T> DataList { get; set; }
        public List<ErrorInfo> Errors { get; set; }
        public BusinessStatus Status { get; set; }
        public string Message { get; set; }
    }
    public enum BusinessStatus
    {
        Ok,
        Created,
        Updated,
        NotFound,
        Deleted,
        NothingModified,
        Error,
        PreConditionFailed,
        InputValidationFailed,
        KeyAlreadyExists,
        NotImplemented,
        UnAuthorized,
        ServiceUnAvailable

    }
}
